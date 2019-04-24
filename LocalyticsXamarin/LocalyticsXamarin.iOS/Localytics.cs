using System;
using System.Collections;
using CoreLocation;
using Foundation;
using UIKit;
using System.Collections.Generic;
using LocalyticsXamarin.Shared;
using LocalyticsXamarin.Common;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using System.ComponentModel;

namespace LocalyticsXamarin.IOS
{
    public partial class Localytics
    {
        static Localytics _instance;

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static Localytics SharedInstance()
        {
            if (_instance == null)
            {
                _instance = new Localytics();
            }
            return _instance;
        }

        public static void TagPlacesPushReceived(LLPlacesCampaign campaign)
        {
            Localytics.TagPlacesPushReceivedPrivate(campaign);
        }

        // @required +(void)tagPlacesPushOpened:(LLPlacesCampaign * _Nonnull)campaign;
        public static void TagPlacesPushOpened(LLPlacesCampaign campaign)
        {
            Localytics.TagPlacesPushOpenedPrivate(campaign);
        }

        // @required +(void)tagPlacesPushOpened:(LLPlacesCampaign * _Nonnull)campaign withActionIdentifier:(NSString * _Nonnull)identifier;
        public static void TagPlacesPushOpened(LLPlacesCampaign campaign, string identifier)
        {
            Localytics.TagPlacesPushOpened(campaign, identifier);
        }

        // @required +(void)triggerPlacesNotificationForCampaign:(LLPlacesCampaign * _Nonnull)campaign;
        public static void TriggerPlacesNotificationForCampaign(LLPlacesCampaign campaign)
        {
            Localytics.TriggerPlacesNotificationForCampaign(campaign);
        }

        public static void TagCustomerRegistered(IDictionary<string, object> customerProps, string methodName, NSDictionary attributes)
        {
            var customer = Convertor.toCustomer(customerProps);
            Localytics.TagCustomerRegisteredPrivate(customer, methodName, attributes);
        }

        public static void TagCustomerRegistered(LLCustomer customer, string methodName, NSDictionary attributes)
        {
            Localytics.TagCustomerRegisteredPrivate(customer, methodName, attributes);
        }

        public static void TagCustomerLoggedIn(IDictionary<string, object> customerProps, string methodName, NSDictionary attributes)
        {
            var customer = Convertor.toCustomer(customerProps);
            Localytics.TagCustomerLoggedInPrivate(customer, methodName, attributes);
        }

        public static void TagCustomerLoggedIn(LLCustomer customer, string methodName, NSDictionary attributes)
        {
            Localytics.TagCustomerLoggedInPrivate(customer, methodName, attributes);
        }

        // Not Recommended because the AppDelegate is implemented as c# callbacks and swizzling is going to have to understand that it's a proxied object.
        // Xamarin doesnt account for the notification observers registered in the native iOS SDK, so we need to manually register it again.

        public static void AutoIntegrate(string appKey, Foundation.NSDictionary localyticsOptions, Foundation.NSDictionary launchOptions)
        {
            Localytics.AutoIntegratePrivate(appKey, localyticsOptions, launchOptions);
            NSObject notificationObserver = NSNotificationCenter.DefaultCenter.AddObserver(UIApplication.DidBecomeActiveNotification, (obj) => { });
        }

        public static void Integrate(string appKey, Foundation.NSDictionary localyticsOptions)
        {
            Localytics.IntegratePrivate(appKey, localyticsOptions);
            NSObject notificationObserver = NSNotificationCenter.DefaultCenter.AddObserver(UIApplication.DidBecomeActiveNotification, (obj) => { });
        }

        public static void AddProfileAttributes(string attribute, LLProfileScope scope, params object[] values)
        {
            Localytics.AddProfileAttributesToSetPrivate(Convertor.ToArray(values), attribute, scope);
        }

        public static void RemoveProfileAttributes(string attribute, LLProfileScope scope, params object[] values)
        {
            Localytics.RemoveProfileAttributesFromSetPrivate(Convertor.ToArray(values), attribute, scope);
        }

