using System.Collections.Generic;
using Newtonsoft.Json;

namespace NNChallenge.Model.Generated
{
    public class Forecast
    {
        [JsonProperty("forecastday")]
        public List<Forecastday> Forecastday { get; set; }
    }
}