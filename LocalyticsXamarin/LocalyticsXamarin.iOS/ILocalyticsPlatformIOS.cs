using System;
using System.Collections;
using System.Collections.Generic;
using Foundation;

namespace LocalyticsXamarin.iOS
{
	public class LocalyticsPlatformIOS //:/ ILocalytics
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

        public void TagEvent(string eventName)
        {
            Localytics.TagEvent(eventName);
        }

        public void TagEvent(string eventName, System.Collections.Generic.IDictionary<string, string> attributes)
        {
            Localytics.TagEvent(eventName, attributes.ToNSDictionary());
        }

        public void TagEvent(string eventName, System.Collections.Generic.IDictionary<string, string> attributes, long customerValueIncrease)
        {
            Localytics.TagEvent(eventName, attributes.ToNSDictionary(), customerValueIncrease);
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


        public void TriggerInAppMessage(string triggerName)
        {
            Localytics.TriggerInAppMessage(triggerName);
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

        public void TagPurchased(string itemName, string itemId, string itemType, double itemPrice, IDictionary<string, string> attributes)
        {
            Localytics.TagPurchased(itemName, itemId, itemType, new NSNumber(itemPrice), attributes.ToNSDictionary());
        }

        public void TagAddedToCart(string itemName, string itemId, string itemType, double itemPrice, IDictionary<string, string> attributes)
        {
            Localytics.TagAddedToCart(itemName, itemId, itemType, itemPrice, attributes.ToNSDictionary());
        }

        public void TagStartedCheckout(double totalPrice, double itemCount, IDictionary<string, string> attributes)
        {
            Localytics.TagStartedCheckout(totalPrice, itemCount, attributes.ToNSDictionary());
        }

        public void TagCompletedCheckout(double totalPrice, double itemCount, IDictionary<string, string> attributes)
        {
            Localytics.TagCompletedCheckout(new NSNumber(totalPrice), new NSNumber(itemCount), attributes.ToNSDictionary());
        }

        public void TagContentViewed(string contentName, string contentId, string contentType, IDictionary<string, string> attributes)
        {
            Localytics.TagContentViewed(contentName, contentId, contentType, attributes.ToNSDictionary());
        }

        public void TagSearched(string queryText, string contentType, double resultCount, IDictionary<string, string> attributes)
        {
            Localytics.TagSearched(queryText, contentType, new NSNumber(resultCount), attributes.ToNSDictionary());
        }

        public void TagShared(string contentName, string contentId, string contentType, string methodName, IDictionary<string, string> attributes)
        {
            Localytics.TagShared(contentName, contentId, contentType, methodName, attributes.ToNSDictionary());
        }

        public void TagContentRated(string contentName, string contentId, string contentType, double rating, IDictionary<string, string> attributes)
        {
            Localytics.TagContentRated(contentName, contentId, contentType, new NSNumber(rating), attributes.ToNSDictionary());
        }

        public void TagCustomerRegistered(IDictionary<string, object> customer, string methodName, IDictionary<string, string> attributes)
        {
            Localytics.TagCustomerRegistered(customer, methodName, attributes.ToNSDictionary());
        }

        public void TagCustomerLoggedIn(IDictionary<string, object> customer, string methodName, IDictionary<string, string> attributes)
        {
            Localytics.TagCustomerLoggedIn(customer, methodName, attributes.ToNSDictionary());
        }

        public void TagCustomerLoggedOut(IDictionary<string, string> attributes)
        {
            Localytics.TagCustomerLoggedOut(attributes.ToNSDictionary());
        }

        public void TagInvited(string methodName, IDictionary attributes)
        {
            Localytics.TagInvited(methodName, attributes.ToNSDictionary());
        }

        public void RedirectLoggingToDisk()
        {
            Localytics.RedirectLoggingToDisk();
        }

        public void DidRegisterUserNotificationSettings()
        {
            Localytics.DidRegisterUserNotificationSettings();
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

        public void SetOptions(IDictionary options)
        {
            Localytics.SetOptions(options.ToNSDictionary());
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

        public void TagImpressionForInAppCampaign(object campaign, string customAction)
        {
            Localytics.TagImpressionForInAppCampaign((LLInAppCampaign)campaign, customAction);
        }

        public object[] AllInboxCampaigns()
        {
            return Localytics.AllInboxCampaigns();
        }

       public void TagImpressionForInboxCampaign(object campaign, string customAction)
        {
            Localytics.TagImpressionForInboxCampaign((LLInboxCampaign)campaign, customAction);
        }

        public void TagImpressionForPushToInboxCampaign(object campaign, bool success)
        {
            Localytics.TagImpressionForPushToInboxCampaign((LLInboxCampaign)campaign, success);
        }

        public void InboxListItemTapped(object campaign)
        {
            Localytics.InboxListItemTapped((LLInboxCampaign)campaign);
        }

        public void TagPlacesPushReceived(object campaign)
        {
            Localytics.TagPlacesPushReceived((LLPlacesCampaign)campaign);
        }

        public void TagPlacesPushOpened(object campaign)
        {
            Localytics.TagPlacesPushOpened((LLPlacesCampaign)campaign);
        }

        public void TagPlacesPushOpened(object campaign, string identifier)
        {
            Localytics.TagPlacesPushOpened((LLPlacesCampaign)campaign, identifier);
        }

        public void TriggerPlacesNotificationForCampaign(object campaign)
        {
            Localytics.TriggerPlacesNotificationForCampaign((LLPlacesCampaign)campaign);
        }

        public void TriggerPlacesNotificationForCampaignId(long campaignId, string regionId)
        {
            Localytics.TriggerPlacesNotificationForCampaignId((nint)campaignId, regionId);
        }

    }
}
