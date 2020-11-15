using Prism.Navigation;
using RestApp.Common.Entities;
using RestApp.Prism.Helpers;
using System.Collections.ObjectModel;

namespace RestApp.Prism.ViewModels
{
    internal class CataloguePageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private ObservableCollection<Catalogue> _images;
        public CataloguePageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            _navigationService = navigationService;
            Title = Languages.Catalogue;
        }
        public ObservableCollection<Catalogue> Images
        {
            get => _images;
            set => SetProperty(ref _images, value);
        }

    }
}
