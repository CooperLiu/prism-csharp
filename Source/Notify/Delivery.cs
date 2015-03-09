using System;
using System.Collections.Generic;
using System.Text;

namespace Prism.Notify
{
    //消息内容
    public class PrismDelivery
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
