using System;
using Android.App;
using Android.Content;
using Android.Gms.Gcm;
using Android.Gms.Iid;
using Android.Util;
using System.Diagnostics;
using LocalyticsMaui.Android;

namespace LocalyticsSample
{
	[Service(Exported = false)]
    class RegistrationIntentService : IntentService
    {
        static object locker = new object();

        public RegistrationIntentService() : base("RegistrationIntentService") {
			Debug.WriteLine("RegistrationIntentService:Constructor");
		}

        protected override void OnHandleIntent(Intent intent)
        {
			Debug.WriteLine("RegistrationIntentService:OnHandleIntent");
            try
            {
                Log.Info("RegistrationIntentService", "Calling InstanceID.GetToken");
                lock (locker)
                {
                    var instanceID = InstanceID.GetInstance(this);
                    var token = instanceID.GetToken(
						"977036904838", GoogleCloudMessaging.InstanceIdScope, null);

                    Log.Info("RegistrationIntentService", "GCM Registration Token: " + token);
                    SendRegistrationToAppServer(token);
                    Subscribe(token);
                }
            }
            catch (Exception e)
            {
				Console.WriteLine("Exception " + e.Message);
                Log.Debug("RegistrationIntentService", "Failed to get a registration token ");
                return;
            }
        }

        void SendRegistrationToAppServer(string token)
        {
			// Add custom implementation here as needed.
			Localytics.PushRegistrationId = token;
        }

        void Subscribe(string token)
        {
            var pubSub = GcmPubSub.GetInstance(this);
            pubSub.Subscribe(token, "/topics/global", null);
        }
    }
}
