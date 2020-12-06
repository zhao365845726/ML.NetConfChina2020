
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

        public Transactions(TransactionsDto transactionsDto) : this()
        {
            LastUpdateTime = transactionsDto.LastUpdateTime;
            OrderNum = transactionsDto.OrderNum;
            Status = transactionsDto.Status;
            UserId = transactionsDto.UserId;
            Quota = transactionsDto.Quota;
            Method = transactionsDto.Method;
        }

        public void Update(TransactionsDto transactionsDto)
        {
            LastUpdateTime = transactionsDto.LastUpdateTime;
            OrderNum = transactionsDto.OrderNum;
            Status = transactionsDto.Status;
            UserId = transactionsDto.UserId;
            Quota = transactionsDto.Quota;
            Method = transactionsDto.Method;
        }

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
