using System;
using System.Collections.Generic;
using System.Text;
using Prism.PrismClient;
using Prism.PrismNotify;
using Prism.PrismOAuth;

namespace Prism
{
    public class Prism
    {
        private string _key;
        private string _host;
        private string _secret;

        public Client Client;
        public OAuth OAuth;
        public Notify Notify;

        
        public const string UserAgent = "Prism/dotNet";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="host">服务器</param>
        /// <param name="key">应用的Key</param>
        /// <param name="secret">应用的Secret</param>
        public Prism(string host, string key, string secret)
        {
            this._key = key;
            this._host = host;
            this._secret = secret;
            this.Client = new Client(host, key, secret, UserAgent);
            this.OAuth = new OAuth(this.Client);
            this.Notify = new Notify(this.Client.OAuthToken, UserAgent, host);
        }

    }
}
