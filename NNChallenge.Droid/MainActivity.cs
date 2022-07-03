using System;
using Android.App;
using Android.OS;
using AndroidX.AppCompat.App;
using Android.Widget;
using Android.Content;
using System.Collections.Generic;
using NNChallenge.Constants;

namespace NNChallenge.Droid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Spinner _spinnerLocations;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_location);

            Button buttonForecast = FindViewById<Button>(Resource.Id.button_forecast);

            if (buttonForecast != null)
                buttonForecast.Click += OnForecastClick;

            _spinnerLocations = FindViewById<Spinner>(Resource.Id.spinner_location);

            var adapter = new ArrayAdapter<string>(
                this,
                Android.Resource.Layout.SimpleSpinnerDropDownItem,
                LocationConstants.LOCATIONS
            );

            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);

            if (_spinnerLocations != null)
                _spinnerLocations.Adapter = adapter;
        }

        private void OnForecastClick(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(ForecastActivity));
            intent.PutExtra(ForecastConstants.SelectedCityName, _spinnerLocations.SelectedItem?.ToString());
            StartActivity(intent);
        }
    }
}