        static public bool LoggingEnabled
        {
            get
            {
                return Localytics.IsLoggingEnabledPrivate;
            }
            set
            {
                Localytics.SetLoggingEnabledPrivate(value);
            }
        }

        static public string PushTokenInfo
        {
            get
            {
                return Localytics.PushToken();
            }
        }

        static public bool OptedOut
        {
            get
            {
                return Localytics.IsOptedOut;
            }
            set
            {
                Localytics.SetOptedOut(value);
            }
        }

        static public bool TestModeEnabled
        {
            get
            {
                return Localytics.IsTestModeEnabled;
            }
            set
            {
                Localytics.SetTestModeEnabled(value);
            }
        }

        static public bool PrivacyOptedOut { get => Localytics.IsPrivacyOptedOutPrivate(); set => Localytics.SetPrivacyOptedOutPrivate(value); }

        static public void SetIdentifier(string identifier, string value)
        {
            Localytics.SetIdentifierPrivate(value, identifier);
        }

        static AnalyticsListener analyticsListener = new AnalyticsListener();
        static LocalyticsMessagingListener messagingListener = new LocalyticsMessagingListener();
        static LocalyticsListener localyticsListener = new LocalyticsListener();
        static LocalyticsCallToActionListener callToActionListener = new LocalyticsCallToActionListener();
        static Localytics()
        {
            LocalyticsSDK.UpdatePluginVersion();
            Localytics.SetAnalyticsDelegate(analyticsListener);
            Localytics.SetMessagingDelegate(messagingListener);
            Localytics.SetLocationDelegate(localyticsListener);
            Localytics.SetCallToActionDelegate(callToActionListener);
        }

        static public EventHandler<LocalyticsDidTriggerRegionsEventArgs> LocalyticsDidTriggerRegions;
        static public EventHandler<LocalyticsDidUpdateLocationEventArgs> LocalyticsDidUpdateLocation;
        static public EventHandler<LocalyticsDidUpdateMonitoredGeofencesEventArgs> LocalyticsDidUpdateMonitoredGeofences;
        public sealed class LocalyticsListener : LLLocationDelegate
        {
            public override void LocalyticsDidTriggerRegions(LLRegion[] regions, LLRegionEvent regionEvent)
            {
                Localytics.LocalyticsDidTriggerRegions?.Invoke(this, new LocalyticsDidTriggerRegionsEventArgs(regions, regionEvent));
            }

            public override void LocalyticsDidUpdateLocation(CLLocation location)
            {
                Localytics.LocalyticsDidUpdateLocation?.Invoke(this, new LocalyticsDidUpdateLocationEventArgs(location));
            }

            public override void LocalyticsDidUpdateMonitoredRegions(LLRegion[] addedRegions, LLRegion[] removedRegions)
            {
                Localytics.LocalyticsDidUpdateMonitoredGeofences?.Invoke(null, new LocalyticsDidUpdateMonitoredGeofencesEventArgs(addedRegions, removedRegions));
            }
        }

        internal EventHandler<LocalyticsSessionDidOpenEventArgs> SessionDidOpen;
        internal EventHandler<LocalyticsDidTagEventEventArgs> DidTagEvent;
        internal EventHandler<LocalyticsSessionWillOpenEventArgs> SessionWillOpen;
        internal EventHandler SessionWillClose;
        internal sealed class AnalyticsListener : LLAnalyticsDelegate
        {

            public override void LocalyticsSessionDidOpenHandler(bool isFirst, bool isUpgrade, bool isResume)
            {
                SharedInstance().SessionDidOpen?.Invoke(null, new LocalyticsSessionDidOpenEventArgs(isFirst, isUpgrade, isResume));
            }

            public override void LocalyticsDidTagEventHandler(string eventName, Foundation.NSDictionary attributes, Foundation.NSNumber customerValueIncrease)
            {
                SharedInstance().DidTagEvent?.Invoke(null, LocalyticsDidTagEventEventArgs.CreateUsingDictionary(eventName, attributes, customerValueIncrease?.LongValue));
            }

            public override void LocalyticsSessionWillOpenHandler(bool isFirst, bool isUpgrade, bool isResume)
            {
                SharedInstance().SessionWillOpen?.Invoke(null, new LocalyticsSessionWillOpenEventArgs(isFirst, isUpgrade, isResume));
            }

