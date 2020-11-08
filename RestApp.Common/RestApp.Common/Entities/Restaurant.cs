using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace RestApp.Common.Entities
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

        [Display(Name = "Image")]
        public Guid ImageId { get; set; }


        public ICollection<RestaurantImage> RestaurantImages { get; set; }

        [DisplayName("Product Images Number")]
        public int RestaurantImagesNumber => RestaurantImages == null ? 0 : RestaurantImages.Count;

        [Display(Name = "Image")]
        public string ImageFullPath => RestaurantImages == null || RestaurantImages.Count == 0
            ? $"https://onsalecarmona.azurewebsites.net/images/noimage.png"
            : RestaurantImages.FirstOrDefault().ImageFullPath;
    }
}
