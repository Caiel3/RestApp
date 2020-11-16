using Newtonsoft.Json;
using Prism.Navigation;
using RestApp.Common.Helpers;
using RestApp.Common.Models;
using RestApp.Common.Responses;
using RestApp.Prism.Helpers;
using RestApp.Prism.ItemsViewModels;
using RestApp.Prism.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace RestApp.Prism.ViewModels
{
    public class RestAppMasterDetailPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private UserResponse _user;

        public RestAppMasterDetailPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
            LoadMenus();
            LoadUser();
        }
        public ObservableCollection<MenuItemViewModel> Menus { get; set; }

        public UserResponse User
        {
            get => _user;
            set => SetProperty(ref _user, value);
        }

        private void LoadUser()
        {
            if (Settings.IsLogin)
            {
                TokenResponse token = JsonConvert.DeserializeObject<TokenResponse>(Settings.Token);
                User = token.User;
            }
        }

        private void LoadMenus()
        {
            List<Menu> menus = new List<Menu>
        {
                 new Menu
            {
                Icon = "ic_fingerprint",
                PageName = $"{nameof(LoginPage)}",
                Title = Settings.IsLogin? Languages.Logout : Languages.Login
            },
            new Menu
            {
                Icon = "ic_person",
                PageName = $"{nameof(ModifyUserPage)}",
                Title = Languages.ModifyUser
            },
            new Menu
            {
                Icon = "ic_restaurant",
                PageName = $"{nameof(RestaurantPage)}",
                Title = Languages.Restaurants
            },
            new Menu
            {
                Icon = "ic_chrome_reader_mode",
                PageName = $"{nameof(ViewReservationPage)}",
                Title = Languages.ViewReservation
            },
            new Menu
            {
                Icon = "ic_add_circle",
                PageName = $"{nameof(AddPointSalePage)}",
                Title = Languages.AddPoinSale
            },
            new Menu
            {
                Icon = "ic_room",
                PageName = $"{nameof(RestaurantLocationPage)}",
                Title = Languages.RestaurantsLocation
            },
            new Menu
            {
                Icon = "ic_alarm_on",
                PageName = $"{nameof(BussinesHourPage)}",
                Title = Languages.BussinesHour
            }

        };

            Menus = new ObservableCollection<MenuItemViewModel>(
                menus.Select(m => new MenuItemViewModel(_navigationService)
                {
                    Icon = m.Icon,
                    PageName = m.PageName,
                    Title = m.Title,
                    IsLoginRequired = m.IsLoginRequired
                }).ToList());
        }
    }

}
