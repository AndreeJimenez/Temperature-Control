using System;
using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Widget;
using TemperatureControlApp.Droid.Renders;
using TemperatureControlApp.Models;
using TemperatureControlApp.Renders;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.Android;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomMap), typeof(CustomMapRenderer))]
namespace TemperatureControlApp.Droid.Renders
{
    public class CustomMapRenderer : MapRenderer, GoogleMap.IInfoWindowAdapter
    {
        TemperatureModel Temperature;

        public CustomMapRenderer(Context context) : base(context) { }

        protected override void OnElementChanged(ElementChangedEventArgs<Map> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                this.Temperature = ((CustomMap)e.NewElement).Temperature;
            }
        }

        protected override void OnMapReady(GoogleMap map)
        {
            base.OnMapReady(map);

            NativeMap.SetInfoWindowAdapter(this);
        }

        protected override MarkerOptions CreateMarker(Pin pin)
        {
            var marker = new MarkerOptions();
            marker.SetPosition(new LatLng(Temperature.Latitude, Temperature.Longitude));
            marker.SetTitle(Temperature.Comments);
            return marker;
        }

        public Android.Views.View GetInfoContents(Marker marker)
        {
            var inflater = Android.App.Application.Context.GetSystemService(Context.LayoutInflaterService) as Android.Views.LayoutInflater;
            if (inflater != null)
            {
                Android.Views.View view;
                view = inflater.Inflate(Resource.Layout.MarkerWindow, null);
                var infoComments = view.FindViewById<TextView>(Resource.Id.MarkerWindowComments);

                if (infoComments != null) infoComments.Text = Temperature.Comments;

                return view;
            }
            return null;
        }

        public Android.Views.View GetInfoWindow(Marker marker)
        {
            return null;
        }
    }
}