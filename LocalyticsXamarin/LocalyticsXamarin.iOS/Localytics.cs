using System;
using System.Collections;
using CoreLocation;
using Foundation;
using UIKit;
using System.Collections.Generic;
using LocalyticsXamarin.Shared;
using LocalyticsXamarin.Common;
using System.Runtime.CompilerServices;

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

        /* Events ... */
		public event EventHandler<LocalyticsDidTriggerRegionsEventArgs> LocalyticsDidTriggerRegions
        {
            add
            {
				LocationListener.LocationDidTriggerRegionsEvent += value;
            }
            remove
            {
				LocationListener.LocationDidTriggerRegionsEvent -= value;
            }
        }

		public event EventHandler<LocalyticsDidUpdateLocationEventArgs> LocalyticsDidUpdateLocation
        {
            add
            {
				LocationListener.LocationUpdateEvent += value;
            }
            remove
            {
				LocationListener.LocationUpdateEvent -= value;
            }
        }

        public event EventHandler<LocalyticsDidUpdateMonitoredGeofencesEventArgs> LocalyticsDidUpdateMonitoredGeofences
        {
            add
            {
				LocationListener.LocationDidUpdateMonitoredRegionsEvent += value;
            }
            remove
            {
				LocationListener.LocationDidUpdateMonitoredRegionsEvent -= value;
            }
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

		public class LocalyticsDidTriggerRegionsEventArgs : EventArgs
		{
			public LLRegion[] regions;
			public LLRegionEvent regionEvent;

			public LocalyticsDidTriggerRegionsEventArgs(LLRegion[] regions, LLRegionEvent regionEvent)
			{
				this.regions = regions;
				this.regionEvent = regionEvent;
			}
		}

		public class LocalyticsDidUpdateLocationEventArgs : EventArgs
		{
			public CLLocation location;
			public LocalyticsDidUpdateLocationEventArgs(CLLocation location)
			{
				this.location = location;
			}
		}

		public class LocalyticsDidUpdateMonitoredGeofencesEventArgs : EventArgs
		{
			public LLRegion[] addedRegions, removedRegions;

			public LocalyticsDidUpdateMonitoredGeofencesEventArgs(LLRegion[] addedRegions, LLRegion[] removedRegions)
			{
				this.addedRegions = addedRegions;
				this.removedRegions = removedRegions;
			}
		}

		public sealed class LocationListener : LLLocationDelegate
		{
			static public EventHandler<LocalyticsDidTriggerRegionsEventArgs> LocationDidTriggerRegionsEvent;
			static public EventHandler<LocalyticsDidUpdateLocationEventArgs> LocationUpdateEvent;
			static public EventHandler<LocalyticsDidUpdateMonitoredGeofencesEventArgs> LocationDidUpdateMonitoredRegionsEvent;
			public override void LocalyticsDidTriggerRegions(LLRegion[] regions, LLRegionEvent regionEvent)
			{
				LocationDidTriggerRegionsEvent?.Invoke(this, new LocalyticsDidTriggerRegionsEventArgs(regions, regionEvent));
			}

			public override void LocalyticsDidUpdateLocation(CLLocation location)
			{
				LocationUpdateEvent?.Invoke(this, new LocalyticsDidUpdateLocationEventArgs(location));
			}

			public override void LocalyticsDidUpdateMonitoredRegions(LLRegion[] addedRegions, LLRegion[] removedRegions)
			{
				LocationDidUpdateMonitoredRegionsEvent?.Invoke(null, new LocalyticsDidUpdateMonitoredGeofencesEventArgs(addedRegions, removedRegions));
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

		public class LocalyticsSessionDidOpenEventArgs : SessionEventArgs
		{
			public LocalyticsSessionDidOpenEventArgs(bool isFirst, bool isUpgrade, bool isResume)
				: base(isFirst, isUpgrade, isResume)
			{
			}
		}
  
		public class LocalyticsDidTagEventEventArgs : EventArgs
		{
			public string EventName { get; set; }
			public IDictionary Attributes { get; set; }
			public double? customerValue { get; set; }
			public LocalyticsDidTagEventEventArgs(string name,
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
	
		public class LocalyticsSessionWillOpenEventArgs : SessionEventArgs
		{
			public LocalyticsSessionWillOpenEventArgs(bool isFirst, bool isUpgrade, bool isResume)
				: base(isFirst, isUpgrade, isResume)
			{
			}
		}

		public class LocalyticsSessionWillCloseEventArgs : EventArgs
		{
			// No Extra Args.

		}

		public event EventHandler<LocalyticsDidTagEventEventArgs> LocalyticsDidTagEvent
        {
            add
            {
				AnalyticsListener.SessionDidTagEvent += value;
            }
            remove
            {
				AnalyticsListener.SessionDidTagEvent -= value;
            }
        }

        public event EventHandler<LocalyticsSessionDidOpenEventArgs> LocalyticsSessionDidOpen
        {
            add
            {
				AnalyticsListener.SessionDidOpenEvent += value;
            }
            remove
            {
				AnalyticsListener.SessionDidOpenEvent -= value;
            }
        }

		public event EventHandler<LocalyticsSessionWillCloseEventArgs> LocalyticsSessionWillClose
        {
            add
            {
				AnalyticsListener.SessionWillCloseEvent += value;
            }
            remove
            {
				AnalyticsListener.SessionWillCloseEvent -= value;
            }
        }

        public event EventHandler<LocalyticsSessionWillOpenEventArgs> LocalyticsSessionWillOpen
        {
            add
            {
				AnalyticsListener.SessionWillOpenEvent += value;
            }
            remove
            {
				AnalyticsListener.SessionWillOpenEvent -= value;
            }
        }

		sealed class AnalyticsListener : LLAnalyticsDelegate
		{
			static internal EventHandler<LocalyticsSessionDidOpenEventArgs> SessionDidOpenEvent;
			static internal EventHandler<LocalyticsDidTagEventEventArgs> SessionDidTagEvent;
			static internal EventHandler<LocalyticsSessionWillOpenEventArgs> SessionWillOpenEvent;
			static internal EventHandler<LocalyticsSessionWillCloseEventArgs> SessionWillCloseEvent;

			public override void LocalyticsSessionDidOpen(bool isFirst, bool isUpgrade, bool isResume)
			{
				SessionDidOpenEvent?.Invoke(null, new LocalyticsSessionDidOpenEventArgs(isFirst, isUpgrade, isResume));
			}

			public override void LocalyticsDidTagEvent(string eventName, Foundation.NSDictionary attributes, Foundation.NSNumber customerValueIncrease)
			{
				SessionDidTagEvent?.Invoke(null, new LocalyticsDidTagEventEventArgs(eventName, attributes, customerValueIncrease?.DoubleValue));
			}

			public override void LocalyticsSessionWillOpen(bool isFirst, bool isUpgrade, bool isResume)
			{
				SessionWillOpenEvent?.Invoke(null, new LocalyticsSessionWillOpenEventArgs(isFirst, isUpgrade, isResume));
			}

			public override void LocalyticsSessionWillClose()
			{
				SessionWillCloseEvent?.Invoke(null, new LocalyticsSessionWillCloseEventArgs());
			}
		}

		public static InAppDidDisplayEventHandler InAppDidDisplayEvent;
		public static InAppWillDismissEventHandler InAppWillDismissEvent;
		public static InAppDidDismissEventHandler InAppDidDismissEvent;
		public static Func<bool> InAppDelaySessionStartMessages;

		public class InboxWillDispayViewControllerEventArgs : EventArgs { } // No Extra Args.
		public delegate void InboxWillDisplayViewControllerEventHandler(object sender, InboxWillDispayViewControllerEventArgs e);
		public class InboxDidDisplayViewControllerEventArgs : EventArgs { } // No Extra Args.
		public delegate void InboxDidDisplayViewControllerEventHandler(object sender, InboxDidDisplayViewControllerEventArgs e);
		public class InboxWillDismissViewControllerEventArgs : EventArgs { } // No Extra Args.
		public delegate void InboxWillDismissViewControllerEventHandler(object sender, InboxWillDismissViewControllerEventArgs e);
		public class InboxDidDismissViewControllerEventArgs : EventArgs { } // No Extra Args.
		public delegate void InboxDidDismissViewControllerEventHandler(object sender, InboxDidDismissViewControllerEventArgs e);

		static public InboxDidDismissViewControllerEventHandler InboxDidDismissViewControllerEvent;
		static public InboxDidDisplayViewControllerEventHandler InboxDidDisplayViewControllerEvent;
		static public InboxWillDisplayViewControllerEventHandler InboxWillDisplayViewControllerEvent;
		static public InboxWillDismissViewControllerEventHandler InboxWillDismissViewControllerEvent;

		public static Func<LLInAppCampaign, bool> InAppShouldShow;
		public static Func<string, bool> ShouldDeepLink;
		public static Func<LLInAppCampaign, LLInAppConfiguration, LLInAppConfiguration> InAppWillDisplay;

		public static Func<LLPlacesCampaign, bool> PlacesShouldDisplayCampaign;
		public static Func<UILocalNotification, LLPlacesCampaign, UILocalNotification> PlacesWillDisplayNotification;
		public static Func<UserNotifications.UNMutableNotificationContent, LLPlacesCampaign, UserNotifications.UNMutableNotificationContent> PlacesWillDisplayNotificationContent;

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
				InAppDidDisplayEvent?.Invoke(null, new InAppDidDisplayEventArgs());
			}

			public override void LocalyticsWillDismissInAppMessage()
			{
				InAppWillDismissEvent?.Invoke(null, new InAppWillDismissEventArgs());
			}

			public override void LocalyticsDidDismissInAppMessage()
			{
				InAppDidDismissEvent?.Invoke(null, new InAppDidDismissEventArgs());
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
				return ShouldDeepLink != null ? ShouldDeepLink(url.AbsoluteString) : true;
			}
		}
	}
}
