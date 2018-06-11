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

namespace LocalyticsXamarin.Android
{
    public partial class Localytics
    {
        public static InAppDidDisplayEventHandler InAppDidDisplayEvent;
        public static InAppWillDismissEventHandler InAppWillDismissEvent;
        public static InAppDidDismissEventHandler InAppDidDismissEvent;
        public static Func<bool> InAppDelaySessionStartMessages;

        public static Func<NativeInAppCampaign, bool> InAppShouldShow;
        public static Func<string, bool> ShouldDeepLink;
        public static Func<NativeInAppCampaign, NativeInAppConfiguration, NativeInAppConfiguration> InAppWillDisplay;
        public static Func<NativePushCampaign, bool> ShouldShowPushNotification;
        public static Func<NotificationCompat.Builder, NativePushCampaign, NotificationCompat.Builder> WillShowPushNotification;
        public static Func<NativePlacesCampaign, bool> ShouldShowPlacesPushNotification;
        public static Func<NotificationCompat.Builder, NativePlacesCampaign, NotificationCompat.Builder> WillShowPlacesPushNotification;

        public static Func<NativePlacesCampaign, bool> PlacesShouldDisplayCampaign;

        public sealed class MessagingListener //: global::Java.Lang.Object, IMessagingListenerV2
        {
            //public IMessagingListenerImplementor(object sender)
            //    : base(
            //        global::Android.Runtime.JNIEnv.StartCreateInstance("mono/com/localytics/android/AnalyticsListenerImplementor", "()V"),
            //        JniHandleOwnership.TransferLocalRef)
            //{
            //    global::Android.Runtime.JNIEnv.FinishCreateInstance(((global::Java.Lang.Object)this).Handle, "()V");
            //    this.sender = sender;
            //}
            //public static MessagingListener() {
                
            //}

            public void LocalyticsDidDismissInAppMessage()
            {
                InAppDidDismissEvent?.Invoke(null, new InAppDidDismissEventArgs());
            }

            public void LocalyticsDidDisplayInAppMessage()
            {
                InAppDidDisplayEvent?.Invoke(null, new InAppDidDisplayEventArgs());
            }

            public void LocalyticsWillDismissInAppMessage()
            {
                InAppWillDismissEvent?.Invoke(null, new InAppWillDismissEventArgs());
            }

            public bool LocalyticsShouldDelaySessionStartInAppMessages()
            {
                return InAppDelaySessionStartMessages == null || InAppDelaySessionStartMessages();
            }

            public bool LocalyticsShouldShowInAppMessage(NativeInAppCampaign campaign)
            {
                return InAppShouldShow != null ? InAppShouldShow(campaign) : true;
            }

            public bool LocalyticsShouldDeeplink(string url)
            {
                return ShouldDeepLink != null ? ShouldDeepLink(url) : true;
            }

            public NativeInAppConfiguration LocalyticsWillDisplayInAppMessage(NativeInAppCampaign campaign, NativeInAppConfiguration configuration)
            {
                return InAppWillDisplay != null ? InAppWillDisplay(campaign, configuration) : configuration;
            }

            public bool LocalyticsShouldShowPushNotification(NativePushCampaign pushCampaign)
            {
                return ShouldShowPushNotification != null ? ShouldShowPushNotification(pushCampaign) : true;
            }

            public NotificationCompat.Builder LocalyticsWillShowPushNotification(NotificationCompat.Builder p0, NativePushCampaign campaign)
            {
                return WillShowPushNotification != null ? WillShowPushNotification(p0, campaign) : p0;
            }
            public bool LocalyticsShouldShowPlacesPushNotification(NativePlacesCampaign placesCampaign)
            {
                return ShouldShowPlacesPushNotification != null ? ShouldShowPlacesPushNotification(placesCampaign) : true;
            }

            public NotificationCompat.Builder LocalyticsWillShowPlacesPushNotification(NotificationCompat.Builder p0, NativePlacesCampaign campaign)
            {
                return WillShowPlacesPushNotification != null ? WillShowPlacesPushNotification(p0, campaign) : p0;
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
