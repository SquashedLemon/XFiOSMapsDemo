# XFiOSMapsDemo
Sample repo to demostrate customizing Google Maps in an Xamarin.Froms iOS app. Custom styles can be obtained at [Snazzy Maps](https://snazzymaps.com/).

# Getting Started
You'll need an API key, more details can be found [here](https://developers.google.com/maps/documentation/ios-sdk/get-api-key)

Once you get the API key, you can replace the value of MAPS_API_KEY in AppConstants under Utils in the PCL
```
public static readonly string GOOGLE_MAPS_KEY = "<your key>";
```
App uses XLab's Autofac container for IoC and DI

#### Default Google Maps

<img src="/Screenshots/default_map_style.png" width="200" height="384" alt="default_img">

#### After applying style

<img src="/Screenshots/custom_maps_style.png" width="200" height="384" alt="styled_img">

#### Final result

<img src="/Screenshots/screencast.gif" width="200" height="384" alt="styled_gif">

