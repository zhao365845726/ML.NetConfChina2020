
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

        public Category(CategoryDto categoryDto) : this()
        {
            LastUpdateTime = categoryDto.LastUpdateTime;
            Name = categoryDto.Name;
            Sort = categoryDto.Sort;
            Pid = categoryDto.Pid;
        }

        public void Update(CategoryDto categoryDto)
        {
            LastUpdateTime = categoryDto.LastUpdateTime;
            Name = categoryDto.Name;
            Sort = categoryDto.Sort;
            Pid = categoryDto.Pid;
        }

        /// <summary>
        /// 分类名称
        /// </summary>
        [MaxLength(500)]
        public string Name { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 父级id
        /// </summary>
        [MaxLength(50)]
        public string Pid { get; set; }

    }
}
