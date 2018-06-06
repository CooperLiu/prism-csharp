﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prism.Domain
{
    /// <summary>
    /// b2c.order.leave_message 添加买家留言
    /// </summary>
    public class B2cOrderLeaveMessageRequest
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
        /// Json 格式 含三个参数：        op_name:留言操作人，op_time: 添加留言时间，op_content:留言内容。
        public string message { get; set; }
    }

}