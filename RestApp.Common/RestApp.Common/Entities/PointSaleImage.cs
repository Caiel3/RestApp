using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RestApp.Common.Entities
{
    public class PointSaleImage
    {
        public int Id { get; set; }

        [Display(Name = "Image")]
        public Guid ImageId { get; set; }

        //TODO: Pending to put the correct paths
        [Display(Name = "Image")]
        public string ImageFullPath => ImageId == Guid.Empty
            ? $"https://onsalecarmona.azurewebsites.net/images/noimage.png"
            : $"https://programaciondistribuida.blob.core.windows.net/products/{ImageId}";
    }

}
