using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Senparc.Ncf.Core.Models;

namespace NetConf.Xncf.Admin.Models.DatabaseModel
{
    /// <summary>
    /// Products 实体类
    /// </summary>
    [Table(Register.DATABASE_PREFIX + nameof(Products))]//必须添加前缀，防止全系统中发生冲突
    [Serializable]
    public class Products : EntityBase<string>
    {
        public Products()
        {
            Id = Guid.NewGuid().ToString();
            AddTime = DateTime.Now;
            this.LastUpdateTime = AddTime;
        }

        /// <summary>
        /// 分类Id
        /// </summary>
        [MaxLength(50), Description("string|CategoryId|分类Id|50")]
        public string CategoryId { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        [MaxLength(50), Description("string|Name|商品名称|50")]
        public string Name { get; set; }
        /// <summary>
        /// 封面图
        /// </summary>
        [MaxLength(200), Description("string|Cover|商品名称|200")]
        public string Cover { get; set; }
        /// <summary>
        /// 视频简介
        /// </summary>
        [MaxLength(200), Description("string|Video|商品名称|200")]
        public string Video { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        [MaxLength(5000), Description("string|Content|商品名称|5000")]
        public string Content { get; set; }
    }
}
