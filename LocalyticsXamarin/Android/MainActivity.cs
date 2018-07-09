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
using Firebase.Messaging;
using Firebase.Iid;
using Android.Util;
using Android.Gms.Common;
using LocalyticsXamarin.Shared;

namespace LocalyticsSample.Android
{
    [Activity(Label = "LocalyticsSample.Android", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

			if (IsPlayServicesAvailable())
            {
                var intent = new Intent(this, typeof(RegistrationIntentService));
                StartService(intent);
            }

            Localytics.SetOption("ll_gcm_sender_id", "GCMID");

            global::Xamarin.Forms.Forms.Init(this, bundle);

            LocalyticsSDK localytics = LocalyticsSDK.SharedInstance;
            Localytics.SessionTimeoutInterval = 10;
            localytics.CustomerId = "Sample Customer";

            localytics.SetProfileAttribute("Sample Attribute", LocalyticsXamarin.Common.XFLLProfileScope.Application,  83);
            localytics.AddProfileAttributesToSet("Sample Set", LocalyticsXamarin.Common.XFLLProfileScope.Organization, new long[] { 321, 654 });

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
					Console.WriteLine(GoogleApiAvailability.Instance.GetErrorString(resultCode));
                else
                {
					Console.WriteLine("This device is not supported");
                    Finish();
                }
                return false;
            }
            else
            {
				Console.WriteLine("Google Play Services is available.") ;
                return true;
            }
        }
    }
}
