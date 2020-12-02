using ReatApp.Web.Data;
using ReatApp.Web.Data.Entities;
using ReatApp.Web.Models;
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
                UserId = model.UserId,
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
                Latitude = model.Latitude,
                Longitude = model.Longitude,
                HourFinish = model.HourFinish,
                HourStart = model.HourStart,
                Tables = model.Tables,
                Address = model.Address,
                CatalogueImage = model.CatalogueImage                
            };
        }

        public PointSaleViewModel ToPointSaleViewModel(PointSale pointSale,string Id,string Type)
        {


            return new PointSaleViewModel
            {
                Restaurants = _combosHelper.GetComboRestaurants(Id,Type),
                Restaurant = pointSale.Restaurant,
                RestaurantId = pointSale.Restaurant.Id,
                Description = pointSale.Description,
                Id = pointSale.Id,
                Name = pointSale.Name,
                HourFinish = pointSale.HourFinish,
                HourStart = pointSale.HourStart,
                Latitude = pointSale.Latitude,
                Longitude = pointSale.Longitude,
                Tables = pointSale.Tables,
                Address = pointSale.Address,
                CatalogueImage = pointSale.CatalogueImage
            };
        }


      

    }

}
