using System;
using System.Collections;
using CoreLocation;
using Foundation;
using UIKit;
using System.Collections.Generic;
using LocalyticsXamarin.Shared;

namespace LocalyticsXamarin.IOS
{
    public partial class Localytics
    {
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

        public static void TagCustomerLoggedIn(IDictionary<string, object> customerProps, string methodName, NSDictionary attributes)
        {
            var customer = Convertor.toCustomer(customerProps);
            Localytics.TagCustomerLoggedInPrivate(customer, methodName, attributes);
        }

        // Not Recommended because the AppDelegate is implemented as c# callbacks and swizzling is going to have to understand that it's a proxied object.
        public static void AutoIntegrate(string appKey, Foundation.NSDictionary localyticsOptions, Foundation.NSDictionary launchOptions)
        {
            Localytics.AutoIntegratePrivate(appKey, localyticsOptions, launchOptions);
        }
        public static void Integrate(string appKey, Foundation.NSDictionary localyticsOptions)
        {
            Localytics.IntegratePrivate(appKey, localyticsOptions);
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
        static LocationListener locationListener = new LocationListener();
        static Localytics()
        {
			LocalyticsPlatformCommon.UpdatePluginVersion();
            Localytics.SetAnalyticsDelegatePrivate(analyticsListener);
            Localytics.SetMessagingDelegatePrivate(messagingListener);
            Localytics.SetLocationDelegatePrivate(locationListener);
        }

        public class LocationTriggerRegionsEventArgs : EventArgs
        {
            public LLRegion[] regions;
            public LLRegionEvent regionEvent;

            public LocationTriggerRegionsEventArgs(LLRegion[] regions, LLRegionEvent regionEvent)
            {
                this.regions = regions;
                this.regionEvent = regionEvent;
            }
        }
        public delegate void LocationDidTriggerRegionsEventHandler(object sender, LocationTriggerRegionsEventArgs e);
        static public event LocationDidTriggerRegionsEventHandler LocationDidTriggerRegionsEvent;

        public class LocationUpdateEventArgs : EventArgs
        {
            public CLLocation location;
            public LocationUpdateEventArgs(CLLocation location)
            {
                this.location = location;
            }
        }
        public delegate void LocationUpdateEventHandler(object sender, LocationUpdateEventArgs e);
        static public event LocationUpdateEventHandler LocationUpdateEvent;

        public class LocationMonitoredRegionsEventArgs : EventArgs
        {
            public LLRegion[] addedRegions, removedRegions;

            public LocationMonitoredRegionsEventArgs(LLRegion[] addedRegions, LLRegion[] removedRegions)
            {
                this.addedRegions = addedRegions;
                this.removedRegions = removedRegions;
            }
        }
        public delegate void LocationDidUpdateMonitoredRegionsEventHandler(object sender, LocationMonitoredRegionsEventArgs e);
        static public event LocationDidUpdateMonitoredRegionsEventHandler LocationDidUpdateMonitoredRegionsEvent;


        public sealed class LocationListener : LLLocationDelegate
        {
            public override void LocalyticsDidTriggerRegions(LLRegion[] regions, LLRegionEvent regionEvent)
            {
                LocationDidTriggerRegionsEvent?.Invoke(this, new LocationTriggerRegionsEventArgs(regions, regionEvent));
            }

            public override void LocalyticsDidUpdateLocation(CLLocation location)
            {
                LocationUpdateEvent?.Invoke(this, new LocationUpdateEventArgs(location));
            }

            public override void LocalyticsDidUpdateMonitoredRegions(LLRegion[] addedRegions, LLRegion[] removedRegions)
            {
                LocationDidUpdateMonitoredRegionsEvent?.Invoke(null, new LocationMonitoredRegionsEventArgs(addedRegions, removedRegions));
            }
        }

        public class SessionEventArgs : EventArgs
        {
            public bool First { get; set; }
            public bool Upgrade { get; set; }
            public bool Resume { get; set; }

            public SessionEventArgs(bool isFirst, bool isUpgrade, bool isResume)
            {
                First = isFirst;
                Upgrade = isUpgrade;
                Resume = isResume;
            }

            public override string ToString()
            {
                return string.Format("First:{0} Upgrade:{1} Resume:{2}", First, Upgrade, Resume);
            }
        }

        public class SessionDidOpenEventArgs : SessionEventArgs
        {
            public SessionDidOpenEventArgs(bool isFirst, bool isUpgrade, bool isResume)
                : base(isFirst, isUpgrade, isResume)
            {
            }
        }

        public delegate void SessionDidOpenEventHandler(object sender, SessionDidOpenEventArgs e);


        static public event SessionDidOpenEventHandler SessionDidOpenEvent;

        public class SessionDidTagEventArgs : EventArgs
        {
            public string EventName { get; set; }
            public IDictionary Attributes { get; set; }
            public double? customerValue { get; set; }
            public SessionDidTagEventArgs(string name,
                                          IDictionary attribs,
                                          double? customerValue)
            {
                EventName = name;
                Attributes = attribs;
                this.customerValue = customerValue;
            }
            public override string ToString()
            {
                return string.Format("EventName:{0} customerValue:{1} Attributes:{2}", EventName, customerValue, Attributes.ToString());
            }
        }
        public delegate void SessionDidTagEventHandler(object sender, SessionDidTagEventArgs e);
        static public event SessionDidTagEventHandler SessionDidTagEvent;

        public class SessionWillOpenEventArgs : SessionEventArgs
        {
            public SessionWillOpenEventArgs(bool isFirst, bool isUpgrade, bool isResume)
                : base(isFirst, isUpgrade, isResume)
            {
            }
        }
        public delegate void SessionWillOpenEventHandler(object sender, SessionWillOpenEventArgs e);
        static public event SessionWillOpenEventHandler SessionWillOpenEvent;


        public class SessionWillCloseEventArgs : EventArgs
        {
            // No Extra Args.

        }
        public delegate void SessionWillCloseEventHandler(object sender, SessionWillCloseEventArgs e);
        static public event SessionWillCloseEventHandler SessionWillCloseEvent;

        sealed class AnalyticsListener : LLAnalyticsDelegate
        {
            public override void LocalyticsSessionDidOpen(bool isFirst, bool isUpgrade, bool isResume)
            {
                SessionDidOpenEvent?.Invoke(null, new SessionDidOpenEventArgs(isFirst, isUpgrade, isResume));
            }

            public override void LocalyticsDidTagEvent(string eventName, Foundation.NSDictionary attributes, Foundation.NSNumber customerValueIncrease)
            {
                SessionDidTagEvent?.Invoke(null, new SessionDidTagEventArgs(eventName, attributes, customerValueIncrease?.DoubleValue));
            }

            public override void LocalyticsSessionWillOpen(bool isFirst, bool isUpgrade, bool isResume)
            {
                SessionWillOpenEvent?.Invoke(null, new SessionWillOpenEventArgs(isFirst, isUpgrade, isResume));
            }

            public override void LocalyticsSessionWillClose()
            {
                SessionWillCloseEvent?.Invoke(null, new SessionWillCloseEventArgs());
            }
        }


        public class InAppEventArgs : EventArgs { } // No Extra Args.

        public class InAppDidDisplayEventArgs : EventArgs { } // No Extra Args.
        public delegate void InAppDidDisplayEventHandler(object sender, InAppDidDisplayEventArgs e);
        public class InAppWillDismissEventArgs : EventArgs { } // No Extra Args.
        public delegate void InAppWillDismissEventHandler(object sender, InAppWillDismissEventArgs e);
        public class InAppDidDismissEventArgs : EventArgs { } // No Extra Args.
        public delegate void InAppDidDismissEventHandler(object sender, InAppDidDismissEventArgs e);


        public static InAppDidDisplayEventHandler InAppDidDisplayEvent;
        public static InAppWillDismissEventHandler InAppWillDismissEvent;
        public static InAppDidDismissEventHandler InAppDidDismissEvent;

        public class InboxWillDispayViewControllerEventArgs : EventArgs { } // No Extra Args.
        public delegate void InboxWillDisplayViewControllerEventHandler(object sender, InboxWillDispayViewControllerEventArgs e);
        public class InboxDidDisplayViewControllerEventArgs : EventArgs { } // No Extra Args.
        public delegate void InboxDidDisplayViewControllerEventHandler(object sender, InboxDidDisplayViewControllerEventArgs e);
        public class InboxWillDismissViewControllerEventArgs : EventArgs { } // No Extra Args.
        public delegate void InboxWillDismissViewControllerEventHandler(object sender, InboxWillDismissViewControllerEventArgs e);
        public class InboxDidDismissViewControllerEventArgs : EventArgs { } // No Extra Args.
        public delegate void InboxDidDismissViewControllerEventHandler(object sender, InboxDidDismissViewControllerEventArgs e);

        public delegate void InAppShouldShowDelegte(LLInAppCampaign campaign);

        static public InboxDidDismissViewControllerEventHandler InboxDidDismissViewControllerEvent;
        static public InboxDidDisplayViewControllerEventHandler InboxDidDisplayViewControllerEvent;
        static public InboxWillDisplayViewControllerEventHandler InboxWillDisplayViewControllerEvent;
        static public InboxWillDismissViewControllerEventHandler InboxWillDismissViewControllerEvent;
        public static Func<bool> InAppDelaySessionStartMessages;

        public static class NativeHelper
        {
            //public static void OnSessionDidOpenEvent(SessionDidOpenEventArgs eventArgs)
            //{
            //    SessionDidOpenEvent?.Invoke(null, eventArgs);
            //}
            //public static void OnSessionDidTagEvent(SessionDidTagEventArgs eventArgs)
            //{
            //    SessionDidTagEvent?.Invoke(null, eventArgs);
            //}
            //public static void OnSessionWillOpenEvent(SessionWillOpenEventArgs eventArgs)
            //{
            //    SessionWillOpenEvent?.Invoke(null, eventArgs);
            //}
            //public static void OnSessionWillCloseEvent()
            //{
            //    SessionWillCloseEvent?.Invoke(null, new SessionWillCloseEventArgs());
            //}

            public static void OnInAppDidDisplayEvent()
            {
                InAppDidDisplayEvent?.Invoke(null, new InAppDidDisplayEventArgs());
            }

            public static void OnInAppWillDismissEvent()
            {
                InAppWillDismissEvent?.Invoke(null, new InAppWillDismissEventArgs());
            }

            public static void OnInAppDidDismissEvent()
            {
                InAppDidDismissEvent?.Invoke(null, new InAppDidDismissEventArgs());
            }

            public static void OnInboxWillDisplayViewControllerEvent()
            {
                InboxWillDisplayViewControllerEvent?.Invoke(null, new InboxWillDispayViewControllerEventArgs());
            }

            public static void OnInboxDidDisplayViewControllerEvent()
            {
                InboxDidDisplayViewControllerEvent?.Invoke(null, new InboxDidDisplayViewControllerEventArgs());
            }

            public static void OnInboxWillDismissViewControllerEvent()
            {
                InboxDidDisplayViewControllerEvent?.Invoke(null, new InboxDidDisplayViewControllerEventArgs());
            }

            public static void OnInboxDidDismissViewControllerEvent()
            {
                InboxDidDismissViewControllerEvent?.Invoke(null, new InboxDidDismissViewControllerEventArgs());
            }
        }

        public static Func<LLInAppCampaign, bool> InAppShouldShow;

        public static Func<LLInAppCampaign, LLInAppConfiguration, LLInAppConfiguration> InAppWillDisplay;
        public static Func<LLPlacesCampaign, bool> PlacesShouldDisplayCampaign;
        public static Func<UILocalNotification, LLPlacesCampaign, UILocalNotification> PlacesWillDisplayNotification;
        public static Func<UserNotifications.UNMutableNotificationContent, LLPlacesCampaign, UserNotifications.UNMutableNotificationContent> PlacesWillDisplayNotificationContent;
        public static Func<Foundation.NSUrl, bool> ShouldDeepLink;

        public sealed class LocalyticsMessagingListener : LLMessagingDelegate
        {
            public override bool LocalyticsShouldShowInAppMessage(LLInAppCampaign campaign)
            {
                return InAppShouldShow != null ? InAppShouldShow(campaign) : true;
            }

            public override bool LocalyticsShouldDelaySessionStartInAppMessages()
            {
                return InAppDelaySessionStartMessages == null || InAppDelaySessionStartMessages();
            }

            public override LLInAppConfiguration LocalyticsWillDisplayInAppMessage(LLInAppCampaign campaign, LLInAppConfiguration configuration)
            {
                return InAppWillDisplay != null ? InAppWillDisplay(campaign, configuration) : configuration;
            }

            public override void LocalyticsDidDisplayInAppMessage()
            {
                Localytics.NativeHelper.OnInAppDidDisplayEvent();
            }

            public override void LocalyticsWillDismissInAppMessage()
            {
                Localytics.NativeHelper.OnInAppWillDismissEvent();
            }

            public override void LocalyticsDidDismissInAppMessage()
            {
                Localytics.NativeHelper.OnInAppDidDismissEvent();
            }

            public override void LocalyticsWillDisplayInboxDetailViewController()
            {
                Localytics.NativeHelper.OnInboxWillDismissViewControllerEvent();
            }

            public override void LocalyticsDidDisplayInboxDetailViewController()
            {
                Localytics.NativeHelper.OnInboxDidDisplayViewControllerEvent();
            }

            public override void LocalyticsWillDismissInboxDetailViewController()
            {
                Localytics.NativeHelper.OnInboxWillDismissViewControllerEvent();
            }

            public override void LocalyticsDidDismissInboxDetailViewController()
            {
                Localytics.NativeHelper.OnInboxDidDismissViewControllerEvent();
            }

            public override bool LocalyticsShouldDisplayPlacesCampaign(LLPlacesCampaign campaign)
            {
                return PlacesShouldDisplayCampaign != null ? PlacesShouldDisplayCampaign(campaign) : true;
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
                return ShouldDeepLink != null ? ShouldDeepLink(url) : true;
            }
        }
    }
}
