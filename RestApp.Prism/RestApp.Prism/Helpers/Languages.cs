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
    }

}
