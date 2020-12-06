
using Senparc.Ncf.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NetConf.Xncf.Admin.Models.DatabaseModel.Dto
{
    public class CategoryDto : DtoBase
    {
        public CategoryDto()
        {
        }

        public CategoryDto(string id, string name, int sort, string pid)
        {
            Id = id;
            Name = name;
            Sort = sort;
            Pid = pid;
        }

        public string Id { get; set; }

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
