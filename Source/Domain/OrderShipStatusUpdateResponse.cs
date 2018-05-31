using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prism.Domain
{
    /// <summary>
    /// 更新发货单状态 b2c.order.ship_status_update
    /// </summary>
    public class OrderShipStatusUpdateResponse
    {
        public string delivery_id { get; set; }

        public string tid { get; set; }
    }
}
