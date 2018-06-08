using LocalyticsSample.Shared;
using LocalyticsXamarin.Common;
using System.Diagnostics;
#if __IOS__
using System;

using Foundation;
using UIKit;
using LocalyticsXamarin.IOS;
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
            Debug.WriteLine("PlacesWillDisplayNotification {0}", placesCampaign);
            return localNotification;
        }


        public UserNotifications.UNMutableNotificationContent PlacesWillDisplayNotificationContent(UserNotifications.UNMutableNotificationContent notificationContent, LLPlacesCampaign placesCampaign)
        {
            Debug.WriteLine("PlacesWillDisplayNotificationContent {0}", placesCampaign);
            return notificationContent;
        }


        public bool ShouldDeepLink(NSUrl url)
        {
            Debug.WriteLine("ShouldDeepLink Url:{0}", url.ToString());
            return shouldDeepLink;
        }


        public bool PlacesShouldDisplay(LLPlacesCampaign placesCampaign)
        {
            Debug.WriteLine("PlacesShouldDisplay campaign:{0}", placesCampaign);
            return placesShouldDisplay;
        }


        public LLInAppConfiguration InAppWillDisplay(LLInAppCampaign inAppCampaign, LLInAppConfiguration inAppConfiguration)
        {
            Debug.WriteLine("InAppWillDisplay campaign:{0}", inAppCampaign);
            return inAppConfiguration;
        }

        public bool InAppShouldShow(LLInAppCampaign inAppCampaign)
        {
            Debug.WriteLine("LLInAppCampaign campaign:{0}", inAppCampaign);
            return inappShouldDisplay;
        }
#endif

        public void RegisterEvents()
        {
#if __IOS__
            Localytics.InAppShouldShow = InAppShouldShow;
            Localytics.InAppWillDisplay = InAppWillDisplay;
            Localytics.PlacesWillDisplayNotification = PlacesWillDisplayNotification;
            Localytics.PlacesWillDisplayNotificationContent = PlacesWillDisplayNotificationContent;
            Localytics.ShouldDeepLink = ShouldDeepLink;

            //Localytics.PlacesShouldDisplayCampaign += (campaign) =>
            //{
            //    Console.Write("LocalyticsShouldDisplayPlacesCampaign");
            //    return true;
            //};

            //Localytics.PlacesWillDisplayNotification += (localNotification, campaign) =>
            //{
            //    Console.WriteLine("PlacesWillDisplayNotification");
            //    return localNotification;
            //};

            //Localytics.PlacesWillDisplayNotificationContent += (notificationContent, campaign) =>
            //{
            //    Console.Write("PlacesWillDisplayNotificationContent");
            //    return notificationContent;
            //};
#endif
        }
    }
}
