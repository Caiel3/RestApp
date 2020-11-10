using Prism.Navigation;
using RestApp.Common.Entities;
using RestApp.Common.Responses;
using RestApp.Common.Services;
using RestApp.Prism.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Essentials;

namespace RestApp.Prism.ViewModels
{
    
    public class RestaurantPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        private ObservableCollection<PointSale> _pointsale;

        public RestaurantPageViewModel(INavigationService navigationService, IApiService apiService) : base(navigationService)
        {
            _navigationService = navigationService;
            _apiService = apiService;
            Title = Languages.Restaurants;
            LoadPointsSalesAsync();
        }

        public ObservableCollection<PointSale> PointSale
        {
            get => _pointsale;
            set => SetProperty(ref _pointsale, value);
        }

        private async void LoadPointsSalesAsync()
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await App.Current.MainPage.DisplayAlert(Languages.Error, Languages.ConnectionError, Languages.Accept);
                return;
            }

            string url = App.Current.Resources["UrlAPI"].ToString();
            Response response = await _apiService.GetListAsync<PointSale>(
                url,
                "/api",
                "/PointsSale");

            if (!response.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    response.Message,
                    Languages.Accept);
                return;
            }

            List<PointSale> myPointSales = (List<PointSale>)response.Result;
            PointSale = new ObservableCollection<PointSale>(myPointSales);
        }
    }

}
