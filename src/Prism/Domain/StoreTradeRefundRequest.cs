using System;
using System.ComponentModel.DataAnnotations;

namespace Prism.Domain
{

    /// <summary>
    /// 创建退款单 store.trade.refund.add 
    /// </summary>
    public class StoreTradeRefundRequest : PrismRequestBase<StoreTradeRefundRequestData, StoreTradeAftersaleAddResponseData>
    {
        public override string ApiMethod { get; set; } = "store.trade.refund.add";
    }

    /// <summary>
    /// 创建退款单 store.trade.refund.add 
    /// </summary>
    public class StoreTradeRefundRequestData
    {
        /// <summary>
        /// 节点号  格 式 :’B2C 节 点号’_’OMS 节点号’
        /// </summary>
        [Required]
        public string node_id { get; set; }

        [Required]
        public string refund_id { get; set; }

        [Required]
        public string tid { get; set; }

        /// <summary>
        /// 买家收款银行
        /// </summary>
        public string buyer_bank { get; set; }
        /// <summary>
        /// 买家收款账号
        /// </summary>
        public string buyer_account { get; set; }
        /// <summary>
        /// 买家收款人姓名
        /// </summary>
        public string buyer_name { get; set; }

        /// <summary>
        /// 买家（会员）ID
        /// </summary>
        public string buyer_id { get; set; }

        /// <summary>
        /// 本次退款金额
        /// </summary>
        public string refund_fee { get; set; }

        /// <summary>
        /// 当前单据选择的货币类型。可选值：CNY（人民币），USD（美元），JPY（日元）。- 默认为CNY（人民币）
        /// </summary>
        public string currency { get; set; }

        /// <summary>
        /// 实际货币金额
        /// </summary>
        public string currency_fee { get; set; }

        /// <summary>
        /// 退款类型。可选值：online（在线）, offline（线下）, deposit（预存款）
        /// </summary>
        public string pay_type { get; set; }

        /// <summary>
        /// 退款方式 ID
        /// </summary>
        public string payment_tid { get; set; }

        /// <summary>
        /// 退款方式
        /// </summary>
        public string payment_type { get; set; }

        /// <summary>
        /// 卖家退款账户
        /// </summary>
        public string seller_account { get; set; }

        /// <summary>
        /// 退款单创建时间。格        式：yyyy-MM-ddHH:mm:ss
        ///  </summary>
        public DateTime t_begin { get; set; }

        /// <summary>
        /// 商家发款时间。格式： yyyy-MM-dd HH:mm:ss
        /// </summary>
        public DateTime t_sent { get; set; }

        /// <summary>
        /// 买家确认收款时间。格式：yyyy-MM-dd HH:mm:ss
        /// </summary>
        public DateTime t_received { get; set; }

        /// <summary>
        /// 退款单类型:apply(退款申请),refund(已退款)
        /// </summary>
        public string refund_type { get; set; }

        /// <summary>
        /// 当 refund_type 的值为refund 时，退款单状态，可选值： SUCC:支付成 功, FAILED:支付失败,CANCEL:未支付,ERROR:参数异常,INVALID:校验错误,PROGRESS:处理中,TIMEOUT:超时, READY:准备中；当refund_type 的值为apply 时，退款申请单状态： APPLY:退款申请,VERIFY:审核中, SUCC:审核通过, REFUND:已退 款, FAIL:审核不通过
        /// </summary>
        public string status { get; set; }
        public string refund_operator { get; set; }
        public string memo { get; set; }

        /// <summary>
        /// 支付网关的内部交易单号
        /// </summary>
        public string outer_no { get; set; }
    }
}
