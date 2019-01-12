using System;
using System.Collections.Generic;
using Android.App;
using Android.Locations;
using Android.Runtime;
using Android.Support.V4.App;

using LocalyticsXamarin.Android;
using LocalyticsXamarin.Common;
using LocalyticsXamarin.Shared;

namespace LocalyticsMessagingSample.Android
{
    [Application]
    public class LocalyticsAutoIntegrateApplication : Application
    {
        public static LocalyticsXamarin.Shared.LocalyticsSDK localyticsXamarin;

        public LocalyticsAutoIntegrateApplication(IntPtr handle, JniHandleOwnership ownerShip) : base(handle, ownerShip)
        {
        }
        override public void OnCreate()
        {
            base.OnCreate();
            localyticsXamarin = LocalyticsXamarin.Shared.LocalyticsSDK.SharedInstance;

            Localytics.SetOption("ll_app_key", "f737ce58a68aea90b4c79fc-0bc951b0-b42b-11e3-429f-00a426b17dd8");
#if DEBUG
            localyticsXamarin.LoggingEnabled = true;
#endif

            Localytics.AutoIntegrate(this);
            Localytics.SetLocationMonitoringEnabled(true);

			// Analytics callbacks
            LocalyticsSDK.LocalyticsDidTagEvent += LL_OnLocalyticsDidTagEvent;
            LocalyticsSDK.LocalyticsSessionWillOpen += LL_OnLocalyticsSessionWillOpen;
            LocalyticsSDK.LocalyticsSessionDidOpen += LL_OnLocalyticsSessionDidOpen;
            LocalyticsSDK.LocalyticsSessionWillClose += LL_OnLocalyticsSessionWillClose;

            // Messaging callbacks
            LocalyticsSDK.InAppDelaySessionStartMessagesDelegate = LocalyticsSDK_InAppDelaySessionStartMessagesDelegate; ;
            LocalyticsSDK.InAppShouldShowDelegate = LocalyticsSDK_InAppShouldShowDelegate;

            LocalyticsSDK.InAppDidDismissEvent += LL_OnLocalyticsDidDismissInAppMessage;
            LocalyticsSDK.InAppWillDismissEvent += LL_OnLocalyticsWillDismissInAppMessage;
            LocalyticsSDK.InAppDidDisplayEvent += LL_OnLocalyticsDidDisplayInAppMessage;
            LocalyticsSDK.InAppWillDisplayDelegate = LL_OnLocalyticsWillDisplayInAppMessage;


            LocalyticsSDK.PlacesShouldDisplayCampaignDelegate = LL_OnLocalyticsShouldShowPlacesPushNotification;
            Localytics.WillShowPlacesPushNotification += LL_OnLocalyticsWillShowPlacesPushNotification;

            Localytics.ShouldShowPushNotification += LL_OnLocalyticsShouldShowPushNotification;
            Localytics.WillShowPushNotification += LL_OnLocalyticsWillShowPushNotification;

            //// Location callbacks
            LocalyticsSDK.LocalyticsDidUpdateLocation += LL_OnLocalyticsDidUpdateLocation;
            LocalyticsSDK.LocalyticsDidTriggerRegions += LocalyticsSDK_LocalyticsDidTriggerRegions;
            LocalyticsSDK.LocalyticsDidUpdateMonitoredGeofences += LL_OnLocalyticsDidUpdateMonitoredGeofences;
        
            Localytics.ShouldPromptForLocationPermission += Localytics_ShouldPromptForLocationPermission;

            LocalyticsSDK.ShouldDeepLinkDelegate += LocalyticsSDK_ShouldDeepLinkDelegate;

            Localytics.DeeplinkToSettings += Localytics_DeeplinkToSettings;

            LocalyticsSDK.SharedInstance.OpenSession();
        }

        void LocalyticsSDK_LocalyticsDidTriggerRegions(object sender, LocalyticsDidTriggerRegionsEventArgs e)
        {
            Console.WriteLine("XamarinCallback: LocalyticsDidTriggerRegions " + e);
        }

        bool Localytics_ShouldPromptForLocationPermission(Campaign arg)
        {
            Console.WriteLine("XamarinCallback: ShouldPromptForLocationPermission " + arg);
            return true;
        }

        bool LocalyticsSDK_ShouldDeepLinkDelegate(string deepLink)
        {
            Console.WriteLine("XamarinCallback: Request to deeplink to url {0}", deepLink);
            return true;
        }

        bool Localytics_DeeplinkToSettings(object intent, Campaign campaign)
        {
            Console.WriteLine("XamarinCallback: ShouldPromptForLocationPermission {0} campaign = {1}", intent , campaign);
            return true;
        }

        bool LocalyticsSDK_InAppShouldShowDelegate(InAppCampaign arg)
        {
            Console.WriteLine("XamarinCallback: Should Show InApp {0}", arg);
            return true;
        }

