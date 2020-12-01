using Newtonsoft.Json;
using Prism.Commands;
using Prism.Navigation;
using ReatApp.Web.Data.Entities;
using RestApp.Common.Helpers;
using RestApp.Common.Request;
using RestApp.Common.Responses;
using RestApp.Common.Services;
using RestApp.Prism.Helpers;
using RestApp.Prism.Views;
using Syncfusion.SfBusyIndicator.XForms;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace RestApp.Prism.ViewModels
{
    class ReservationPageViewModel:ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        private PointSaleHelper _pointsale;
        private UserHelper_temp _user;     
        private DateTime _dateReservation;
        private TimeSpan _HourReservation;
        private UserResponse _userReservation;
        private bool _isRunning;
        private DelegateCommand _SaveReservationCommand;
        public ReservationPageViewModel(INavigationService _navigationService,IApiService apiService)
            :base(_navigationService)
        {
            _navigationService = _navigationService;
            _apiService = apiService;
            Title = Languages.Reservation;
        }
        public DelegateCommand SaveReservationCommand => _SaveReservationCommand ??
         (_SaveReservationCommand = new DelegateCommand(SaveReservationAsync));

        public DateTime DateReservation
        {
            get => _dateReservation;
            set => SetProperty(ref _dateReservation, value);
        }
        public UserResponse UserReservation
        {
            get => _userReservation;
            set => SetProperty(ref _userReservation, value);
        }
        public TimeSpan HourReservation
        {
            get => _HourReservation;
            set => SetProperty(ref _HourReservation, value);
        }
        public PointSaleHelper PointSale
        {
            get => _pointsale;
            set => SetProperty(ref _pointsale, value);
        }
        public UserHelper_temp User
        {
            get => _user;
            set => SetProperty(ref _user, value);
        }
        public bool IsRunning
        {
            get => _isRunning;
            set => SetProperty(ref _isRunning, value);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.ContainsKey("pointsale"))
            {
                PointSale = parameters.GetValue<PointSaleHelper>("pointsale");             
                Title = PointSale.Restaurant.Name+" "+ PointSale.Name;
            }
        }

        private async void SaveReservationAsync()
        {
            bool isValid = await ValidateDataAsync();
            if (!isValid)
            {
                return;
            }
            IsRunning = true;

            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                IsRunning = false;                
                await App.Current.MainPage.DisplayAlert(Languages.Error, Languages.ConnectionError, Languages.Accept);
                return;
            }
            TokenResponse token = JsonConvert.DeserializeObject<TokenResponse>(Settings.Token);
            UserReservation = token.User;
            DateTime dateReservation = DateReservation+HourReservation;
            string url = App.Current.Resources["UrlAPI"].ToString();
            ReservationRequest request = new ReservationRequest
            {
                User = UserReservation,
                pointSale=PointSale,
                Date= dateReservation
            };
                       
            Response response = await _apiService.PostReservationsAsync(url, "api", "/Booking", request, token.Token);
            IsRunning = false;          

            if (!response.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert(Languages.Error, response.Message, Languages.Accept);
                return;
            }
            await App.Current.MainPage.DisplayAlert(Languages.Success, Languages.ReservationSuccess, Languages.Accept);            
        }

        private async Task<bool> ValidateDataAsync()
        {
            if (HourReservation>PointSale.HourStart.TimeOfDay && HourReservation < PointSale.HourFinish.TimeOfDay)
            {
                await App.Current.MainPage.DisplayAlert(Languages.Error, Languages.HourOutRange, Languages.Accept);
                return false;
            }
            if (DateReservation < System.DateTime.Now)
            {
                await App.Current.MainPage.DisplayAlert(Languages.Error, Languages.DateAnt, Languages.Accept);
                return false;
            }

            return true;
        }
    }
}
