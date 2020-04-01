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
using LocalyticsXamarin.Shared;

using Android.Gms.Common;
using Firebase.Iid;
using Android.Util;

namespace LocalyticsSample.Android
{
    [Activity(Label = "LocalyticsSample.Android", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            var refreshedToken = FirebaseInstanceId.Instance.Token;
            IsPlayServicesAvailable();
            Log.Debug("FIREBASE", "Refreshed token: " + refreshedToken);

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

        public bool IsPlayServicesAvailable()
        {
            int resultCode = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(this);
            if (resultCode != ConnectionResult.Success)
            {
                if (GoogleApiAvailability.Instance.IsUserResolvableError(resultCode))
                    Log.Debug("FIREBASE", GoogleApiAvailability.Instance.GetErrorString(resultCode));
                else
                {
                    Finish();
                }
                return false;
            }
            else
            {
                Log.Debug("FIREBASE", "Google Play Services is available.");
                return true;
            }
        }
    }
}
