using System;
using System.Collections.Generic;

using Android.Locations;
using Android.Support.V4.App;

using LocalyticsXamarin.Android;
using LocalyticsXamarin.AndroidPatch;

namespace LocalyticsXamarin.Android
{
	public class LocalyticsEvents
	{
		public delegate void LocalyticsDidTagEvent(string eventName, IDictionary<string, string> attributes, long customerValueIncrease);
		public delegate void LocalyticsSessionDidOpen(bool isFirst, bool isUpgrade, bool isResume);
		public delegate void LocalyticsSessionWillClose();
		public delegate void LocalyticsSessionWillOpen(bool isFirst, bool isUpgrade, bool isResume);

		public delegate void LocalyticsDidDismissInAppMessage();
		public delegate void LocalyticsDidDisplayInAppMessage();
		public delegate void LocalyticsWillDismissInAppMessage();
		public delegate void LocalyticsWillDisplayInAppMessage();
		public delegate bool LocalyticsShouldShowPushNotification(PushCampaign campaign);
		public delegate NotificationCompat.Builder LocalyticsWillShowPushNotification(NotificationCompat.Builder builder, PushCampaign campaign);
		public delegate bool LocalyticsShouldShowPlacesPushNotification(PlacesCampaign campaign);
		public delegate NotificationCompat.Builder LocalyticsWillShowPlacesPushNotification(NotificationCompat.Builder builder, PlacesCampaign campaign);

		public delegate void LocalyticsDidUpdateLocation(Location location);
		public delegate void LocalyticsDidTriggerRegions(IList<Region> regions, LLRegionEvent regionEvent);
		public delegate void LocalyticsDidUpdateMonitoredGeofences(IList<CircularRegion> added, IList<CircularRegion> removed);

		public static event LocalyticsDidTagEvent OnLocalyticsDidTagEvent;
		public static event LocalyticsSessionDidOpen OnLocalyticsSessionDidOpen;
		public static event LocalyticsSessionWillClose OnLocalyticsSessionWillClose;
		public static event LocalyticsSessionWillOpen OnLocalyticsSessionWillOpen;

		public static event LocalyticsDidDismissInAppMessage OnLocalyticsDidDismissInAppMessage;
		public static event LocalyticsDidDisplayInAppMessage OnLocalyticsDidDisplayInAppMessage;
		public static event LocalyticsWillDismissInAppMessage OnLocalyticsWillDismissInAppMessage;
		public static event LocalyticsWillDisplayInAppMessage OnLocalyticsWillDisplayInAppMessage;
		public static event LocalyticsShouldShowPushNotification OnLocalyticsShouldShowPushNotification;
		public static event LocalyticsWillShowPushNotification OnLocalyticsWillShowPushNotification;
		public static event LocalyticsShouldShowPlacesPushNotification OnLocalyticsShouldShowPlacesPushNotification;
		public static event LocalyticsWillShowPlacesPushNotification OnLocalyticsWillShowPlacesPushNotification;

		public static event LocalyticsDidUpdateLocation OnLocalyticsDidUpdateLocation;
		public static event LocalyticsDidTriggerRegions OnLocalyticsDidTriggerRegions;
		public static event LocalyticsDidUpdateMonitoredGeofences OnLocalyticsDidUpdateMonitoredGeofences;

		private static LocalyticsProxyListener llProxyListener;

		private static AnalyticsProxyListener analyticsListener;
		private static MessagingProxyListener messagingListener;
		private static LocationProxyListener locationListener;

		public static void SubscribeToAll() {
			llProxyListener = new LocalyticsProxyListener ();
			analyticsListener = new AnalyticsProxyListener ();
			messagingListener = new MessagingProxyListener ();
			locationListener = new LocationProxyListener ();

			llProxyListener.SetAnalyticsProxyListener (analyticsListener);
			llProxyListener.SetMessagingProxyListener (messagingListener);
			llProxyListener.SetLocationProxyListener (locationListener);
		}

		class AnalyticsProxyListener : Java.Lang.Object, IAnalyticsProxyListener
		{
			public void LocalyticsDidTagEvent (string eventName, IDictionary<string, string> attributes, long customerValueIncrease)
			{
				if (LocalyticsEvents.OnLocalyticsDidTagEvent != null) {
					LocalyticsEvents.OnLocalyticsDidTagEvent (eventName, attributes, customerValueIncrease);
				}
			}

