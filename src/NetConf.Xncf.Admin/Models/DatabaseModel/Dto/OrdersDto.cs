
using Senparc.Ncf.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NetConf.Xncf.Admin.Models.DatabaseModel.Dto
{
    public class OrdersDto : DtoBase
    {
        public OrdersDto()
        {
        }

        public OrdersDto(string id, string orderNum, string productId, string userId, int number, decimal amount, decimal paidAmount, int status)
        {
            Id = id;
            OrderNum = orderNum;
            ProductId = productId;
            UserId = userId;
            Number = number;
            Amount = amount;
            PaidAmount = paidAmount;
            Status = status;
        }

        public string Id { get; set; }

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
