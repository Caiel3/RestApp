﻿using RestApp.Common.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReatApp.Web.Data.Entities
{
    public class Restaurant
    {

        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "The filed {0} must contain less than {1} Characteres.")]
        [Required]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal Price { get; set; }

        [DisplayName("Is Active")]
        public bool IsActive { get; set; }

        [DisplayName("Is Starred")]
        public bool IsStarred { get; set; }

        public ICollection<RestaurantImage> RestaurantImages { get; set; }

        [DisplayName("Product Images Number")]
        public int ProductImagesNumber => RestaurantImages == null ? 0 : RestaurantImages.Count;

        [Display(Name = "Image")]
        public string ImageFullPath => RestaurantImages == null || RestaurantImages.Count == 0
            ? $"https://onsalecarmona.azurewebsites.net/images/noimage.png"
            : RestaurantImages.FirstOrDefault().ImageFullPath;

        //public ICollection<Qualification> Qualifications { get; set; }

        //[DisplayName("Product Qualifications")]
        //public int ProductQualifications => Qualifications == null ? 0 : Qualifications.Count;

        //[DisplayFormat(DataFormatString = "{0:N2}")]
        //public float Qualification => Qualifications == null || Qualifications.Count == 0 ? 0 : Qualifications.Average(q => q.Score);

    }

}
