using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Pins.Controls;

[assembly: ExportRenderer(typeof(VerticalSlider), typeof(Pins.iOS.Controls.VerticalSliderRenderer))]
namespace Pins.iOS.Controls
{
    public class VerticalSliderRenderer : SliderRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Slider> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.Transform = CoreGraphics.CGAffineTransform.MakeRotation(-1.571f);
            }
        }
    }
}