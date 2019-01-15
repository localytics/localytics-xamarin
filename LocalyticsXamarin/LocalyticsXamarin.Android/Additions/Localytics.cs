using System;
using System.Runtime.CompilerServices;
using LocalyticsXamarin.Common;
using LocalyticsXamarin.Shared;
using Android.Runtime;
using Android.Support.V4.App;

using NativeInAppCampaign = LocalyticsXamarin.Android.InAppCampaign;
using NativeInboxCampaign = LocalyticsXamarin.Android.InboxCampaign;
using NativeImpressionType = LocalyticsXamarin.Android.Localytics.ImpressionType;
using NativePlacesCampaign = LocalyticsXamarin.Android.PlacesCampaign;
using NativePushCampaign = LocalyticsXamarin.Android.PushCampaign;

namespace LocalyticsXamarin.Android
{
    public partial class DidTagEventEventArgs
    { 
        public double? CustomerValue {
            get {
                return CustomerValueLong;
            }
        }
    }

    public partial class Localytics
	{
		static Localytics()
		{
			LocalyticsSDK.UpdatePluginVersion();
			Localytics.SetMessagingListener(new MessagingListenerImplementation());
            Localytics.SetCallToActionListener(new CTAListenerImplementation());
		}

		static Localytics _instance;

		[MethodImpl(MethodImplOptions.Synchronized)]
		internal static Localytics SharedInstance()
		{
			if (_instance == null) {
				_instance = new Localytics();
			}
			return _instance;
		}

        public static Func<NativePushCampaign, bool> ShouldShowPushNotification;
        public static Func<NotificationCompat.Builder, NativePlacesCampaign, NotificationCompat.Builder> WillShowPlacesPushNotification;
        public static Func<NotificationCompat.Builder, NativePushCampaign, NotificationCompat.Builder> WillShowPushNotification;


        internal sealed class MessagingListenerImplementation : MessagingListenerV2Adapter
        {
            public override void LocalyticsDidDisplayInAppMessage()
            {
                var __h = LocalyticsSDK.InAppDidDisplayEvent;
                if (__h != null)
                    __h(null, new InAppDidDisplayEventArgs());
            }

            public override void LocalyticsWillDismissInAppMessage()
            {
                var __h = LocalyticsSDK.InAppWillDismissEvent;
                if (__h != null)
                    __h(null, new InAppWillDismissEventArgs());
            }

            public override void LocalyticsDidDismissInAppMessage()
            {
                var __h = LocalyticsSDK.InAppDidDismissEvent;
                if (__h != null)
                    __h(null, new InAppDidDismissEventArgs());
            }

            public override bool LocalyticsShouldDeeplink(string p0)
            {
                var __h = LocalyticsSDK.ShouldDeepLinkDelegate;
                if (__h != null)
                    return __h(p0);
                return true;
            }

            public override bool LocalyticsShouldDelaySessionStartInAppMessages()
            {
                var __h = LocalyticsSDK.InAppDelaySessionStartMessagesDelegate;
                // By Default we should not delay. i.e., when no delegate is defined.
                if (__h != null)
                    return __h();
                return false; // Dont Delay Session start.
            }

            public override bool LocalyticsShouldShowInAppMessage(global::LocalyticsXamarin.Android.InAppCampaign p0)
            {
                var __h = LocalyticsSDK.InAppShouldShowDelegate;
                if (__h != null)
                    return __h(p0);
                return true;
            }

            public override bool LocalyticsShouldShowPlacesPushNotification(Android.PlacesCampaign p0)
            {
                var __h = LocalyticsSDK.PlacesShouldDisplayCampaignDelegate;
                if (__h != null)
                    return __h(p0);
                return true;
            }

            public override bool LocalyticsShouldShowPushNotification(global::LocalyticsXamarin.Android.PushCampaign p0)
            {
                var __h = ShouldShowPushNotification;
                if (__h != null)
                    return __h(p0);
                return true;
            }

            public override global::LocalyticsXamarin.Android.InAppConfiguration LocalyticsWillDisplayInAppMessage(global::LocalyticsXamarin.Android.InAppCampaign p0, global::LocalyticsXamarin.Android.InAppConfiguration p1)
            {
                var __h = LocalyticsSDK.InAppWillDisplayDelegate;
                if (__h != null)
                    return __h(p0, p1);
                return p1;
            }

            public override global::Android.Support.V4.App.NotificationCompat.Builder LocalyticsWillShowPlacesPushNotification(global::Android.Support.V4.App.NotificationCompat.Builder p0, global::LocalyticsXamarin.Android.PlacesCampaign p1)
            {
                var __h = WillShowPlacesPushNotification;
                if (__h != null)
                    return __h(p0, p1);
                return p0;
            }
            public override NotificationCompat.Builder LocalyticsWillShowPushNotification(NotificationCompat.Builder p0, Android.PushCampaign p1)
            {
                var __h = WillShowPushNotification;
                if (__h != null)
                    return __h(p0, p1);
                return p0;
            }
        }

        public static Func<LocalyticsXamarin.Android.Campaign, bool> ShouldPromptForLocationPermission;
        public static Func<global::Android.Content.Intent, LocalyticsXamarin.Android.Campaign, bool> DeeplinkToSettings;

        public class CTAListenerImplementation : LocalyticsXamarin.Android.CallToActionListenerAdapterV2
        {
            public override bool LocalyticsShouldDeeplink(string p0, LocalyticsXamarin.Android.Campaign p1)
            {
                if (LocalyticsSDK.CallToActionShouldDeepLinkDelegate != null) {
                    return LocalyticsSDK.CallToActionShouldDeepLinkDelegate(p0, Convertor.CampaignFrom(p1));
                }
                return true;
            }
            public override void LocalyticsDidOptOut(bool p0, LocalyticsXamarin.Android.Campaign p1)
            {
                if (LocalyticsSDK.DidOptOut != null) {
                    LocalyticsSDK.DidOptOut(null, new DidOptOutEventArgs(p0, Convertor.CampaignFrom(p1)));
                }
            }

            public override void LocalyticsDidPrivacyOptOut(bool p0, LocalyticsXamarin.Android.Campaign p1)
            {
                if (LocalyticsSDK.DidPrivacyOptOut != null) {
                    LocalyticsSDK.DidPrivacyOptOut(null, new DidOptOutEventArgs(p0, Convertor.CampaignFrom(p1)));
                }
            }

            public override bool LocalyticsShouldPromptForLocationPermissions(LocalyticsXamarin.Android.Campaign p0)
            {
                if (ShouldPromptForLocationPermission!=null) {
                    ShouldPromptForLocationPermission(p0);
                }
                return true;
            }

            public override bool LocalyticsShouldDeeplinkToSettings(global::Android.Content.Intent p0, LocalyticsXamarin.Android.Campaign p1)
            {
                if (DeeplinkToSettings != null)
                {
                    return DeeplinkToSettings(p0, p1);
                }
                return true;
            }
        }
	}
}
