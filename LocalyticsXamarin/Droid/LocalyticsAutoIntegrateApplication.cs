using System;
using Android.App;
using Android.Runtime;

using LocalyticsXamarin.Android;

namespace LocalyticsSample.Droid
{
	[Application]
	public class LocalyticsAutoIntegrateApplication: Application
	{
		public LocalyticsAutoIntegrateApplication (IntPtr handle, JniHandleOwnership ownerShip) : base (handle, ownerShip) 
		{ 
		}

		override public void OnCreate() {
			base.OnCreate ();

			#if DEBUG
			Localytics.LoggingEnabled = true;
			#endif

			RegisterActivityLifecycleCallbacks (new LocalyticsActivityLifecycleCallbacks (this));
		}
	}
}

