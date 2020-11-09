using Prism.Navigation;
using RestApp.Prism.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestApp.Prism.ViewModels
{
   
    public class RestaurantTabbedPageViewModel : ViewModelBase
    {
        public RestaurantTabbedPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = Languages.Restaurants;
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            
        }
    }

}
