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

 			Localytics.SessionDidOpenEvent += (sender, e) =>
             {
                 Console.WriteLine("Xamarin SessionDidOpenEvent: " + e);
             };

            Localytics.SessionDidTagEvent += (sender, e) => {
                 Console.WriteLine("Xamarin SessionDidTagEvent: " + e);
             };

            Localytics.SessionWillCloseEvent += (sender, e) => {
                Console.WriteLine("Xamarin SessionWillCloseEvent: " + e);
            };

            Localytics.SessionWillOpenEvent += (sender, e) => {
                Console.WriteLine("Xamarin SessionWillOpenEvent: " + e);
            };			

			Localytics.InAppDidDismissEvent += (sender, e) =>
            {
                Console.WriteLine("LocalyticsDidDismissInAppMessage");
			};

			Localytics.InAppDidDisplayEvent += (sender, e) =>
            {
                Console.WriteLine("LocalyticsDidDisplayInAppMessage");
            };

			Localytics.InAppWillDismissEvent += (sender, e) =>
            {
                Console.WriteLine("LocalyticsWillDismissInAppMessage");
            };
            
			Localytics.InAppWillDisplay += (campaign, configurastion) =>
            {
                Console.WriteLine("LocalyticsWillDisplayInAppMessage");
                return configurastion;
            };



			// Localytics Auto Integrate
			Localytics.LoggingEnabled = true;
			Localytics.Integrate ("36a67f27a597f8b391e6ba5-14b11240-c640-11e3-99ae-005cf8cbabd8", launchOptions ?? new NSDictionary());

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
