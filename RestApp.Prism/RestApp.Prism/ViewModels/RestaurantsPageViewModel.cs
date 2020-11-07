using Prism.Navigation;
using RestApp.Common.Services;
using RestApp.Prism.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestApp.Prism.ViewModels
{
    class RestaurantsPageViewModel:ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;

        public RestaurantsPageViewModel(INavigationService navigationService, IApiService apiService)
            :base(navigationService)
        {
            _navigationService = navigationService;
            _apiService = apiService;
            Title = Languages.Restaurants;
        }
    }
}
