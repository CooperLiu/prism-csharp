using System;
using System.Collections.Generic;
using Prism.Logging;

namespace Prism.Client
{
    internal class PrismSignProvider
    {
        private static readonly ILog Logger = LogProvider.For<PrismSignProvider>();

        public static string GetSign(string method, string path, string secret, PrismParams headers, PrismParams getParams, PrismParams postParams)
        {
            var items = new List<string>();
            items.Add(secret);
            items.Add(method);
            items.Add(PrismParams.Encode(path));
            items.Add(PrismParams.Encode(headers.headers_str()));
            items.Add(PrismParams.Encode(getParams.sort_join("sign")));
            items.Add(PrismParams.Encode(postParams.sort_join("sign")));
            items.Add(secret);
            string signstr = String.Join("&", items.ToArray());

            Logger.Info($"Prism Signed Str:{signstr}");

            return EncryptionAlgorithmProvider.Md5(signstr);
        }

        
    }
}
