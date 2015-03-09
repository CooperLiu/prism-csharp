using System;
using System.Collections.Generic;
using System.Text;
using Prism.Client;

namespace Prism.OAuth
{
    public class PrismOAuth
    {
        private PrismClient _client;


        public PrismOAuth(PrismClient client)
        {
            this._client = client;
        }

        /// <summary>
        /// RequireOAuth 获取认证凭据
        /// e.g.
        /// {
        ///     "access_token": "xxx",
        ///     "data": {
        ///     "@id": "000000",
        ///     "login": "xxx",
        ///     "email": "xxx@xxx.com",
        ///     "firstname": "xxx",
        ///     "lastname": "xxx"
        ///     },
        ///     "expires_in": xxx,
        ///     "refresh_expires": xxx,
        ///     "refresh_token": "xxx",
        ///     "session_id": "xxx"
        /// }
        /// </summary>
        /// <param name="code">字符串 token提取码 跳转验证登录后返回</param>
        /// <returns></returns>
        public PrismResponse RequireOAuth(string code)
        {
            PrismParams parameters = new PrismParams { };
            parameters.Add("code", code);
            parameters.Add("grant_type", "authorization_code");

            PrismResponse response = this._client.Post("oauth/token", parameters);
            return response;
            
        }

    }
}
