using Prism.Navigation;
using RestApp.Common.Services;
using RestApp.Prism.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestApp.Prism.ViewModels
{
    class RestaurantPageViewModel:ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;

        public RestaurantPageViewModel(INavigationService navigationService, IApiService apiService)
            :base(navigationService)
        {
            _navigationService = navigationService;
            _apiService = apiService;
            Title = Languages.Restaurants;
        }
    }
}
