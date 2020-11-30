using RestApp.Common.Helpers;
using RestApp.Prism.Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace RestApp.Prism.Helpers
{
    public static class Languages
    {
        static Languages()
        {
            CultureInfo ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
            Resource.Culture = ci;
            Culture = ci.Name;
            DependencyService.Get<ILocalize>().SetLocale(ci);
        }

        public static string Culture { get; set; }
        public static string Accept => Resource.Accept;
        public static string ConnectionError => Resource.ConnectionError;
        public static string Error => Resource.Error;
        public static string Restaurants => Resource.Restaurants;
        public static string Login => Resource.Login;
        public static string Logout => Resource.Logout;
        public static string ModifyUser => Resource.ModifyUser;
        public static string ViewReservation => Resource.ViewReservation;
        public static string AddPoinSale => Resource.AddPointSale;
        public static string RestaurantsLocation => Resource.RestaurantsLocation;
        public static string BussinesHour => Resource.BussinesHour;
        public static string Email => Resource.Email;
        public static string EmailError => Resource.EmailError;
        public static string EmailPlaceHolder => Resource.EmailPlaceHolder;
        public static string Password => Resource.Password;
        public static string PasswordError => Resource.PasswordError;
        public static string PasswordPlaceHolder => Resource.PasswordPlaceHolder;
        public static string ForgotPassword => Resource.ForgotPassword;
        public static string LoginError => Resource.LoginError;
        public static string Loading => Resource.Loading;
        public static string Catalogue => Resource.Catalogue;
        public static string Qualification => Resource.Qualification;
        public static string Location => Resource.Location;
        public static string Register => Resource.Register;
        public static string Document => Resource.Document;

        public static string DocumentError => Resource.DocumentError;

        public static string DocumentPlaceHolder => Resource.DocumentPlaceHolder;

        public static string FirstName => Resource.FirstName;

        public static string FirstNameError => Resource.FirstNameError;

        public static string FirstNamePlaceHolder => Resource.FirstNamePlaceHolder;

        public static string LastName => Resource.LastName;

        public static string LastNameError => Resource.LastNameError;

        public static string LastNamePlaceHolder => Resource.LastNamePlaceHolder;

        public static string Address => Resource.Address;

        public static string AddressError => Resource.AddressError;

        public static string AddressPlaceHolder => Resource.AddressPlaceHolder;

        public static string Phone => Resource.Phone;

        public static string PhoneError => Resource.PhoneError;

        public static string PhonePlaceHolder => Resource.PhonePlaceHolder;        

        public static string PasswordConfirm => Resource.PasswordConfirm;

        public static string PasswordConfirmError1 => Resource.PasswordConfirmError1;

        public static string PasswordConfirmError2 => Resource.PasswordConfirmError2;

        public static string PasswordConfirmPlaceHolder => Resource.PasswordConfirmPlaceHolder;

        public static string Ok => Resource.Ok;

        public static string RegisterMessge => Resource.RegisterMessge;
        public static string UserType => Resource.UserType;
        public static string UserRestaurant => Resource.UserRestaurant;
        public static string UserUser => Resource.UserUser; 
        public static string UserTypePlaceHolder => Resource.UserTypePlaceHolder;
        public static string UserTypeAdminRestaurant => Resource.UserTypeAdminRestaurant;

        public static string Qualifications => Resource.Qualifications;

        public static string QualificationNumber => Resource.QualificationNumber;

        public static string Details => Resource.Details;
        public static string DescripcionEmpty => Resource.DescripcionEmpty;
        public static string Name => Resource.Name;
        public static string Descripcion => Resource.Descripcion;
        public static string PointSale => Resource.PointSale;
        public static string Reservation => Resource.Reservation;
        public static string Search => Resource.Search;
        public static string RemarksPlaceHolder => Resource.RemarksPlaceHolder;
        public static string QualificationError => Resource.QualificationError;
        public static string NewQualification => Resource.NewQualification; 
        public static string Save => Resource.Save;
        public static string LoginFirstMessage => Resource.LoginFirstMessage;
        public static string RestaurantCheck => Resource.RestaurantCheck;
        public static string PictureSource => Resource.PictureSource;
        public static string Cancel => Resource.Cancel;
        public static string FromCamera => Resource.FromCamera;
        public static string FromGallery => Resource.FromGallery;
        public static string NoCameraSupported => Resource.NoCameraSupported;
        public static string NoGallerySupported => Resource.NoGallerySupported;
        public static string ChangePassword => Resource.ChangePassword;
        public static string ChangeUserMessage => Resource.ChangeUserMessage;

        public static string ConfirmNewPassword => Resource.ConfirmNewPassword;

        public static string ConfirmNewPasswordError1 => Resource.ConfirmNewPasswordError1;

        public static string ConfirmNewPasswordError2 => Resource.ConfirmNewPasswordError2;

        public static string ConfirmNewPasswordPlaceHolder => Resource.ConfirmNewPasswordPlaceHolder;

        public static string CurrentPassword => Resource.CurrentPassword;

        public static string CurrentPasswordError => Resource.CurrentPasswordError;

        public static string CurrentPasswordPlaceHolder => Resource.CurrentPasswordPlaceHolder;

        public static string NewPassword => Resource.NewPassword;

        public static string NewPasswordError => Resource.NewPasswordError;

        public static string NewPasswordPlaceHolder => Resource.NewPasswordPlaceHolder;

        public static string Error005 => Resource.Error005;

        public static string ChangePassworrdMessage => Resource.ChangePassworrdMessage;

        public static string LoginFacebook => Resource.LoginFacebook;

        public static string ChangeOnSocialNetwork => Resource.ChangeOnSocialNetwork;
        public static string Restaurant => Resource.Restaurant;

    }

}
