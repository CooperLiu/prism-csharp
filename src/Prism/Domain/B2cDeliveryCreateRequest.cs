using System;
using System.Collections.Generic;

namespace Prism.Domain
{
    /// <summary>
    /// b2c.delivery.create 添加发货单
    /// </summary>
    public class B2cDeliveryCreateRequest : PrismWebhookRequestBase<B2cDeliveryCreateRequestData, B2cDeliveryCreateResponseData>
    {
        public override string ApiMethod { get; set; } = "b2c.delivery.create";
    }

    /// <summary>
    /// b2c.delivery.create 添加发货单
    /// </summary>
    public class B2cDeliveryCreateRequestData
    {
        /// <summary>
        /// 节点号  格 式 :’ OMS 节 点号’_’B2C 节点号’   
        /// /// </summary>
        public string node_id { get; set; }

        /// <summary>
        /// 发货单号
        /// </summary>
        public string delivery_bn { get; set; }

        /// <summary>
        /// 交易 ID
        /// </summary>
        public string order_bn { get; set; }

        /// <summary>
        /// 是否保价        可选值:true 保价，false 不保价
        /// </summary>
        public bool is_protect { get; set; }

        /// <summary>
        /// 是否货到付款
        /// </summary>
        public bool is_cod { get; set; }

        /// <summary>
        /// 买家（会员）ID
        /// </summary>
        public string buyer_id { get; set; }

        /// <summary>
        /// 配送方式
        /// </summary>
        public string delivery { get; set; }

        /// <summary>
        /// 配送费用
        /// </summary>
        public string money { get; set; }

        /// <summary>
        /// 物流公司
        /// </summary>
        public string logi_name { get; set; }

        /// <summary>
        /// 物 流 公 司 代 码 . 如"POST" 就代表中国邮政,"ZJS"就代表宅急送
        /// </summary>
        public string logistics_code { get; set; }

        /// <summary>
        /// 物流单号
        /// </summary>
        public string logi_no { get; set; }

        /// <summary>
        /// 收货人的姓名
        /// </summary>
        public string ship_name { get; set; }

        /// <summary>
        /// 收货人的所在省份
        /// </summary>
        public string ship_state { get; set; }

        /// <summary>
        /// 收货人的所在城市
        /// </summary>
        public string ship_city { get; set; }

        /// <summary>
        /// 收货人的所在地区
        /// </summary>
        public string ship_district { get; set; }

        /// <summary>
        /// 收货人的详细地址
        /// </summary>
        public string Ship_address { get; set; }

        /// <summary>
        /// 收货人的邮编
        /// </summary>
        public string ship_zip { get; set; }

        /// <summary>
        /// 收货人的手机号码
        /// </summary>
        public string ship_mobile { get; set; }

        /// <summary>
        /// 收货人的电话号码
        /// </summary>
        public string ship_phone { get; set; }

        /// <summary>
        /// 收货人 Email 地址
        /// </summary>
        public string ship_email { get; set; }

        /// <summary>
        /// 发货单生成时间  格式： yyyy-MM-dd HH:mm:ss
        /// </summary>
        public DateTime? t_begin { get; set; }

        /// <summary>
        /// 发货单结束时间  格式： yyyy-MM-dd HH:mm:ss
        /// </summary>
        public DateTime? t_confirm { get; set; }

        /// <summary>
        /// 发货单状态 可选值： SUCC:发货成功, FAILED:发货失败,CANCEL: 取消发货 ,LOST:丢失, PROGRESS:配货中, TIMEOUT:超时, READY:准备中
        /// </summary>
        public string status { get; set; }

        /// <summary>
        /// 发货单备注
        /// </summary>
        public string memo { get; set; }

        /// <summary>
        /// 发货单明细
        /// </summary>
        [JsonFormat(typeof(ShippingItem))]
        public List<ShippingItem> items { get; set; }
    }

    //public class ShippingItemWrap
    //{
    //    /// <summary>
    //    /// 发货单明细
    //    /// </summary>
    //    public List<ShippingItem> ShippingItem { get; set; }
    //}

    public class ShippingItem
    {
        /// <summary>
        /// 货品类型  可 选 值 :product(货 品),gift(赠品),adjunct(配件),pkg(捆绑)
        /// </summary>
        public string item_type { get; set; }

        /// <summary>
        /// 货品名
        /// </summary>
        public string product_name { get; set; }

        /// <summary>
        /// 货品编号
        /// </summary>
        public string product_bn { get; set; }

        /// <summary>
        /// 货品发货件数
        /// </summary>
        public int number { get; set; }
    }
}
