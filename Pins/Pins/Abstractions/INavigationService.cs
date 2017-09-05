using Pins.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pins.Abstractions
{
    public interface INavigationService
    {
        BaseViewModel PreviousPageViewModel { get; }
        Task InitializeAsync();
        Task NavigateToAsync<TViewModel>() where TViewModel : BaseViewModel;
        Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : BaseViewModel;
        Task RemoveLastFromBackStackAsync();
        Task RemoveBackStackAsync();
        Task PopAsync();
    }
}
