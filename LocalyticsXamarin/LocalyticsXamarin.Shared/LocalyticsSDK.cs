using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Diagnostics;

#if __IOS__
using Foundation;
using CoreLocation;
using UIKit;
using LocalyticsXamarin.IOS;
#else
using Java.Util;
using Android.Runtime;

using LocalyticsXamarin.Android;
#endif
using LocalyticsXamarin.Common;


#if __IOS__
using NativeNumber = Foundation.NSNumber;
using NativeInAppCampaign = LocalyticsXamarin.IOS.LLInAppCampaign;
using NativeInboxCampaign = LocalyticsXamarin.IOS.LLInboxCampaign;
using NativeImpressionType = LocalyticsXamarin.IOS.LLImpressionType;
using NativePlacesCampaign = LocalyticsXamarin.IOS.LLPlacesCampaign;
using NativeInAppConfiguration = LocalyticsXamarin.IOS.LLInAppConfiguration;
using NativeLocalyticsDidUpdateMonitoredGeofencesEventArgs = LocalyticsXamarin.IOS.LocalyticsDidUpdateMonitoredGeofencesEventArgs;
#else
using NativeNumber = Java.Lang.Long;
using NativeInAppCampaign = LocalyticsXamarin.Android.InAppCampaign;
using NativeInboxCampaign = LocalyticsXamarin.Android.InboxCampaign;
using NativeImpressionType = LocalyticsXamarin.Android.Localytics.ImpressionType;
using NativePlacesCampaign = LocalyticsXamarin.Android.PlacesCampaign;
using NativeInAppConfiguration = LocalyticsXamarin.Android.InAppConfiguration;
using NativeLocalyticsDidUpdateLocationEventArgs = LocalyticsXamarin.Android.LocalyticsDidUpdateLocationEventArgs;
using NativeLocalyticsDidUpdateMonitoredGeofencesEventArgs = LocalyticsXamarin.Android.LocalyticsDidUpdateMonitoredGeofencesEventArgs;
#endif


namespace LocalyticsXamarin.Shared
{
    public class LocalyticsSDK : ILocalytics
    {
        protected LocalyticsSDK() { }

        //Messaging Listener functions
        public static EventHandler<InAppDidDisplayEventArgs> InAppDidDisplayEvent;
        public static EventHandler<InAppWillDismissEventArgs> InAppWillDismissEvent;
        public static EventHandler<InAppDidDismissEventArgs> InAppDidDismissEvent;
        public static Func<bool> InAppDelaySessionStartMessagesDelegate;
        public static Func<NativeInAppCampaign, bool> InAppShouldShowDelegate;
        public static Func<string, bool> ShouldDeepLinkDelegate;
        public static Func<NativeInAppCampaign, NativeInAppConfiguration, NativeInAppConfiguration> InAppWillDisplayDelegate;
        public static Func<NativePlacesCampaign, bool> PlacesShouldDisplayCampaignDelegate;

        //CallToAction Listener delegates
        public static Func<string, ICampaignBase, bool> CallToActionShouldDeepLinkDelegate;
        public static EventHandler<DidOptOutEventArgs> DidOptOut;
        public static EventHandler<DidOptOutEventArgs> DidPrivacyOptOut;


        public static event EventHandler LocalyticsSessionWillClose
        {
            add
            {
                Localytics.SharedInstance().SessionWillClose += value;
            }
            remove
            {
                Localytics.SharedInstance().SessionWillClose -= value;
            }
        }

        public static event EventHandler<LocalyticsDidTagEventEventArgs> LocalyticsDidTagEvent
        {
            add
            {
                Localytics.SharedInstance().DidTagEvent += (o, args) =>
                {
                    value(o, new LocalyticsDidTagEventEventArgs(args.EventName, args.CustomerValue, args.Attributes));
                };
            }
            remove
            {
                Localytics.SharedInstance().DidTagEvent -= (o, args) =>
                {
                    value(o, new LocalyticsDidTagEventEventArgs(args.EventName, args.CustomerValue, args.Attributes));
                };
            }
        }

