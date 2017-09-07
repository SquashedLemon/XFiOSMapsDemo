using Pins.Abstractions;
using Pins.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Pins.ViewModels
{
    public class BaseViewModel : BindableObject
    {
        protected readonly IUserDialogService userDialogService;
        protected readonly INavigationService navigationService;

        public BaseViewModel()
        {
            navigationService = DependencyLocator.Resolve<INavigationService>();
            userDialogService = DependencyLocator.Resolve<IUserDialogService>();
        }

        public virtual Task InitializeAsync(object navigationData)
        {
            return Task.FromResult(false);
        }

        public virtual Task OnAppearing()
        {
            return Task.FromResult(default(object));
        }

        public virtual Task OnDisappearing()
        {
            return Task.FromResult(default(object));
        }
    }
}
