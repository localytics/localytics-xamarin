using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using LocalyticsXamarin.Android;
using LocalyticsSample.Shared;
using Android.Gms.Common;
using Android.Util;
using LocalyticsXamarin.Shared;

namespace LocalyticsSample.Android
{

    [Activity(Label = "LocalyticsSample.Android", Icon = "@mipmap/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    [IntentFilter(new[] { Intent.ActionView },
Categories = new[] {
Intent.ActionView,
Intent.CategoryDefault,
Intent.CategoryBrowsable
},
DataScheme = "ampYOUR-APP-KEY"
)
]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            // Sample Code for Docs.
            LocalyticsSDK localytics = LocalyticsSDK.SharedInstance;
            localytics.SetOption("ll_session_timeout_seconds", 10);
            localytics.CustomerId = "Sample Customer";
            localytics.SetProfileAttribute("Sample Attribute", LocalyticsXamarin.Common.XFLLProfileScope.Application,  83);
            localytics.AddProfileAttribute("Sample Set", LocalyticsXamarin.Common.XFLLProfileScope.Organization,  321, 654 );
            localytics.TagEvent("Test Event");
            localytics.TagScreen("Test Screen");
            localytics.Upload();

            LoadApplication(new App());
        }


        protected override void OnNewIntent(Intent intent)
        {
            base.OnNewIntent(intent);
            this.Intent = intent;
        }

    }
}
