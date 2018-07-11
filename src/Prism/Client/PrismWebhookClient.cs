using System;
using System.Collections.Generic;
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
            Func<TCallbackRequest, Task<TCallbackResponse>> handlerFunc,
            IEnumerable<KeyValuePair<string, string>> requestHeaders = null)
            where TCallbackRequest : PrismWebhookRequestBase<TCallbackRequestData, TCallbackResponse>
            where TCallbackRequestData : class, new()
        {
            //验签

            return await handlerFunc(request);
        }
    }
}
