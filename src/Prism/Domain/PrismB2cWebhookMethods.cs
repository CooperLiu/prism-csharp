namespace Prism.Domain
{
    public class PrismB2cWebhookMethods
    {
        /// <summary>
        /// 添加售后申请单 
        /// </summary>
        public const string B2cAftersaleCreateRequestMethod = "b2c.aftersale.create";

        /// <summary>
        /// 更新售后申请的状态 
        /// </summary>
        public const string B2cAftersaleUpdateRequestMethod = "b2c.aftersale.update";

        /// <summary>
        /// 添加发货单 
        /// </summary>
        public const string B2cDeliveryCreateRequestMethod = "b2c.delivery.create";

        /// <summary>
        /// 发货单更新
        /// </summary>
        public const string B2cDeliveryUpdateRequestMethod = "b2c.delivery.update";

        /// <summary>
        ///  添加买家留言 
        /// </summary>
        public const string B2cOrderLeaveMessageRequestMethod = "b2c.order.leave_message";

        /// <summary>
        /// 更新订单备注
        /// </summary>
        public const string B2cOrderRemarkRequestMethod = "b2c.order.remark";

        /// <summary>
        /// 更新发货单状态 
        /// </summary>
        public const string B2cOrderShipStatusUpdateRequestMethod = "b2c.order.ship_status_update";

        /// <summary>
        /// 订单状态更新
        /// </summary>
        public const string B2cOrderStatusUpdateRequestMethod = "b2c.order.status_update";

        /// <summary>
        /// 添加支付单 
        /// </summary>
        public const string B2cPaymentCreateRequestMethod = "b2c.payment.create";

        /// <summary>
        /// 添加退款单 
        /// </summary>
        public const string B2cRefundCreateRequestMethod = "b2c.refund.create";

        /// <summary>
        /// 添加退货单
        /// </summary>
        public const string B2cReshipCreateRequestMethod = "b2c.reship.create";

        /// <summary>
        /// 获取支付方式 
        /// </summary>
        public const string EctoolsGetPaymentsGetAllRequestMethod = "ectools.get_payments.get_all";
    }
}
