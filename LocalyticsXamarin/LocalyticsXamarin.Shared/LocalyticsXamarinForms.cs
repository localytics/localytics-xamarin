using System;
using System.Diagnostics;
using LocalyticsSample.Shared;
using LocalyticsXamarin.Common;

#if __IOS__
using Foundation;
using UIKit;
using LocalyticsXamarin.IOS;
using NativeInAppCampaign = LocalyticsXamarin.IOS.LLInAppCampaign;
using NativePlacesCampaign = LocalyticsXamarin.IOS.LLPlacesCampaign;
#else
using Android.Support.V4.App;
using LocalyticsXamarin.Android;
using NativeInAppCampaign = LocalyticsXamarin.Android.InAppCampaign;
using NativePlacesCampaign = LocalyticsXamarin.Android.PlacesCampaign;
#endif

[assembly: Xamarin.Forms.Dependency(typeof(LocalyticsXamarin.Shared.LocalyticsXamarinForms))]
namespace LocalyticsXamarin.Shared
{
	public class LocalyticsXamarinForms : LocalyticsPlatform, ILocalytics, IPlatform  //    ,ILocalyticsIOS
	{
		bool inappShouldDisplay = true;
		bool placesShouldDisplay = true;
		bool shouldDeepLink = true;

		public void SetPlacesShouldDisplay(bool display)
		{
			placesShouldDisplay = display;
		}

		public void SetInAppShouldDisplay(bool display)
		{
			inappShouldDisplay = display;
		}

		public void SetShouldDeeplink(bool display)
		{
			shouldDeepLink = display;
		}

#if __IOS__
		public UILocalNotification PlacesWillDisplayNotification(UILocalNotification localNotification, LLPlacesCampaign placesCampaign)
		{
			Console.WriteLine("XamarinEvent PlacesWillDisplayNotification {0}", placesCampaign);
			return localNotification;
		}


		public UserNotifications.UNMutableNotificationContent PlacesWillDisplayNotificationContent(UserNotifications.UNMutableNotificationContent notificationContent, LLPlacesCampaign placesCampaign)
		{
			Console.WriteLine("XamarinEvent PlacesWillDisplayNotificationContent {0}", placesCampaign);
			return notificationContent;
		}
		public LLInAppConfiguration InAppWillDisplay(NativeInAppCampaign inAppCampaign, LLInAppConfiguration inAppConfiguration)
        {
            Console.WriteLine("XamarinEvent InAppWillDisplay campaign:{0}", inAppCampaign);
            return inAppConfiguration;
        }
#endif

        public bool InAppShouldShow(NativeInAppCampaign inAppCampaign)
        {
            Console.WriteLine("XamarinEvent LLInAppCampaign campaign:{0}", inAppCampaign);
            return inappShouldDisplay;
        }

		public bool PlacesShouldDisplay(NativePlacesCampaign placesCampaign)
        {
            Console.WriteLine("XamarinEvent PlacesShouldDisplay campaign:{0}", placesCampaign);
            return placesShouldDisplay;
        }

		public bool ShouldDeepLink(string url)
        {
            Console.WriteLine("XamarinEvent ShouldDeepLink Url:{0}", url);
            return shouldDeepLink;
        }

		public void RegisterEvents()
		{
			Localytics myInstance = Localytics.SharedInstance();
#if __IOS__
            Localytics.PlacesWillDisplayNotification = PlacesWillDisplayNotification;
            Localytics.PlacesWillDisplayNotificationContent = PlacesWillDisplayNotificationContent;
#endif
			Localytics.InAppShouldShow = InAppShouldShow;
			Localytics.ShouldDeepLink = ShouldDeepLink;
            
			myInstance.LocalyticsDidTriggerRegions  += (sender, e) => {
				Console.WriteLine("XamarinEvent LocalyticsDidTriggerRegions " + e.ToString());
			};
            
			myInstance.LocalyticsDidUpdateLocation += (sender, e) => {
				Console.WriteLine("XamarinEvent LocalyticsDidUpdateLocation " + e.ToString());
			};
            
			myInstance.LocalyticsDidUpdateMonitoredGeofences  += (sender, e) => {
				Console.WriteLine("XamarinEvent LocalyticsDidUpdateMonitoredGeofences " + e.ToString());
			};

			// Analytics Events
			myInstance.LocalyticsSessionDidOpen += (sender, e) =>
            {
                Console.WriteLine("XamarinEvent SessionDidOpenEvent: " + e);
            };            
			myInstance.LocalyticsDidTagEvent += (sender, e) => {
				Console.WriteLine("XamarinEvent SessionDidTagEvent: " + e);
            };
            
			myInstance.LocalyticsSessionWillClose += (sender, e) => {
				Console.WriteLine("XamarinEvent SessionWillCloseEvent: " + e);
            };
            
			myInstance.LocalyticsSessionWillOpen += (sender, e) => {
				Console.WriteLine("XamarinEvent SessionWillOpenEvent: " + e);
            };

            Localytics.InAppDidDismissEvent += (sender, e) =>
            {
				Console.WriteLine("XamarinEvent LocalyticsDidDismissInAppMessage");
            };

            Localytics.InAppDidDisplayEvent += (sender, e) =>
            {
				Console.WriteLine("XamarinEvent LocalyticsDidDisplayInAppMessage");
            };

            Localytics.InAppWillDismissEvent += (sender, e) =>
            {
				Console.WriteLine("XamarinEvent LocalyticsWillDismissInAppMessage");
            };

            Localytics.InAppWillDisplay += (campaign, configuration) =>
            {
				Console.WriteLine("XamarinEvent LocalyticsWillDisplayInAppMessage");
				return configuration;
            };
        }
    }
}
