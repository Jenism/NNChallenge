using NNChallenge.Interfaces;
using System;

namespace NNChallenge.Model
{
    public class HourWeatherForecastVO : IHourWeatherForecastVO
    {
        public DateTime Date { get; set; }
        public float TeperatureCelcius { get; set; }
        public float TeperatureFahrenheit { get; set; }
        public string ForecastPitureURL { get; set; }
    }
}