using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        //public async Task<TCallbackResponse> Handle<TCallbackResponse>(
        //    NameValueCollection @params,
        //    string httpMethod,
        //    string apiAbsolutePath,
        //    string apiMethod
        //    )
        //{
        //    return null;
        //}

        public async Task<TCallbackResponse> Handle<TCallbackRequest, TCallbackResponse>(
            TCallbackRequest request,
            string httpMethod,
            string apiAbsolutePath,
            string apiMethod,
            Func<TCallbackRequest, Task<TCallbackResponse>> handlerFunc)
        {
            return await handlerFunc(request);
        }
    }
}
