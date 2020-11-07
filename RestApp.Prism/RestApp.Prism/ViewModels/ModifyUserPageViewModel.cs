using Prism.Navigation;
using RestApp.Prism.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestApp.Prism.ViewModels
{
    public class ModifyUserPageViewModel:ViewModelBase
    {
        public ModifyUserPageViewModel(INavigationService navigationService) 
            : base(navigationService)
        {
            Title = Languages.ModifyUser;
        }
    }
}
