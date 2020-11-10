using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ReatApp.Web.Helpers
{
    public interface ICombosHelper
    {
        IEnumerable<SelectListItem> GetComboRestaurants();
    }



}
