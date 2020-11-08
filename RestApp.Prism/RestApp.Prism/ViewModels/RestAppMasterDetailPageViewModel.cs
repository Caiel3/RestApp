using Prism.Navigation;
using RestApp.Common.Models;
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

        public RestAppMasterDetailPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
            LoadMenus();
        }
        public ObservableCollection<MenuItemViewModel> Menus { get; set; }

        private void LoadMenus()
        {
            List<Menu> menus = new List<Menu>
        {
                 new Menu
            {
                Icon = "ic_fingerprint",
                PageName = $"{nameof(LoginPage)}",
                Title = Languages.Login
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
                PageName = $"{nameof(RestaurantTabbedPage)}",
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
