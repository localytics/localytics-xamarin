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

#if DEBUG
			localyticsXamarin.LoggingEnabled = true;
#endif
            Localytics.SetOption("ll_app_key", "YOUR_APP_KEY");

            Localytics.AutoIntegrate(this);
            Localytics.SetLocationMonitoringEnabled(true);

			//// Analytics callbacks
            LocalyticsSDK.SharedInstance.DidTagEvent += LL_OnLocalyticsDidTagEvent;
            LocalyticsSDK.SharedInstance.SessionWillOpen += LL_OnLocalyticsSessionWillOpen;
            LocalyticsSDK.SharedInstance.SessionDidOpen += LL_OnLocalyticsSessionDidOpen;
            LocalyticsSDK.LocalyticsSessionWillClose += LL_OnLocalyticsSessionWillClose;

            //// Messaging callbacks
            LocalyticsSDK.InAppDidDismissEvent += LL_OnLocalyticsDidDismissInAppMessage;
            LocalyticsSDK.InAppDidDisplayEvent += LL_OnLocalyticsDidDisplayInAppMessage;
            LocalyticsSDK.InAppWillDismissEvent += LL_OnLocalyticsWillDismissInAppMessage;
            LocalyticsSDK.InAppWillDisplayDelegate += LL_OnLocalyticsWillDisplayInAppMessage;

            Localytics.ShouldShowPushNotification += LL_OnLocalyticsShouldShowPushNotification;
            LocalyticsSDK.PlacesShouldDisplayCampaignDelegate += LL_OnLocalyticsShouldShowPlacesPushNotification;

            Localytics.WillShowPushNotification += LL_OnLocalyticsWillShowPushNotification;
            Localytics.WillShowPlacesPushNotification += LL_OnLocalyticsWillShowPlacesPushNotification;

            //// Location callbacks
            LocalyticsSDK.LocalyticsDidUpdateLocation += LL_OnLocalyticsDidUpdateLocation;
            LocalyticsSDK.LocalyticsDidTriggerRegions += (sender, e) => {
                Console.WriteLine("XamarinEvent LocalyticsDidTriggerRegions " + e);
            };
            LocalyticsSDK.LocalyticsDidUpdateMonitoredGeofences += LL_OnLocalyticsDidUpdateMonitoredGeofences;
        }

        void LL_OnLocalyticsDidTagEvent(object sender, LocalyticsDidTagEventEventArgs eventArgs)
        {
            string eventName = eventArgs.EventName;
            IDictionary<string, string> attributes = eventArgs.Attributes;
            double? customerValueIncrease = eventArgs.CustomerValue;
            if (attributes != null)
            {
                Console.WriteLine("Did tag event: name: " + eventName + " attributes.Count: " + attributes.Count + " customerValueIncrease: " + customerValueIncrease);
            }
            else
            {
                Console.WriteLine("Did tag event: name: " + eventName + " attributes.Count: " + 0 + " customerValueIncrease: " + customerValueIncrease);
            }
        }

        void LL_OnLocalyticsSessionWillClose(object sender, EventArgs eventArgs)
        {
            Console.WriteLine("Session will close");
        }

        void LL_OnLocalyticsSessionDidOpen(object sender, LocalyticsSessionDidOpenEventArgs args)
        {
            Console.WriteLine("Session did open: isFirst: " + args.First + " isUpgrade: " + args.Upgrade + " isResume: " + args.Resume);
        }

        void LL_OnLocalyticsSessionWillOpen(object sender, LocalyticsSessionWillOpenEventArgs args)
        {
            Console.WriteLine("Session will open: isFirst: " + args.First + " isUpgrade: " + args.Upgrade + " isResume: " + args.Resume);
        }

        void LL_OnLocalyticsDidDismissInAppMessage(object sender, InAppDidDismissEventArgs eventArgs)
        {
            Console.WriteLine("DidDismissInAppMessage");
        }

        void LL_OnLocalyticsDidDisplayInAppMessage(object sender, InAppDidDisplayEventArgs eventArgs)
        {
            Console.WriteLine("DidDisplayInAppMessage");
        }

        void LL_OnLocalyticsWillDismissInAppMessage(object sender, InAppWillDismissEventArgs eventArgs)
        {
            Console.WriteLine("WillDismissInAppMessage");
        }

        InAppConfiguration LL_OnLocalyticsWillDisplayInAppMessage(InAppCampaign campaign, InAppConfiguration configuration)
        {
            Console.WriteLine("WillDisplayInAppMessage");
            return configuration;
        }

        bool LL_OnLocalyticsShouldShowPushNotification(PushCampaign campaign)
        {
            Console.WriteLine("Should show push notification. Name: " + campaign.Name + ". Campaign Id: " + campaign.CampaignId + ". Message: " + campaign.Message);
            return true;
        }

        NotificationCompat.Builder LL_OnLocalyticsWillShowPushNotification(NotificationCompat.Builder builder, PushCampaign campaign)
        {
            Console.WriteLine("Will show push notification. Name: " + campaign.Name + ". Campaign Id: " + campaign.CampaignId + ". Message: " + campaign.Message);
            return builder;
        }

        bool LL_OnLocalyticsShouldShowPlacesPushNotification(PlacesCampaign campaign)
        {
            Console.WriteLine("Should show places notification. Name: " + campaign.Name + ". Campaign Id: " + campaign.CampaignId + ". Message: " + campaign.Message);
            return true;
        }

        NotificationCompat.Builder LL_OnLocalyticsWillShowPlacesPushNotification(NotificationCompat.Builder builder, PlacesCampaign campaign)
        {
            Console.WriteLine("Will show places push notification. Name: " + campaign.Name + ". Campaign Id: " + campaign.CampaignId + ". Message: " + campaign.Message);
            return builder;
        }

        void LL_OnLocalyticsDidUpdateLocation(object sender, LocalyticsDidUpdateLocationEventArgs eventArgs)
        {
            Console.WriteLine("Did update location: " + eventArgs.Location);
        }

        void LL_OnLocalyticsDidTriggerRegions(object sender, LocalyticsDidTriggerRegionsEventArgs eventArgs)
        {
            Console.WriteLine("Did trigger regions: " + eventArgs.Regions + " with event: " + eventArgs.RegionEvent);
        }

        void LL_OnLocalyticsDidUpdateMonitoredGeofences(object sender, LocalyticsDidUpdateMonitoredGeofencesEventArgs eventArgs)
        {
            Console.WriteLine("Did update monitored geofences. Added: " + eventArgs.AddedRegions + " and removed: " + eventArgs.RemovedRegions);
        }
    }
}

