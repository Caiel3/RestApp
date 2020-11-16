using Prism.Navigation;
using ReatApp.Web.Data.Entities;
using RestApp.Common.Entities;
using RestApp.Prism.Helpers;
using System.Collections.ObjectModel;

namespace RestApp.Prism.ViewModels
{
    internal class CataloguePageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private PointSaleHelper _pointsale;
        private ObservableCollection<Catalogue> _images;
        public CataloguePageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
             _navigationService = navigationService;
            Title = Languages.Catalogue;
           
        }
        public PointSaleHelper PointSale
        {
            get => _pointsale;
            set => SetProperty(ref _pointsale, value);
        }
        public ObservableCollection<Catalogue> Images
        {
            get => _images;
            set => SetProperty(ref _images, value);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.ContainsKey("pointsale"))
            {
                PointSale = parameters.GetValue<PointSaleHelper>("pointsale");
                Title = PointSale.Name;
                Images = new ObservableCollection<Catalogue>(PointSale.CatalogueImage);
            }
        }


    }
}
