using System;
using System.Collections.Generic;
using CoreLocation;
using Foundation;
using UIKit;

namespace LocalyticsXamarin.IOS
{
    public abstract class LocalyticsPlatformCommon
    {
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
            else if (customerValueIncrease == null)
            {
                Localytics.TagEvent(eventName, attributes.ToNSDictionary());
            }
            else
            {
                Localytics.TagEvent(eventName, attributes.ToNSDictionary(), customerValueIncrease);
            }
        }

        public void TagScreen(string screenName)
        {
            Localytics.TagScreen(screenName);
        }

        public void SetCustomDimension(string value, uint dimension)
        {
            Localytics.SetCustomDimension(value, dimension);
        }

        public string GetCustomDimension(uint dimension)
        {
            return Localytics.GetCustomDimension(dimension);
        }

        public void SetIdentifier(string value, string identifier)
        {
            Localytics.SetIdentifier(value, identifier);
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
                return Localytics.PushTokenInfo;
            }
        }

        public void TriggerInAppMessage(string triggerName, IDictionary<string, string> attributes)
        {
            if (attributes == null)
            {
                Localytics.TriggerInAppMessageInternal(triggerName);
                return;
            }
            Localytics.TriggerInAppMessage(triggerName, attributes.ToNSDictionary());
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
            get
            {
                return Localytics.TestModeEnabled;
            }
            set
            {
                Localytics.TestModeEnabled = value;
            }
        }

        public string InstallId
        {
            get
            {
                return Localytics.InstallId();
            }
        }

        public string LibraryVersion
        {
            get
            {
                return Localytics.LibraryVersion();
            }
        }

        public string AppKey
        {
            get
            {
                return Localytics.AppKey();
            }
        }

        public bool PrivacyOptedOut { get => Localytics.PrivacyOptedOut; set => Localytics.PrivacyOptedOut = value; }

        public object[] InboxCampaigns { get => Localytics.InboxCampaigns; }

        public bool InAppAdIdParameterEnabled { get => Localytics.InAppAdIdParameterEnabled; set => Localytics.InAppAdIdParameterEnabled = value; }
        public bool InboxAdIdParameterEnabled { get => Localytics.InboxAdIdParameterEnabled; set => Localytics.InboxAdIdParameterEnabled = value; }

        public void TagPurchased(string itemName, string itemId, string itemType, long? itemPrice, IDictionary<string, string> attributes)
        {
            NSNumber price = null;
            if (itemPrice != null)
            {
                price = new NSNumber(itemPrice.Value);
            }
            Localytics.TagPurchased(itemName, itemId, itemType, price, attributes.ToNSDictionary());
        }

        public void TagAddedToCart(string itemName, string itemId, string itemType, long? itemPrice, IDictionary<string, string> attributes)
        {
            Localytics.TagAddedToCart(itemName, itemId, itemType, itemPrice, attributes.ToNSDictionary());
        }

        public void TagStartedCheckout(long? totalPrice, long? itemCount, IDictionary<string, string> attributes)
        {
            Localytics.TagStartedCheckout(totalPrice, itemCount, attributes.ToNSDictionary());
        }

        public void TagCompletedCheckout(long? totalPrice, long? itemCount, IDictionary<string, string> attributes)
        {
            NSNumber price = null;
            if (totalPrice.HasValue)
            {
                price = new NSNumber(totalPrice.Value);
            }
            NSNumber count = null;
            if (itemCount.HasValue)
            {
                count = new NSNumber(itemCount.Value);
            }
            Localytics.TagCompletedCheckout(price, count, attributes.ToNSDictionary());
        }

        public void TagContentViewed(string contentName, string contentId, string contentType, IDictionary<string, string> attributes)
        {
            Localytics.TagContentViewed(contentName, contentId, contentType, attributes.ToNSDictionary());
        }

        public void TagSearched(string queryText, string contentType, long? resultCount, IDictionary<string, string> attributes)
        {
            NSNumber count = null;
            if (resultCount.HasValue)
            {
                count = new NSNumber(resultCount.Value);
            }
            Localytics.TagSearched(queryText, contentType, count, attributes.ToNSDictionary());
        }

        public void TagShared(string contentName, string contentId, string contentType, string methodName, IDictionary<string, string> attributes)
        {
            Localytics.TagShared(contentName, contentId, contentType, methodName, attributes.ToNSDictionary());
        }

        public void TagContentRated(string contentName, string contentId, string contentType, long? rating, IDictionary<string, string> attributes)
        {
            NSNumber ratingValue = null;
            if (rating.HasValue)
            {
                ratingValue = new NSNumber(rating.Value);
            }
            Localytics.TagContentRated(contentName, contentId, contentType, ratingValue, attributes.ToNSDictionary());
        }

        public void TagCustomerRegistered(IDictionary<string, object> customerProps, string methodName, IDictionary<string, string> attributes)
        {
            Localytics.TagCustomerRegistered(customerProps, methodName, attributes.ToNSDictionary());
        }

        public void TagCustomerLoggedIn(IDictionary<string, object> customer, string methodName, IDictionary<string, string> attributes)
        {
            Localytics.TagCustomerLoggedIn(customer, methodName, attributes.ToNSDictionary());
        }

        public void TagCustomerLoggedOut(IDictionary<string, string> attributes)
        {
            Localytics.TagCustomerLoggedOut(attributes.ToNSDictionary());
        }

        public void TagInvited(string methodName, IDictionary<string, string> attributes)
        {
            Localytics.TagInvited(methodName, attributes.ToNSDictionary());
        }

        public void SetInAppMessageDismissButtonImageWithName(string imageName)
        {
            Localytics.SetInAppMessageDismissButtonImageWithName(imageName);
        }

        public void SetInAppMessageDismissButtonHidden(bool hidden)
        {
            Localytics.SetInAppMessageDismissButtonHidden(hidden);
        }

        public void SetInboxCampaign(object campaign, bool read)
        {
            Localytics.SetInboxCampaign((LLInboxCampaign)campaign, read);
        }

        public long InboxCampaignsUnreadCount()
        {
            return Localytics.InboxCampaignsUnreadCount();
        }

        public void SetLocationMonitoringEnabled(bool enabled)
        {
            Localytics.SetLocationMonitoringEnabled(enabled);
        }

        public void SetOptions(IDictionary<string, object> options)
        {
            Localytics.SetOptions(Convertor.ToNSDictionary(options));
        }

        public void PauseDataUploading(bool pause)
        {
            Localytics.PauseDataUploading(pause);
        }

        public void SetCustomerId(string customerId, bool optedOut)
        {
            Localytics.SetCustomerId(customerId, optedOut);
        }

        public void TriggerInAppMessagesForSessionStart()
        {
            Localytics.TriggerInAppMessagesForSessionStart();
        }

        public void TagImpressionForInAppCampaign(LLInAppCampaign campaign, LLImpressionType type)
        {
            Localytics.TagImpressionForInAppCampaign(campaign, type);
        }

        public void TagImpressionForInAppCampaign(LLInAppCampaign campaign, string customAction)
        {
            Localytics.TagImpressionForInAppCampaign(campaign, customAction);
        }

        public object[] AllInboxCampaigns()
        {
            return Localytics.AllInboxCampaigns();
        }

        public void TagImpressionForInboxCampaign(LLInboxCampaign campaign, LLImpressionType impressionType)
        {
            Localytics.TagImpressionForInboxCampaign((LLInboxCampaign)campaign, impressionType);
        }

        public void TagImpressionForInboxCampaign(LLInboxCampaign campaign, string customAction)
        {
            Localytics.TagImpressionForInboxCampaign((LLInboxCampaign)campaign, customAction);
        }

        //     public void TagImpressionForPushToInboxCampaign(LLInboxCampaign campaign, bool success)
        //     {
        //Localytics.TagImpressionForInboxCampaign(campaign, success);
        //}

        public void TagImpressionForPushToInboxCampaign(object campaign, bool success)
        {
            Localytics.TagImpressionForPushToInboxCampaign((LLInboxCampaign)campaign, success);
        }

        public void InboxListItemTapped(LLInboxCampaign campaign)
        {
            Localytics.InboxListItemTapped((LLInboxCampaign)campaign);
        }

        public void TagPlacesPushReceived(LLPlacesCampaign campaign)
        {
            Localytics.TagPlacesPushReceived((LLPlacesCampaign)campaign);
        }

        public void TagPlacesPushOpened(LLPlacesCampaign campaign, string identifier)
        {
            if (identifier == null)
            {
                Localytics.TagPlacesPushOpened((LLPlacesCampaign)campaign);
            }
            else
            {
                Localytics.TagPlacesPushOpened((LLPlacesCampaign)campaign, identifier);
            }
        }

        public void TriggerPlacesNotificationForCampaign(object campaign)
        {
            Localytics.TriggerPlacesNotificationForCampaign((LLPlacesCampaign)campaign);
        }

        public void TriggerPlacesNotificationForCampaignId(long campaignId, string regionId)
        {
            Localytics.TriggerPlacesNotificationForCampaignId((nint)campaignId, regionId);
        }

        public void RefreshAllInboxCampaigns(Action<object[]> inboxCampaignsDelegate)
        {
            Localytics.RefreshAllInboxCampaigns(x => inboxCampaignsDelegate(x));
        }

        public void RefreshInboxCampaigns(Action<object[]> inboxCampaignsDelegate)
        {
            Localytics.RefreshInboxCampaigns(x => inboxCampaignsDelegate(x));
        }

        //#pragma region Platform Specific API's
        public void RedirectLoggingToDisk()
        {
            Localytics.RedirectLoggingToDisk();
        }

        public void DidRegisterUserNotificationSettings()
        {
            Localytics.DidRegisterUserNotificationSettings();
        }

        public void SetLocation(CLLocationCoordinate2D location)
        {
            Localytics.SetLocation(location);
        }

        public bool HandleTestModeURL(NSUrl url)
        {
            return Localytics.HandleTestModeURL(url);
        }

        public void SetInAppMessageDismissButtonImage(UIImage image)
        {
            Localytics.SetInAppMessageDismissButtonImage(image);
        }

        public LLRegion[] GeofencesToMonitor(CLLocationCoordinate2D currentCoordinate)
        {
            return Localytics.GeofencesToMonitor(currentCoordinate);
        }

        public void TriggerRegion(object region, LLRegionEvent regionEvent, CLLocation location)
        {
            Localytics.TriggerRegion((CLRegion)region, regionEvent, location);
        }

        public void TriggerRegions(object[] regions, LLRegionEvent regionEvent, CLLocation location)
        {
            Localytics.TriggerRegions((CLRegion[])regions, regionEvent, location);
        }
    }
}
