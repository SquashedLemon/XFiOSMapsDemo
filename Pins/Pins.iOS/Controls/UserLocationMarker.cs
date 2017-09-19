using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Pins.iOS.Helpers;

namespace Pins.iOS.Controls
{
    public class UserLocationMarker : UIView
    {
        public UserLocationMarker() : base(new CoreGraphics.CGRect(0, 0, 30, 30))
        {
            var innerCircle = new UIView(new CoreGraphics.CGRect(10, 10, 10, 10));
            innerCircle.Layer.CornerRadius = 5;
            innerCircle.Layer.BackgroundColor = OSAppConstants.USER_MARKER_CGCOLOR;
            AddSubview(innerCircle);

            var outerDisk = new UIView(new CoreGraphics.CGRect(0, 0, 30, 30));
            outerDisk.Layer.CornerRadius = 15;
            outerDisk.Layer.BackgroundColor = OSAppConstants.USER_MARKER_LIGHT_CGCOLOR;

            var scalingAnimation = new CoreAnimation.CABasicAnimation();
            scalingAnimation.KeyPath = "transform.scale";
            scalingAnimation.Duration = 1.5;
            scalingAnimation.RepeatCount = float.MaxValue;
            scalingAnimation.AutoReverses = true;
            scalingAnimation.From = NSNumber.FromFloat(0.5f);
            scalingAnimation.To = NSNumber.FromFloat(1.0f);
            outerDisk.Layer.AddAnimation(scalingAnimation, "scale");
            AddSubview(outerDisk);
            
            //BackgroundColor = UIColor.FromRGBA(1, 1, 1, 0.5f);
        }
    }
}