using System;
using CustomThings.Droid.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Widget;

[assembly: ResolutionGroupName("CustomThings")]
[assembly: ExportEffect(typeof(BorderlessEntryEffect), nameof(BorderlessEntryEffect))]
namespace CustomThings.Droid.Effects
{
    public class BorderlessEntryEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            if (Control is EditText editText)
            {
                editText.Background = null;
            }
        }

        protected override void OnDetached()
        {

        }
    }
}
