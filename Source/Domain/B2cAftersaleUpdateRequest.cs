using System.ComponentModel.DataAnnotations;

namespace Prism.Domain
{
    /// <summary>
    /// b2c.aftersale.update 更新售后申请的状态
    /// </summary>
    public class B2cAftersaleUpdateRequest
    {
        /// <summary>
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
        /// 状态可选值:1(申请中),2(审核中),3(接受申请),4(完成 ),5(拒 绝 ),6(已 收货 ),7(已质检),8(补 差价),9(已拒绝退款)
        /// </summary>
        [Required]
        public string status { get; set; }

        /// <summary>
        /// 处理内容
        /// </summary>
        [Required]
        public string memo { get; set; }
    }
}
