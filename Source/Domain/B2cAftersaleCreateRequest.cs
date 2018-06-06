using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Prism.Domain
{
    /// <summary>
    /// b2c.aftersale.create 添加售后申请单
    /// </summary>
    public class B2cAftersaleCreateRequest
    {
        // <summary>
        /// 节点号  格 式 :’B2C 节 点号’_’OMS 节点号’
        /// </summary>
        [Required]
        public string node_id { get; set; }

        /// <summary>
        /// 售后申请单 ID
        /// </summary>
        [Required]
        public int return_bn { get; set; }

        /// <summary>
        /// 交易 ID
        /// </summary>
        [Required]
        public int order_bn { get; set; }

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
        public string comment { get; set; }

        /// <summary>
        /// 申请时间  格 式 :YYYY-MM-dd HH:mm:ss
        /// </summary>
        public DateTime add_time { get; set; }

        /// <summary>
        /// 售后备注
        /// </summary>
        public string memo { get; set; }

        /// <summary>
        /// 状态        可选值:1(申请中),2(审        核中),3(接受申请),4(完        成 ),5(拒 绝 ),6(已 收       货 ),7(已质检),8(补 差      价),9(已拒绝退款)
        /// </summary>
        public string status { get; set; }

        /// <summary>
        /// 会员（买家）ID        /// </summary>
        public string member_id { get; set; }

        /// <summary>
        /// 售后申请明细
        /// </summary>
        public AfterSaleItemWrap return_product_items { get; set; }

        /// <summary>
        /// 附件（通常为 url）
        /// </summary>
        public string url { get; set; }
       

    }

    public class AfterSaleItemWrap
    {
        public List<AfterSaleItemInfo> AfterSaleItem { get; set; }
    }

    public class AfterSaleItemInfo
    {
        public string bn { get; set; }
        public string name { get; set; }
        public string num { get; set; }
    }
}
