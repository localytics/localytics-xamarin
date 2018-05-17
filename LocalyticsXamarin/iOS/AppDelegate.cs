using System;

using Foundation;
using UIKit;

using LocalyticsSample.Shared;
using LocalyticsXamarin.iOS;

namespace LocalyticsSample.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
            {
                var pushSettings = UIUserNotificationSettings.GetSettingsForTypes(
                                   UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound,
                                   new NSSet());

                UIApplication.SharedApplication.RegisterUserNotificationSettings(pushSettings);
                UIApplication.SharedApplication.RegisterForRemoteNotifications();
            }
            else
            {
                UIRemoteNotificationType notificationTypes = UIRemoteNotificationType.Alert | UIRemoteNotificationType.Badge | UIRemoteNotificationType.Sound;
                UIApplication.SharedApplication.RegisterForRemoteNotificationTypes(notificationTypes);
            }

			Localytics.SessionDidOpenEvent += (sender, e) =>
                     {
                         Console.WriteLine("Xamarin SessionDidOpenEvent: " + e.ToString());
                     };
            Localytics.SessionDidTagEvent += (sender, e) => {
                         Console.WriteLine("Xamarin SessionDidTagEvent: " + e.ToString());
                     };

            Localytics.SessionWillCloseEvent += (sender, e) => {
                         Console.WriteLine("Xamarin SessionWillCloseEvent: " + e.ToString());
                     };

            Localytics.SessionWillOpenEvent += (sender, e) => {
                         Console.WriteLine("Xamarin SessionWillOpenEvent: " + e.ToString());
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

			Localytics.PlacesShouldDisplayCampaign += (campaign) =>
					  {
						  Console.Write("LocalyticsShouldDisplayPlacesCampaign");
						  return true;
					  };

			Localytics.PlacesWillDisplayNotification += (localNotification, campaign) =>
			{
				Console.WriteLine("PlacesWillDisplayNotification");
				return localNotification;
			};

			Localytics.PlacesWillDisplayNotificationContent += (notificationContent, campaign) =>
			  {
				  Console.Write("PlacesWillDisplayNotificationContent");
				return notificationContent;
			  };

            #if DEBUG
			Localytics.LoggingEnabled = true;
			#endif

			// Localytics Auto Integrate
			Localytics.AutoIntegrate ("d66a71cf596a2df62e39508-6de4aff6-2236-11e8-4a93-007c928ca240", options != null? options : new NSDictionary(), new NSDictionary());

			// Register for remote notifications
			if (UIDevice.CurrentDevice.CheckSystemVersion (8, 0)) {
				var pushSettings = UIUserNotificationSettings.GetSettingsForTypes (
					UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound,
					new NSSet ());

				UIApplication.SharedApplication.RegisterUserNotificationSettings (pushSettings);
				UIApplication.SharedApplication.RegisterForRemoteNotifications ();
			} else {
				UIRemoteNotificationType notificationTypes = UIRemoteNotificationType.Alert | UIRemoteNotificationType.Badge | UIRemoteNotificationType.Sound;
				UIApplication.SharedApplication.RegisterForRemoteNotificationTypes (notificationTypes);
			}

			global::Xamarin.Forms.Forms.Init ();

			// Code for starting up the Xamarin Test Cloud Agent
			#if ENABLE_TEST_CLOUD
			Xamarin.Calabash.Start();
			#endif

			LoadApplication (new App ());

			return base.FinishedLaunching (app, options);
		}

		public override void RegisteredForRemoteNotifications(UIApplication application, NSData deviceToken)
        {
			Localytics.SetPushToken(deviceToken);
        }
	}
}