        public static event EventHandler<LocalyticsSessionDidOpenEventArgs> LocalyticsSessionDidOpen
        {
            add
            {
                Localytics.SharedInstance().SessionDidOpen += (o, args) =>
                {
                    value(o, new LocalyticsSessionDidOpenEventArgs(args.First, args.Upgrade, args.Resume));
                };
            }
            remove
            {
                Localytics.SharedInstance().SessionDidOpen -= (o, args) =>
                {
                    value(o, new LocalyticsSessionDidOpenEventArgs(args.First, args.Upgrade, args.Resume));
                };
            }
        }

        public static event EventHandler<LocalyticsSessionWillOpenEventArgs> LocalyticsSessionWillOpen
        {
            add
            {
                Localytics.SharedInstance().SessionWillOpen += (o, args) =>
                {
                    value(o, new LocalyticsSessionWillOpenEventArgs(args.First, args.Upgrade, args.Resume));
                };
            }
            remove
            {
                Localytics.SharedInstance().SessionWillOpen -= (o, args) =>
                {
                    value(o, new LocalyticsSessionWillOpenEventArgs(args.First, args.Upgrade, args.Resume));
                };
            }
        }

        /* Events ... */
        public static event EventHandler<LocalyticsDidTriggerRegionsEventArgs> LocalyticsDidTriggerRegions
        {
            add
            {
#if __IOS__
                Localytics
#else
                Localytics.SharedInstance()
#endif
                  .LocalyticsDidTriggerRegions += value;
            }
            remove
            {
#if __IOS__
                Localytics
#else
                Localytics.SharedInstance()
#endif
                          .LocalyticsDidTriggerRegions -= value;
            }
        }

        public static event EventHandler<LocalyticsDidUpdateLocationEventArgs> LocalyticsDidUpdateLocation
        {
            add
            {
#if __IOS__
                Localytics
#else
                Localytics.SharedInstance()
#endif
                          .LocalyticsDidUpdateLocation += value;
            }
            remove
            {
#if __IOS__
                Localytics
#else
                Localytics.SharedInstance()
#endif
                          .LocalyticsDidUpdateLocation -= value;
            }
        }

        public static event EventHandler<LocalyticsDidUpdateMonitoredGeofencesEventArgs> LocalyticsDidUpdateMonitoredGeofences
        {
            add
            {
#if __IOS__
                Localytics
#else
                Localytics.SharedInstance()
#endif
                          .LocalyticsDidUpdateMonitoredGeofences += value;
            }
            remove
            {
#if __IOS__
                Localytics
#else
                Localytics.SharedInstance()
#endif
                .LocalyticsDidUpdateMonitoredGeofences -= value;
            }
        }

