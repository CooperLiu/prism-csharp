using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Net;
using System.IO;
using System.Security.Cryptography;

namespace Prism
{
    public class PrismClient
    {
        //应用的Key
        public string Key;

        //api 服务器 e.g. http://example.com/api
        public string Server;

        //超时时间，默认5000
        public int Timeout = 5000;

        //是否为长连接，默认为真
        public bool KeepAlive = true;


        //key对应的secret
        private string secret;

        public PrismClient(string server, string key, string secret)
        {
            this.Key = key;
            this.Server = server;
            this.secret = secret;
        }

        //生成HttpWebRequest实例
        private HttpWebRequest CreateRequest(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.KeepAlive = this.KeepAlive;
            request.UserAgent = this.UserAgent(); 
            request.Timeout = this.Timeout; 
            return request;
        }

        //用户代理
        public string UserAgent()
        {
            return "Prism/dotNet"; 
        }

        //处理get请求
        public PrismResponse Get(string api, PrismParams parameters)
        {
            return this.action("GET", api, parameters);
        }

        //处理post请求
        public PrismResponse Post(string api, PrismParams parameters)
        {
            return this.action("POST", api, parameters);
        }

        //RequireOAuth 获取认证凭据
        //e.g.
        //{
        //    "access_token": "xxx",
        //    "data": {
        //    "@id": "000000",
        //    "login": "xxx",
        //    "email": "xxx@xxx.com",
        //    "firstname": "xxx",
        //    "lastname": "xxx"
        //    },
        //    "expires_in": xxx,
        //    "refresh_expires": xxx,
        //    "refresh_token": "xxx",
        //    "session_id": "xxx"
        //}
        //param: code 字符串 token提取码 跳转验证登录后返回
        //retrun: PrismResponse实例
        public PrismResponse RequireOAuth(string code)
        {
            PrismParams parameters = new PrismParams { };
            parameters.Add("code", code);
            parameters.Add("grant_type", "authorization_code");

            PrismResponse response = this.Post("oauth/token", parameters);
            return response;
        }

        private PrismResponse action(string method, string api, PrismParams parameters)
        {
            try
            {
                PrismParams headers = new PrismParams { };
                PrismParams getParams = new PrismParams { };
                PrismParams postParams = new PrismParams { };
                string uristr = this.Server + "/" + api;
                Uri uri = new Uri(uristr);

                bool use_query_in_uri = false;

                switch (method)
                {
                    case "GET":
                        getParams = parameters;
                        use_query_in_uri = true;
                        break;
                    default:
                        postParams = parameters;
                        break;
                }


                this.FixParams(method, uri.AbsolutePath, parameters, headers, getParams, postParams);

                if (use_query_in_uri)
                {
                    uristr = uristr + "?" + getParams.ToString();
                }
                HttpWebRequest request = this.CreateRequest(uristr);

                request.Method = method;

                if (use_query_in_uri == false)
                {
                    byte[] postData = postParams.ToBytes();
                    request.ContentLength = postData.Length;
                    request.ContentType = "application/x-www-form-urlencoded";

                    using (var dataStream = request.GetRequestStream())
                    {
                        dataStream.Write(postData, 0, postData.Length);
                        dataStream.Close();
                    }
                }

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                return new PrismResponse(response);
            }
            catch (WebException e)
            {
                try
                {
                    HttpWebResponse response = (HttpWebResponse)e.Response;
                    throw new PrismException(e, response);
                }
                catch (PrismException)
                {
                    throw e;
                }
                catch
                {
                    throw e;
                }
            }
            catch
            {
                throw;
            }
        }

        //添加签名
        public void FixParams(string method, string path, PrismParams parameters
            , PrismParams headers, PrismParams getParams, PrismParams postParams)
        {
            parameters.Add("client_id", this.Key);
            if (true)
            {
                parameters.Add("sign_time", Convert.ToString(this.timestamp()));
                parameters.Add("sign", this.Sign(path, headers, getParams, postParams, method));
            }
        }

        private Int32 timestamp()
        {
            return (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        }

        private String Sign(string url, PrismParams header, PrismParams getParams,
            PrismParams postParams, String method)
        {

            string uri_path = url;
            List<string> items = new List<string>();
            items.Add(this.secret);
            items.Add(method);
            items.Add(PrismParams.Encode(uri_path));
            items.Add(PrismParams.Encode(header.sort_join("sign")));
            items.Add(PrismParams.Encode(getParams.sort_join("sign")));
            items.Add(PrismParams.Encode(postParams.sort_join("sign")));
            items.Add(this.secret);
            string signstr = String.Join("&", items.ToArray());

            MD5 md5Hash = MD5.Create();
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(signstr));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("X2"));
            }
            return sBuilder.ToString();
        }
    }
}
