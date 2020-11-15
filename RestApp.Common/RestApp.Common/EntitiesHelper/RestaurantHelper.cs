using System;
using System.ComponentModel.DataAnnotations;

namespace ReatApp.Web.Data.Entities
{
    public class RestaurantHelper
    {
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "The filed {0} must contain less than {1} Characteres.")]
        [Required]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "Image")]
        public Guid ImageId { get; set; }

        public UserHelper User { get; set; }

        //TODO: Pending to put the correct paths
        [Display(Name = "Image")]
        public string ImageFullPath => ImageId == Guid.Empty
            ? $"https://onsalecarmona.azurewebsites.net/images/noimage.png"
            : $"https://programaciondistribuida.blob.core.windows.net/categories/{ImageId}";

    }
}
