using ReatApp.Web.Data;
using ReatApp.Web.Models;
using RestApp.Common.Entities;
using System;
using System.Threading.Tasks;

namespace ReatApp.Web.Helpers
{
    public class ConverterHelper : IConverterHelper
    {
        private readonly DataContext _context;
        private readonly ICombosHelper _combosHelper;

        public ConverterHelper(DataContext context, ICombosHelper combosHelper)
        {
            _context = context;
            _combosHelper = combosHelper;
        }

        public Restaurant ToRestaurant(RestaurantViewModel model, Guid imageId, bool isNew)
        {
            return new Restaurant
            {
                Id = isNew ? 0 : model.Id,
                ImageId = imageId,
                Name = model.Name,
                Description = model.Description
            };
        }

        public RestaurantViewModel ToRestaurantViewModel(Restaurant restaurant)
        {
            return new RestaurantViewModel
            {
                Id = restaurant.Id,
                ImageId = restaurant.ImageId,
                Name = restaurant.Name,
                Description = restaurant.Description
            };
        }

        public async Task<PointSale> ToPointSaleAsync(PointSaleViewModel model, bool isNew)
        {
            return new PointSale
            {
                Restaurant = await _context.Restaurants.FindAsync(model.RestaurantId),
                Description = model.Description,
                Id = isNew ? 0 : model.Id,
                Name = model.Name,
                PointSaleImage = model.PointSaleImage
            };
        }

        public PointSaleViewModel ToPointSaleViewModel(PointSale pointSale)
        {
            return new PointSaleViewModel
            {
                Restaurants = _combosHelper.GetComboRestaurants(),
                Restaurant = pointSale.Restaurant,
                RestaurantId = pointSale.Restaurant.Id,
                Description = pointSale.Description,
                Id = pointSale.Id,
                Name = pointSale.Name,
                PointSaleImage = pointSale.PointSaleImage
            };
        }



    }

}
