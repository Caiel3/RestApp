using Prism.Navigation;
using RestApp.Prism.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestApp.Prism.ViewModels
{
    class QualificationPageViewModel:ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public QualificationPageViewModel(INavigationService navigationService):base(navigationService)
        {
            _navigationService = navigationService;
            Title = Languages.Qualification;
        }
    }
}
