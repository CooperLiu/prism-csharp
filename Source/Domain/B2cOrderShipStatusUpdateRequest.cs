using System.ComponentModel.DataAnnotations;

namespace Prism.Domain
{
    /// <summary>
    /// b2c.order.ship_status_update 更新发货单状态
    /// </summary>
    public class B2cOrderShipStatusUpdateRequest : PrismWebhookRequestBase<B2cOrderShipStatusUpdateRequestData, B2cOrderShipStatusUpdateResponseData>
    {
        public override string ApiMethod { get; set; } = "b2c.order.ship_status_updat";
    }

    /// <summary>
    /// b2c.order.ship_status_update 更新发货单状态
    /// </summary>
    public class B2cOrderShipStatusUpdateRequestData
    {
        /// <summary>
        /// 节点号 格 式 :’ OMS 节 点号’_’B2C 节点号’
        /// </summary>
        [Required]
        public string node_id { get; set; }

        /// <summary>
        /// 交易 id
        /// </summary>
        [Required]
        public string order_bn { get; set; }

        /// <summary>
        /// 交易发货状态  可选值：SHIP_NO:未发货, SHIP_PREPARE:配货中, SHIP_PART:部分发货, SHIP_FINISH:全部发货, RESHIP_PART:部分退货, RESHIP_ALL:全部退货
        /// </summary>
        [Required]
        public string ship_status { get; set; }
    }
}
