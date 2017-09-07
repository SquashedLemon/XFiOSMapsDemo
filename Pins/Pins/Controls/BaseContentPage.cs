using System;
using Pins.ViewModels;
using Xamarin.Forms;

namespace Pins.Controls
{
    public class BaseContentPage : ContentPage
    {
        public BaseContentPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await (BindingContext as BaseViewModel).OnAppearing();
        }

        protected override async void OnDisappearing()
        {
            base.OnAppearing();
            await (BindingContext as BaseViewModel).OnDisappearing();
        }
    }
}