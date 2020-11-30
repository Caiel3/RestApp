using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestApp.Common.Helpers
{
    public static class Settings
    {
        private const string _token = "token";
        private const string _isLogin = "isLogin";
        private const string _isRestaurant = "isRestaurant";
        private static readonly string _stringDefault = string.Empty;
        private const string _PointSale = "pointsale";
        private static readonly bool _boolDefault = false;

        private static ISettings AppSettings => CrossSettings.Current;

        public static string Token
        {
            get => AppSettings.GetValueOrDefault(_token, _stringDefault);
            set => AppSettings.AddOrUpdateValue(_token, value);
        }

        public static bool IsLogin
        {
            get => AppSettings.GetValueOrDefault(_isLogin, _boolDefault);
            set => AppSettings.AddOrUpdateValue(_isLogin, value);
        }
        public static bool IsRestaurant
        {
            get => AppSettings.GetValueOrDefault(_isRestaurant, _boolDefault);
            set => AppSettings.AddOrUpdateValue(_isRestaurant, value);
        }
        public static string PointSale
        {
            get => AppSettings.GetValueOrDefault(_PointSale, _stringDefault);
            set => AppSettings.AddOrUpdateValue(_PointSale, value);
        }

    }

}
