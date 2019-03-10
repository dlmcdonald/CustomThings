using System;
using Android.Content;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using CustomThings.CustomRenderers;
using CustomThings.Droid.CustomRenderers;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace CustomThings.Droid.CustomRenderers
{
    public class CustomEntryRenderer : EntryRenderer
    {
        public CustomEntryRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                //Cleanup
            }
            if (e.NewElement != null)
            {
                //Customise
                Control.Background = null;
            }
        }
    }
}
