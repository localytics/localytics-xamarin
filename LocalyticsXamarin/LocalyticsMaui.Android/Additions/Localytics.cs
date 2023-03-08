using System;
using System.Runtime.CompilerServices;
using LocalyticsXamarin.Common;
using LocalyticsXamarin.Shared;
using Android.Runtime;
using AndroidX.Core.App;

using NativeInAppCampaign = LocalyticsMaui.Android.InAppCampaign;
using NativeInboxCampaign = LocalyticsMaui.Android.InboxCampaign;
using NativeImpressionType = LocalyticsMaui.Android.Localytics.ImpressionType;
using NativePlacesCampaign = LocalyticsMaui.Android.PlacesCampaign;
using NativePushCampaign = LocalyticsMaui.Android.PushCampaign;

namespace LocalyticsMaui.Android
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
			Localytics.SetMessagingListener(new IMessagingListenerV2Implementor());
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

        [Register("mono/com/localytics/android/MessagingListenerV2Implementor")]
        internal sealed partial class IMessagingListenerV2Implementor : global::Java.Lang.Object, IMessagingListenerV2
        {
            public IMessagingListenerV2Implementor()
                : base(
                    JNIEnv.StartCreateInstance("mono/com/localytics/android/MessagingListenerV2Implementor", "()V"),
                    JniHandleOwnership.TransferLocalRef)
            {
                JNIEnv.FinishCreateInstance(this.Handle, "()V");
                //this.sender = sender;
            }

            public void LocalyticsDidDisplayInAppMessage()
            {
                var __h = LocalyticsSDK.InAppDidDisplayEvent;
                if (__h != null)
                    __h(null, new InAppDidDisplayEventArgs());
            }

            public void LocalyticsWillDismissInAppMessage()
            {
                var __h = LocalyticsSDK.InAppWillDismissEvent;
                if (__h != null)
                    __h(null, new InAppWillDismissEventArgs());
            }

            public void LocalyticsDidDismissInAppMessage()
            {
                var __h = LocalyticsSDK.InAppDidDismissEvent;
                if (__h != null)
                    __h(null, new InAppDidDismissEventArgs());
            }

            public bool LocalyticsShouldDelaySessionStartInAppMessages()
            {
                var __h = LocalyticsSDK.InAppDelaySessionStartMessagesDelegate;
                if (__h != null)
                    return __h();
                return true;
            }

            public bool LocalyticsShouldShowInAppMessage(NativeInAppCampaign p0)
            {
                var __h = LocalyticsSDK.InAppShouldShowDelegate;
                if (__h != null)
                    return __h(p0);
                return true;
            }

            public bool LocalyticsShouldShowPlacesPushNotification(NativePlacesCampaign p0)
            {
                var __h = LocalyticsSDK.PlacesShouldDisplayCampaignDelegate;
                if (__h != null)
                    return __h(p0);
                return true;
            }

            public bool LocalyticsShouldShowPushNotification(NativePushCampaign p0)
            {
                var __h = ShouldShowPushNotification;
                if (__h != null)
                    return __h(p0);
                return true;
            }

            public InAppConfiguration LocalyticsWillDisplayInAppMessage(NativeInAppCampaign p0, InAppConfiguration p1)
            {
                var __h = LocalyticsSDK.InAppWillDisplayDelegate;
                if (__h != null)
                    return __h(p0, p1);
                return p1;
            }

            public NotificationCompat.Builder LocalyticsWillShowPlacesPushNotification(NotificationCompat.Builder p0, NativePlacesCampaign p1)
            {
                var __h = WillShowPlacesPushNotification;
                if (__h != null)
                    return __h(p0, p1);
                return p0;
            }
            public NotificationCompat.Builder LocalyticsWillShowPushNotification(NotificationCompat.Builder p0, NativePushCampaign p1)
            {
                var __h = WillShowPushNotification;
                if (__h != null)
                    return __h(p0, p1);
                return p0;
            }

            internal static bool __IsEmpty(IMessagingListenerV2Implementor value)
            {
                return LocalyticsSDK.InAppDidDisplayEvent != null && LocalyticsSDK.InAppWillDismissEvent != null &&
                                    LocalyticsSDK.InAppDidDismissEvent != null && LocalyticsSDK.ShouldDeepLinkDelegate != null &&
                                    LocalyticsSDK.InAppDelaySessionStartMessagesDelegate != null && LocalyticsSDK.InAppShouldShowDelegate != null &&
                                    LocalyticsSDK.PlacesShouldDisplayCampaignDelegate != null && ShouldShowPushNotification != null &&
                                    LocalyticsSDK.InAppWillDisplayDelegate != null && WillShowPlacesPushNotification != null &&
                    WillShowPushNotification != null;
            }
        }

        public static Func<Campaign, bool> ShouldPromptForLocationPermission;
        public static Func<global::Android.Content.Intent, Campaign, bool> DeeplinkToSettings;

        public class CTAListenerImplementation : CallToActionListenerAdapterV2
        {
            public override bool LocalyticsShouldDeeplink(string p0, Campaign p1)
            {
                if (LocalyticsSDK.CallToActionShouldDeepLinkDelegate != null) {
                    return LocalyticsSDK.CallToActionShouldDeepLinkDelegate(p0, Convertor.CampaignFrom(p1));
                }
                return true;
            }
            public override void LocalyticsDidOptOut(bool p0, Campaign p1)
            {
                if (LocalyticsSDK.DidOptOut != null) {
                    LocalyticsSDK.DidOptOut(null, new DidOptOutEventArgs(p0, Convertor.CampaignFrom(p1)));
                }
            }

            public override void LocalyticsDidPrivacyOptOut(bool p0, Campaign p1)
            {
                if (LocalyticsSDK.DidPrivacyOptOut != null) {
                    LocalyticsSDK.DidPrivacyOptOut(null, new DidOptOutEventArgs(p0, Convertor.CampaignFrom(p1)));
                }
            }

            public override bool LocalyticsShouldPromptForLocationPermissions(Campaign p0)
            {
                if (ShouldPromptForLocationPermission!=null) {
                    ShouldPromptForLocationPermission(p0);
                }
                return true;
            }

            public override bool LocalyticsShouldDeeplinkToSettings(global::Android.Content.Intent p0, Campaign p1)
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
