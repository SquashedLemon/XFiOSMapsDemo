using Pins.Utils;
using Plugin.Geolocator.Abstractions;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Pins.ViewModels
{
    public class MapViewModel : BaseViewModel
    {
        IGeolocator geolocator;
        IPermissions permissions;

        public MapViewModel(IGeolocator _geolocator, IPermissions _permissions)
        {
            geolocator = _geolocator;
            permissions = _permissions;
        }

        private Position _UserLocation = AppConstants.DEFAULT_USER_LOCATION;
        public Position UserLocation
        {
            get { return _UserLocation; }
            set { _UserLocation = value; OnPropertyChanged("UserLocation"); }
        }

        public override async Task OnAppearing()
        {
            //permissions
            PermissionStatus status = await permissions.CheckPermissionStatusAsync(Permission.Location);
            if(status != PermissionStatus.Granted)
            {
                var permissionsStatus= await permissions.RequestPermissionsAsync(Permission.Location);
                if(permissionsStatus.ContainsKey(Permission.Location) && permissionsStatus[Permission.Location] == PermissionStatus.Granted)
                {
                    await GetPositionAsync();
                }
                else
                {
                    //popup
                    return;
                }
            }
        }

        async Task GetPositionAsync()
        {
            Position userPosition = null;

            try
            {
                userPosition = await geolocator.GetPositionAsync();
            }
            catch (Exception ex)
            {
                //toast to user?
            }

            if (userPosition != null)
            {
                UserLocation = userPosition;
            }
        }
    }
}
