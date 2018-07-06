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

        private string _host;
        private string _key;
        private string _secret;

        private PrismClient _client;
        private PrismOAuth _oAuth;
        private PrismNotify _notify;

        
        public const string UserAgent = "Prism/dotNet";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="host">服务器</param>
        /// <param name="key">应用的Key</param>
        /// <param name="secret">应用的Secret</param>
        public PrismDotNet(string host, string key, string secret)
        {
            this._host = host;
            this._key = key;
            this._secret = secret;

            this._client = new PrismClient(this._host, this._key, this._secret, UserAgent);
            this._oAuth = new PrismOAuth(this._client);
            this._notify = new PrismNotify(this._client);
        }


        public PrismClient Client()
        {
            return this._client;
        }

        public PrismOAuth OAuth()
        {
            return this._oAuth;
        }

        public PrismNotify Notify()
        {
            return this._notify;
        }
    }
}
