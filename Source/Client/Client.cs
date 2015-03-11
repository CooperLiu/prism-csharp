using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Net;
using System.IO;
using System.Security.Cryptography;

namespace Prism.Client
{
    public class PrismClient
    {
        //应用的Key
        public string Key;

        //api 服务器
        public string Server;

        public string UserAgent;

        //超时时间，默认5000
        public int Timeout = 5000;

        //是否为长连接，默认为真
        public bool KeepAlive = true;

        //带token请求，oauth后获取
        public string OAuthToken;

        //key对应的secret
        private string _secret;

        public PrismClient(string server, string key, string secret, string userAgent)
        {
            this.Key = key;
            this.Server = server;
            this.UserAgent = userAgent;
            this._secret = secret;
        }

        //生成HttpWebRequest实例
        private HttpWebRequest CreateRequest(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.KeepAlive = this.KeepAlive;
            request.UserAgent = this.UserAgent; 
            request.Timeout = this.Timeout;
            request.UserAgent = this.UserAgent;

            if (this.OAuthToken != null)
            {
                request.Headers.Add("Authorization", "Bearer " + this.OAuthToken);
            }

            return request;
        }

        
        //处理get请求
        public PrismResponse Get(string api, PrismParams parameters )
        {
            return this.action("GET", api, parameters);
        }

        //处理post请求
        public PrismResponse Post(string api, PrismParams parameters)
        {
            return this.action("POST", api, parameters);
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

            //http 方法 https方法直接传递 client_secret
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

        /// <summary>
        /// 签名算法
        /// </summary>
        /// <param name="url"> /path/to/method</param>
        /// <param name="header"> urnencode(HeaderKey1 + HeaderValue1 + HeaderKey2 + HeaderValue2 ...)</param>
        /// <param name="getParams"> urnencode(GetKey1 + GetValue1 + GetKey2 + GetValue2 ...)</param>
        /// <param name="postParams"> urnencode(PostKey1 + PostValue1 + PostKey2 + PostValue2 ...)</param>
        /// <param name="method"> GET | POST | DELETE | PUT</param>
        /// <returns></returns>
        private String Sign(string url, PrismParams header, PrismParams getParams,
            PrismParams postParams, String method)
        {

            string uri_path = url;
            List<string> items = new List<string>();
            items.Add(this._secret);
            items.Add(method);
            items.Add(PrismParams.Encode(uri_path));
            items.Add(PrismParams.Encode(header.sort_join("sign")));
            items.Add(PrismParams.Encode(getParams.sort_join("sign")));
            items.Add(PrismParams.Encode(postParams.sort_join("sign")));
            items.Add(this._secret);
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
