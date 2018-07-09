namespace Prism.Domain
{

    /// <summary>
    /// b2c.order.status_update 订单状态更新
    /// </summary>
    public class B2cOrderStatusUpdateRequest : PrismWebhookRequestBase<B2cOrderStatusUpdateRequestData, B2cOrderStatusUpdateResponseData>
    {
        public override string ApiMethod { get; set; } = PrismB2cWebhookMethods.B2cOrderStatusUpdateRequestMethod;
    }

    /// <summary>
    /// b2c.order.status_update 订单状态更新
    /// </summary>
    public class B2cOrderStatusUpdateRequestData
    {
        /// <summary>
        /// 节点号        格 式 :’ OMS 节 点        号’_’B2C 节点号’
        /// </summary>
        public string node_id { get; set; }

        /// <summary>
        /// 交易 id
        /// </summary>
        public string order_bn { get; set; }

        /// <summary>
        /// 交易状态 可选值： active:交易处理中, dead 交易作废即交易关闭, finish:交易成功
        /// </summary>
        public string status { get; set; }
    }
}
