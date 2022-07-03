
using System.Threading.Tasks;
using Android.App;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Widget;
using NNChallenge.Interfaces;

namespace NNChallenge.Droid
{
    [Activity(Label = "ForecastActivity")]
    public class ForecastActivity : Activity
    {
        private string _selectedCity;
        private IWeatherForecast _weatherForcast;
        private ListView _forecastListView;
        private TextView _txtCity;
        
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_forecast);
            _selectedCity = Intent?.GetStringExtra(Constants.ForecastConstants.SelectedCityName);
            _forecastListView = FindViewById<ListView>(Resource.Id.forecastListView);
            _txtCity = FindViewById<TextView>(Resource.Id.txtCity);
            _txtCity.Text = _selectedCity;
            
            _weatherForcast = new WeatherForecast();
            var forecastVO = await _weatherForcast.GetAsync(_selectedCity);

            var adapter = new ForecastListAdapter(this, forecastVO?.HourForecast);
            _forecastListView.Adapter = adapter;
        }
    }
}
