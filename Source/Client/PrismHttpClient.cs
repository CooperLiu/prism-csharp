using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Prism.Extensions;

namespace Prism.Client
{
    public class PrismHttpClient
    {
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


        public async Task<PrismHttpResponse<TData>> Execute<TData>(
            string httpMethod,
            string apiName,
            IEnumerable<KeyValuePair<string, string>> headers,
            PrismParams postParams)
        {
            //加签
            var requestUrl = ApiGateway + "api/oms?method=" + apiName;

            var method = GetHttpMethodMapping(httpMethod.ToUpper());

            var secret = this.ClientSecret;

            var hearderParams = new PrismParams();
            if (headers != null)
            {
                foreach (var item in headers)
                {
                    hearderParams.Add(item.Key, item.Value);
                }
            }


            var getParams = new PrismParams();
            var uri = new Uri(requestUrl);

            var queryString = uri.Query.Replace("?", "");
            var queryStringNameValues = queryString.Split(new[] { '&' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in queryStringNameValues)
            {
                var nameValue = item.Split(new[] { "=" }, StringSplitOptions.RemoveEmptyEntries);
                if (nameValue.Any() && nameValue.Length == 2)
                {
                    getParams.Add(nameValue[0], nameValue[1]);
                }
            }

            var signParameters = method == HttpMethod.Get || method == HttpMethod.Delete ? getParams : postParams;
            signParameters.Add("client_id", this.ClientId);
            signParameters.Add("sign_time", GetUnixTimestamp().ToString());

            signParameters.Add("sign", GetSign(httpMethod, uri.AbsolutePath, hearderParams, getParams, signParameters));

            if (method == HttpMethod.Get)
            {
                requestUrl = requestUrl + signParameters.ToString();
            }


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

                IEnumerable<string> headerValue;
                response.Headers.TryGetValues("X-Request-Id", out headerValue);

                return JsonConvert.DeserializeObject<PrismHttpResponse<TData>>(resMsg);
            }
        }

        private string GetSign(string method, string path, PrismParams headers, PrismParams getParams, PrismParams postParams)
        {
            var items = new List<string>();
            items.Add(this.ClientSecret);
            items.Add(method);
            items.Add(PrismParams.Encode(path));
            items.Add(PrismParams.Encode(headers.headers_str()));
            items.Add(PrismParams.Encode(getParams.sort_join("sign")));
            items.Add(PrismParams.Encode(postParams.sort_join("sign")));
            items.Add(this.ClientSecret);
            string signstr = String.Join("&", items.ToArray());

            System.Diagnostics.Debug.WriteLine(signstr);

            MD5 md5Hash = MD5.Create();
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(signstr));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("X2"));
            }
            return sBuilder.ToString();
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

        private Int32 GetUnixTimestamp()
        {
            return (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        }

    }
}
