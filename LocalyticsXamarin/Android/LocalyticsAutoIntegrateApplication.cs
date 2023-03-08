using System;
using Android.App;
using Android.Runtime;

using LocalyticsMaui.Android;

namespace LocalyticsSample.Android
{
    [Application]
    public class LocalyticsAutoIntegrateApplication : Application
    {
        public LocalyticsAutoIntegrateApplication(IntPtr handle, JniHandleOwnership ownerShip) : base(handle, ownerShip)
        {
        }

        override public void OnCreate()
        {
            base.OnCreate();

#if DEBUG
            var localytics = LocalyticsXamarin.Shared.LocalyticsSDK.SharedInstance;
			localytics.LoggingEnabled = true;
#endif

            Localytics.AutoIntegrate(this);

        }
    }
}