        static LocalyticsSDK _instance;
        public static LocalyticsSDK SharedInstance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new LocalyticsSDK();
                }
                return _instance;
            }
        }
        internal static void UpdatePluginVersion()
        {
            var ver = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            string versionString = string.Format("Xamarin_{0}.{1}.{2}", ver.Major, ver.Minor, ver.Build);
            Console.WriteLine("Version is {0}", versionString);
#if __IOS__
            Localytics.SetOptions(Foundation.NSDictionary.FromObjectAndKey(new Foundation.NSString(versionString), new Foundation.NSString("plugin_library")));
#else
            Localytics.SetOption("plugin_library", versionString);
#endif
        }
        public XFLLInAppMessageDismissButtonLocation InAppMessageDismissButtonLocation
        {
            get
            {
                return Utils.ToXFLLInAppMessageDismissButtonLocation(Localytics.GetInAppMessageDismissButtonLocation());
            }
            set
            {
                Localytics.SetInAppMessageDismissButtonLocation(Utils.ToLLInAppMessageDismissButtonLocation(value));
            }
        }

        public void OpenSession()
        {
            Localytics.OpenSession();
        }

        public void CloseSession()
        {
            Localytics.CloseSession();
        }

        public void Upload()
        {
            Localytics.Upload();
        }

        public void TagEvent(string eventName, IDictionary<string, string> attributes = null, long? customerValueIncrease = null)
        {
            if (attributes == null && customerValueIncrease == null)
            {
                Localytics.TagEvent(eventName);
            }
            else if (customerValueIncrease == null && attributes != null)
            {
#if __IOS__
                Localytics.TagEvent(eventName, attributes.ToNSDictionary());
#else
                Localytics.TagEvent(eventName, attributes);
#endif
            }
            else
            {
#if __IOS__
                Localytics.TagEvent(eventName, attributes.ToNSDictionary(), customerValueIncrease);
#else
                Localytics.TagEvent(eventName, attributes, customerValueIncrease.Value);
#endif
            }
        }

        public void TagScreen(string screenName)
        {
            Localytics.TagScreen(screenName);
        }

        public void SetCustomDimension(string value, uint dimension)
        {
#if __IOS__
            Localytics.SetCustomDimension(value, dimension);
#else
            Localytics.SetCustomDimension((int)dimension, value);
#endif
        }

        public string GetCustomDimension(uint dimension)
        {
#if __IOS__
            return Localytics.GetCustomDimension(dimension);
#else
            return Localytics.GetCustomDimension((int)dimension);
#endif
        }

        public void SetIdentifier(string value, string identifier)
        {
            Localytics.SetIdentifier(identifier, value);
        }

        public string GetIdentifier(string identifier)
        {
            return Localytics.GetIdentifier(identifier);
        }

        public string CustomerId
        {
            get
            {
                return Localytics.CustomerId;
            }
            set
            {
                Localytics.CustomerId = value;
            }
        }

        public void SetCustomerEmail(string email)
        {
            Localytics.SetCustomerEmail(email);
        }

        public void SetCustomerFirstName(string firstName)
        {
            Localytics.SetCustomerFirstName(firstName);
        }

        public void SetCustomerLastName(string lastName)
        {
            Localytics.SetCustomerLastName(lastName);
        }

        public void SetCustomerFullName(string fullName)
        {
            Localytics.SetCustomerFullName(fullName);
        }

        public string PushTokenInfo
        {
            get
            {
#if __IOS__
                return Localytics.PushTokenInfo;
#else
                return Localytics.PushRegistrationId;
#endif
            }
        }

        public void TriggerInAppMessage(string triggerName, IDictionary<string, string> attributes)
        {
            if (attributes == null)
            {
#if __IOS__
                Localytics.TriggerInAppMessageInternal(triggerName);
#else
                Localytics.TriggerInAppMessage(triggerName);
#endif
                return;
            }
#if __IOS__
            Localytics.TriggerInAppMessage(triggerName, attributes.ToNSDictionary());
#else
            Localytics.TriggerInAppMessage(triggerName, attributes);
#endif
        }

        public void DismissCurrentInAppMessage()
        {
            Localytics.DismissCurrentInAppMessage();
        }

        public bool LoggingEnabled
        {
            get
            {
                return Localytics.LoggingEnabled;
            }
            set
            {
                Localytics.LoggingEnabled = value;
            }
        }

        public void EnableLiveDeviceLogging()
        {
            Localytics.EnableLiveDeviceLogging();
        }

        public bool OptedOut
        {
            get
            {
                return Localytics.OptedOut;
            }
            set
            {
                Localytics.OptedOut = value;
            }
        }

        public bool TestModeEnabled
        {
            get => Localytics.TestModeEnabled;
            set => Localytics.TestModeEnabled = value;
        }

        public string InstallId
        {
            get => Localytics.InstallId;
        }

        public string LibraryVersion
        {
            get => Localytics.LibraryVersion;
        }

       public string LocalAuthenticationToken
       {
#if __IOS__
            get => "";
#else
            get => Localytics.LocalAuthenticationToken;
#endif
        }

        public string AppKey
        {
            get => Localytics.AppKey;
        }

        public bool PrivacyOptedOut { get => Localytics.PrivacyOptedOut; set => Localytics.PrivacyOptedOut = value; }

        public IInboxCampaign[] AllInboxCampaigns()
        {
            return Convertor.From(Localytics.AllInboxCampaigns);
        }

        public IInboxCampaign[] DisplayableInboxCampaigns()
        {
            return Convertor.From(Localytics.DisplayableInboxCampaigns);
        }


        public bool InAppAdIdParameterEnabled
        {
            get => Localytics.IsAdidAppendedToInAppUrls;
            set => Localytics.AppendAdidToInAppUrls(value);
        }

        public bool InboxAdIdParameterEnabled
        {
            get => Localytics.IsAdidAppendedToInboxUrls;
            set => Localytics.AppendAdidToInboxUrls(value);
        }

        public void TagPurchased(string itemName, string itemId, string itemType, long? itemPrice, IDictionary<string, string> attributes)
        {
            NativeNumber price = null;
            if (itemPrice != null)
            {
                price = new NativeNumber(itemPrice.Value);
            }
#if __IOS__
            Localytics.TagPurchased(itemName, itemId, itemType, price, attributes.ToNSDictionary());
#else
            Localytics.TagPurchased(itemName, itemId, itemType, price, attributes);
#endif
        }

        public void TagAddedToCart(string itemName, string itemId, string itemType, long? itemPrice, IDictionary<string, string> attributes)
        {
#if __IOS__
            Localytics.TagAddedToCart(itemName, itemId, itemType, itemPrice, attributes.ToNSDictionary());
#else
            Localytics.TagAddedToCart(itemName, itemId, itemType, new NativeNumber(itemPrice.Value), attributes);
#endif
        }

        public void TagStartedCheckout(long? totalPrice, long? itemCount, IDictionary<string, string> attributes)
        {
#if __IOS__
            Localytics.TagStartedCheckout(totalPrice, itemCount, attributes.ToNSDictionary());
#else
            Localytics.TagStartedCheckout(new Java.Lang.Long(totalPrice.Value), new Java.Lang.Long(itemCount.Value), attributes);
#endif
        }

        public void TagCompletedCheckout(long? totalPrice, long? itemCount, IDictionary<string, string> attributes)
        {
            NativeNumber price = null;
            if (totalPrice.HasValue)
            {
                price = new NativeNumber(totalPrice.Value);
            }
            NativeNumber count = null;
            if (itemCount.HasValue)
            {
                count = new NativeNumber(itemCount.Value);
            }
#if __IOS__
            Localytics.TagCompletedCheckout(price, count, attributes.ToNSDictionary());
#else
            Localytics.TagCompletedCheckout(price, count, attributes);
#endif
        }

        public void TagContentViewed(string contentName, string contentId, string contentType, IDictionary<string, string> attributes)
        {
#if __IOS__
            Localytics.TagContentViewed(contentName, contentId, contentType, attributes.ToNSDictionary());
#else
            Localytics.TagContentViewed(contentName, contentId, contentType, attributes);
#endif
        }

        public void TagSearched(string queryText, string contentType, long? resultCount, IDictionary<string, string> attributes)
        {
            NativeNumber count = null;
            if (resultCount.HasValue)
            {
                count = new NativeNumber(resultCount.Value);
            }
#if __IOS__
            Localytics.TagSearched(queryText, contentType, count, attributes.ToNSDictionary());
#else
            Localytics.TagSearched(queryText, contentType, count, attributes);
#endif
        }

        public void TagShared(string contentName, string contentId, string contentType, string methodName, IDictionary<string, string> attributes)
        {
#if __IOS__
            Localytics.TagShared(contentName, contentId, contentType, methodName, attributes.ToNSDictionary());
#else
            Localytics.TagShared(contentName, contentId, contentType, methodName, attributes);
#endif
        }

        public void TagContentRated(string contentName, string contentId, string contentType, long? rating, IDictionary<string, string> attributes)
        {
            NativeNumber ratingValue = null;
            if (rating.HasValue)
            {
                ratingValue = new NativeNumber(rating.Value);
            }
#if __IOS__
            Localytics.TagContentRated(contentName, contentId, contentType, ratingValue, attributes.ToNSDictionary());
#else
            Localytics.TagContentRated(contentName, contentId, contentType, ratingValue, attributes);
#endif
        }

        public void TagCustomerRegistered(IDictionary<string, object> customerProps, string methodName, IDictionary<string, string> attributes)
        {
#if __IOS__
            Localytics.TagCustomerRegistered(customerProps, methodName, attributes.ToNSDictionary());
#else
            var cust = Convertor.toCustomer(customerProps);
            Localytics.TagCustomerRegistered(cust, methodName, attributes);
#endif
        }

        public void TagCustomerRegistered(IXLCustomer customer, string methodName, IDictionary<string, string> attributes)
        {
            var cust = Convertor.toCustomer(customer);
#if __IOS__
            Localytics.TagCustomerRegistered(cust, methodName, attributes.ToNSDictionary());
#else
            Localytics.TagCustomerRegistered(cust, methodName, attributes);
#endif
        }

        public void TagCustomerLoggedIn(IDictionary<string, object> customerProps, string methodName, IDictionary<string, string> attributes)
        {
#if __IOS__
            Localytics.TagCustomerLoggedIn(customerProps, methodName, attributes.ToNSDictionary());
#else
            var cust = Convertor.toCustomer(customerProps);
            Localytics.TagCustomerLoggedIn(cust, methodName, attributes);
#endif
        }

        public void TagCustomerLoggedIn(IXLCustomer customer, string methodName, IDictionary<string, string> attributes)
        {
            var cust = Convertor.toCustomer(customer);
#if __IOS__
            Localytics.TagCustomerLoggedIn(cust, methodName, attributes.ToNSDictionary());
#else
            Localytics.TagCustomerLoggedIn(cust, methodName, attributes);
#endif
        }

        public void TagCustomerLoggedOut(IDictionary<string, string> attributes)
        {
#if __IOS__
            Localytics.TagCustomerLoggedOut(attributes.ToNSDictionary());
#else
            Localytics.TagCustomerLoggedOut(attributes);
#endif
        }

        public void TagInvited(string methodName, IDictionary<string, string> attributes)
        {
#if __IOS__
            Localytics.TagInvited(methodName, attributes.ToNSDictionary());
#else
            Localytics.TagInvited(methodName, attributes);
#endif
        }

