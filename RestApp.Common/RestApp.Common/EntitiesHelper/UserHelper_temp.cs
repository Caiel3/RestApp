
using RestApp.Common.Enums;
using RestApp.Common.Responses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReatApp.Web.Data.Entities
{
    public class UserHelper_temp
    {
        [MaxLength(20)]
        [Required]
        public string Document { get; set; }

        [Display(Name = "First Name")]
        [MaxLength(50)]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [MaxLength(50)]
        [Required]
        public string LastName { get; set; }

        [MaxLength(100)]
        public string Address { get; set; }

        [Display(Name = "Image")]
        public Guid ImageId { get; set; }

        //TODO: Pending to put the correct paths
        [Display(Name = "Image")]
        public string ImageFullPath => ImageId == Guid.Empty
            ? $"https://restappdistribuida.azurewebsites.net/images/noimage.png"
            : $"https://onsale.blob.core.windows.net/users/{ImageId}";

        [Display(Name = "User Type")]
        public UserType UserType { get; set; }


        [Display(Name = "User")]
        public string FullName => $"{FirstName} {LastName}";

        [Display(Name = "User")]
        public string FullNameWithDocument => $"{FirstName} {LastName} - {Document}";

        public static implicit operator UserHelper_temp(TokenResponse v)
        {
            throw new NotImplementedException();
        }
    }

}
