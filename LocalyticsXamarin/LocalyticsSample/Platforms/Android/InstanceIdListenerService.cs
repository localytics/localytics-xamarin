using System;
using Android.App;
using Android.Content;
using Android.Gms.Iid;

namespace LocalyticsSample
{
	[Service(Exported = false), IntentFilter(new[] { "com.google.android.gms.iid.InstanceID" })]
	public class InstanceIdListenerService
    {
		[Service(Exported = false), IntentFilter(new[] { "com.google.android.gms.iid.InstanceID" })]
        class MyInstanceIDListenerService : InstanceIDListenerService
        {
            public override void OnTokenRefresh()
            {
                var intent = new Intent(this, typeof(RegistrationIntentService));
                StartService(intent);
            }
        }
    }
}