			public void LocalyticsSessionDidOpen (bool isFirst, bool isUpgrade, bool isResume)
			{
				if (LocalyticsEvents.OnLocalyticsSessionDidOpen != null) {
					LocalyticsEvents.OnLocalyticsSessionDidOpen (isFirst, isUpgrade, isResume);
				}
			}

			public void LocalyticsSessionWillClose ()
			{
				if (LocalyticsEvents.OnLocalyticsSessionWillClose != null) {
					LocalyticsEvents.OnLocalyticsSessionWillClose ();
				}
			}

			public void LocalyticsSessionWillOpen (bool isFirst, bool isUpgrade, bool isResume)
			{
				if (LocalyticsEvents.OnLocalyticsSessionWillOpen != null) {
					LocalyticsEvents.OnLocalyticsSessionWillOpen (isFirst, isUpgrade, isResume);
				}
			}
		}

		class MessagingProxyListener : Java.Lang.Object, IMessagingProxyListener
		{
			public void LocalyticsDidDismissInAppMessage ()
			{
				if (LocalyticsEvents.OnLocalyticsDidDismissInAppMessage != null)
					LocalyticsEvents.OnLocalyticsDidDismissInAppMessage ();
			}

			public void LocalyticsDidDisplayInAppMessage ()
			{
				if (LocalyticsEvents.OnLocalyticsDidDisplayInAppMessage != null)
					LocalyticsEvents.OnLocalyticsDidDisplayInAppMessage ();
			}

			public void LocalyticsWillDismissInAppMessage ()
			{
				if (LocalyticsEvents.OnLocalyticsWillDismissInAppMessage != null)
					LocalyticsEvents.OnLocalyticsWillDismissInAppMessage ();
			}

			public void LocalyticsWillDisplayInAppMessage ()
			{
				if (LocalyticsEvents.OnLocalyticsWillDisplayInAppMessage != null)
					LocalyticsEvents.OnLocalyticsWillDisplayInAppMessage ();
			}

			public bool LocalyticsShouldShowPushNotification(PushCampaign campaign)
			{
				if (LocalyticsEvents.OnLocalyticsShouldShowPushNotification != null)
					return LocalyticsEvents.OnLocalyticsShouldShowPushNotification (campaign);
				else
					return true;
			}

			public Java.Lang.Object LocalyticsWillShowPushNotification(Java.Lang.Object builder, PushCampaign campaign)
			{
				if (LocalyticsEvents.OnLocalyticsWillShowPushNotification != null)
					return LocalyticsEvents.OnLocalyticsWillShowPushNotification((NotificationCompat.Builder) builder, campaign);
				else
					return builder;
			}

			public bool LocalyticsShouldShowPlacesPushNotification(PlacesCampaign campaign)
			{
				if (LocalyticsEvents.OnLocalyticsShouldShowPlacesPushNotification != null)
					return LocalyticsEvents.OnLocalyticsShouldShowPlacesPushNotification(campaign);
				else
					return true;
			}

			public Java.Lang.Object LocalyticsWillShowPlacesPushNotification(Java.Lang.Object builder, PlacesCampaign campaign)
			{
				if (LocalyticsEvents.OnLocalyticsWillShowPlacesPushNotification != null)
					return LocalyticsEvents.OnLocalyticsWillShowPlacesPushNotification((NotificationCompat.Builder) builder, campaign);
				else
					return builder;
			}
		}

		class LocationProxyListener : Java.Lang.Object, ILocationProxyListener
		{
			public void LocalyticsDidUpdateLocation(Location location)
			{
				if (LocalyticsEvents.OnLocalyticsDidUpdateLocation != null)
					LocalyticsEvents.OnLocalyticsDidUpdateLocation (location);
			}

			public void LocalyticsDidTriggerRegions(IList<Region> regions, LLRegionEvent regionEvent)
			{
				if (LocalyticsEvents.OnLocalyticsDidTriggerRegions != null)
					LocalyticsEvents.OnLocalyticsDidTriggerRegions(regions, regionEvent);
			}

			public void LocalyticsDidUpdateMonitoredGeofences(IList<CircularRegion> added, IList<CircularRegion> removed)
			{
				if (LocalyticsEvents.OnLocalyticsDidUpdateMonitoredGeofences != null)
					LocalyticsEvents.OnLocalyticsDidUpdateMonitoredGeofences(added, removed);
			}
		}
	}
}

