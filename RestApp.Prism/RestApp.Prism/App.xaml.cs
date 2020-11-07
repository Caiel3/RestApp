using Prism;
using Prism.Ioc;
using RestApp.Prism.ViewModels;
using RestApp.Prism.Views;
using Xamarin.Essentials.Interfaces;
using Xamarin.Essentials.Implementation;
using Xamarin.Forms;
using RestApp.Common.Services;
using Syncfusion.Licensing;

namespace RestApp.Prism
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            SyncfusionLicenseProvider.RegisterLicense("MzQ4MDEyQDMxMzgyZTMzMmUzMG8zNlRQQmZGUHFVK1RGNnhSL2owcHZsZGl4NUxPclArbm9TWXZlWGZuWEE9");
            InitializeComponent();

           await NavigationService.NavigateAsync($"{nameof(RestAppMasterDetailPage)}/NavigationPage/{nameof(RestaurantPage)}");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();
            containerRegistry.Register<IApiService, ApiService>();
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<RestaurantPage, RestaurantPageViewModel>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<ViewReservationPage, ViewReservationPageViewModel>();
            containerRegistry.RegisterForNavigation<AddPointSalePage, AddPointSalePageViewModel>();
            containerRegistry.RegisterForNavigation<RestaurantLocationPage, RestaurantLocationPageViewModel>();
            containerRegistry.RegisterForNavigation<BussinesHourPage, BussinesHourPageViewModel>();
            containerRegistry.RegisterForNavigation<RestAppMasterDetailPage, RestAppMasterDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<ModifyUserPage, ModifyUserPageViewModel>();
        }
    }
}
