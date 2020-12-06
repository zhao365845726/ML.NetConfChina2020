
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

        public Products(ProductsDto productsDto) : this()
        {
            LastUpdateTime = productsDto.LastUpdateTime;
            CategoryId = productsDto.CategoryId;
            Name = productsDto.Name;
            Cover = productsDto.Cover;
            Video = productsDto.Video;
            Content = productsDto.Content;
            Price = productsDto.Price;
        }

        public void Update(ProductsDto productsDto)
        {
            LastUpdateTime = productsDto.LastUpdateTime;
            CategoryId = productsDto.CategoryId;
            Name = productsDto.Name;
            Cover = productsDto.Cover;
            Video = productsDto.Video;
            Content = productsDto.Content;
            Price = productsDto.Price;
        }

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

        /// <summary>
        /// 商品价格
        /// </summary>
        public decimal Price { get; set; }

    }
}
