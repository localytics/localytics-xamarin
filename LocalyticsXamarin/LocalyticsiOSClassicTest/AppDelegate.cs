using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

using LocalyticsXamarin.iOS;

namespace LocalyticsiOSClassicTest
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		
		public override UIWindow Window {
			get;
			set;
		}

		public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
		{
			#if DEBUG
			Localytics.SetLoggingEnabled(true);
			#endif

			// Localytics Auto Integrate
			Localytics.AutoIntegrate ("xxxxxxxxxxxxxxxxxxxxxxx-xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx", launchOptions != null? launchOptions : new NSDictionary());

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

			this.SmokeTest ();

			// Code to start the Xamarin Test Cloud Agent
			#if ENABLE_TEST_CLOUD
			Xamarin.Calabash.Start();
			#endif

			return true;
		}
		
		// This method is invoked when the application is about to move from active to inactive state.
		// OpenGL applications should use this method to pause.
		public override void OnResignActivation (UIApplication application)
		{
		}
		
		// This method should be used to release shared resources and it should store the application state.
		// If your application supports background exection this method is called instead of WillTerminate
		// when the user quits.
		public override void DidEnterBackground (UIApplication application)
		{
		}
		
		// This method is called as part of the transiton from background to active state.
		public override void WillEnterForeground (UIApplication application)
		{
		}
		
		// This method is called when the application is about to terminate. Save data, if needed.
		public override void WillTerminate (UIApplication application)
		{
		}

		private void SmokeTest ()
		{
			Localytics.CustomerId = "XamarinIOSClassic CustomerId";
			Localytics.SetProfileAttribute ((NSString)("IOSClassic Age"), "83", LLProfileScope.Organization);

			Localytics.AddProfileAttributesToSet(new NSObject[] { (NSNumber)(222), (NSString)("333") }, "IOSClassic numbers", LLProfileScope.Application);

			Localytics.DeleteProfileAttribute("TestDeleteProfileAttribute", LLProfileScope.Application);

			Localytics.SetCustomerEmail("XamarinIOSClassic Email");
			Localytics.SetCustomerFirstName("XamarinIOSClassic FirstName");
			Localytics.SetCustomerLastName("XamarinIOSClassic LastName");
			Localytics.SetCustomerFullName("XamarinIOSClassic Full Name");

			Localytics.SetCustomDimension("XamarinFormIOSCD1", 1);

			Localytics.TagEvent ("XamarinIOSClassic Start");
			Localytics.TagScreen ("XamarinIOSClassic Landing");

			Localytics.Upload ();
		}
	}
}

