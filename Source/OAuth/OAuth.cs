using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Newtonsoft.Json.Linq;
using Prism.Client;
using WebSocket4Net;

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
        public string RequireOAuth(string code)
        {
            PrismParams parameters = new PrismParams { };
            parameters.Add("code", code);
            parameters.Add("grant_type", "authorization_code");

            PrismResponse response = this._client.Post("oauth/token", parameters);
            JObject ja = (JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(response.ToString());
            if (ja["access_token"] != null)
            {
                this._client.OAuthToken = ja["access_token"].ToString();
            }
            return this._client.OAuthToken;
        }

        /// <summary>
        /// 生成oauth uri
        /// </summary>
        /// <param name="redirectUri">重定向uri</param>
        /// <returns></returns>
        public string OAuthUri(string redirectUri)
        {
            PrismParams p = new PrismParams();
            p.Add("client_id", this._client.Key);
            p.Add("redirect_uri", redirectUri);
            return this._client.Server + "/oauth/authorize?" + p.ToString();
        }

    }
}
