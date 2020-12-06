
using Senparc.Ncf.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NetConf.Xncf.Admin.Models.DatabaseModel.Dto
{
    public class TransactionsDto : DtoBase
    {
        public TransactionsDto()
        {
        }

        public TransactionsDto(string id, string orderNum, int status, string userId, decimal quota, int method)
        {
            Id = id;
            OrderNum = orderNum;
            Status = status;
            UserId = userId;
            Quota = quota;
            Method = method;
        }

        public string Id { get; set; }

        /// <summary>
        /// 订单编号
        /// </summary>
        [MaxLength(50)]
        public string OrderNum { get; set; }

        /// <summary>
        /// 交易状态(1-待处理;2-已处理;)
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 用户Id
        /// </summary>
        [MaxLength(50)]
        public string UserId { get; set; }

        /// <summary>
        /// 交易金额
        /// </summary>
        public decimal Quota { get; set; }

        /// <summary>
        /// 支付方式(1-微信;2-支付宝;3-账户余额;)
        /// </summary>
        public int Method { get; set; }

    }
}
