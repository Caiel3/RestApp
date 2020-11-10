using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using RestApp.Common.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ReatApp.Web.Models
{
    public class PointSaleViewModel : PointSale
    {
        [Display(Name = "Restaurant")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a Restaurant.")]
        [Required]
        public int RestaurantId { get; set; }

        public IEnumerable<SelectListItem> Restaurants { get; set; }

        [Display(Name = "Image")]
        public IFormFile ImageFile { get; set; }
    }

}
