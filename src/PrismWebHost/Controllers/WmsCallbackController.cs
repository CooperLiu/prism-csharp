using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Prism;
using Prism.Domain;

namespace PrismWebHost.Controllers
{
    public class WmsCallbackController : ApiController
    {
        /// <summary>
        /// 商派回调测试
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/Eshop")]
        public async Task<dynamic> Eshop()
        {

            var nv = await Request.Content.ReadAsFormDataAsync();

            var method = nv["method"];

            switch (method.ToLower())
            {
                case PrismB2cWebhookMethods.B2cDeliveryCreateRequestMethod:
                    //业务逻辑处理
                    break;
                case PrismB2cWebhookMethods.B2cDeliveryUpdateRequestMethod:
                    var updatedData = NameValueConvertor.MapTo<B2cDeliveryUpdateRequestData>(nv);

                    var request = new B2cDeliveryUpdateRequest();

                    request.Data = updatedData;

                    //验签
                    //业务逻辑处理
                    var responseData = new B2cDeliveryUpdateResponseData();
                    //包装响应体
                    break;
                case PrismB2cWebhookMethods.B2cReshipCreateRequestMethod:
                    break;
                default:
                    break;
            }

            var data = NameValueConvertor.MapTo<B2cDeliveryCreateRequestData>(nv);

            await Task.CompletedTask;

            return new
            {
                result = "OK"
            };
        }
    }
}