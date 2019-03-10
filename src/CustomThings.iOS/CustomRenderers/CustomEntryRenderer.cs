using System;
using Xamarin.Forms;
using CustomThings.iOS.CustomRenderers;
using CustomThings.CustomRenderers;
using Xamarin.Forms.Platform.iOS;
using UIKit;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace CustomThings.iOS.CustomRenderers
{
    public class CustomEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                //cleanup
            }
            if (e.NewElement != null)
            {
                Control.BorderStyle = UITextBorderStyle.None;
            }
        }
    }
}
