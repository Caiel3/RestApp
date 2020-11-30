using Prism.Commands;
using Prism.Navigation;
using ReatApp.Web.Data.Entities;
using RestApp.Common.Entities;
using RestApp.Common.Responses;
using RestApp.Common.Services;
using RestApp.Prism.Helpers;
using RestApp.Prism.ItemsViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Essentials;

namespace RestApp.Prism.ViewModels
{
    
    public class RestaurantPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        private ObservableCollection<PointSaleHelper> _pointsale;
        private bool _isRunning;
        private string _search;
        private List<PointSaleHelper> _myRestaurants;
        private DelegateCommand _searchCommand;
        private ObservableCollection<RestaurantItemViewModel> _pointsSales;

        public RestaurantPageViewModel(INavigationService navigationService, IApiService apiService) : base(navigationService)
        {
            _navigationService = navigationService;
            _apiService = apiService;
            Title = Languages.Restaurants;
            LoadPointsSalesAsync();           
        }
        public DelegateCommand SearchCommand => _searchCommand ?? (_searchCommand = new DelegateCommand(ShowRestaurants));
        public string Search
        {
            get => _search;
            set
            {
                SetProperty(ref _search, value);
                ShowRestaurants();
            }
        }
        public ObservableCollection<RestaurantItemViewModel> PointSale
        {
            get => _pointsSales;
            set => SetProperty(ref _pointsSales, value);
        }


        public bool IsRunning
        {
            get => _isRunning;
            set => SetProperty(ref _isRunning, value);
        }

        public ObservableCollection<PointSaleHelper> PointSales
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
            IsRunning = true;

            string url = App.Current.Resources["UrlAPI"].ToString();
            Response response = await _apiService.GetListAsync<PointSaleHelper>(
                url,
                "/api",
                "/PointsSale");

            IsRunning = false;
            if (!response.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    response.Message,
                    Languages.Accept);
                return;
            }
            _myRestaurants = (List<PointSaleHelper>)response.Result;
            ShowRestaurants(); 
        }
        private void ShowRestaurants()
        {
            if (string.IsNullOrEmpty(Search))
            
            {
                PointSale = new ObservableCollection<RestaurantItemViewModel>(_myRestaurants.Select(p => new RestaurantItemViewModel(_navigationService)
                {
                   
                    Description = string.IsNullOrEmpty(p.Description)?Languages.DescripcionEmpty: p.Description,
                    Id = p.Id,                   
                    Name = p.Name,
                    CatalogueImage=p.CatalogueImage,
                    Qualifications = p.Qualifications,
                    Restaurant=p.Restaurant
                    
                })
                .ToList());

            }
            else
            {
                PointSale = new ObservableCollection<RestaurantItemViewModel>(_myRestaurants.Select(p => new RestaurantItemViewModel(_navigationService)
                {

                    Description = string.IsNullOrEmpty(p.Description) ? Languages.DescripcionEmpty : p.Description,
                    Id = p.Id,
                    Name = p.Name,
                    CatalogueImage = p.CatalogueImage,
                    Qualifications=p.Qualifications,
                    Restaurant = p.Restaurant
                })
                .Where(p => p.Name.ToLower().Contains(Search.ToLower()))
                .ToList());

            }
        }
    }

}
