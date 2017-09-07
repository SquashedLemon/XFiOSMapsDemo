using Pins.Abstractions;
using Pins.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Pins
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            DependencyLocator.InitVMContainer();
        }

        private Task InitNavigation()
        {
            var navigationService = DependencyLocator.Resolve<INavigationService>();
            return navigationService.InitializeAsync();
        }

        protected override async void OnStart()
        {
            await InitNavigation();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
