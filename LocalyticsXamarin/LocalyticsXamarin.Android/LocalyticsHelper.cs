using System;
using System.Collections.Generic;
using LocalyticsXamarin.Shared;
using LocalyticsXamarin.Common;
using NativeInAppCampaign = LocalyticsXamarin.Android.InAppCampaign;
using NativeInAppConfiguration = LocalyticsXamarin.Android.InAppConfiguration;
using NativeInboxCampaign = LocalyticsXamarin.Android.InboxCampaign;
using NativeImpressionType = LocalyticsXamarin.Android.Localytics.ImpressionType;
using NativePlacesCampaign = LocalyticsXamarin.Android.PlacesCampaign;
using NativePushCampaign = LocalyticsXamarin.Android.PushCampaign;
using Android.Support.V4.App;
using Android.Runtime;

namespace LocalyticsXamarin.Android
{
	public partial class Localytics
	{
		public static InAppDidDisplayEventHandler InAppDidDisplayEvent;
		public static InAppWillDismissEventHandler InAppWillDismissEvent;
		public static InAppDidDismissEventHandler InAppDidDismissEvent;
		public static Func<string, bool> ShouldDeepLink;
		public static Func<bool> InAppDelaySessionStartMessages;
		public static Func<NativeInAppCampaign, bool> InAppShouldShow;
		public static Func<NativePlacesCampaign, bool> PlacesShouldDisplayCampaign;
		public static Func<NativePushCampaign, bool> ShouldShowPushNotification;
		public static Func<NativeInAppCampaign, NativeInAppConfiguration, NativeInAppConfiguration> InAppWillDisplay;
		public static Func<NotificationCompat.Builder, NativePlacesCampaign, NotificationCompat.Builder> WillShowPlacesPushNotification;
		public static Func<NotificationCompat.Builder, NativePushCampaign, NotificationCompat.Builder> WillShowPushNotification;

		[global::Android.Runtime.Register("mono/com/localytics/android/MessagingListenerV2Implementor")]
		internal sealed partial class IMessagingListenerV2Implementor : global::Java.Lang.Object, IMessagingListenerV2
		{
			//object sender;

			public IMessagingListenerV2Implementor()
				: base(
					global::Android.Runtime.JNIEnv.StartCreateInstance("mono/com/localytics/android/MessagingListenerV2Implementor", "()V"),
					JniHandleOwnership.TransferLocalRef)
			{
				global::Android.Runtime.JNIEnv.FinishCreateInstance(((global::Java.Lang.Object)this).Handle, "()V");
				//this.sender = sender;
			}

			public void LocalyticsDidDisplayInAppMessage()
			{
				var __h = InAppDidDisplayEvent;
				if (__h != null)
					__h(null, new InAppDidDisplayEventArgs());
			}

			public void LocalyticsWillDismissInAppMessage()
			{
				var __h = InAppWillDismissEvent;
				if (__h != null)
					__h(null, new InAppWillDismissEventArgs());
			}

			public void LocalyticsDidDismissInAppMessage()
			{
				var __h = InAppDidDismissEvent;
				if (__h != null)
					__h(null, new InAppDidDismissEventArgs());
			}

			public bool LocalyticsShouldDeeplink(string p0)
			{
				var __h = ShouldDeepLink;
				if (__h != null)
					return __h(p0);
				return true;
			}

			public bool LocalyticsShouldDelaySessionStartInAppMessages()
			{
				var __h = InAppDelaySessionStartMessages;
				if (__h != null)
					return __h();
				return true;
			}

			public bool LocalyticsShouldShowInAppMessage(global::LocalyticsXamarin.Android.InAppCampaign p0)
			{
				var __h = InAppShouldShow;
				if (__h != null)
					return __h(p0);
				return true;
			}

			public bool LocalyticsShouldShowPlacesPushNotification(global::LocalyticsXamarin.Android.PlacesCampaign p0)
			{
				var __h = PlacesShouldDisplayCampaign;
				if (__h != null)
					return __h(p0);
				return true;
			}

			public bool LocalyticsShouldShowPushNotification(global::LocalyticsXamarin.Android.PushCampaign p0)
			{
				var __h = ShouldShowPushNotification;
				if (__h != null)
					return __h(p0);
				return true;
			}

			public global::LocalyticsXamarin.Android.InAppConfiguration LocalyticsWillDisplayInAppMessage(global::LocalyticsXamarin.Android.InAppCampaign p0, global::LocalyticsXamarin.Android.InAppConfiguration p1)
			{
				var __h = InAppWillDisplay;
				if (__h != null)
					return __h(p0, p1);
				return p1;
			}

			public global::Android.Support.V4.App.NotificationCompat.Builder LocalyticsWillShowPlacesPushNotification(global::Android.Support.V4.App.NotificationCompat.Builder p0, global::LocalyticsXamarin.Android.PlacesCampaign p1)
			{
				var __h = WillShowPlacesPushNotification;
				if (__h != null)
					return __h(p0, p1);
				return p0;
			}
			public global::Android.Support.V4.App.NotificationCompat.Builder LocalyticsWillShowPushNotification(global::Android.Support.V4.App.NotificationCompat.Builder p0, global::LocalyticsXamarin.Android.PushCampaign p1)
			{
				var __h = WillShowPushNotification;
				if (__h != null)
					return __h(p0, p1);
				return p0;
			}

			internal static bool __IsEmpty(IMessagingListenerV2Implementor value)
			{
				return InAppDidDisplayEvent != null && InAppWillDismissEvent != null &&
					InAppDidDismissEvent != null && ShouldDeepLink != null &&
					InAppDelaySessionStartMessages != null && InAppShouldShow != null &&
					PlacesShouldDisplayCampaign != null && ShouldShowPushNotification != null &&
					InAppWillDisplay != null && WillShowPlacesPushNotification != null &&
					WillShowPushNotification != null;
			}
		}
	}

	internal sealed partial class IInboxRefreshListenerImplementor
	{
		Action<LocalyticsXamarin.Android.InboxCampaign[]> inboxRefresh;
		public IInboxRefreshListenerImplementor() : this(null)
		{
			this.Handler += handleRefresh;
		}

		void handleRefresh(object sender, InboxRefreshEventArgs args)
		{
			Action<LocalyticsXamarin.Android.InboxCampaign[]> callback = inboxRefresh;
			if (callback != null)
			{
				//IList<InboxCampaign> list = args.P0;
				callback(null);
			}
		}

		public void SetCallback(Action<LocalyticsXamarin.Android.InboxCampaign[]> inboxCampaignsDelegate)
		{
			inboxRefresh = inboxCampaignsDelegate;
		}
	}

	public sealed class InboxRefreshImplementationPlatform
	{
		readonly IInboxRefreshListenerImplementor implementor = new IInboxRefreshListenerImplementor();
		public void SetCallback(Action<LocalyticsXamarin.Android.InboxCampaign[]> inboxCampaignsDelegate)
		{
			implementor.SetCallback(inboxCampaignsDelegate);
		}
	}
}
