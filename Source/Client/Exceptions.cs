using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace Prism.Client
{
    class PrismException : System.Exception
    {
        Exception e;
        public PrismResponse Response;

        public PrismException(WebException e, HttpWebResponse rsp)
        {
            this.e = e;
            this.Response = new PrismResponse(rsp);
        }

        public override string ToString()
        {
            return "PrismException: " + this.Response.ToString() + this.e.StackTrace;
        }
    }
}
