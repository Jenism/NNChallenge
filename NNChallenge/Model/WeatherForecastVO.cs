using NNChallenge.Interfaces;

namespace NNChallenge.Model
{
    public class WeatherForecastVO : IWeatherForcastVO
    {
        public string City { get; set; }
        public IHourWeatherForecastVO[] HourForecast { get; set; }
    }
}