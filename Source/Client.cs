using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Security.Cryptography;

namespace Prism
{
    public class PrismClient
    {

        public string Key;
        public string Server;
        public int Timeout;
        public bool KeepAlive;
        public string OAuthToken;
        private string secret;

        public PrismClient(string server, string key, string secret)
        {
            this.Key = key;
            this.Server = server;
            this.secret = secret;
            this.Timeout = 5000;
            this.KeepAlive = true;
        }

        public HttpWebRequest request(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.KeepAlive = this.KeepAlive;
            request.UserAgent = this.UserAgent(); 
            request.Timeout = this.Timeout;
            return request;
        }

        public string UserAgent()
        {
            return "Prism/dotNet"; 
        }

        public PrismResponse Get(string api, PrismParams parameters)
        {
            return this.action("GET", api, parameters);
        }

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
                HttpWebRequest request = this.request(uristr);
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
                    throw;
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
