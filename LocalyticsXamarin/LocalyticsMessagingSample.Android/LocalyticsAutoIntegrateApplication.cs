using System;
using System.Collections.Generic;
using Android.App;
using Android.Runtime;

using LocalyticsXamarin.Android;

namespace LocalyticsMessagingSample.Android
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

			// RegisterActivityLifecycleCallbacks to auto integrate Localytics 
			RegisterActivityLifecycleCallbacks (new LocalyticsActivityLifecycleCallbacks (this));

			LocalyticsEvents.SubscribeToAll ();

			LocalyticsEvents.OnLocalyticsDidTagEvent += LL_OnLocalyticsDidTagEvent;
			LocalyticsEvents.OnLocalyticsSessionWillOpen += LL_OnLocalyticsSessionWillOpen;
			LocalyticsEvents.OnLocalyticsSessionDidOpen += LL_OnLocalyticsSessionDidOpen;
			LocalyticsEvents.OnLocalyticsSessionWillClose += LL_OnLocalyticsSessionWillClose;

			LocalyticsEvents.OnLocalyticsDidDismissInAppMessage += LL_OnLocalyticsDidDismissInAppMessage;
			LocalyticsEvents.OnLocalyticsDidDisplayInAppMessage += LL_OnLocalyticsDidDisplayInAppMessage;
			LocalyticsEvents.OnLocalyticsWillDismissInAppMessage += LL_OnLocalyticsWillDismissInAppMessage;
			LocalyticsEvents.OnLocalyticsWillDisplayInAppMessage += LL_OnLocalyticsWillDisplayInAppMessage;
		}

		void LL_OnLocalyticsDidTagEvent(string eventName, IDictionary<string, string> attributes, long customerValueIncrease)
		{
			Console.WriteLine("Did tag event: name: " + eventName + " attributes.Count: " + attributes.Count + " customerValueIncrease: " + customerValueIncrease);
		}

		void LL_OnLocalyticsSessionWillClose()
		{
			Console.WriteLine("Session will close");
		}

		void LL_OnLocalyticsSessionDidOpen(bool isFirst, bool isUpgrade, bool isResume)
		{
			Console.WriteLine("Session did open: isFirst: " + isFirst + " isUpgrade: " + isUpgrade + " isResume: " + isResume);
		}

		void LL_OnLocalyticsSessionWillOpen(bool isFirst, bool isUpgrade, bool isResume)
		{
			Console.WriteLine("Session will open: isFirst: " + isFirst + " isUpgrade: " + isUpgrade + " isResume: " + isResume);
		}

		void LL_OnLocalyticsDidDismissInAppMessage()
		{
			Console.WriteLine ("DidDismissInAppMessage");
		}

		void LL_OnLocalyticsDidDisplayInAppMessage()
		{
			Console.WriteLine ("DidDisplayInAppMessage");
		}

		void LL_OnLocalyticsWillDismissInAppMessage()
		{
			Console.WriteLine ("WillDismissInAppMessage");
		}

		void LL_OnLocalyticsWillDisplayInAppMessage()
		{
			Console.WriteLine ("WillDisplayInAppMessage");
		}
	}
}

