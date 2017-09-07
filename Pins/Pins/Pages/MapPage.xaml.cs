using Pins.Controls;
using Pins.Utils;
using Pins.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pins.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : BaseContentPage
    {
        public MapPage()
        {
            InitializeComponent();

            BindingContext = DependencyLocator.Resolve<MapViewModel>();
        }
    }
}
