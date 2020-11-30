using Microsoft.AspNetCore.Mvc.Rendering;
using ReatApp.Web.Data;
using System.Collections.Generic;
using System.Linq;

namespace ReatApp.Web.Helpers
{
    public class CombosHelper : ICombosHelper
    {
        private readonly DataContext _context;

        public CombosHelper(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> GetComboRestaurants(string Id, string Type)
        {
            List<SelectListItem> list ;
            if (Type == "Admin")
            {
                 list = _context.Restaurants.Select(t => new SelectListItem
                   {
                       Text = t.Name,
                       Value = $"{t.Id}"

                   })
                   .OrderBy(t => t.Text)
                   .ToList();

                list.Insert(0, new SelectListItem
                {
                    Text = "[Select a restaurant...]",
                    Value = "0"
                });

                return list;
            }

            list = _context.Restaurants.Where(q => q.UserId == Id)
                .Select(t => new SelectListItem
                {
                    Text = t.Name,
                    Value = $"{t.Id}"

                })
                .OrderBy(t => t.Text)
                .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "[Select a restaurant...]",
                Value = "0"
            });

            return list;
        }
    }


}
