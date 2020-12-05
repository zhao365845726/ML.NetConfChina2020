using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Senparc.Ncf.Core.Models;

namespace NetConf.Xncf.Admin.Models.DatabaseModel
{
    /// <summary>
    /// Category 实体类
    /// </summary>
    [Table(Register.DATABASE_PREFIX + nameof(Category))]//必须添加前缀，防止全系统中发生冲突
    [Serializable]
    public class Category : EntityBase<string>
    {
        public Category()
        {
            Id = Guid.NewGuid().ToString();
            AddTime = DateTime.Now;
            this.LastUpdateTime = AddTime;
        }

        /// <summary>
        /// 分类名称
        /// </summary>
        [MaxLength(500), Description("string|Name|分类名称|500")]
        public string Name { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        [Description("int|Sort|排序")]
        public int Sort { get; set; }
        /// <summary>
        /// 父级id
        /// </summary>
        [MaxLength(50), Description("string|Pid|父级id|50")]
        public string Pid { get; set; }
    }
}