            public override void LocalyticsSessionWillCloseHandler()
            {
                SharedInstance().SessionWillClose?.Invoke(null, new EventArgs());
            }
        }

        public class InboxWillDispayViewControllerEventArgs : EventArgs { } // No Extra Args.
        public delegate void InboxWillDisplayViewControllerEventHandler(object sender, InboxWillDispayViewControllerEventArgs e);
        public class InboxDidDisplayViewControllerEventArgs : EventArgs { } // No Extra Args.
        public delegate void InboxDidDisplayViewControllerEventHandler(object sender, InboxDidDisplayViewControllerEventArgs e);
        public class InboxWillDismissViewControllerEventArgs : EventArgs { } // No Extra Args.
        public delegate void InboxWillDismissViewControllerEventHandler(object sender, InboxWillDismissViewControllerEventArgs e);
        public class InboxDidDismissViewControllerEventArgs : EventArgs { } // No Extra Args.
        public delegate void InboxDidDismissViewControllerEventHandler(object sender, InboxDidDismissViewControllerEventArgs e);

        public static InboxDidDismissViewControllerEventHandler InboxDidDismissViewControllerEvent;
        public static InboxDidDisplayViewControllerEventHandler InboxDidDisplayViewControllerEvent;
        public static InboxWillDisplayViewControllerEventHandler InboxWillDisplayViewControllerEvent;
        public static InboxWillDismissViewControllerEventHandler InboxWillDismissViewControllerEvent;

        public static Func<UILocalNotification, LLPlacesCampaign, UILocalNotification> PlacesWillDisplayNotification;
        public static Func<UserNotifications.UNMutableNotificationContent, LLPlacesCampaign, UserNotifications.UNMutableNotificationContent> PlacesWillDisplayNotificationContent;

        public sealed class LocalyticsMessagingListener : LLMessagingDelegate
        {
            public override bool LocalyticsShouldShowInAppMessage(LLInAppCampaign campaign)
            {
                return LocalyticsSDK.InAppShouldShowDelegate != null ? LocalyticsSDK.InAppShouldShowDelegate(campaign) : true;
            }

            public override bool LocalyticsShouldDelaySessionStartInAppMessages()
            {
                return LocalyticsSDK.InAppDelaySessionStartMessagesDelegate == null || LocalyticsSDK.InAppDelaySessionStartMessagesDelegate();
            }

            public override LLInAppConfiguration LocalyticsWillDisplayInAppMessage(LLInAppCampaign campaign, LLInAppConfiguration configuration)
            {
                return LocalyticsSDK.InAppWillDisplayDelegate != null ? LocalyticsSDK.InAppWillDisplayDelegate(campaign, configuration) : configuration;
            }

            public override void LocalyticsDidDisplayInAppMessage()
            {
                LocalyticsSDK.InAppDidDisplayEvent?.Invoke(null, new InAppDidDisplayEventArgs());
            }

            public override void LocalyticsWillDismissInAppMessage()
            {
                LocalyticsSDK.InAppWillDismissEvent?.Invoke(null, new InAppWillDismissEventArgs());
            }

            public override void LocalyticsDidDismissInAppMessage()
            {
                LocalyticsSDK.InAppDidDismissEvent?.Invoke(null, new InAppDidDismissEventArgs());
            }

            public override void LocalyticsWillDisplayInboxDetailViewController()
            {
                InboxWillDisplayViewControllerEvent?.Invoke(null, new InboxWillDispayViewControllerEventArgs());
            }

            public override void LocalyticsDidDisplayInboxDetailViewController()
            {
                InboxDidDisplayViewControllerEvent?.Invoke(null, new InboxDidDisplayViewControllerEventArgs());
            }

            public override void LocalyticsWillDismissInboxDetailViewController()
            {
                InboxDidDisplayViewControllerEvent?.Invoke(null, new InboxDidDisplayViewControllerEventArgs());
            }

            public override void LocalyticsDidDismissInboxDetailViewController()
            {
                InboxDidDismissViewControllerEvent?.Invoke(null, new InboxDidDismissViewControllerEventArgs());
            }

