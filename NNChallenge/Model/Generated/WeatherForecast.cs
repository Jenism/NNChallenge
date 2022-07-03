using Newtonsoft.Json;

namespace NNChallenge.Model.Generated
{
    public class WeatherForecast
    {
        [JsonProperty("location")]
        public Location Location { get; set; }

        [JsonProperty("current")]
        public Current Current { get; set; }

        [JsonProperty("forecast")]
        public Forecast Forecast { get; set; }
    }

}

