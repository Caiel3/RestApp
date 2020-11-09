using Prism.Navigation;
using RestApp.Prism.Helpers;

namespace RestApp.Prism.ViewModels
{
    internal class CataloguePageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public CataloguePageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            _navigationService = navigationService;
            Title = Languages.Catalogue;
        }
    }
}
