using System;
using System.Collections.Generic;
using System.Text;

namespace Prism.Notify
{
    //消息内容
    public class PrismDelivery
    {
        public string client_id { get; set; }
        public string app { get; set; }
        public string key { get; set; }
        public string type { get; set; }
        public object body { get; set; }
        public int time { get; set; }
        public int tag { get; set; }

        public PrismDelivery()
        {
            this.client_id = "";
            this.app = "";
            this.key = "";
            this.type = "";
            this.body = null;
            this.time = -1;
            this.tag = -1;
        }
    }
}
