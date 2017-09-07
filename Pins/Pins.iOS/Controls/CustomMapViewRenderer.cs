using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms.Platform.iOS;
using Pins.Controls;
using Xamarin.Forms;
using Pins.iOS.Helpers;
using Google.Maps;
using Pins.Utils;

[assembly: ExportRenderer(typeof(CustomMapView), typeof(Pins.iOS.Controls.CustomMapViewRenderer))]
namespace Pins.iOS.Controls
{
    public class CustomMapViewRenderer : ViewRenderer<CustomMapView, ExtendedMapView>
    {
        private ExtendedMapView mapView;

        protected override void OnElementChanged(ElementChangedEventArgs<CustomMapView> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || Element == null)
                return;

            var formsElement = Element as CustomMapView;

            if (Control == null)
            {
                mapView = new ExtendedMapView();
                mapView.MapStyle = MapStyle.FromJson(AppConstants.MAP_STYLE_FLAT, null);

                mapView.Delegate = new CustomMapViewDelegate();
                SetNativeControl(mapView);
            }
        }
    }
}