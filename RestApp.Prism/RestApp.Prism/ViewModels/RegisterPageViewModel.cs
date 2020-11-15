using FFImageLoading.Work;
using Prism.Commands;
using Prism.Navigation;
using RestApp.Common.Enums;
using RestApp.Common.Request;
using RestApp.Common.Responses;
using RestApp.Common.Services;
using RestApp.Prism.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace RestApp.Prism.ViewModels
{
 
    public class RegisterPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IRegexHelper _regexHelper;
        private readonly IApiService _apiService;
        private ImageSource _image;
        private UserRequest _user;                
        private bool _isRunning;
        private bool _isEnabled;
        private UserType _userTypes;
        private DelegateCommand _registerCommand;

        public RegisterPageViewModel(
            INavigationService navigationService,
            IRegexHelper regexHelper,
            IApiService apiService)
            : base(navigationService)
        {
            _navigationService = navigationService;
            _regexHelper = regexHelper;
            _apiService = apiService;
            Title = Languages.Register;           
            IsEnabled = true;
            User = new UserRequest();
          
        }        
        
        public List<string> UserTypes
        {
            get
            {
                return new List<string> { Languages.UserType, Languages.UserTypeAdminRestaurant };
            }
        }

        public DelegateCommand RegisterCommand => _registerCommand ?? (_registerCommand = new DelegateCommand(RegisterAsync));

        public ImageSource Image
        {
            get => _image;
            set => SetProperty(ref _image, value);
        }

        public UserRequest User
        {
            get => _user;
            set => SetProperty(ref _user, value);
        }

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

        
        private async void RegisterAsync()
        {
            bool isValid = await ValidateDataAsync();
            if (!isValid)
            {
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
        }

        public List<string> BreedNames
        {
            get
            {
                return new List<string> { "Border Collie", "Labrador Retriever", "Pit Bull" };
            }
        }
     

        private async Task<bool> ValidateDataAsync()
        {
            if (string.IsNullOrEmpty(User.Document))
            {
                await App.Current.MainPage.DisplayAlert(Languages.Error, Languages.DocumentError, Languages.Accept);
                return false;
            }

            if (string.IsNullOrEmpty(User.FirstName))
            {
                await App.Current.MainPage.DisplayAlert(Languages.Error, Languages.FirstNameError, Languages.Accept);
                return false;
            }

            if (string.IsNullOrEmpty(User.LastName))
            {
                await App.Current.MainPage.DisplayAlert(Languages.Error, Languages.LastNameError, Languages.Accept);
                return false;
            }

            if (string.IsNullOrEmpty(User.Address))
            {
                await App.Current.MainPage.DisplayAlert(Languages.Error, Languages.AddressError, Languages.Accept);
                return false;
            }

            if (string.IsNullOrEmpty(User.Email) || !_regexHelper.IsValidEmail(User.Email))
            {
                await App.Current.MainPage.DisplayAlert(Languages.Error, Languages.EmailError, Languages.Accept);
                return false;
            }

            if (string.IsNullOrEmpty(User.Phone))
            {
                await App.Current.MainPage.DisplayAlert(Languages.Error, Languages.PhoneError, Languages.Accept);
                return false;
            }

       

            if (string.IsNullOrEmpty(User.Password) || User.Password?.Length < 6)
            {
                await App.Current.MainPage.DisplayAlert(Languages.Error, Languages.PasswordError, Languages.Accept);
                return false;
            }

            if (string.IsNullOrEmpty(User.PasswordConfirm))
            {
                await App.Current.MainPage.DisplayAlert(Languages.Error, Languages.PasswordConfirmError1, Languages.Accept);
                return false;
            }

            if (User.Password != User.PasswordConfirm)
            {
                await App.Current.MainPage.DisplayAlert(Languages.Error, Languages.PasswordConfirmError2, Languages.Accept);
                return false;
            }

            return true;
        }
    }


}
