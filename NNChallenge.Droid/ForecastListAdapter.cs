using Android.Views;
using Android.Widget;
using System.Collections.Generic;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using NNChallenge.Interfaces;

namespace NNChallenge.Droid
{
    public class ForecastListAdapter : BaseAdapter<IHourWeatherForecastVO>
    {
        private readonly Context _context;
        readonly IHourWeatherForecastVO[] _items;
        private IImageCache _imageCache;

        public ForecastListAdapter(Context context, IHourWeatherForecastVO[] items)
        {
            _context = context;
            _items = items;
            _imageCache = new ImageCache();
        }

        public override IHourWeatherForecastVO this[int position] => _items[position];

        public override int Count => _items.Length;

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var row = convertView ?? LayoutInflater.From(_context).Inflate(Resource.Layout.forecast_row, null, false);

            var imgWeatherIcon = row.FindViewById<ImageView>(Resource.Id.imgWeatherIcon);
            var image =
                _imageCache.Get($"http:{_items[position].ForecastPitureURL}");

            var bitmap = BitmapFactory.DecodeByteArray(image, 0, image.Length);

            imgWeatherIcon.SetImageBitmap(bitmap);

            var txtTemperature = row.FindViewById<TextView>(Resource.Id.txtTemperature);
            txtTemperature.Text =
                $"{_items[position].TeperatureCelcius}C / {_items[position].TeperatureCelcius}F";

            var txtDate = row.FindViewById<TextView>(Resource.Id.txtDate);
            txtDate.Text = _items[position].Date.ToString("D");

            var txtTime = row.FindViewById<TextView>(Resource.Id.txtTime);
            txtTime.Text = _items[position].Date.ToString("t");

            return row;

        }
    }
}