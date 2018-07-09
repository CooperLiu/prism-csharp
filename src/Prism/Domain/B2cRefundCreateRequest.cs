using System;


namespace Prism.Domain
{
    /// <summary>
    /// 添加退款单 b2c.refund.create 
    /// </summary>
    public class B2cRefundCreateRequest : PrismWebhookRequestBase<B2cRefundCreateRequestData, B2cRefundCreateResponseData>
    {
        public override string ApiMethod { get; set; } = PrismB2cWebhookMethods.B2cRefundCreateRequestMethod;
    }

    /// <summary>
    /// 添加退款单 b2c.refund.create 
    /// </summary>
    public class B2cRefundCreateRequestData
    {
        /// <summary>
        /// 节点号        格 式 :’ OMS 节 点        号’_’B2C 节点号’
        /// </summary>
        public string node_id { get; set; }

        /// <summary>
        /// 退款单 ID
        /// </summary>
        public int refund_bn { get; set; }

        /// <summary>
        /// 交易 ID
        /// </summary>
        public string order_bn { get; set; }

        /// <summary>
        /// 买家收款银行
        /// </summary>
        public string bank { get; set; }

        /// <summary>
        /// 买家收款账号
        /// </summary>
        public string account { get; set; }

        /// <summary>
        /// 买家（会员）ID
        /// </summary>
        public string buyer_id { get; set; }

        /// <summary>
        /// 买家收款人姓名
        /// </summary>
        public string buyer_name { get; set; }

        /// <summary>
        /// 卖家支付帐号
        /// </summary>
        public string pay_account { get; set; }

        /// <summary>
        /// 本次退款金额
        /// </summary>
        public string money { get; set; }

        /// <summary>
        /// 当前单据选择的支付        货币类型        可选值：CNY（人民币），USD（美元），JPY（日元）。- 默认为 CNY（人民币）
        /// </summary>
        public string currency { get; set; }

        /// <summary>
        /// 实际货币金额
        /// </summary>
        public string cur_money { get; set; }

        /// <summary>
        /// 支付类型        可 选 值 ： online （ 在        线 ） , offline （ 线         下）, deposit（预存款）
        /// </summary>
        public string pay_type { get; set; }

        /// <summary>
        /// 退款方式 ID
        /// </summary>
        public string payment_tid { get; set; }

        /// <summary>
        /// 退款方式
        /// </summary>
        public string pay_name { get; set; }

        /// <summary>
        /// 退款单创建时间 格式： yyyy-MM-dd HH:mm:ss
        /// </summary>
        public DateTime t_begin { get; set; }

        /// <summary>
        /// 商家发款时间  格式： yyyy-MM-dd HH:mm:ss
        /// </summary>
        public DateTime t_payed { get; set; }

        /// <summary>
        /// 买家确认收款时间 格式： yyyy-MM-dd HH:mm:ss
        /// </summary>
        public DateTime t_confirm { get; set; }

        /// <summary>
        /// 退款单状态，可选值：        SUCC:支付成功, FAILED:支付失败, CANCEL:未支付, ERROR:参数异常,INVALID: 校 验 错 误,PROGRESS: 处理中 ,TIMEOUT:超时, READY:准备中；
        /// </summary>
        public string status { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string memo { get; set; }

        /// <summary>
        /// 支付网关的内部交易单号
        /// </summary>
        public string trade_no { get; set; }



    }
}