#if __IOS__
        public void SetInAppMessageDismissButtonImageWithName(string imageName)
        {
            Localytics.SetInAppMessageDismissButtonImageWithName(imageName);
        }
#endif

        public void SetInAppMessageDismissButtonHidden(bool hidden)
        {
#if __IOS__
            Localytics.SetInAppMessageDismissButtonHidden(hidden);
#else
            // View.INVISBLE or 4 hides  it.
            Localytics.SetInAppMessageDismissButtonVisibility(hidden ? 4 : 1);
#endif
        }

        public void SetInboxCampaign(IInboxCampaign campaign, bool read)
        {
            Localytics.SetInboxCampaignRead((NativeInboxCampaign)campaign.Handle(), read);
        }

        public void DeleteInboxCampaign(IInboxCampaign campaign)
        {
            Localytics.DeleteInboxCampaign((NativeInboxCampaign)campaign.Handle());
        }

        public void InboxListItemTapped(IInboxCampaign campaign)
        {
            Localytics.InboxListItemTapped((NativeInboxCampaign)campaign.Handle());
        }

        public long InboxCampaignsUnreadCount()
        {
            return Localytics.InboxCampaignsUnreadCount;
        }

        public void SetLocationMonitoringEnabled(bool enabled)
        {
            Localytics.SetLocationMonitoringEnabled(enabled);
        }

        public void SetOptions(IDictionary<string, object> options)
        {
            Localytics.SetOptions(
#if __IOS__
            options.ToNSDictionary()
#else
            Convertor.ToGenericDictionary(options)
#endif
            );
        }

        public void SetOption(string key, object value)
        {
            var dict = new Dictionary<string, object>();
            dict.Add(key, value);
            this.SetOptions(dict);
        }

        public void PauseDataUploading(bool pause)
        {
            Localytics.PauseDataUploading(pause);
        }

        public void SetCustomerId(string customerId, bool optedOut)
        {
            Localytics.SetCustomerIdWithPrivacyOptedOut(customerId, optedOut);
        }

        public void TriggerInAppMessagesForSessionStart()
        {
            Localytics.TriggerInAppMessagesForSessionStart();
        }

        public void TagInAppImpression(NativeInAppCampaign campaign, NativeImpressionType type)
        {
            Localytics.TagInAppImpression(campaign, type);
        }

        public void TagInAppImpression(NativeInAppCampaign campaign, string customAction)
        {
            Localytics.TagInAppImpression(campaign, customAction);
        }

        public void TagImpression(IInboxCampaign campaign, string customAction)
        {
#if __IOS__
            Localytics.TagInboxImpression((NativeInboxCampaign)campaign.Handle(), customAction);
#else
            if ("click".Equals(customAction, StringComparison.InvariantCultureIgnoreCase))
            {
                Localytics.TagInboxImpression((NativeInboxCampaign)campaign.Handle(), NativeImpressionType.Click);
            }
            else if ("dismiss".Equals(customAction, StringComparison.InvariantCultureIgnoreCase))
            {
                Localytics.TagInboxImpression((NativeInboxCampaign)campaign.Handle(), Localytics.ImpressionType.Dismiss);
            }
            else
            {
                Localytics.TagInboxImpression((NativeInboxCampaign)campaign.Handle(), customAction);
            }
#endif
        }

        public void TagImpressionForInboxCampaign(NativeInboxCampaign campaign, NativeImpressionType impressionType)
        {
            Localytics.TagInboxImpression(campaign, impressionType);
        }

        public void TagImpressionForPushToInboxCampaign(object campaign, bool success)
        {
#if __IOS__
            Localytics.TagImpressionForPushToInboxCampaign((NativeInboxCampaign)campaign, success);
#else
            // FIXME Native doesnt support Deeplink Success on Android. - request submitted to Native SDK for review.
            Localytics.TagPushToInboxImpression((NativeInboxCampaign)campaign);
#endif
        }

        //public void InboxListItemTapped(IInboxCampaign campaign)
        //{
        //	Localytics.InboxListItemTapped((NativeInboxCampaign)campaign.Handle());
        //}

        public void TagPlacesPushReceived(NativePlacesCampaign campaign)
        {
            Localytics.TagPlacesPushReceived(campaign);
        }

        public void TagPlacesPushOpened(NativePlacesCampaign campaign, string identifier)
        {
#if __IOS__
            if (identifier == null)
            {
                Localytics.TagPlacesPushOpened(campaign);
            }
            else
            {
                Localytics.TagPlacesPushOpened(campaign, identifier);
            }
#else
            Localytics.TagPlacesPushOpened(campaign, identifier);
#endif
        }

        public void TriggerPlacesNotificationForCampaign(object campaign)
        {
            Localytics.TriggerPlacesNotification((NativePlacesCampaign)campaign);
        }

        public void TriggerPlacesNotificationForCampaignId(long campaignId, string regionId)
        {
#if __IOS__
            Localytics.TriggerPlacesNotification((nint)campaignId, regionId);
#else
            Localytics.TriggerPlacesNotification(campaignId, regionId);
#endif
        }

