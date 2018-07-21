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
    public class LocalyticsXamarinForms : LocalyticsSDK, ILocalytics, IPlatform
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
#endif

        public bool InAppShouldShowHandler(NativeInAppCampaign inAppCampaign)
        {
            Console.WriteLine("XamarinEvent LLInAppCampaign campaign:{0}", inAppCampaign);
            return inappShouldDisplay;
        }

        public bool PlacesShouldDisplay(NativePlacesCampaign placesCampaign)
        {
            Console.WriteLine("XamarinEvent PlacesShouldDisplay campaign:{0}", placesCampaign);
            return placesShouldDisplay;
        }

        public bool ShouldDeepLinkHandler(string url)
        {
            Console.WriteLine("XamarinEvent ShouldDeepLink Url:{0}", url);
            return shouldDeepLink;
        }

        public void RegisterEvents()
        {
            //Localytics myInstance = Localytics.SharedInstance();
#if __IOS__
            Localytics.PlacesWillDisplayNotification = PlacesWillDisplayNotification;
            Localytics.PlacesWillDisplayNotificationContent = PlacesWillDisplayNotificationContent;
#endif
            LocalyticsSDK.InAppShouldShowDelegate = InAppShouldShowHandler;
            LocalyticsSDK.ShouldDeepLinkDelegate = ShouldDeepLinkHandler;

            LocalyticsSDK.LocalyticsDidTriggerRegions += (sender, e) =>
            {
                Console.WriteLine("XamarinEvent LocalyticsDidTriggerRegions " + e);
            };

            LocalyticsSDK.LocalyticsDidUpdateLocation += (sender, e) =>
            {
                Console.WriteLine("XamarinEvent LocalyticsDidUpdateLocation " + e);
            };

            LocalyticsSDK.LocalyticsDidUpdateMonitoredGeofences += (sender, e) =>
            {
                Console.WriteLine("XamarinEvent LocalyticsDidUpdateMonitoredGeofences " + e);
            };

            // Analytics Events
            LocalyticsSDK.LocalyticsSessionDidOpen += (sender, e) =>
            {
                Console.WriteLine("XamarinEvent SessionDidOpenEvent: " + e);
            };
            LocalyticsSDK.LocalyticsDidTagEvent += (sender, e) =>
            {
                Console.WriteLine("XamarinEvent SessionDidTagEvent: " + e);
            };
            LocalyticsSDK.LocalyticsSessionWillClose += (sender, e) =>
            {
                Console.WriteLine("XamarinEvent SessionWillCloseEvent: " + e);
            };
            LocalyticsSDK.LocalyticsSessionWillOpen += (sender, e) =>
            {
                Console.WriteLine("XamarinEvent SessionWillOpenEvent: " + e);
            };

            LocalyticsSDK.InAppDidDismissEvent += (sender, e) =>
            {
                Console.WriteLine("XamarinEvent InAppDidDismissEvent " + e);
            };

            LocalyticsSDK.InAppDidDisplayEvent += (sender, e) =>
            {
                Console.WriteLine("XamarinEvent InAppDidDisplayEvent " + e);
            };

            LocalyticsSDK.InAppWillDismissEvent += (sender, e) =>
            {
                Console.WriteLine("XamarinEvent InAppWillDismissEvent " + e);
            };

            LocalyticsSDK.InAppWillDisplayDelegate = (campaign, configuration) =>
            {
                Console.WriteLine("XamarinEvent LocalyticsWillDisplayInAppMessage " + campaign + "," + configuration);
                return configuration;
            };

            LocalyticsSDK.CallToActionShouldDeepLinkDelegate = (string deeplink, ICampaignBase campaign) =>
            {
                Console.WriteLine("XamarinEvent LocalyticsCallToActionShouldDeepLinkDelegate " + deeplink + "," + campaign);
                return true;
            };

            LocalyticsSDK.DidOptOut = (object sender, DidOptOutEventArgs optOutEventArgs) =>
            {
                Console.WriteLine("XamarinEvent LocalyticsDidOptOut " + optOutEventArgs);
            };

            LocalyticsSDK.DidPrivacyOptOut = (object sender, DidOptOutEventArgs optOutEventArgs) =>
            {
                Console.WriteLine("XamarinEvent LocalyticsDidPrivacyOptOut " + optOutEventArgs);
            };

#if __IOS__
            Localytics.ShouldPromptForLocationWhenInUsePermission = (LLCampaignBase campaign) => {
                Console.WriteLine("XamarinEvent LocalyticsShouldPromptForLocationWhenInUsePermission " + campaign);
                return true;
            };

            Localytics.ShouldPromptForLocationAlwaysPermission = (LLCampaignBase campaign) => {
                Console.WriteLine("XamarinEvent LocalyticsShouldPromptForLocationAlwaysPermission " + campaign);
                return true;
            };

            Localytics.ShouldPromptForNotificationPermission = (LLCampaignBase campaign) => {
                Console.WriteLine("XamarinEvent LocalyticsShouldPromptForNotificationPermission " + campaign);
                return true;
            };
#else
            Localytics.ShouldPromptForLocationPermission = (Campaign campaign) => {
                Console.WriteLine("XamarinEvent LocalyticsShouldPromptForLocationPermission " + campaign);
                return true;
            };
#endif
        }
    }
}
