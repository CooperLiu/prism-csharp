using System;
using System.Collections.Generic;
using System.Text;

namespace Prism.Notify
{
    //消息内容
    public class DeliveryMessage
    {
        public string node_id { get; set; }
        public string order_bn { get; set; }
        public string ship_status { get; set; }

    }
}
