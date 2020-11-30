﻿using ReatApp.Web.Data.Entities;
using ReatApp.Web.Models;
using RestApp.Common.Entities;
using System;
using System.Threading.Tasks;

namespace ReatApp.Web.Helpers
{
    public interface IConverterHelper
    {
        Restaurant ToRestaurant(RestaurantViewModel model, Guid imageId, bool isNew);

        RestaurantViewModel ToRestaurantViewModel(Restaurant Restaurant);

        Task<PointSale> ToPointSaleAsync(PointSaleViewModel model, bool isNew);

        PointSaleViewModel ToPointSaleViewModel(PointSale pointsale, string Id, string Type);


    }

}
