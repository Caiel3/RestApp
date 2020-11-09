using Prism.Navigation;
using RestApp.Prism.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace RestApp.Prism.ViewModels
{
    class LocationDetailsPageViewModel:ViewModelBase
    {
        private readonly INavigationService _navigationservice;

        public LocationDetailsPageViewModel(INavigationService navigationservice):base(navigationservice)
        {
            _navigationservice = navigationservice;
            Title = Languages.Location;
        }
    }
}
