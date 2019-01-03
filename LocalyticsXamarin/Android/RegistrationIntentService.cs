using System;
using Android.App;
using Android.Content;
using Android.Gms.Gcm;
using Android.Gms.Iid;
using Android.Util;
using System.Diagnostics;
using LocalyticsXamarin.Android;
using Android.Gms.Common;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Net.Security;
using static Android.Manifest;
using Java.Security;

namespace LocalyticsXamarin.Shared
{
    [Service(Exported = false)]
    class RegistrationIntentService : IntentService
    {
        private static string GCMAuthorizedEntity = "";
        static object locker = new object();
        public static void AutoIntegrationWithGCMRegisteration(string gcmProjectNumber, string packageName, string appKey, Application app)
        {
            RegistrationIntentService.GCMAuthorizedEntity = gcmProjectNumber;
            Localytics.SetOption("ll_package_name", packageName);
            Localytics.SetOption("ll_test_mode_url_scheme", "amp" + appKey);
            Localytics.SetOption("ll_gcm_push_services_enabled", false);
            Localytics.SetOption("ll_fcm_push_services_enabled", false);
            Localytics.SetOption("ll_gcm_sender_id", gcmProjectNumber);
            Localytics.SetOption("ll_push_tracking_activity_enabled", true);
            Java.Lang.String str = new Java.Lang.String(appKey);
            LocalyticsSDK.SharedInstance.SetOption("ll_app_key", str);
            Localytics.AutoIntegrate(app);

            // Dont register Push. Localytics assumes FCM, if it's in the class Path.
            //Localytics.RegisterPush(); //"YOUR_GCM_PROJECT_NUMBER");
            string playServicesError;
            if (IsPlayServicesAvailable(out playServicesError, app))
            {
                var intent = new Intent(app, typeof(RegistrationIntentService));
                app.StartService(intent);
                Console.WriteLine("LocalyticsRegisterPushGCM: Should Receive Push Token Shortly ");
            }
            else
            {
                Console.WriteLine("LocalyticsRegisterPushGCM: Play Service Response " + playServicesError);
            }
        }
        public static bool IsPlayServicesAvailable(out string txt, Context context)
        {
            bool retVal = false;
            int resultCode = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(context);
            if (resultCode != ConnectionResult.Success)
            {
                if (GoogleApiAvailability.Instance.IsUserResolvableError(resultCode))
                {
                    txt = GoogleApiAvailability.Instance.GetErrorString(resultCode);
                    retVal = true; // User Resolvable Error.
                }
                else
                {
                    txt = "This device is not supported";
                }
            }
            else
            {
                txt = "Google Play Services is available.";
                retVal = true;
            }
            Console.WriteLine(txt);
            return retVal;
        }
        public RegistrationIntentService() : base("RegistrationIntentService") {
		}

        protected override void OnHandleIntent(Intent intent)
        {
			Debug.WriteLine("RegistrationIntentService:OnHandleIntent");
            try
            {
                if (GCMAuthorizedEntity.Length == 0)
                {
                    Log.Error("LocalyticsRegistrationIntentService", "No GCM Authorized Entity Set.");
                    throw new Exception("No GCM Authorized Entity Set.");
                }
                lock (locker)
                {
                    var instanceID = InstanceID.GetInstance(this);
                    var token = instanceID.GetToken(
                        GCMAuthorizedEntity, GoogleCloudMessaging.InstanceIdScope, null);

                    Log.Info("LocalyticsRegistrationIntentService", "GCM Registration Token: " + token);
                    SendRegistrationToAppServer(token);
                }
            }
            catch (Exception e)
            {
				Console.WriteLine("Exception " + e.Message);
                Log.Debug("LocalyticsRegistrationIntentService", "Failed to get a registration token " + e.Message);
                return;
            }
        }

        void SendRegistrationToAppServer(string token)
        {
            Localytics.SetOption("ll_gcm_sender_id", RegistrationIntentService.GCMAuthorizedEntity);
            Log.Info("LocalyticsRegistrationIntentService", "Token Received " + token + "," + RegistrationIntentService.GCMAuthorizedEntity);
			LocalyticsXamarin.Android.Localytics.PushRegistrationId = token;
        }
    }
}
