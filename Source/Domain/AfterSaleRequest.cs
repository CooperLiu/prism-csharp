using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Prism.Domain
{
    /// <summary>
    /// 售后
    /// </summary>
    public class AfterSaleRequest
    {
        [Required]
        public string node_id { get; set; }

        /// <summary>
        /// 售后申请单 ID
        /// </summary>
        [Required]
        public string aftersale_id { get; set; }

        /// <summary>
        /// 交易 ID
        /// </summary>
        [Required]
        public string tid { get; set; }

        /// <summary>
        /// 售后申请标题
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// 申请售后内容
        /// </summary>
        public string content { get; set; }

        /// <summary>
        /// 申请售后留言
        /// </summary>
        public string messager { get; set; }
        /// <summary>
        /// 申请时间  格 式 :YYYY-MM-dd HH:mm:ss
        /// </summary>
        public DateTime created { get; set; }
        public string memo { get; set; }

        /// <summary>
        /// 状态 可选值:1(申请中),2(审核中),3(接受申请),4(完 成 ),5(拒 绝 ),6(已 收货 ),7(已质检),8(补 差价),9(已拒绝退款)
        /// </summary>
        public string status { get; set; }

        /// <summary>
        /// 会员（买家）ID
        /// </summary>
        public string buyer_id { get; set; }

        /// <summary>
        /// 会员名
        /// </summary>
        public string buyer_name { get; set; }

        public List<AfterSaleItem> aftersale_items { get; set; }

        public LogisticsInfo logistics_info { get; set; }

        /// <summary>
        /// 附件（通常为 url）
        /// </summary>
        public string attachment { get; set; }
    }

    public class AfterSaleItem
    {
        public string sku_bn { get; set; }
        public string sku_name { get; set; }
        public int number { get; set; }
    }

    public class LogisticsInfo
    {
        public string logistics_company { get; set; }

        public string logistics_no { get; set; }
    }
}
