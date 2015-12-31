using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;

namespace Prism.Client
{
    public class PrismResponse
    {
        private HttpWebResponse _rsp;
        private string body;
        public string RequestId;

        public PrismResponse(HttpWebResponse response)
        {
            this._rsp = response;
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default);
            this.body = reader.ReadToEnd();
            this.RequestId = response.Headers.Get("X-Request-Id");
        }

        override public string ToString()
        {
            return this.body;
        }
    }
}
