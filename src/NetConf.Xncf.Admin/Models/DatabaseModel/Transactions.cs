using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Senparc.Ncf.Core.Models;

namespace NetConf.Xncf.Admin.Models.DatabaseModel
{
    /// <summary>
    /// Transactions 实体类
    /// </summary>
    [Table(Register.DATABASE_PREFIX + nameof(Transactions))]//必须添加前缀，防止全系统中发生冲突
    [Serializable]
    public class Transactions : EntityBase<string>
    {
        public Transactions()
        {
            Id = Guid.NewGuid().ToString();
            AddTime = DateTime.Now;
            this.LastUpdateTime = AddTime;
        }

        /// <summary>
        /// 订单编号
        /// </summary>
        [MaxLength(50), Description("string|OrderNum|订单编号|50")]
        public string OrderNum { get; set; }
        /// <summary>
        /// 交易状态(1-待处理;2-已处理;)
        /// </summary>
        [Description("int|Status|交易状态(1-待处理;2-已处理;)")]
        public int Status { get; set; }
        /// <summary>
        /// 用户Id
        /// </summary>
        [MaxLength(50), Description("string|UserId|用户Id|50")]
        public string UserId { get; set; }
        /// <summary>
        /// 交易金额
        /// </summary>
        [Description("decimal|Quota|交易金额")]
        public decimal Quota { get; set; }
        /// <summary>
        /// 支付方式(1-微信;2-支付宝;3-账户余额;)
        /// </summary>
        [Description("int|Method|支付方式(1-微信;2-支付宝;3-账户余额;)")]
        public int Method { get; set; }
    }
}
