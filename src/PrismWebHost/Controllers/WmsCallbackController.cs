using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Prism;
using Prism.Client;
using Prism.Domain;
using Prism.Extensions;

namespace PrismWebHost.Controllers
{
    public class WmsCallbackController : ApiController
    {

        /// <summary>
        /// 商派回调测试
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("api/Eshop")]
        public async Task<dynamic> Eshop()
        {
            var callbackApi = "";
            var clientId = "quxabf4t";
            var clientSecret = "2ipua2a6jwslp6cq6fna";
            var client = new PrismWebhookClient(callbackApi, clientId, clientSecret);

            var nv = await Request.Content.ReadAsFormDataAsync();

            var method = nv["method"];
            var sign = nv["sign"];

            var dateStr = nv["date"];

            var date = DateTime.Parse(dateStr);

            switch (method.ToLower())
            {
                case PrismB2cWebhookMethods.B2cDeliveryCreateRequestMethod:
                    //业务逻辑处理
                    break;
                case PrismB2cWebhookMethods.B2cDeliveryUpdateRequestMethod:
                    var request = new B2cDeliveryUpdateRequest();
                    request.Data = NameValueConvertor.MapTo<B2cDeliveryUpdateRequestData>(nv);
                    request.Sign = sign;
                    request.Date = date;

                    var res = await client.Handle<B2cDeliveryUpdateRequest, B2cDeliveryUpdateRequestData, B2cDeliveryUpdateResponseData>(request,
                       () => Task.FromResult(new B2cDeliveryUpdateResponseData()
                       {
                           delivery_id = request.Data.delivery_bn,
                           tid = request.Data.order_bn
                       }));
                    //业务逻辑处理
                    //包装响应体
                    return new PrismWebhookResponse<B2cDeliveryUpdateResponseData>() { data= res };

                case PrismB2cWebhookMethods.B2cReshipCreateRequestMethod:
                    break;
                default:
                    break;
            }

            return new
            {
                result = "OK"
            };
        }
    }
}