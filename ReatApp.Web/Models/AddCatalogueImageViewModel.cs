using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReatApp.Web.Models
{
    public class AddCatalogueImageViewModel
    {
        public int PointSaleId { get; set; }

        [Display(Name = "Image")]
        [Required]
        public IFormFile ImageFile { get; set; }
    }

}
