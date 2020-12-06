
using Senparc.Ncf.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

using NetConf.Xncf.Admin.Models.DatabaseModel.Dto;

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

        public Orders(OrdersDto ordersDto) : this()
        {
            LastUpdateTime = ordersDto.LastUpdateTime;
            OrderNum = ordersDto.OrderNum;
            ProductId = ordersDto.ProductId;
            UserId = ordersDto.UserId;
            Number = ordersDto.Number;
            Amount = ordersDto.Amount;
            PaidAmount = ordersDto.PaidAmount;
            Status = ordersDto.Status;
        }

        public void Update(OrdersDto ordersDto)
        {
            LastUpdateTime = ordersDto.LastUpdateTime;
            OrderNum = ordersDto.OrderNum;
            ProductId = ordersDto.ProductId;
            UserId = ordersDto.UserId;
            Number = ordersDto.Number;
            Amount = ordersDto.Amount;
            PaidAmount = ordersDto.PaidAmount;
            Status = ordersDto.Status;
        }

        /// <summary>
        /// 订单编号
        /// </summary>
        [MaxLength(50)]
        public string OrderNum { get; set; }

        /// <summary>
        /// 商品Id
        /// </summary>
        [MaxLength(50)]
        public string ProductId { get; set; }

        /// <summary>
        /// 用户Id
        /// </summary>
        [MaxLength(50)]
        public string UserId { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// 实付金额
        /// </summary>
        public decimal PaidAmount { get; set; }

        /// <summary>
        /// 订单状态
        /// </summary>
        public int Status { get; set; }

    }
}
