using RestApp.Common.Entities;
using System.Collections.Generic;
using System.Linq;

namespace RestApp.Common.Responses
{
    internal class PointSaleResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        public int Tables { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public Restaurant Restaurant { get; set; }

        public ICollection<Catalogue> CatalogueImage { get; set; }

        public int CatalogueImagesNumber => CatalogueImage == null ? 0 : CatalogueImage.Count;

        public string ImageFullPath => CatalogueImage == null || CatalogueImage.Count == 0
            ? $"https://onsalecarmona.azurewebsites.net/images/noimage.png"
            : CatalogueImage.FirstOrDefault().ImageFullPath;

        public ICollection<QualificationResponse> Qualifications { get; set; }

        public int ProductQualifications => Qualifications == null ? 0 : Qualifications.Count;

        public float Qualification => Qualifications == null || Qualifications.Count == 0 ? 0 : Qualifications.Average(q => q.Score);
    }

}
