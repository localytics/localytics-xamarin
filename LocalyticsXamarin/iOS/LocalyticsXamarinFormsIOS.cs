using System;

using UIKit;
using LocalyticsXamarin.IOS;

[assembly: Xamarin.Forms.Dependency(typeof(LocalyticsSample.Shared.LocalyticsXamarinForms))]
namespace LocalyticsSample.Shared
{
    public class LocalyticsXamarinFormsIOS : LocalyticsXamarinForms
    {

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

        public override bool InAppShouldShowHandler(object inAppCampaign)
        {
            Console.WriteLine("XamarinEvent LLInAppCampaign campaign:{0}", (LLInAppCampaign) inAppCampaign);
            return inappShouldDisplay;
        }

        public override bool PlacesShouldDisplay(object placesCampaign)
        {
            Console.WriteLine("XamarinEvent PlacesShouldDisplay campaign:{0}", (LLPlacesCampaign) placesCampaign);
            return placesShouldDisplay;
        }


        public override void RegisterEvents()
        {
            base.RegisterEvents();

            // LocalyticsSDK.InAppShouldShowDelegate = InAppShouldShowHandler;
            // LocalyticsSDK.ShouldDeepLinkDelegate = ShouldDeepLinkHandler;

            Localytics.PlacesWillDisplayNotification = PlacesWillDisplayNotification;
            Localytics.PlacesWillDisplayNotificationContent = PlacesWillDisplayNotificationContent;
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
            Localytics.ShouldDeepLinkToSettings = (LLCampaignBase campaign) => {
                Console.WriteLine("XamarinEvent ShouldDeepLinkToSettings " + campaign);
                return true;
            };
        }
    }
}