#if __IOS__
        public void RefreshAllInboxCampaigns(Action<IInboxCampaign[]> inboxCampaignsDelegate)
        {
            Localytics.RefreshAllInboxCampaigns(x => inboxCampaignsDelegate(Convertor.From(x)));
        }
#else
        private sealed class InboxRefreshImplementation
        {
            Action<IInboxCampaign[]> callback = null;
            LocalyticsXamarin.Android.InboxRefreshImplementationPlatform listener = new LocalyticsXamarin.Android.InboxRefreshImplementationPlatform();
            public void SetCallback(Action<IInboxCampaign[]> inboxCampaignsDelegate)
            {
                callback = inboxCampaignsDelegate;
                listener.SetCallback(handleCallback);
            }
            public void handleCallback(NativeInboxCampaign[] campaigns)
            {
                callback(Convertor.From(campaigns));
            }
        }
        InboxRefreshImplementation inboxAllRefreshListener = new InboxRefreshImplementation();
        InboxRefreshImplementation inboxRefreshListener = new InboxRefreshImplementation();

        public void RefreshAllInboxCampaigns(Action<IInboxCampaign[]> inboxCampaignsDelegate)
        {
            inboxAllRefreshListener.SetCallback(inboxCampaignsDelegate);
        }
#endif

        public void RefreshInboxCampaigns(Action<IInboxCampaign[]> inboxCampaignsDelegate)
        {
#if __IOS__
            Localytics.RefreshInboxCampaigns(x => inboxCampaignsDelegate(Convertor.From(x)));
#else
            inboxRefreshListener.SetCallback(inboxCampaignsDelegate);
#endif
        }

        public void SetProfileAttribute(string attribute, XFLLProfileScope scope, params object[] values)
        {
            if (values.Length == 1)
            {
                object value = values[0];
#if __IOS__
                Localytics.SetProfileAttribute(NSObject.FromObject(value), attribute, Utils.ToLLProfileScope(scope));
#else
                if (value is long || value is int)
                {
                    Localytics.SetProfileAttribute(attribute, Convert.ToInt64(value), Utils.ToLLProfileScope(scope));
                }
                else if (value is DateTime)
                {
                    DateTime dateTime = (DateTime)value;
                    Localytics.SetProfileAttribute(attribute, new Java.Util.Date(dateTime.Ticks), Utils.ToLLProfileScope(scope));
                }
                else
                {
                    Localytics.SetProfileAttribute(attribute, value.ToString(), Utils.ToLLProfileScope(scope));
                }
#endif
            }
            else
            {
#if __IOS__
                Localytics.SetProfileAttribute(Convertor.ToArray(values), attribute, Utils.ToLLProfileScope(scope));
#else
                object value = values[0];
                if (value is long || value is int)
                {
                    Localytics.SetProfileAttribute(attribute, Convertor.ToLongArray(values), Utils.ToLLProfileScope(scope));
                }
                else if (value is DateTime)
                {
                    Localytics.SetProfileAttribute(attribute, Convertor.ToJavaDateArray(values), Utils.ToLLProfileScope(scope));
                }
                else if (value is string || value is Java.Lang.String)
                {
                    Localytics.SetProfileAttribute(attribute, Convertor.ToStringArray(values), Utils.ToLLProfileScope(scope));
                }
                else
                {
                    Debug.WriteLine("Unknown Object Type " + value.GetType());
                    throw new ArgumentException("SetProfileAttribute- Unknown Array Object Type " + value.GetType());
                }
#endif
            }
        }

        // object must be Date (Android) or NSDate (iOS)
        public void AddProfileAttribute(string attribute, XFLLProfileScope scope, params object[] values)
        {
#if __IOS__
    Localytics.AddProfileAttributes(attribute, Utils.ToLLProfileScope(scope), values);
#else
            object value = values[0];
            if (value is long || value is int)
            {
                Localytics.AddProfileAttributesToSet(attribute, Convertor.ToLongArray(values), Utils.ToLLProfileScope(scope));
            }
            else if (value is long[])
            {
                Localytics.AddProfileAttributesToSet(attribute, value as long[], Utils.ToLLProfileScope(scope));
            }
            else if (value is int[])
            {
                Localytics.AddProfileAttributesToSet(attribute, Array.ConvertAll<int, long>(value as int[], Convert.ToInt64), Utils.ToLLProfileScope(scope));
            }
            else if (value is DateTime)
            {
                Localytics.AddProfileAttributesToSet(attribute, Convertor.ToJavaDateArray(values), Utils.ToLLProfileScope(scope));
            }
            else if (value is string || value is Java.Lang.String)
            {
                Localytics.AddProfileAttributesToSet(attribute, Convertor.ToStringArray(values), Utils.ToLLProfileScope(scope));
            }
            else if (value is string[])
            {
                Localytics.AddProfileAttributesToSet(attribute, value as string[], Utils.ToLLProfileScope(scope));
            }
            else
            {
                Debug.WriteLine("Unknown Object Type " + value.GetType());
                throw new ArgumentException("AddProfileAttribute:2-Unknown Array Object Type " + value.GetType());
            }
#endif
        }

        public void RemoveProfileAttribute(string attribute, XFLLProfileScope scope = XFLLProfileScope.Application, params object[] values)
        {
#if __IOS__
            Localytics.RemoveProfileAttributes(attribute, Utils.ToLLProfileScope(scope), values);
#else
            object value = values[0];
            if (value is long || value is int)
            {
                Localytics.RemoveProfileAttributesFromSet(attribute, Convertor.ToLongArray(values), Utils.ToLLProfileScope(scope));
            }
            else if (value is DateTime)
            {
                Localytics.RemoveProfileAttributesFromSet(attribute, Convertor.ToJavaDateArray(values), Utils.ToLLProfileScope(scope));
            }
            else if (value is string || value is Java.Lang.String)
            {
                Localytics.RemoveProfileAttributesFromSet(attribute, Convertor.ToStringArray(values), Utils.ToLLProfileScope(scope));
            }
            else
            {
                Debug.WriteLine("Unknown Object Type " + value.GetType());
                throw new ArgumentException("RemoveProfileAttributeUnknown Array Object Type " + value.GetType());
            }
#endif
        }

        public void IncrementProfileAttribute(Int64 value, string attribute, XFLLProfileScope scope = XFLLProfileScope.Application)
        {
#if __IOS__
            Localytics.IncrementProfileAttribute((System.nint)value, attribute, Utils.ToLLProfileScope(scope));
#else
            Localytics.IncrementProfileAttribute(attribute, value, Utils.ToLLProfileScope(scope));
#endif
        }

        public void DecrementProfileAttribute(Int64 value, string attribute, XFLLProfileScope scope = XFLLProfileScope.Application)
        {
#if __IOS__
            Localytics.DecrementProfileAttribute((System.nint)value, attribute, Utils.ToLLProfileScope(scope));
#else
            Localytics.DecrementProfileAttribute(attribute, value, Utils.ToLLProfileScope(scope));
#endif
        }

        public void DeleteProfileAttribute(string attribute, XFLLProfileScope scope = XFLLProfileScope.Application)
        {
#if __IOS__
            Localytics.DeleteProfileAttribute(attribute, Utils.ToLLProfileScope(scope));
#else
            Localytics.DeleteProfileAttribute(attribute, Utils.ToLLProfileScope(scope));
#endif
        }

#region Platform specific code
#if __IOS__
        public void AddProfileAttributes(string attribute, LLProfileScope scope, params NSDate[] values)
        {
            Localytics.AddProfileAttributes(attribute, scope, values);
        }

        public void AddDateProfileAttributes(string attribute, LLProfileScope scope, params object[] values)
        {
            Localytics.AddProfileAttributes(attribute, scope, values);
        }

#endif
#endregion
    }
}
