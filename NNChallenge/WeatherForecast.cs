using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NNChallenge.Constants;
using NNChallenge.Interfaces;
using NNChallenge.Model;
using NNChallenge.Model.Generated;

namespace NNChallenge
{
    public interface IWeatherForecast
    {
        public Task<IWeatherForcastVO> GetAsync(string city);
    }

    public class WeatherForecast : IWeatherForecast
    {
        public async Task<IWeatherForcastVO> GetAsync(string city)
        {
            try
            {
                var url = string.Format(ForecastConstants.ForecastApiUrlFormat, city);

                var request = (HttpWebRequest)WebRequest.Create(url);
                using var response = (HttpWebResponse)request.GetResponse();
                await using var stream = response.GetResponseStream();

                if (stream == null)
                    throw new InvalidOperationException("Api call failed");

                using var reader = new StreamReader(stream);

                var forecast = JsonConvert.DeserializeObject<Model.Generated.WeatherForecast>(await reader.ReadToEndAsync());

                var dailyForecast = forecast?.Forecast?.Forecastday;

                IEnumerable<IHourWeatherForecastVO> hourForecast =
                    dailyForecast?
                        .Select(df => df.Hour
                            .Select(h => new HourWeatherForecastVO
                            {
                                Date = DateTime.ParseExact(h.Time, "yyyy-MM-dd HH:mm", null),
                                ForecastPitureURL = h.Condition?.Icon,
                                TeperatureCelcius = h.TempC,
                                TeperatureFahrenheit = h.TempF
                            }))
                        .SelectMany(df => df);

                return new WeatherForecastVO
                {
                    City = city,
                    HourForecast = hourForecast?.ToArray()
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
    }
}
