using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using CustomThings.iOS.Effects;

[assembly: ResolutionGroupName("CustomThings")]
[assembly: ExportEffect(typeof(BorderlessEntryEffect), "BorderlessEntryEffect")]
namespace CustomThings.iOS.Effects
{
    public class BorderlessEntryEffect : PlatformEffect
    {

        protected override void OnAttached()
        {
            if (Control is UITextField entry)
            {
                entry.BorderStyle = UITextBorderStyle.None;
            }
        }

        protected override void OnDetached()
        {

        }
    }
}
