using Autofac;
using Pins.Abstractions;
using Pins.Services;
using Pins.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pins.Helpers
{
    public class DependencyLocator
    {
        public static IContainer Container { get; set; }

        public static void InitVMContainer()
        {
            ContainerBuilder vmBuilder = new ContainerBuilder();

            //services
            vmBuilder.RegisterType<NavigationService>().As<INavigationService>().SingleInstance();
            vmBuilder.RegisterType<AppConstants>().SingleInstance();

            //viewmodels

            vmBuilder.Update(Container);
        }

        public static T Resolve<T>()
        {
            return Container.Resolve<T>();
        }
    }
}
