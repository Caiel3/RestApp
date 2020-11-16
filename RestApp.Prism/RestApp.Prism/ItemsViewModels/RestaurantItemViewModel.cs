using Prism.Commands;
using Prism.Navigation;
using ReatApp.Web.Data.Entities;
using RestApp.Prism.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestApp.Prism.ItemsViewModels
{
    

    public class RestaurantItemViewModel : PointSaleHelper
    {
        private readonly INavigationService _navigationService;
        private DelegateCommand _SelectPointSaleCommand;

        public RestaurantItemViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public DelegateCommand SelectPointSaleCommand => _SelectPointSaleCommand ?? (_SelectPointSaleCommand = new DelegateCommand(SelectProductAsync));

        private async void SelectProductAsync()
        {
            NavigationParameters parameters = new NavigationParameters
            {
                { "pointsale", this }
            };

            await _navigationService.NavigateAsync(nameof(RestaurantTabbedPage), parameters);
        }
    }

}
