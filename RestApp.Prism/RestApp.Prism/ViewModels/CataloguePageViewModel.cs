using Prism.Commands;
using Prism.Navigation;
using ReatApp.Web.Data.Entities;
using RestApp.Common.Entities;
using RestApp.Prism.Helpers;
using RestApp.Prism.Views;
using System.Collections.ObjectModel;

namespace RestApp.Prism.ViewModels
{
    internal class CataloguePageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private PointSaleHelper _pointsale;
        private ObservableCollection<Catalogue> _images;
        private DelegateCommand _AddReservationCommand;
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
        public DelegateCommand ChangePasswordCommand => _AddReservationCommand ??
             (_AddReservationCommand = new DelegateCommand(AddReservation));
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
                Images = new ObservableCollection<Catalogue>(PointSale.CatalogueImage);
            }
        }

        private async void AddReservation()
        {
            NavigationParameters parameters = new NavigationParameters
            {
                {
                    "pointsale",PointSale
                }
            };
            await _navigationService.NavigateAsync(nameof(ReservationPage),parameters);
        }
    }
}
