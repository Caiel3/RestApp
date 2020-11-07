using Prism.Navigation;
using RestApp.Prism.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestApp.Prism.ViewModels
{
    class RestaurantLocationPageViewModel : ViewModelBase
    {
        public RestaurantLocationPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = Languages.RestaurantsLocation;
        }
    }
}
