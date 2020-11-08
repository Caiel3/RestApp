using ReatApp.Web.Models;
using RestApp.Common.Entities;
using System;

namespace ReatApp.Web.Helpers
{
    public class ConverterHelper : IConverterHelper
    {


        public Restaurant ToRestaurant(RestaurantViewModel model, Guid imageId, bool isNew)
        {
            return new Restaurant
            {
                Id = isNew ? 0 : model.Id,
                ImageId = imageId,
                Name = model.Name,
                Description = model.Description,
                IsActive = model.IsActive,
                IsStarred = model.IsStarred,
                Price = model.Price,
                RestaurantImages = model.RestaurantImages
            };
        }

        public RestaurantViewModel ToRestaurantViewModel(Restaurant restaurant)
        {
            return new RestaurantViewModel
            {
                Id = restaurant.Id,
                ImageId = restaurant.ImageId,
                Name = restaurant.Name,
                Description = restaurant.Description,
                IsActive = restaurant.IsActive,
                IsStarred = restaurant.IsStarred,
                Price = restaurant.Price,
                RestaurantImages = restaurant.RestaurantImages
            };
        }


    }

}
