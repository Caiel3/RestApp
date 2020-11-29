using Prism.Commands;
using Prism.Navigation;
using ReatApp.Web.Data.Entities;
using RestApp.Common.Helpers;
using RestApp.Common.Responses;
using RestApp.Prism.Helpers;
using RestApp.Prism.ItemsViewModels;
using RestApp.Prism.Views;
using System.Collections.ObjectModel;
using System.Linq;


namespace RestApp.Prism.ViewModels
{
    public class QualificationPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private PointSaleHelper _pointsale;
        private bool _isRunning;
        private ObservableCollection<QualificationItemViewModel> _qualifications;
        private DelegateCommand _addQualificationCommand;

        public QualificationPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            _navigationService = navigationService;
            Title = Languages.Qualifications;
        }

        public bool IsRunning
        {
            get => _isRunning;
            set => SetProperty(ref _isRunning, value);
        }
        public DelegateCommand AddQualificationCommand => _addQualificationCommand ?? (_addQualificationCommand = new DelegateCommand(AddQualificationAsync));

        public ObservableCollection<QualificationItemViewModel> Qualifications
        {
            get => _qualifications;
            set => SetProperty(ref _qualifications, value);
        }

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            base.OnNavigatedFrom(parameters);

            if (parameters.ContainsKey("pointsale"))
            {
                LoadPointSale(parameters);
            }
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.ContainsKey("pointsale"))
            {
                LoadPointSale(parameters);
            }
        }

        private void LoadPointSale(INavigationParameters parameters)
        {
            IsRunning = true;
            _pointsale = parameters.GetValue<PointSaleHelper>("pointsale");
            if (_pointsale.Qualifications != null)
            {
                Qualifications = new ObservableCollection<QualificationItemViewModel>(
                    _pointsale.Qualifications.Select(q => new QualificationItemViewModel(_navigationService)
                    {
                        Date = q.Date,
                        Id = q.Id,
                        Remarks = q.Remarks,
                        Score = q.Score
                    })
                    .OrderByDescending(q => q.Date)
                    .ToList());
            }

            IsRunning = false;
        }
        private async void AddQualificationAsync()
        {
            if (Settings.IsLogin)
            {
                await _navigationService.NavigateAsync($"{nameof(AddQualificationPage)}");
            }
            else
            {
                await App.Current.MainPage.DisplayAlert(Languages.Error, Languages.LoginFirstMessage, Languages.Accept);
                NavigationParameters parameters = new NavigationParameters
                {
                    { "pageReturn", nameof(AddQualificationPage) }
                };

                await _navigationService.NavigateAsync($"/{nameof(RestAppMasterDetailPage)}/NavigationPage/{nameof(LoginPage)}", parameters);
            }
        }
    }
}
