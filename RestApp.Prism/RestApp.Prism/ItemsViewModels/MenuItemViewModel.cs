using Prism.Commands;
using Prism.Navigation;
using RestApp.Common.Helpers;
using RestApp.Common.Models;
using RestApp.Prism.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestApp.Prism.ItemsViewModels
{
    public class MenuItemViewModel : Menu
    {
        private readonly INavigationService _navigationService;
        private DelegateCommand _selectMenuCommand;

        public MenuItemViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public DelegateCommand SelectMenuCommand => _selectMenuCommand ?? (_selectMenuCommand = new DelegateCommand(SelectMenuAsync));

        private async void SelectMenuAsync()
        {
            if (PageName == nameof(LoginPage) && Settings.IsLogin)
            {
                Settings.IsLogin = false;
                Settings.Token = null;
            }
            await _navigationService.NavigateAsync($"/{nameof(RestAppMasterDetailPage)}/NavigationPage/{PageName}");
        }
    }

}
