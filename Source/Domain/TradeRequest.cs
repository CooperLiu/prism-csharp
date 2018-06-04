using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Prism.Domain
{
    /// <summary>
    /// 交易
    /// </summary>
    public class TradeRequest
    {
        /// <summary>
        /// 节点号 ,格式:B2C 节点号_OMS 节点号 
        /// </summary>
        [Required]
        public string node_id { get; set; }

        [Required]
        public string tid { get; set; }

        [Required]
        public string title { get; set; }

        /// <summary>
        /// 交易创建时间 格式:yyyy-MM-dd HH:mm:ss 
        /// </summary>
        [Required]
        public DateTime? created { get; set; }

        [Required]
        public DateTime? modified { get; set; }

        /// <summary>
        /// 交易状态 可 选 值 ： TRADE_ACTIVE: 交易处 理中, TRADE_CLOSED: 交易作废即交易关闭, TRADE_FINISHED: 交易 成功 
        /// </summary>
        [Required]
        public string status { get; set; }

        /// <summary>
        /// 交易支付状态 可选值： PAY_NO:未付 款, PAY_FINISH:已付款, PAY_TO_MEDIUM: 付款 至担保交易, PAY_PART: 部 分 付 款 , REFUND_PART: 部 分 退 款, REFUND_ALL:全额 退款
        /// </summary>
        [Required]
        public string pay_status { get; set; }

        /// <summary>
        /// 交易物流状态 可选值： SHIP_NO:未发 货, SHIP_PREPARE:配货 中, SHIP_PART:部分发 货, SHIP_FINISH:全部发 货, RESHIP_PART:部分 退货, RESHIP_ALL:全部 退货
        /// </summary>
        public string ship_status { get; set; }

        //是否实体配送  可 选 值 true( 是 ) ， false(否) 
        public bool is_devlivery { get; set; }

        /// <summary>
        /// 是否货到付款 可 选 值 true( 是 ) ， false(否) 
        /// </summary>
        public bool is_cod { get; set; }

        /// <summary>
        /// 是否开发票 可 选 值 ： true(开),false(不开)。默 认不开 
        /// </summary>
        public bool has_invoice { get; set; }

        /// <summary>
        /// 发票抬头 如果 has_invoice 为 true,则此参数为必须 
        /// </summary>
        public string invoice_title { get; set; }
        /// <summary>
        /// 发票金额 
        /// </summary>
        public string invoice_fee { get; set; }

        /// <summary>
        /// 商品总额(不包括配送 费用)
        /// </summary>
        public string total_goods_fee { get; set; }

        /// <summary>
        /// 交易应付总额（包括商 品价格 + 配送费用) 
        /// </summary>
        public string total_trade_fee { get; set; }

        /// <summary>
        /// 折扣优惠金额 
        /// </summary>
        public string discount_fee { get; set; }
        public string goods_discount_fee { get; set; }
        public string orders_discount_fee { get; set; }

        /// <summary>
        /// 详细优惠方案 格式 json: <see cref="PromotionDetail"/>
        /// </summary>
        [JsonFormat]
        public PromotionDetailWrap promotion_details { get; set; }

        /// <summary>
        /// 已支付金额 
        /// </summary>
        public string payed_fee { get; set; }

        /// <summary>
        /// 当前交易选择的货币 类型 可选值：CNY（人 民币），USD（美元）， JPY（日元）。- 默认 为 CNY（人民币） 
        /// </summary>
        public string currency { get; set; }

        /// <summary>
        /// 当前货别汇率
        /// </summary>
        public string currency_rate { get; set; }

        /// <summary>
        /// 当前货币订单总额 
        /// </summary>
        public string total_currency_fee { get; set; }

        /// <summary>
        /// 买家获得积分,返点的 积分。格式:100;单位: 个
        /// </summary>
        public string buyer_obtain_point_fee { get; set; }

        /// <summary>
        /// 买家使用积分 格式:100;单位:个 
        /// </summary>
        public string point_fee { get; set; }

        /// <summary>
        /// 创建交易时的物流 方式 ID（交易完成 前，物流方式有可能 改变
        /// </summary>
        public string shipping_tid { get; set; }

        /// <summary>
        /// 交易物流方式名称
        /// </summary>
        public string shipping_type { get; set; }

        /// <summary>
        /// 交易物流配送费用
        /// </summary>
        public string shipping_fee { get; set; }

        /// <summary>
        /// 是否保价（针对物流配送)
        /// </summary>
        public string is_protect { get; set; }

        /// <summary>
        /// 保价费用（针对物流配送)

        /// </summary>
        public string protect_fee { get; set; }

        /// <summary>
        /// 支付方式 ID
        /// </summary>
        public string payment_tid { get; set; }

        /// <summary>
        /// 支付方式名称
        /// </summary>
        public string payment_type { get; set; }
        /// <summary>
        /// 支付时间。 格式:yyyy-MM-dd HH:mm:ss
        /// </summary>
        public DateTime? pay_time { get; set; }

        /// <summary>
        /// 交易成功时间        格 式 :yyyy-MM-dd        HH:mm:ss
        /// </summary>
        public DateTime? end_time { get; set; }

        /// <summary>
        /// 卖家发货时间        格 式 :yyyy-MM-dd        HH:mm:ss
        /// </summary>
        public DateTime? consign_time { get; set; }

        /// <summary>
        /// 交易有效时间(下单后 的最后付款的截止时间)格 式 :yyyy-MM-dd HH:mm:ss
        /// </summary>
        public DateTime? trade_valid_time { get; set; }

        /// <summary>
        /// 收货人的姓名
        /// </summary>
        public string receiver_name { get; set; }

        /// <summary>
        /// 收货人 email 地址
        /// </summary>
        public string receiver_email { get; set; }

        /// <summary>
        /// 收货人的所在省份
        /// </summary>
        public string receiver_state { get; set; }

        /// <summary>
        /// 收货人的所在城市
        /// </summary>
        public string receiver_city { get; set; }

        /// <summary>
        /// 收货人的所在地区
        /// </summary>
        public string receiver_distric { get; set; }

        /// <summary>
        /// 收货人的详细地址
        /// </summary>
        public string receiver_address { get; set; }

        /// <summary>
        /// 收货人的邮编
        /// </summary>
        public string receiver_zip { get; set; }

        /// <summary>
        /// 收货人的手机号码
        /// </summary>
        public string receiver_mobile { get; set; }

        /// <summary>
        /// 收货人的电话号码
        /// </summary>
        public string dreceiver_phone { get; set; }

        /// <summary>
        /// 收货人要求到货时间
        /// </summary>
        public string receiver_time { get; set; }

        /// <summary>
        /// 买家支付宝账号
        /// </summary>
        public string buyer_alipay_no { get; set; }

        /// <summary>
        /// 买家（会员）ID
        /// </summary>
        public string buyer_id { get; set; }

        /// <summary>
        /// 买家帐号
        /// </summary>
        public string buyer_uname { get; set; }

        /// <summary>
        /// 买家姓名
        /// </summary>
        public string buyer_name { get; set; }

        /// <summary>
        /// 买家的手机号码
        /// </summary>
        public string buyer_mobile { get; set; }

        /// <summary>
        /// 买家的电话号码
        /// </summary>
        public string buyer_phone { get; set; }

        /// <summary>
        /// 买家 email
        /// </summary>
        public string buyer_email { get; set; }

        /// <summary>
        /// 买家的所在省份
        /// </summary>
        public string buyer_state { get; set; }

        /// <summary>
        /// 买家的所在城市
        /// </summary>
        public string buyer_city { get; set; }

        /// <summary>
        /// 买家的所在地区
        /// </summary>
        public string buyer_district { get; set; }

        /// <summary>
        /// 买家的详细地址
        /// </summary>
        public string buyer_address { get; set; }
        /// <summary>
        /// 买家的邮编
        /// </summary>
        public string buyer_zip { get; set; }

        /// <summary>
        /// 买家是否已评价可 选 值 :true(已 评 价),false(未评价)
        /// </summary>
        public string buyer_rate { get; set; }

        /// <summary>
        /// 卖家帐号
        /// </summary>
        public string seller_uname { get; set; }
        public string seller_rate { get; set; }
        public string seller_alipay_no { get; set; }
        public string seller_mobile { get; set; }
        public string seller_phone { get; set; }
        public string seller_memo { get; set; }
        public string seller_flag { get; set; }
        public string seller_name { get; set; }
        public string seller_state { get; set; }
        public string seller_city { get; set; }
        public string seller_district { get; set; }
        public string seller_address { get; set; }
        public string seller_email { get; set; }
        public string seller_zip { get; set; }

        /// <summary>
        /// 交易佣金。精确到2位小 数; 单 位: 元
        /// </summary>
        public string commission_fee { get; set; }

        /// <summary>
        /// 发货人的姓名
        /// </summary>
        public string shipper_name { get; set; }
        public string shipper_phone { get; set; }
        public string shipper_mobile { get; set; }
        public string shipper_state { get; set; }
        public string shipper_city { get; set; }
        public string shipper_district { get; set; }
        public string shipper_address { get; set; }
        public string shipper_zip { get; set; }
        public string shipper_email { get; set; }

        /// <summary>
        /// 交易备注
        /// </summary>
        public string trade_memo { get; set; }

        /// <summary>
        /// 支付手续费
        /// </summary>
        public string pay_cost { get; set; }

        /// <summary>
        /// 买家备注
        /// </summary>
        public string buyer_memo { get; set; }

        /// <summary>
        /// 买家备注旗帜
        /// </summary>
        public string buyer_flag { get; set; }

        /// <summary>
        /// 买家留言
        /// </summary>
        public string buyer_message { get; set; }

        /// <summary>
        /// 交易类型。可选值：fixed (一口价)auction(拍卖)
        /// </summary>
        public string tradetype { get; set; }

        /// <summary>
        /// 发票内容
        /// </summary>
        public string invoice_desc { get; set; }

        /// <summary>
        /// 当前交易下子订单数量
        /// </summary>
        [Required]
        public string orders_number { get; set; }

        /// <summary>
        /// 该笔交易的商品总重量
        /// </summary>
        public string total_weight { get; set; }

        /// <summary>
        /// 订单
        /// </summary>
        [Required]
        [JsonFormat]
        public OrderWrap orders { get; set; }

        /// <summary>
        /// 支付信息
        /// </summary>
        [Required]
        [JsonFormat]
        public PaymentInfoWrap payment_lists { get; set; }

    }

    public class OrderWrap
    {
        public List<Order> order { get; set; }
    }

    public class PaymentInfoWrap
    {
        public List<PaymentInfo> payment_list { get; set; }
    }

    public class Order
    {
        public string oid { get; set; }

        /// <summary>
        /// 订 单 类 型 。 可 选 值 :goods( 商        品),gift(赠品)。默认为 goods
        /// </summary>
        public string type { get; set; }

        /// <summary>
        /// 订单类型别名（中文名称）
        /// </summary>
        public string type_alias { get; set; }

        /// <summary>
        /// 商品 ID
        /// </summary>
        public string iid { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// 订单下商品数量。取值范围:大于零的整数
        /// </summary>
        public string items_num { get; set; }

        /// <summary>
        /// 订单金额(单价 x 数量)
        /// </summary>
        public string total_order_fee { get; set; }
        public string weight { get; set; }
        public string discount_fee { get; set; }

        /// <summary>
        /// 订单状态 可选值： TRADE_ACTIVE:交易处理中, TRADE_CLOSED:交易作废即交易关闭, TRADE_FINISHED:交易成功      
        /// </summary>
        public string status { get; set; }

        /// <summary>
        /// 发货状态可 选 值 ： SHIP_NO: 未 发 货 ,SHIP_PREPARE:配货中, SHIP_PART:部分发货, SHIP_FINISH:全部发货,RESHIP_PART: 部 分 退 货,RESHIP_ALL:全部退货
        /// </summary>
        public string ship_status { get; set; }

        /// <summary>
        /// 支付状态 可 选 值 ： PAY_NO: 未 付 款 ,PAY_FINISH: 已 付 款 ,PAY_TO_MEDIUM: 付 款 至 担 保 交易 , PAY_PART: 部 分 付 款,REFUND_PART: 部 分 退 款,REFUND_ALL:全额退款
        /// </summary>
        public string pay_status { get; set; }

        /// <summary>
        /// 订单发货时间  格式:yyyy-MM-dd HH:mm:ss
        /// </summary>
        public string consign_time { get; set; }

        /// <summary>
        /// 订单商品详细
        /// </summary>
        public OrderItemWrap order_items { get; set; }

        /// <summary>
        /// 子订单销售金额
        /// </summary>
        public string sale_price { get; set; }

        /// <summary>
        /// 是否超卖，true 超卖；false 正常
        /// </summary>
        public bool is_oversold { get; set; }
    }

    public class OrderItemWrap
    {
        public List<OrderItem> item { get; set; }
    }

    public class OrderItem
    {
        /// <summary>
        /// 货品编码
        /// </summary>
        public string bn { get; set; }

        /// <summary>
        /// 货品名称
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 商品的最小库存单位 Sku 的 id
        /// </summary>
        public string sku_id { get; set; }
        /// <summary>
        /// SKU 的值。如：机身颜色:黑色;手机套餐:官方标配
        /// </summary>
        public string sku_properties { get; set; }
        /// <summary>
        /// sku 所属商品 id
        /// </summary>
        public string iid { get; set; }
        /// <summary>
        /// 重量
        /// </summary>
        public string weight { get; set; }
        /// <summary>
        /// 积分
        /// </summary>
        public string score { get; set; }
        /// <summary>
        /// 成本价
        /// </summary>
        public string cost { get; set; }
        /// <summary>
        /// 原价
        /// </summary>
        public string price { get; set; }
        /// <summary>
        /// 单价（实付价）
        /// </summary>
        public string sale_price { get; set; }
        /// <summary>
        /// 金额小计
        /// </summary>
        public string total_item_fee { get; set; }
        /// <summary>
        /// 购买数量
        /// </summary>
        public string num { get; set; }
        /// <summary>
        /// 已发数量
        /// </summary>
        public string sendnum { get; set; }

        /// <summary>
        /// sku 类型        可 选 值 :product(货 品),gift(赠品),adjunct(配件),pkg(捆绑)
        /// </summary>
        public string item_type { get; set; }

        /// <summary>
        /// 货品状态。 normal：正常; cancel: 删除
        /// </summary>
        public string item_status { get; set; }

        /// <summary>
        /// 促销方案 ID
        /// </summary>
        public string promotion_id { get; set; }

        /// <summary>
        /// 商品优惠金额
        /// </summary>
        public string discount_fee { get; set; }

    }

    public class PaymentInfo
    {
        /// <summary>
        /// 支付单编号
        /// </summary>
        public string payment_id { get; set; }

        /// <summary>
        /// 支付单对应的交易 ID
        /// </summary>
        public string tid { get; set; }

        /// <summary>
        /// 卖家收款银行
        /// </summary>
        public string seller_bank { get; set; }

        /// <summary>
        /// 卖家收款帐号
        /// </summary>
        public string seller_account { get; set; }

        /// <summary>
        /// 买家会员 ID
        /// </summary>
        public string buyer_id { get; set; }
        public string buy_name { get; set; }

        /// <summary>
        /// 买家支付账户
        /// </summary>
        public string buyer_account { get; set; }

        /// <summary>
        /// 本次支付金额
        /// </summary>
        public string pay_fee { get; set; }

        /// <summary>
        /// 支付花费
        /// </summary>
        public string paycost { get; set; }

        /// <summary>
        /// 当前单据选择的支付货币类型        可选值：CNY（人民币），USD（美        元），JPY（日元）。- 默认为 CNY（人民币）
        /// </summary>
        public string currency { get; set; }

        /// <summary>
        /// 实际支付金额
        /// </summary>
        public string currency_fee { get; set; }

        /// <summary>
        /// 支付类型        可选值：online（在线）,offline（线        下）, deposit（预存款）
        /// </summary>
        public string pay_type { get; set; }

        /// <summary>
        /// 支付方式编码
        /// </summary>
        public string payment_code { get; set; }

        /// <summary>
        /// 支付方式的名称
        /// </summary>
        public string payment_name { get; set; }

        /// <summary>
        /// 开始支付时间        格式：yyyy-MM-dd HH:mm:ss
        /// </summary>
        public DateTime? t_begin { get; set; }

        /// <summary>
        /// 付款结束时间 格式：yyyy-MM-dd HH:mm:ss
        /// </summary>
        public DateTime? t_end { get; set; }

        /// <summary>
        /// 支付时间        格式：yyyy-MM-dd HH:mm:ss
        /// </summary>
        public DateTime? pay_time { get; set; }

        /// <summary>
        /// 付款单状态 可选值： SUCC:支付成功, FAILED:支付失败, CANCEL:未支付, ERROR:参数异常 , INVALID: 校 验 错 误,PROGRESS:处理中, TIMEOUT:超时,READY:准备中
        /// </summary>
        public string status { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string memo { get; set; }

        /// <summary>
        /// 支付网关的内部交易单号
        /// </summary>
        public string outer_no { get; set; }


    }

    public class PromotionDetailWrap
    {
        public List<PromotionDetail> payment_list { get; set; }
    }

    public class PromotionDetail
    {
        /// <summary>
        /// 优惠对应的订单 ID，可能是交易号 tid,也可能是 oid.ID 决定优惠是在 交易上还是子订单上 
        /// </summary>
        public string pmt_id { get; set; }

        /// <summary>
        /// 优惠描述 
        /// </summary>
        public string promotion_name { get; set; }
        public string promotion_fee { get; set; }
        public string promotion_desc { get; set; }
        /// <summary>
        /// 优惠 id，(由营销工具 id、优惠活 动 id 和优惠详情 id 组成，结构为： 营销工具 id-优惠活动 id_优惠详情 id，如 mjs-123024_211143） 
        /// </summary>
        public string promotion_id { get; set; }

        /// <summary>
        /// 如果是赠品，为赠品商品 ID 
        /// </summary>
        public string gift_item_id { get; set; }

        /// <summary>
        /// 如果是赠品，为赠品商品名称 
        /// </summary>
        public string gift_item_name { get; set; }

        /// <summary>
        /// 如果是赠品，为赠品数量 
        /// </summary>
        public string gift_item_num { get; set; }
    }
}
