using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Senparc.Ncf.Core.Models;

namespace NetConf.Xncf.Admin.Models.DatabaseModel
{
    /// <summary>
    /// User 实体类
    /// </summary>
    [Table(Register.DATABASE_PREFIX + nameof(User))]//必须添加前缀，防止全系统中发生冲突
    [Serializable]
    public class User : EntityBase<string>
    {
        public User()
        {
            Id = Guid.NewGuid().ToString();
            AddTime = DateTime.Now;
            this.LastUpdateTime = AddTime;
        }

        /// <summary>
        /// 用户昵称
        /// </summary>
        [MaxLength(50), Description("string|NickName|用户昵称|50")]
        public string NickName { get; set; }
        /// <summary>
        /// 用户账户
        /// </summary>
        [MaxLength(50), Description("string|Account|用户账户|50")]
        public string Account { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [MaxLength(50), Description("string|Password|密码|50")]
        public string Password { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        [MaxLength(50), Description("string|Name|姓名|50")]
        public string Name { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        [MaxLength(50), Description("string|Gender|性别|50")]
        public string Gender { get; set; }
        /// <summary>
        /// 账户余额
        /// </summary>
        [Description("decimal|Balance|账户余额")]
        public decimal Balance { get; set; }
    }
}
