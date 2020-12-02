using RestApp.Common.Entities;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ReatApp.Web.Data.Entities
{
    public class PointSaleHelper
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

        public RestaurantHelper Restaurant { get; set; }

        [DataType(DataType.MultilineText)]
        public string Remarks { get; set; }

        public TimeSpan HourStart { get; set; }
     
        public TimeSpan HourFinish { get; set; }
        public ICollection<Catalogue> CatalogueImage { get; set; }

        [DisplayName("Point Sale Images Number")]
        public int CatalogueImagesNumber => CatalogueImage == null ? 0 : CatalogueImage.Count;

        //TODO: Pending to put the correct paths
        [Display(Name = "Image")]
        public string ImageFullPath => CatalogueImage == null || CatalogueImage.Count == 0
            ? $"https://onsalecarmona.azurewebsites.net/images/noimage.png"
            : CatalogueImage.FirstOrDefault().ImageFullPath;

        public ICollection<QualificationHelper> Qualifications { get; set; }

        [DisplayName("Poin Sale Qualifications")]
        public int PoinsSaleQualifications => Qualifications == null ? 0 : Qualifications.Count;

        [DisplayFormat(DataFormatString = "{0:N2}")]
        public float Qualification => Qualifications == null || Qualifications.Count == 0 ? 0 : Qualifications.Average(q => q.Score);

    }
}
