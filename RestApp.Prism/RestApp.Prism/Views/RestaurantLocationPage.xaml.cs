using Newtonsoft.Json;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Prism.Navigation;
using RestApp.Common.Helpers;
using RestApp.Common.Responses;
using RestApp.Common.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace RestApp.Prism.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RestaurantLocationPage : ContentPage
    {
        private readonly IGeolocatorService _geolocatorService;
        private readonly IApiService _apiService;
        private readonly INavigationService _navigationService;

        public RestaurantLocationPage(IGeolocatorService geolocatorService,IApiService apiService,INavigationService navigationService)
        {
            InitializeComponent();
            _geolocatorService = geolocatorService;
            _apiService = apiService;
            _navigationService = navigationService;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            MoveMapToCurrentPositionAsync();
            LoadPointSalesAsync();
        }
        private async void LoadPointSalesAsync()
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                return;
            }

            string url = App.Current.Resources["UrlAPI"].ToString();
            Response response = await _apiService.GetListAsync<PointSaleResponse>(url, "api", "/PointsSale");

            if (!response.IsSuccess)
            {
                return;
            }

            List<PointSaleResponse> pointsales = (List<PointSaleResponse>)response.Result;
            foreach (PointSaleResponse pointsale in pointsales)
            {
                MyMap.Pins.Add(new Pin
                {
                    Address = pointsale.Address,
                    Label = pointsale.Restaurant.Name+" "+pointsale.Name,
                    Position = new Position(pointsale.Latitude, pointsale.Longitude),
                    Type = PinType.Place
                });
            }
        }

        private async void MoveMapToCurrentPositionAsync()
        {
            bool isLocationPermision = await CheckLocationPermisionsAsync();

            if (isLocationPermision)
            {
                MyMap.IsShowingUser = true;

                await _geolocatorService.GetLocationAsync();
                if (_geolocatorService.Latitude != 0 && _geolocatorService.Longitude != 0)
                {
                    Position position = new Position(
                        _geolocatorService.Latitude,
                        _geolocatorService.Longitude);
                    MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(
                        position,
                        Distance.FromKilometers(.5)));
                }
            }            
        }

        private async Task<bool> CheckLocationPermisionsAsync()
        {
            Plugin.Permissions.Abstractions.PermissionStatus permissionLocation = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);
            Plugin.Permissions.Abstractions.PermissionStatus permissionLocationAlways = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.LocationAlways);
            Plugin.Permissions.Abstractions.PermissionStatus permissionLocationWhenInUse = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.LocationWhenInUse);
            bool isLocationEnabled = permissionLocation == Plugin.Permissions.Abstractions.PermissionStatus.Granted ||
                                        permissionLocationAlways == Plugin.Permissions.Abstractions.PermissionStatus.Granted ||
                                        permissionLocationWhenInUse == Plugin.Permissions.Abstractions.PermissionStatus.Granted;
            if (isLocationEnabled)
            {
                return true;
            }

            await CrossPermissions.Current.RequestPermissionsAsync(Permission.Location);

            permissionLocation = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);
            permissionLocationAlways = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.LocationAlways);
            permissionLocationWhenInUse = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.LocationWhenInUse);
            return permissionLocation == Plugin.Permissions.Abstractions.PermissionStatus.Granted ||
                    permissionLocationAlways == Plugin.Permissions.Abstractions.PermissionStatus.Granted ||
                    permissionLocationWhenInUse == Plugin.Permissions.Abstractions.PermissionStatus.Granted;
        }

    }
}
