using Prism.Navigation;
using ReatApp.Web.Data.Entities;
using RestApp.Prism.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestApp.Prism.ViewModels
{
  
    public class RestaurantTabbedPageViewModel : ViewModelBase
    {
        private PointSaleHelper _pointsale;
        public RestaurantTabbedPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = Languages.Restaurants;
        }

        public PointSaleHelper PointSale
        {
            get => _pointsale;
            set => SetProperty(ref _pointsale, value);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.ContainsKey("pointsale"))
            {
                PointSale = parameters.GetValue<PointSaleHelper>("pointsale");
                Title = PointSale.Name;
          
            }
        }
    }

}
