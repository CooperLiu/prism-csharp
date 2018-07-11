using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Prism.Domain;
using Prism.Extensions;
using Prism.Logging;

namespace Prism.Client
{
    public class PrismHttpClient
    {

        private static readonly ILog Logger = LogProvider.For<PrismHttpClient>();

        private static readonly HttpClient _httpClient = new HttpClient(new HttpClientHandler() { UseCookies = false });

        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public string ApiGateway { get; set; }

        public int Timeout { get; set; } = 60 * 5;


        public PrismHttpClient(string apiGateway, string clientId, string clientSecret)
        {
            ApiGateway = apiGateway.EnsureEndsWith('/');
            ClientId = clientId;
            ClientSecret = clientSecret;
        }

        public async Task<PrismHttpResponse<TResponseData>> Execute<TResponseData, TRequestData>(
            IPrismRequest<TRequestData, TResponseData> request,
            IEnumerable<KeyValuePair<string, string>> headers = null
            ) where TRequestData : class, new()
        {
            var postParams = NameValueConvertor.MapFrom(request.Data);

            return await Execute<TResponseData>(request.HttpMethod, request.ApiAbsolutePath, request.ApiMethod, postParams, headers);

        }

        public async Task<PrismHttpResponse<TResponseData>> Execute<TResponseData>(
            string httpMethod,
            string apiAbsolutePath,
            string apiMethod,
            PrismParams postParams,
            IEnumerable<KeyValuePair<string, string>> requestHeaders = null
            )
        {
            var requestUrl = ApiGateway + apiAbsolutePath + "?method=" + apiMethod;

            var method = GetHttpMethodMapping(httpMethod);


            var hearderParams = new PrismParams();
            if (requestHeaders != null)
            {
                foreach (var item in requestHeaders)
                {
                    hearderParams.Add(item.Key, item.Value);
                }
            }

            var uri = new Uri(requestUrl);

            var getParams = new PrismParams();
            getParams.GetFromUri(uri);

            var signParameters = method == HttpMethod.Get || method == HttpMethod.Delete ? getParams : postParams;
            signParameters.Add("client_id", this.ClientId);
            signParameters.Add("sign_time", DateTimeExtensions.GetUnixTimestamp().ToString());

            signParameters.Add("sign", PrismSignProvider.GetSign(httpMethod, uri.AbsolutePath, this.ClientSecret, hearderParams, getParams, signParameters));

            if (method == HttpMethod.Get)
            {
                requestUrl = requestUrl + signParameters.ToQueryString();
            }

            Logger.Debug($"Prism SDK: Request Url:{requestUrl},Params:{signParameters.ToQueryString()}");


            using (var msg = new HttpRequestMessage(method, requestUrl))
            {
                if (method == HttpMethod.Post || method == HttpMethod.Put)
                {
                    var signedKv = signParameters.AllKeys.Select(x => new KeyValuePair<string, string>(x, signParameters[x])).ToList();
                    msg.Content = new FormUrlEncodedContent(signedKv);
                }


                var cannelToken = new CancellationTokenSource(TimeSpan.FromSeconds(this.Timeout));

                var response = await _httpClient.SendAsync(msg, cannelToken.Token);
                var resMsg = await response.Content.ReadAsStringAsync();

                Logger.Debug($"Prism SDK: response:{resMsg}");

                //IEnumerable<string> headerValue;
                //response.Headers.TryGetValues("X-Request-Id", out headerValue);

                /* 错误一
                 
                 {
                    "res":"e00060",
                    "msg_id":null,
                    "rsp":"fail",
                    "err_msg":"缺少系统参数:['from_node_id', 'to_node_id']",
                    "data":""""
                }

                 */

                /*错误二
                 * {
                    "res":"",
                    "msg_id":"5B1773670AAD2203CE9A66599446D59D",
                    "err_msg":"",
                    "data":{
                        "msg":"\u8fd4\u56de\u503c\uff1a\u8ba2\u5355\u521b\u5efa\u6210\u529f\uff01\u8ba2\u5355ID\uff1a6482",
                        "rsp":"succ",
                        "data":"{
                            "tid":"742636638891191762227"
                        }"
                    },
                    "rsp":"succ"
                }
                 * 
                 */

                //fixed 接口不能统一结果

                var json = JToken.Parse(resMsg);

                var jsonDataValue = json["data"];
                if (jsonDataValue.ToString() == "\"\"")
                {
                    json["data"] = null;
                }

                return json.ToObject<PrismHttpResponse<TResponseData>>();

                // return JsonConvert.DeserializeObject<PrismHttpResponse<TResponseData>>(json.ToString());
            }
        }


        private HttpMethod GetHttpMethodMapping(string httpMethod)
        {
            switch (httpMethod.ToUpper())
            {
                case "GET": return HttpMethod.Get;
                case "POST": return HttpMethod.Post;
                case "PUT": return HttpMethod.Put;
                case "DELETE": return HttpMethod.Delete;
                default:
                    throw new NotSupportedException();
            }
        }

    }
}
