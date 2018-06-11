using LocalyticsSample.Shared;
using LocalyticsXamarin.Common;
using System.Diagnostics;
using System;
#if __IOS__

using Foundation;
using UIKit;
using LocalyticsXamarin.IOS;
#else
using Android.Support.V4.App;
using LocalyticsXamarin.Android;
#endif

[assembly: Xamarin.Forms.Dependency(typeof(LocalyticsXamarin.Shared.LocalyticsXamarinForms))]
namespace LocalyticsXamarin.Shared
{

    #if __IOS__
    #else
   
    #endif

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
            // Analytics Events
#if __ANDROID__
            Localytics myInstance = new Localytics();
            myInstance.LocalyticsSessionDidOpen += (sender, e) =>
            {
                Console.WriteLine("Xamarin SessionDidOpenEvent: " + e);
            };            
            myInstance.LocalyticsDidTagEvent += (sender, e) => {
                 Console.WriteLine("Xamarin SessionDidTagEvent: " + e);
            };

            myInstance.LocalyticsSessionWillClose += (sender, e) => {
                Console.WriteLine("Xamarin SessionWillCloseEvent: " + e);
            };

            myInstance.LocalyticsSessionWillOpen += (sender, e) => {
                Console.WriteLine("Xamarin SessionWillOpenEvent: " + e);
            };

#else
            Localytics.SessionDidOpenEvent += (sender, e) =>
            {
                Console.WriteLine("Xamarin SessionDidOpenEvent: " + e);
            };
            Localytics.SessionDidTagEvent += (sender, e) =>
            {
                Console.WriteLine("Xamarin SessionDidTagEvent: " + e);
            };

            Localytics.SessionWillCloseEvent += (sender, e) =>
            {
                Console.WriteLine("Xamarin SessionWillCloseEvent: " + e);
            };

            Localytics.SessionWillOpenEvent += (sender, e) =>
            {
                Console.WriteLine("Xamarin SessionWillOpenEvent: " + e);
            };
#endif

#if __IOS__
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

#else

            //Localytics.SetMessagingListener(new Mes)
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

#endif



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
#else
#endif
        }
    }
}
