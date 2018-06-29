using System;
using System.Runtime.CompilerServices;
using LocalyticsXamarin.Shared;
using Android.Runtime;
using Android.Support.V4.App;

using NativeInAppCampaign = LocalyticsXamarin.Android.InAppCampaign;
using NativeInboxCampaign = LocalyticsXamarin.Android.InboxCampaign;
using NativeImpressionType = LocalyticsXamarin.Android.Localytics.ImpressionType;
using NativePlacesCampaign = LocalyticsXamarin.Android.PlacesCampaign;
using NativePushCampaign = LocalyticsXamarin.Android.PushCampaign;
using LocalyticsXamarin.Common;

namespace LocalyticsXamarin.Android
{
    public partial class SessionDidOpenEventArgs : global::System.EventArgs, LocalyticsSessionDidOpenEventArgs
    { }

    public partial class SessionWillOpenEventArgs : global::System.EventArgs, LocalyticsSessionWillOpenEventArgs
    { }

    public partial class DidTagEventEventArgs : global::System.EventArgs, LocalyticsDidTagEventEventArgs
    { 
        public double? CustomerValue {
            get {
                return CustomerValueLong;
            }
        }
    }

    //public partial class SessionDidOpenEventArgs : global::System.EventArgs, LocalyticsSessionDidOpenEventArgs

    public partial class Localytics
	{
		static Localytics()
		{
			LocalyticsSDK.UpdatePluginVersion();
			Localytics.SetMessagingListener(new IMessagingListenerV2Implementor());
		}

		static Localytics _instance;

		[MethodImpl(MethodImplOptions.Synchronized)]
        public static Localytics SharedInstance()
		{
			if (_instance == null) {
				_instance = new Localytics();
			}
			return _instance;
		}

        public static Func<NativePushCampaign, bool> ShouldShowPushNotification;
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

            public bool LocalyticsShouldDeeplink(string p0)
            {
                var __h = LocalyticsSDK.ShouldDeepLinkDelegate;
                if (__h != null)
                    return __h(p0);
                return true;
            }

            public bool LocalyticsShouldDelaySessionStartInAppMessages()
            {
                var __h = LocalyticsSDK.InAppDelaySessionStartMessagesDelegate;
                if (__h != null)
                    return __h();
                return true;
            }

            public bool LocalyticsShouldShowInAppMessage(global::LocalyticsXamarin.Android.InAppCampaign p0)
            {
                var __h = LocalyticsSDK.InAppShouldShowDelegate;
                if (__h != null)
                    return __h(p0);
                return true;
            }

            public bool LocalyticsShouldShowPlacesPushNotification(global::LocalyticsXamarin.Android.PlacesCampaign p0)
            {
                var __h = LocalyticsSDK.PlacesShouldDisplayCampaignDelegate;
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
                var __h = LocalyticsSDK.InAppWillDisplayDelegate;
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
                return LocalyticsSDK.InAppDidDisplayEvent != null && LocalyticsSDK.InAppWillDismissEvent != null &&
                                    LocalyticsSDK.InAppDidDismissEvent != null && LocalyticsSDK.ShouldDeepLinkDelegate != null &&
                                    LocalyticsSDK.InAppDelaySessionStartMessagesDelegate != null && LocalyticsSDK.InAppShouldShowDelegate != null &&
                                    LocalyticsSDK.PlacesShouldDisplayCampaignDelegate != null && ShouldShowPushNotification != null &&
                                    LocalyticsSDK.InAppWillDisplayDelegate != null && WillShowPlacesPushNotification != null &&
                    WillShowPushNotification != null;
            }
        }

	}
}
