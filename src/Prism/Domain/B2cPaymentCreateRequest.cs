using System;

namespace Prism.Domain
{
    /// <summary>
    /// b2c.payment.create 添加支付单
    /// </summary>
    public class B2cPaymentCreateRequest : PrismWebhookRequestBase<B2cPaymentCreateRequestData, B2cPaymentCreateResponseData>
    {
        public override string ApiMethod { get; set; } = "b2c.payment.create";
    }

    /// <summary>
    /// b2c.payment.create 添加支付单
    /// </summary>
    public class B2cPaymentCreateRequestData
    {
        /// <summary>
        /// 节点号        格 式 :’ OMS 节 点        号’_’B2C 节点号’
        /// </summary>
        public string node_id { get; set; }

        /// <summary>
        /// 付款单编号(付款单 ID)
        /// </summary>
        public int payment_bn { get; set; }

        /// <summary>
        /// 交易 ID
        /// </summary>
        public string order_bn { get; set; }

        /// <summary>
        /// 卖家收款银行
        /// </summary>
        public string bank { get; set; }

        /// <summary>
        /// 卖家收款账号
        /// </summary>
        public string account { get; set; }

        /// <summary>
        /// 买家支付账户
        /// </summary>
        public string pay_account { get; set; }

        /// <summary>
        /// 本次支付金额
        /// </summary>
        public string money { get; set; }

        /// <summary>
        /// 支付花费
        /// </summary>
        public string paycost { get; set; }

        /// <summary>
        /// 当前单据选择的支付        货币类型        可选值：CNY（人民币），USD（美元），JPY（日元）。- 默认为 CNY（人民币）
        /// </summary>
        public string currency { get; set; }

        /// <summary>
        /// 实际支付货币金额
        /// </summary>
        public string cur_money { get; set; }

        /// <summary>
        /// 支付类型 可 选 值 ： online （ 在线 ） , offline （ 线下）, deposit（预存款）        
        /// </summary>
        public string pay_type { get; set; }

        /// <summary>
        /// 支付方式 ID
        /// </summary>
        public string payment_tid { get; set; }

        /// <summary>
        /// 支付方式
        /// </summary>
        public string paymethod { get; set; }

        /// <summary>
        /// 开始支付时间        格式： yyyy-MM-dd HH:mm:ss
        /// </summary>
        public DateTime? t_begin { get; set; }

        /// <summary>
        /// 付款结束支付时间        格式： yyyy-MM-dd HH:mm:ss
        /// </summary>
        public DateTime? t_end { get; set; }

        /// <summary>
        /// 付款单状态  可选值： SUCC:支付成功, FAILED:支付失败,CANCEL: 未 支 付 ,ERROR: 参 数 异 常,INVALID: 校 验 错 误,PROGRESS: 处理中 ,TIMEOUT:超时, READY:准备中
        /// </summary>
        public string status { get; set; }

        public string memo { get; set; }

        /// <summary>
        /// 支付网关的内部交易单号
        /// </summary>
        public string trade_no { get; set; }
    }
}
