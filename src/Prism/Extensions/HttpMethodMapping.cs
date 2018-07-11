using System;
using System.Net.Http;

namespace Prism.Extensions
{
    static class HttpMethodMapping
    {
        public static HttpMethod Map(string httpMethod)
        {
            switch (httpMethod.ToUpper())
            {
                case "GET": return HttpMethod.Get;
                case "POST": return HttpMethod.Post;
                case "PUT": return HttpMethod.Put;
                case "DELETE": return HttpMethod.Delete;
                default:
                    throw new NotSupportedException();
            }
        }
    }
}