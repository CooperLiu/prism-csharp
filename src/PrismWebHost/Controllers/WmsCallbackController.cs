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

            var request = await Request.Content.ReadAsStringAsync();

            var nv = await Request.Content.ReadAsFormDataAsync();

            var data = NameValueConvertor.MapTo<B2cDeliveryCreateRequestData>(nv);

            await Task.CompletedTask;

            return new
            {
                result = "OK"
            };
        }
    }
}