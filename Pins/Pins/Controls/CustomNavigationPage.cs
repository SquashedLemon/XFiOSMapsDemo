using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Pins.Controls
{
    public class CustomNavigationPage : NavigationPage
    {
        public CustomNavigationPage() : base()
        {
        }

        public CustomNavigationPage(Page root) : base(root)
        {
        }
    }
}