        bool LocalyticsSDK_InAppDelaySessionStartMessagesDelegate()
        {
            Console.WriteLine("XamarinCallback: Delay InApp Session Start. Not Delayed");
            return false;
        }

        void LL_OnLocalyticsDidTagEvent(object sender, LocalyticsDidTagEventEventArgs eventArgs)
        {
            string eventName = eventArgs.EventName;
            IDictionary<string, string> attributes = eventArgs.Attributes;
            double? customerValueIncrease = eventArgs.CustomerValue;
            if (attributes != null)
            {
                Console.WriteLine("XamarinCallback: Did tag event: name: " + eventName + " attributes.Count: " + attributes.Count + " customerValueIncrease: " + customerValueIncrease);
            }
            else
            {
                Console.WriteLine("XamarinCallback: Did tag event: name: " + eventName + " attributes.Count: " + 0 + " customerValueIncrease: " + customerValueIncrease);
            }
        }

        void LL_OnLocalyticsSessionWillClose(object sender, EventArgs eventArgs)
        {
            Console.WriteLine("XamarinCallback: Session will close");
        }

        void LL_OnLocalyticsSessionDidOpen(object sender, LocalyticsSessionDidOpenEventArgs args)
        {
            Console.WriteLine("XamarinCallback: Session did open: isFirst: " + args.First + " isUpgrade: " + args.Upgrade + " isResume: " + args.Resume);
        }

        void LL_OnLocalyticsSessionWillOpen(object sender, LocalyticsSessionWillOpenEventArgs args)
        {
            Console.WriteLine("XamarinCallback: Session will open: isFirst: " + args.First + " isUpgrade: " + args.Upgrade + " isResume: " + args.Resume);
        }

        void LL_OnLocalyticsDidDismissInAppMessage(object sender, InAppDidDismissEventArgs eventArgs)
        {
            Console.WriteLine("XamarinCallback: DidDismissInAppMessage");
        }

        void LL_OnLocalyticsDidDisplayInAppMessage(object sender, InAppDidDisplayEventArgs eventArgs)
        {
            Console.WriteLine("XamarinCallback: DidDisplayInAppMessage");
        }

        void LL_OnLocalyticsWillDismissInAppMessage(object sender, InAppWillDismissEventArgs eventArgs)
        {
            Console.WriteLine("XamarinCallback: WillDismissInAppMessage");
        }

        InAppConfiguration LL_OnLocalyticsWillDisplayInAppMessage(InAppCampaign campaign, InAppConfiguration configuration)
        {
            Console.WriteLine("XamarinCallback: WillDisplayInAppMessage");
            return configuration;
        }

        bool LL_OnLocalyticsShouldShowPushNotification(PushCampaign campaign)
        {
            Console.WriteLine("XamarinCallback: Should show push notification. Name: " + campaign.Name + ". Campaign Id: " + campaign.CampaignId + ". Message: " + campaign.Message);
            return true;
        }

        NotificationCompat.Builder LL_OnLocalyticsWillShowPushNotification(NotificationCompat.Builder builder, PushCampaign campaign)
        {
            Console.WriteLine("XamarinCallback: Will show push notification. Name: " + campaign.Name + ". Campaign Id: " + campaign.CampaignId + ". Message: " + campaign.Message);
            return builder;
        }

        bool LL_OnLocalyticsShouldShowPlacesPushNotification(PlacesCampaign campaign)
        {
            Console.WriteLine("XamarinCallback: Should show places notification. Name: " + campaign.Name + ". Campaign Id: " + campaign.CampaignId + ". Message: " + campaign.Message);
            return true;
        }

        NotificationCompat.Builder LL_OnLocalyticsWillShowPlacesPushNotification(NotificationCompat.Builder builder, PlacesCampaign campaign)
        {
            Console.WriteLine("XamarinCallback: Will show places push notification. Name: " + campaign.Name + ". Campaign Id: " + campaign.CampaignId + ". Message: " + campaign.Message);
            return builder;
        }

        void LL_OnLocalyticsDidUpdateLocation(object sender, LocalyticsDidUpdateLocationEventArgs eventArgs)
        {
            Console.WriteLine("XamarinCallback: Did update location: " + eventArgs.Location);
        }

        void LL_OnLocalyticsDidTriggerRegions(object sender, LocalyticsDidTriggerRegionsEventArgs eventArgs)
        {
            Console.WriteLine("XamarinCallback: Did trigger regions: " + eventArgs.Regions + " with event: " + eventArgs.RegionEvent);
        }

        void LL_OnLocalyticsDidUpdateMonitoredGeofences(object sender, LocalyticsDidUpdateMonitoredGeofencesEventArgs eventArgs)
        {
            Console.WriteLine("XamarinCallback: Did update monitored geofences. Added: " + eventArgs.AddedRegions + " and removed: " + eventArgs.RemovedRegions);
        }
    }
}

