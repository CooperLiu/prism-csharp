using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prism.Domain
{

    /// <summary>
    /// b2c.order.remark 更新订单备注
    /// </summary>
    public class B2cOrderRemarkRequest : PrismWebhookRequestBase<B2cOrderRemarkRequestData, B2cOrderRemarkResponseData>
    {
        public override string ApiMethod { get; set; } = "b2c.order.remark";
    }

    /// <summary>
    /// b2c.order.remark 更新订单备注
    /// </summary>
    public class B2cOrderRemarkRequestData
    {
        /// <summary>
        /// 节点号 格 式 :’ OMS 节 点号’_’B2C 节点号’
        /// </summary>
        [Required]
        public string node_id { get; set; }

        /// <summary>
        /// 交易 id
        /// </summary>
        [Required]
        public string order_bn { get; set; }

        /// <summary>
        /// 交易备注 。{‘open_name’:’ 备 注 添加 者’,’ open_time’:’ 备注时间 ’,’op_content’:’备注内容’}
        /// </summary>
        [Required]
        public string memo { get; set; }

        /// <summary>
        /// 交易备注旗帜  可选值为：0(灰色), 1(红色), 2(黄色), 3(绿色),4(蓝色), 5(粉红色)，7(橙色),8(紫色) 默认 值为 0
        /// </summary>
        [Required]
        public int mark_type { get; set; }
    }
}
