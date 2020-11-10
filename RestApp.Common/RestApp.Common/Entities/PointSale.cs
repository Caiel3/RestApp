using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace RestApp.Common.Entities
{
    public class PointSale
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }


        public Restaurant Restaurant { get; set; }

        public ICollection<PointSaleImage> PointSaleImage { get; set; }

        [DisplayName("Point Sale Images Number")]
        public int PointSaleImagesNumber => PointSaleImage == null ? 0 : PointSaleImage.Count;

        //TODO: Pending to put the correct paths
        [Display(Name = "Image")]
        public string ImageFullPath => PointSaleImage == null || PointSaleImage.Count == 0
            ? $"https://onsalecarmona.azurewebsites.net/images/noimage.png"
            : PointSaleImage.FirstOrDefault().ImageFullPath;
    }

}
