using LocalyticsSample.Shared;
using LocalyticsXamarin.Common;
using System.Diagnostics;
using System;
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
#if __IOS__
            Localytics.PlacesWillDisplayNotification = PlacesWillDisplayNotification;
            Localytics.PlacesWillDisplayNotificationContent = PlacesWillDisplayNotificationContent;
 #else
			Localytics myInstance = new Localytics();
            //Localytics.PlacesWillDisplayNotification = PlacesWillDisplayNotification;
            //Localytics.PlacesWillDisplayNotificationContent = PlacesWillDisplayNotificationContent;
#endif
			Localytics.InAppShouldShow = InAppShouldShow;
			Localytics.ShouldDeepLink = ShouldDeepLink;

#if __IOS__
			Localytics.LocationDidTriggerRegionsEvent
#else
			myInstance.LocalyticsDidTriggerRegions 
			#endif
			          += (sender, e) => {
				Console.WriteLine("XamarinEvent LocalyticsDidTriggerRegions " + e.ToString());
			};

			#if __IOS__
			Localytics.LocationUpdateEvent
#else
			myInstance.LocalyticsDidUpdateLocation 
			#endif
			          += (sender, e) => {
				Console.WriteLine("XamarinEvent LocalyticsDidUpdateLocation " + e.ToString());
			};

			#if __IOS__
			Localytics.LocationDidUpdateMonitoredRegionsEvent
#else
			myInstance.LocalyticsDidUpdateMonitoredGeofences 
			#endif
			          += (sender, e) => {
				Console.WriteLine("XamarinEvent LocalyticsDidUpdateMonitoredGeofences " + e.ToString());
			};

			// Analytics Events
#if __IOS__
			Localytics.SessionDidOpenEvent
#else
			myInstance.LocalyticsSessionDidOpen
#endif
					   += (sender, e) =>
            {
                Console.WriteLine("XamarinEvent SessionDidOpenEvent: " + e);
            };            
			#if __IOS__
			Localytics.SessionDidTagEvent
#else
			myInstance.LocalyticsDidTagEvent
#endif
             += (sender, e) => {
				Console.WriteLine("XamarinEvent SessionDidTagEvent: " + e);
            };

			#if __IOS__
			Localytics.SessionWillCloseEvent
#else
			myInstance.LocalyticsSessionWillClose
#endif
             += (sender, e) => {
				Console.WriteLine("XamarinEvent SessionWillCloseEvent: " + e);
            };

			#if __IOS__
			Localytics.SessionWillOpenEvent
#else
			myInstance.LocalyticsSessionWillOpen
#endif
             += (sender, e) => {
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
