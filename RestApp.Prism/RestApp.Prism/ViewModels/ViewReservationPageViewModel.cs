using Prism.Navigation;
using RestApp.Prism.Helpers;

namespace RestApp.Prism.ViewModels
{
    internal class ViewReservationPageViewModel : ViewModelBase
    {
        public ViewReservationPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = Languages.ViewReservation;
        }
    }
}
