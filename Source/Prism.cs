using System;
using System.Collections.Generic;
using System.Text;
using Prism.Client;
using Prism.Notify;
using Prism.OAuth;

namespace Prism
{
    public class PrismDotNet
    {
        private string _key;
        private string _host;
        private string _secret;

        public PrismClient Client;
        public PrismOAuth OAuth;
        public PrismNotify Notify;

        
        public const string UserAgent = "Prism/dotNet";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="host">服务器</param>
        /// <param name="key">应用的Key</param>
        /// <param name="secret">应用的Secret</param>
        public PrismDotNet(string host, string key, string secret)
        {
            this._key = key;
            this._host = host;
            this._secret = secret;
            this.Client = new PrismClient(host, key, secret, UserAgent);
            this.OAuth = new PrismOAuth(this.Client);
            this.Notify = new PrismNotify(this.Client.OAuthToken, UserAgent, host);
        }

    }
}
