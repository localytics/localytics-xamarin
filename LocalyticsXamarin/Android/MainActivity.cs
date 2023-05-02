using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using LocalyticsMaui.Android;
using LocalyticsSample.Shared;
using Firebase.Messaging;
using Firebase.Iid;
using Android.Util;
using Android.Gms.Common;
using LocalyticsMaui.Shared;

namespace LocalyticsSample.Android
{
    [Activity(Label = "LocalyticsSample.Android", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    [IntentFilter(new[] { Intent.ActionView },
              Categories = new[] { Intent.CategoryBrowsable, Intent.CategoryDefault },
              DataScheme = "ampb70c948d304fc756d8b6e63-ecd3437a-a073-11e6-c6e3-008d99911bee",
              DataHost = "testMode")]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            // Sample Code for Docs.

            LocalyticsSDK localytics = LocalyticsSDK.SharedInstance;
            Localytics.RegisterPush();
            
            localytics.SetOption("ll_session_timeout_seconds", 10);
            localytics.CustomerId = "Sample Customer";
            localytics.SetProfileAttribute("Sample Attribute", LocalyticsMaui.Common.XFLLProfileScope.Application,  83);
            localytics.AddProfileAttribute("Sample Set", LocalyticsMaui.Common.XFLLProfileScope.Organization,  321, 654 );
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
