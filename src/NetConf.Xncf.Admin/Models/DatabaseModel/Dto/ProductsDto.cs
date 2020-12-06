
using Senparc.Ncf.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NetConf.Xncf.Admin.Models.DatabaseModel.Dto
{
    public class ProductsDto : DtoBase
    {
        public ProductsDto()
        {
        }

        public ProductsDto(string id, string categoryId, string name, string cover, string video, string content)
        {
            Id = id;
            CategoryId = categoryId;
            Name = name;
            Cover = cover;
            Video = video;
            Content = content;
        }

        public string Id { get; set; }

        /// <summary>
        /// 分类Id
        /// </summary>
        [MaxLength(50)]
        public string CategoryId { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        [MaxLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        [MaxLength(200)]
        public string Cover { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        [MaxLength(200)]
        public string Video { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        [MaxLength(5000)]
        public string Content { get; set; }

    }
}
