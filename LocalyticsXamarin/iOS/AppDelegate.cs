using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

using LocalyticsXamarin.iOS;

namespace LocalyticsSample.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		private LocalyticsAnalyticsListener_iOS analyticsListener;
		private LocalyticsMessagingListener_iOS messagingListener;

		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			analyticsListener = new LocalyticsAnalyticsListener_iOS ();
			messagingListener = new LocalyticsMessagingListener_iOS ();

			Localytics.SetAnalyticsDelegate (analyticsListener);
			Localytics.SetMessagingDelegate (messagingListener);

			#if DEBUG
			Localytics.SetLoggingEnabled(true);
			#endif

			// Localytics Auto Integrate
			Localytics.AutoIntegrate ("YOUR_LOCALYTICS_APP_KEY", options != null? options : new NSDictionary());

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
	}
}

