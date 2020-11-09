using Prism.Navigation;
using RestApp.Prism.Helpers;

namespace RestApp.Prism.ViewModels
{
    internal class BussinesHourPageViewModel : ViewModelBase
    {
        public BussinesHourPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = Languages.BussinesHour;
        }
    }
}
