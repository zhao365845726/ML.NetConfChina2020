using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Senparc.Ncf.Core.Models;

namespace NetConf.Xncf.Admin.Models.DatabaseModel
{
    /// <summary>
    /// Orders 实体类
    /// </summary>
    [Table(Register.DATABASE_PREFIX + nameof(Orders))]//必须添加前缀，防止全系统中发生冲突
    [Serializable]
    public class Orders : EntityBase<string>
    {
        public Orders()
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
        /// 商品Id
        /// </summary>
        [MaxLength(50), Description("string|ProductId|商品Id|50")]
        public string ProductId { get; set; }
        /// <summary>
        /// 用户Id
        /// </summary>
        [MaxLength(50), Description("string|UserId|用户Id|50")]
        public string UserId { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        [Description("int|Number|数量")]
        public int Number { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        [Description("decimal|Amount|金额")]
        public decimal Amount { get; set; }
        /// <summary>
        /// 实付金额
        /// </summary>
        [Description("decimal|PaidAmount|实付金额")]
        public decimal PaidAmount { get; set; }
        /// <summary>
        /// 订单状态(1-待支付;2-已支付;3-待评价;4-已完成;99-购物车;)
        /// </summary>
        [Description("int|Status|订单状态")]
        public int Status { get; set; }
    }
}
