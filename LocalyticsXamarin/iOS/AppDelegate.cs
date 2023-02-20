using System;

using Foundation;
using UIKit;

using LocalyticsSample.Shared;
using LocalyticsXamarin.IOS;
using System.Diagnostics;

namespace LocalyticsSample.IOS
{
    
	[Register ("AppDelegate")]
	public class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching (UIApplication uiApplication, NSDictionary launchOptions)
		{
			global::Xamarin.Forms.Forms.Init();

            // Code for starting up the Xamarin Test Cloud Agent
#if ENABLE_TEST_CLOUD
            Xamarin.Calabash.Start();
#endif

            LoadApplication(new App());

			// Localytics Integrate
			Localytics.LoggingEnabled = true;
            Localytics.Integrate ("b70c948d304fc756d8b6e63-ecd3437a-a073-11e6-c6e3-008d99911bee", launchOptions ?? new NSDictionary());

			// Register for remote notifications
				var pushSettings = UIUserNotificationSettings.GetSettingsForTypes (
					UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound,
					new NSSet ());

				UIApplication.SharedApplication.RegisterUserNotificationSettings (pushSettings);
				UIApplication.SharedApplication.RegisterForRemoteNotifications ();

			return base.FinishedLaunching (uiApplication, launchOptions);
		}

		public override void RegisteredForRemoteNotifications(UIApplication application, NSData deviceToken)
        {
			Console.WriteLine("Push Token Registered " + deviceToken.DebugDescription);
			Localytics.SetPushToken(deviceToken);
        }

		public override void FailedToRegisterForRemoteNotifications(UIApplication application, NSError error)
		{
			Console.WriteLine("Failed to Register for Notifications " + error);
		}      
	}
}
