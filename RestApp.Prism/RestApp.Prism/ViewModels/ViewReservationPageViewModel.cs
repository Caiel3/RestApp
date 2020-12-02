using Prism.Navigation;
using ReatApp.Web.Data.Entities;
using RestApp.Common.Enums;
using RestApp.Common.Helpers;
using RestApp.Common.Request;
using RestApp.Common.Responses;
using RestApp.Common.Services;
using RestApp.Prism.Helpers;

namespace RestApp.Prism.ViewModels
{
    internal class ViewReservationPageViewModel : ViewModelBase
    {
        public ViewReservationPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = Languages.ViewReservation;
            _apiService = apiService;
            LoadReservationsAsync();
        }

        public int MyProperty { get; set; }

        public bool IsRunning
        {
            get => _isRunning;
            set => SetProperty(ref _isRunning, value);
        }

        public ObservableCollection<BookingResponse> bookings
        {
            get => _bookings;
            set => SetProperty(ref _bookings, value);
        }
        private async void LoadReservationsAsync()
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await App.Current.MainPage.DisplayAlert(Languages.Error, Languages.ConnectionError, Languages.Accept);
                return;
            }
            IsRunning = true;

            string url = App.Current.Resources["UrlAPI"].ToString();
            Response response = await _apiService.GetListReservationsAsync<BookingResponse>(
                url,
                "/api",
                "/Booking",
                JsonConvert.DeserializeObject<TokenResponse>(Settings.Token).Token);

            IsRunning = false;
            if (!response.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    response.Message,
                    Languages.Accept);
                return;
            }
            _myBookings = (List<BookingResponse>)response.Result;
            bookings = new ObservableCollection<BookingResponse>(_myBookings.Select(p => new BookingResponse()
            {

                Date =p.Date,
                pointSale=p.pointSale,
                User=p.User
                
            })               
                .Where(u => u.User.Id==JsonConvert.DeserializeObject<TokenResponse>(Settings.Token).User.Id).ToList());
        }   
    }
}
