using Prism.Navigation;
using RestApp.Prism.Helpers;

namespace RestApp.Prism.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        public LoginPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = Languages.Login;
        }
    }

}
