using System;
using System.Collections.Generic;
using System.Text;

namespace Prism.PrismNotify
{
    //消息内容
    public class Delivery
    {
        public string Key;
        public string App;
        public string RoutingKey;
        public string ContentType;
        public object Body;
        public int Time;
        public int Tag;
    }
}
