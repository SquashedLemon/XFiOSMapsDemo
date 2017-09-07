using Pins.Utils;
using Plugin.Geolocator.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Pins.Controls
{
    public class CustomMapView : View
    {
        public static readonly BindableProperty ZoomProperty = BindableProperty.Create("Zoom", typeof(int), typeof(CustomMapView), 10, BindingMode.TwoWay);
        public int Zoom
        {
            get { return (int)GetValue(ZoomProperty); }
            set { SetValue(ZoomProperty, value); }
        }

        public static readonly BindableProperty RecenterMapProperty = BindableProperty.Create("RecenterMap", typeof(bool), typeof(CustomMapView), false, BindingMode.TwoWay);
        public bool RecenterMap
        {
            get { return (bool)GetValue(RecenterMapProperty); }
            set { SetValue(RecenterMapProperty, value); }
        }

        public static readonly BindableProperty UserInteractionEnabledProperty = BindableProperty.Create("UserInteractionEnabled", typeof(bool), typeof(CustomMapView), true, BindingMode.TwoWay);
        public bool UserInteractionEnabled
        {
            get { return (bool)GetValue(UserInteractionEnabledProperty); }
            set { SetValue(UserInteractionEnabledProperty, value); }
        }

        public static readonly BindableProperty UserLocationProperty = BindableProperty.Create("UserLocation", typeof(Position), typeof(CustomMapView), AppConstants.DEFAULT_USER_LOCATION, BindingMode.TwoWay);
        public Position UserLocation
        {
            get { return (Position)GetValue(UserLocationProperty); }
            set { SetValue(UserLocationProperty, value); }
        }

        public CustomMapView()
        {

        }
    }
}
