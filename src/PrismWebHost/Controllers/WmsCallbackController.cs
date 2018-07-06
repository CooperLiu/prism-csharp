using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

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
        public async Task<dynamic> Eshop(string input)
        {
            await Task.CompletedTask;

            return new
            {
                result = "OK"
            };
        }
    }
}