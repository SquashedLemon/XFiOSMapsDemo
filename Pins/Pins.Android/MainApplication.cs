using System;

using Android.App;
using Android.OS;
using Android.Runtime;
using Plugin.CurrentActivity;
using XLabs.Ioc;
using Pins.Helpers;
using Autofac;

namespace Pins.Droid
{
	//You can specify additional application information in this attribute
    [Application]
    public class MainApplication : Application, Application.IActivityLifecycleCallbacks
    {
        public MainApplication(IntPtr handle, JniHandleOwnership transer)
          :base(handle, transer)
        {
            if (!Resolver.IsSet)
            {
                SetIoc();
            }
        }

        public override void OnCreate()
        {
            base.OnCreate();
            RegisterActivityLifecycleCallbacks(this);
            //A great place to initialize Xamarin.Insights and Dependency Services!
        }

        public override void OnTerminate()
        {
            base.OnTerminate();
            UnregisterActivityLifecycleCallbacks(this);
        }

        public void OnActivityCreated(Activity activity, Bundle savedInstanceState)
        {
            CrossCurrentActivity.Current.Activity = activity;
        }

        public void OnActivityDestroyed(Activity activity)
        {
        }

        public void OnActivityPaused(Activity activity)
        {
        }

        public void OnActivityResumed(Activity activity)
        {
            CrossCurrentActivity.Current.Activity = activity;
        }

        public void OnActivitySaveInstanceState(Activity activity, Bundle outState)
        {
        }

        public void OnActivityStarted(Activity activity)
        {
            CrossCurrentActivity.Current.Activity = activity;
        }

        public void OnActivityStopped(Activity activity)
        {
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