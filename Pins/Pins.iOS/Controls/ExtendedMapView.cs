using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Google.Maps;
using CoreLocation;
using CoreAnimation;
using Xamarin.Forms.Platform.iOS;

namespace Pins.iOS.Controls
{
    public class ExtendedMapView : MapView
    {
        public CLLocationCoordinate2D UserPositon { get; set; }
        Marker UserPositionMarker;
        Dictionary<string, Marker> mapMarkers;

        public ExtendedMapView()
        {
            mapMarkers = new Dictionary<string, Marker>();
        }

        public void DrawPath(CLLocationCoordinate2D desPosition)
        {
            
        }

        double CalculateDistance(double lat1, double lon1, double lat2, double lon2)
        {
            double R = 6372.8; // In kilometers
            double dLat = Math.PI * (lat2 - lat1) / 180.0;
            double dLon = Math.PI * (lon2 - lon1) / 180.0;
            lat1 = Math.PI * (lat1) / 180.0;
            lat2 = Math.PI * (lat2) / 180.0;

            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) + Math.Sin(dLon / 2) * Math.Sin(dLon / 2) * Math.Cos(lat1) * Math.Cos(lat2);
            double c = 2 * Math.Asin(Math.Sqrt(a));
            return (R * c) * 1000; //meters
        }

        string DetermineTravelMode(CLLocationCoordinate2D start, CLLocationCoordinate2D stop)
        {
            var distace = CalculateDistance(start.Latitude, start.Longitude, stop.Latitude, stop.Longitude);
            if (distace > 1000)
                return "driving";
            else if (distace > 250)
                return "bicycling";
            else
                return "walking";
        }

        public void UpdateUserPosition(double newLatitude, double newLongitude)
        {
            if (UserPositon.Latitude != newLatitude || UserPositon.Longitude != newLongitude)
            {
                UserPositon = new CLLocationCoordinate2D(newLatitude, newLongitude);
                if (UserPositionMarker == null)
                    UserPositionMarker = new Marker();

                UserPositionMarker.Map = null;
                UserPositionMarker.Position = UserPositon;
                UserPositionMarker.Map = this;
            }
        }

        public void RecenterToUserPosition()
        {
            RecenterToPosition(UserPositon);
        }

        public void RecenterToPosition(CLLocationCoordinate2D position)
        {
            CATransaction.Begin();
            Foundation.NSNumber nsobj = Foundation.NSNumber.FromFloat(1.5f);
            CATransaction.SetValueForKey(nsobj, CATransaction.AnimationDurationKey);
            this.Animate(CameraPosition.FromCamera(position.Latitude, position.Longitude, Camera.Zoom));
            CATransaction.Commit();
        }

        public void FitUserAndMarker(CLLocationCoordinate2D desPosition)
        {
            CoordinateBounds mapBounds = new CoordinateBounds(UserPositon, desPosition);
            this.Animate(CameraUpdate.FitBounds(mapBounds, new UIEdgeInsets(50, 35, 50, 35)));
        }

        public void AddMarker(string markerId, string title, CLLocationCoordinate2D markerPosition)
        {
            if (mapMarkers.ContainsKey(markerId))
            {
                //Marker Id must be unique
                return;
            }

            Marker newMarker = new Marker() { Position = markerPosition, Title = title };
            mapMarkers[markerId] = newMarker;
            newMarker.Map = this;
        }
    }
}