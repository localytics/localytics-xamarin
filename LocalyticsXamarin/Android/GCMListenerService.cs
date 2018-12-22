using Android.App;
using Android.Content;
using Android.OS;
using Android.Gms.Gcm;
using Android.Util;
using LocalyticsXamarin.Android;
#if DISPLAY_CUSTOM_NOTIFICATION
using Android.Support.V4.App;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Net.Security;
#endif

[assembly: UsesPermission("com.google.android.c2dm.permission.RECEIVE")]

namespace LocalyticsXamarin.Shared
{
    [Service(Exported = false), IntentFilter(new[] { "com.google.android.c2dm.intent.RECEIVE" }, Categories = new[] { "YOUR-PACKAGE-NAME" })]
    public class MyGcmListenerService : GcmListenerService
    {
        public override void OnMessageReceived(string from, Bundle data)
        {
#if DEBUG
            foreach (string key in data.KeySet())
            {
                Log.Debug("MyGcmListenerService", key);
            }
            Log.Debug("MyGcmListenerService", "google.delivered_priority: " + data.GetString("google.delivered_priority"));
            Log.Debug("MyGcmListenerService", "google.original_priority: " + data.GetString("google.original_priority"));
            Log.Debug("MyGcmListenerService", "from:    " + from);
            Log.Debug("MyGcmListenerService", "message: " + data.GetString("message"));
            Log.Debug("MyGcmListenerService", "ll_title: " + data.GetString("ll_title"));
            // Tag a custom event for debugging.
            LocalyticsSDK.SharedInstance.TagEvent("Recieved a Push Message");
            LocalyticsSDK.SharedInstance.Upload();
#endif

            // For custom rendering of notifications define DISPLAY_CUSTOM_NOTIFICATION 
#if DISPLAY_CUSTOM_NOTIFICATION
            SendNotification(data)
#else
            Localytics.DisplayPushNotification(data);
#endif
        }

#if DISPLAY_CUSTOM_NOTIFICATION
        // Display Notifications
        void SendNotification(Bundle data)
        {
            var trackingIntent = new Intent(this, typeof(LocalyticsXamarin.Android.PushTrackingActivity));
            trackingIntent.PutExtras(data); // add all extras from received bundle

            int requestCode = requestCode = data.GetInt("requestCode");
            var pendingIntent = PendingIntent.GetActivity(this, requestCode, trackingIntent, PendingIntentFlags.UpdateCurrent);

            string message = data.GetString("message");

            // TODO : Update this code to address all the various notification features that are required.
            var notificationBuilder = new Notification.Builder(this) //new Notification.Builder(this, "localytics_default")
                .SetSmallIcon(YOUR-APP-ICON-RESOURCE-ID-Resource.Mipmap.icon) // Replace this with your App's Icon
                .SetContentTitle(data.GetString("ll_title"))
                .SetContentText(message)
                .SetDefaults(NotificationDefaults.All)
                .SetStyle(new Notification.BigTextStyle().BigText(message))
                .SetAutoCancel(true)
                .SetContentIntent(pendingIntent);
            var notificationManager = (NotificationManager)GetSystemService(Context.NotificationService);
            notificationManager.Notify(requestCode, notificationBuilder.Build());
        }
#endif
    }
}
