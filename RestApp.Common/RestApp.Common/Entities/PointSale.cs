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

        [MaxLength(100)]
        public string Address { get; set; }

        public int Tables { get; set; }

        [DisplayFormat(DataFormatString = "{0:N4}")]
        public double Latitude { get; set; }

        [DisplayFormat(DataFormatString = "{0:N4}")]

        public double Longitude { get; set; }

        public Restaurant Restaurant { get; set; }

        public ICollection<Catalogue> CatalogueImage { get; set; }

        [DisplayName("Point Sale Images Number")]
        public int CatalogueImagesNumber => CatalogueImage == null ? 0 : CatalogueImage.Count;

        //TODO: Pending to put the correct paths
        [Display(Name = "Image")]
        public string ImageFullPath => CatalogueImage == null || CatalogueImage.Count == 0
            ? $"https://onsalecarmona.azurewebsites.net/images/noimage.png"
            : CatalogueImage.FirstOrDefault().ImageFullPath;
    }

}
