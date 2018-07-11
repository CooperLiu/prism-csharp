using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Prism.Domain;
using Prism.Extensions;
using Prism.Logging;

namespace Prism.Client
{
    public class PrismWebhookClient
    {
        private static readonly ILog Logger = LogProvider.For<PrismWebhookClient>();

        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public string ApiGateway { get; set; }

        public PrismWebhookClient(string apiGateway, string clientId, string clientSecret)
        {
            ApiGateway = apiGateway.EnsureEndsWith('/');
            ClientId = clientId;
            ClientSecret = clientSecret;
        }

        public async Task<TCallbackResponse> Handle<TCallbackRequest, TCallbackRequestData, TCallbackResponse>(
            TCallbackRequest request,
            Func<Task<TCallbackResponse>> handlerFunc,
            IEnumerable<KeyValuePair<string, string>> requestHeaders = null)
            where TCallbackRequest : PrismWebhookRequestBase<TCallbackRequestData, TCallbackResponse>
            where TCallbackRequestData : class, new()
        {
            //验签
            //var hearderParams = new PrismParams();
            //if (requestHeaders != null)
            //{
            //    foreach (var item in requestHeaders)
            //    {
            //        hearderParams.Add(item.Key, item.Value);
            //    }
            //}

            //var method = HttpMethodMapping.Map(request.HttpMethod);

            //var getParams = new PrismParams();

            //var postParams = NameValueConvertor.MapFrom(request.Data);

            //var signParameters = method == HttpMethod.Get || method == HttpMethod.Delete ? getParams : postParams;
            //signParameters.Add("client_id", this.ClientId);
            //signParameters.Add("sign_time", request.Date.ToUnixTimestamp().ToString());

            //var verifiedSign = PrismSignProvider.GetSign(request.HttpMethod, request.ApiAbsolutePath, this.ClientSecret, hearderParams,
            //    getParams, signParameters);

            //if (verifiedSign.Equals(request.Sign, StringComparison.OrdinalIgnoreCase))
            //{
            //    Logger.Debug($"Prism Webhook Sign Error");
            //}

            return await handlerFunc();
        }
    }
}
