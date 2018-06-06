﻿using System.ComponentModel.DataAnnotations;

namespace Prism.Domain
{
    /// <summary>
    /// ectools.get_payments.get_all 获取支付方式
    /// </summary>
    public class EctoolsGetPaymentsGetAllRequest
    {
        /// <summary>
        /// 节点号 格 式 :’ OMS 节 点号’_’B2C 节点号’
        /// </summary>
        [Required]
        public string node_id { get; set; }
    }

}
