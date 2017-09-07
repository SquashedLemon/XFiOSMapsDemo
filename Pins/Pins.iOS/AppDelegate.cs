using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using Google.Maps;
using Autofac;
using XLabs.Ioc;
using Pins.Utils;

namespace Pins.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            MapServices.ProvideAPIKey(AppConstants.GOOGLE_MAPS_KEY);

            global::Xamarin.Forms.Forms.Init();
            Xamarin.FormsMaps.Init();

            if (!Resolver.IsSet)
            {
                SetIoc();
            }

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }

        void SetIoc()
        {
            var builder = new ContainerBuilder();

            builder.RegisterInstance(Plugin.Geolocator.CrossGeolocator.Current).As<Plugin.Geolocator.Abstractions.IGeolocator>();
            builder.RegisterInstance(Plugin.Permissions.CrossPermissions.Current).As<Plugin.Permissions.Abstractions.IPermissions>();
            builder.RegisterInstance(Plugin.Connectivity.CrossConnectivity.Current).As<Plugin.Connectivity.Abstractions.IConnectivity>();

            DependencyLocator.Container = builder.Build();
        }
    }
}
