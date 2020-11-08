using Microsoft.AspNetCore.Http;
using RestApp.Common.Entities;
using System.ComponentModel.DataAnnotations;

namespace ReatApp.Web.Models
{
    public class RestaurantViewModel : Restaurant
    {
        [Display(Name = "Image")]
        public IFormFile ImageFile { get; set; }

    }


}
