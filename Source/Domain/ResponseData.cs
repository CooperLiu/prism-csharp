using System.Collections.Generic;

namespace Prism.Domain
{
    public class ResponseData
    {
        public string tid { get; set; }
    }

    /// <summary>
    /// 创建订单store.trade.add 
    /// </summary>
    public class StoreTradeAddResponseData
    {
        public string msg { get; set; }

        public string rsp { get; set; }

        public ResponseData data { get; set; }
    }

    /// <summary>
    /// 创建售后申请 store.trade.aftersale.add
    /// </summary>
    public class StoreTradeAftersaleAddResponseData : ResponseData
    {
        public string aftersale_id { get; set; }
    }

    /// <summary>
    /// 创建退款单 store.trade.refund.add
    /// </summary>
    public class StoreTradeRefundResponseData : ResponseData
    {
        public string refund_id { get; set; }

        public string retry { get; set; }
    }


    /// <summary>
    ///订单状态更新 b2c.order.status_update 
    /// </summary>
    public class B2cOrderStatusUpdateResponseData : ResponseData
    {

    }

    /// <summary>
    ///更新订单备注 b2c.order.remark 
    /// </summary>
    public class B2cOrderRemarkResponseData : ResponseData
    {

    }

    /// <summary>
    /// 添加支付单 b2c.payment.create 
    /// </summary>
    public class B2cPaymentCreateResponseData : ResponseData
    {
        public string payment_id { get; set; }
    }

    /// <summary>
    /// 添加退款单 b2c.refund.create
    /// </summary>
    public class B2cRefundCreateResponseData : ResponseData
    {
        public string refund_id { get; set; }
    }

    /// <summary>
    /// 添加退货单 b2c.reship.create 
    /// </summary>
    public class B2cReshipCreateResponseData : ResponseData
    {
        public string reship_id { get; set; }
    }

    /// <summary>
    /// 添加发货单 b2c.delivery.create 
    /// </summary>
    public class B2cDeliveryCreateResponseData : ResponseData
    {
        public string delivery_id { get; set; }
    }

    /// <summary>
    ///更新发货单物流信息  b2c.delivery.update 
    /// </summary>
    public class B2cDeliveryUpdateResponseData : ResponseData
    {
        public string delivery_id { get; set; }
    }


    /// <summary>
    /// 更新发货单状态 b2c.order.ship_status_update
    /// </summary>
    public class B2cOrderShipStatusUpdateResponseData : ResponseData
    {
        public string delivery_id { get; set; }

    }

    /// <summary>
    /// 更新售后申请的状态 b2c.aftersale.update 
    /// </summary>
    public class B2cAfterSaleUpdateResponseData : ResponseData
    {
        public string return_id { get; set; }
    }

    /// <summary>
    /// 添加售后申请单 b2c.aftersale.create 
    /// </summary>
    public class B2cAfterSaleCreateResponseData : ResponseData
    {
        public string return_id { get; set; }
    }

    /// <summary>
    ///添加买家留言  b2c.order.leave_message 
    /// </summary>
    public class B2cOrderLeaveMessageResponseData : ResponseData
    {

    }

    /// <summary>
    /// 获取支付方式 ectools.get_payments.get_all 
    /// </summary>
    public class EctoolsGetPaymentsGetAllResponseData
    {
        public List<PaymentMethodInfo> data { get; set; }
    }

    public class PaymentMethodInfo
    {
        public string custom_name { get; set; }

        public string pay_bn { get; set; }

        public string pay_type { get; set; }
    }



}
