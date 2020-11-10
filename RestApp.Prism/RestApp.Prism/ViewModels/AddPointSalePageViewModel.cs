using Prism.Navigation;
using RestApp.Prism.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestApp.Prism.ViewModels
{
    class AddPointSalePageViewModel : ViewModelBase
    {
        public AddPointSalePageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = Languages.AddPoinSale;
        }
    }
}