            public override bool LocalyticsShouldDisplayPlacesCampaign(LLPlacesCampaign campaign)
            {
                return LocalyticsSDK.PlacesShouldDisplayCampaignDelegate != null ? LocalyticsSDK.PlacesShouldDisplayCampaignDelegate(campaign) : true;
            }

            public override UILocalNotification LocalyticsWillDisplayNotification(UILocalNotification notification, LLPlacesCampaign campaign)
            {
                return PlacesWillDisplayNotification != null ? PlacesWillDisplayNotification(notification, campaign) : notification;
            }

            public override UserNotifications.UNMutableNotificationContent LocalyticsWillDisplayNotificationContent(UserNotifications.UNMutableNotificationContent notification, LLPlacesCampaign campaign)
            {
                return PlacesWillDisplayNotificationContent != null ? PlacesWillDisplayNotificationContent(notification, campaign) : notification;
            }

            public override bool LocalyticsShouldDeeplink(Foundation.NSUrl url)
            {
                return LocalyticsSDK.ShouldDeepLinkDelegate != null ? LocalyticsSDK.ShouldDeepLinkDelegate(url.AbsoluteString) : true;
            }
        }

        public static Func<LLCampaignBase, bool> ShouldPromptForLocationWhenInUsePermission;
        public static Func<LLCampaignBase, bool> ShouldPromptForLocationAlwaysPermission;
        public static Func<LLCampaignBase, bool> ShouldPromptForNotificationPermission;
        public static Func<LLCampaignBase, bool> ShouldDeepLinkToSettings;
        public static Action<CLLocationManager> RequestAlwaysAuthorization;
        public static Action<CLLocationManager> RequestWhenInUseAuthorization;

        public sealed class LocalyticsCallToActionListener : LLCallToActionDelegate
        {
            public override void LocalyticsDidOptOut(bool optOut, LLCampaignBase campaign)
            {
                LocalyticsSDK.DidOptOut?.Invoke(null, new DidOptOutEventArgs(optOut, Convertor.CampaignFrom(campaign)));
            }

            public override void LocalyticsDidPrivacyOptOut(bool optOut, LLCampaignBase campaign)
            {
                LocalyticsSDK.DidPrivacyOptOut?.Invoke(null, new DidOptOutEventArgs(optOut, Convertor.CampaignFrom(campaign)));
            }

            public override bool LocalyticsShouldDeeplink(NSUrl url, LLCampaignBase campaign)
            {
                return LocalyticsSDK.CallToActionShouldDeepLinkDelegate != null ?
                                    LocalyticsSDK.CallToActionShouldDeepLinkDelegate(url.AbsoluteString, Convertor.CampaignFrom(campaign)) : true;
            }

            public override bool LocalyticsShouldPromptForLocationAlwaysPermissions(LLCampaignBase campaign)
            {
                return ShouldPromptForLocationAlwaysPermission == null || ShouldPromptForLocationAlwaysPermission(campaign);
            }

            public override bool LocalyticsShouldPromptForLocationWhenInUsePermissions(LLCampaignBase campaign)
            {
                return ShouldPromptForLocationWhenInUsePermission == null || ShouldPromptForLocationWhenInUsePermission(campaign);
            }

            public override bool LocalyticsShouldPromptForNotificationPermissions(LLCampaignBase campaign)
            {
                return ShouldPromptForNotificationPermission == null || ShouldPromptForNotificationPermission(campaign);
            }

            public override bool LocalyticsShouldDeeplinkToSettings(LLCampaignBase campaign)
            {
                return ShouldDeepLinkToSettings == null || ShouldDeepLinkToSettings(campaign);
            }
            public override void RequestAlwaysAuthorizationFromApp(CLLocationManager locationManager)
            {
                if (RequestAlwaysAuthorization != null) {
                    RequestAlwaysAuthorization(locationManager);
                }
            }
            public override void RequestWhenInUseAuthorizationFromApp(CLLocationManager locationManager)
            {
                if (RequestWhenInUseAuthorization != null) {
                    RequestWhenInUseAuthorization(locationManager);
                }
            }
        }
    }
}
