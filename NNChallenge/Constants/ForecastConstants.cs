using System;
using System.Collections.Generic;
using System.Text;

namespace NNChallenge.Constants
{
    public static class ForecastConstants
    {
        public const string SelectedCityName = "CITY_NAME";
        public const string ForecastApiUrlFormat = @"http://api.weatherapi.com/v1/forecast.json?key=898147f83a734b7dbaa95705211612&q={0}&days=3&aqi=no&alerts=no";
    }
}
