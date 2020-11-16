using Newtonsoft.Json;
using Prism.Commands;
using Prism.Navigation;
using ReatApp.Web.Data.Entities;
using RestApp.Common.Helpers;
using RestApp.Common.Request;
using RestApp.Common.Responses;
using RestApp.Common.Services;
using RestApp.Prism.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace RestApp.Prism.ViewModels
{   
    public class AddQualificationPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        private bool _isRunning;
        private bool _isEnabled;
        private DelegateCommand _saveCommand;

        public AddQualificationPageViewModel(INavigationService navigationService, IApiService apiService)
            : base(navigationService)
        {
            _navigationService = navigationService;
            _apiService = apiService;
            Title = Languages.NewQualification;
            IsEnabled = true;
        }

        public DelegateCommand SaveCommand => _saveCommand ?? (_saveCommand = new DelegateCommand(SaveAsync));

        public float Qualification { get; set; }

        public string Remarks { get; set; }

        public bool IsRunning
        {
            get => _isRunning;
            set => SetProperty(ref _isRunning, value);
        }

        public bool IsEnabled
        {
            get => _isEnabled;
            set => SetProperty(ref _isEnabled, value);
        }

        private async void SaveAsync()
        {
            if (Qualification == 0)
            {
                await App.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    Languages.QualificationError,
                    Languages.Accept);
                return;
            }

            IsRunning = true;
            IsEnabled = false;

            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                IsRunning = false;
                IsEnabled = true;
                await App.Current.MainPage.DisplayAlert(Languages.Error, Languages.ConnectionError, Languages.Accept);
                return;
            }

            QualificationResponse myProduct = JsonConvert.DeserializeObject<QualificationResponse>(Settings.PointSale);
            string url = App.Current.Resources["UrlAPI"].ToString();
            QualificationRequest request = new QualificationRequest
            {
                PointSaleId = myProduct.Id,
                Remarks = Remarks,
                Score = Qualification
            };

            TokenResponse token = JsonConvert.DeserializeObject<TokenResponse>(Settings.Token);
            Response response = await _apiService.PostQualificationAsync(url, "api", "/Qualifications", request, token.Token);
            IsRunning = false;
            IsEnabled = true;

            if (!response.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert(Languages.Error, response.Message, Languages.Accept);
                return;
            }

            PointSaleHelper pointSale = (PointSaleHelper)response.Result;
            NavigationParameters parameters = new NavigationParameters
            {
                { "pointsale", pointSale }
            };

            await _navigationService.GoBackAsync(parameters);
        }
    }

}
