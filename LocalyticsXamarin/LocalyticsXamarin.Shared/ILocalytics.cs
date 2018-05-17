using System;
using System.Collections;
using System.Collections.Generic;

namespace LocalyticsXamarin.Common
{
	public enum XFLLInAppMessageDismissButtonLocation : ulong
    {
        Left,
        Right
    }

    public enum XFLLProfileScope : ulong
    {
        Application,
        Organization
    }

    public delegate void InboxCampaignsDelegate(object[] campaigns);
    public interface ILocalytics
    {
        void OpenSession();
        void CloseSession();
        void Upload();

        void TagEvent(string eventName);
        void TagEvent(string eventName, IDictionary<string, string> attributes);
        void TagEvent(string eventName, IDictionary<string, string> attributes, long customerValueIncrease);


        void TagPurchased(string itemName, string itemId, string itemType, double itemPrice, IDictionary<string, string> attributes);
        void TagAddedToCart(string itemName, string itemId, string itemType, double itemPrice, IDictionary<string, string> attributes);
        void TagStartedCheckout(double totalPrice, double itemCount, IDictionary<string, string> attributes);
        void TagCompletedCheckout(double totalPrice, double itemCount, IDictionary<string, string> attributes);
        void TagContentViewed(string contentName, string contentId, string contentType, IDictionary<string, string> attributes);
        void TagSearched(string queryText, string contentType, double resultCount, IDictionary<string, string> attributes);
        void TagShared(string contentName, string contentId, string contentType, string methodName, IDictionary<string, string> attributes);
        void TagContentRated(string contentName, string contentId, string contentType, double rating, IDictionary<string, string> attributes);
        void TagCustomerRegistered(IDictionary<string, object> customer, string methodName, IDictionary<string, string> attributes);
        void TagCustomerLoggedIn(IDictionary<string, object> customer, string methodName, IDictionary<string, string> attributes);
        void TagCustomerLoggedOut(IDictionary<string, string> attributes);
        void TagInvited(string methodName, IDictionary attributes);

        void TagScreen(string screenName);


        void SetCustomDimension(string value, uint dimension);
        string GetCustomDimension(uint dimension);

        void SetIdentifier(string value, string identifier);
        string GetIdentifier(string identifier);

        string CustomerId { get; set; }

        void SetProfileAttribute(Object value, string attribute, XFLLProfileScope scope = XFLLProfileScope.Application);
        void AddProfileAttributes(string attribute, XFLLProfileScope scope, params object[] values);
        void RemoveProfileAttributes(string attribute, XFLLProfileScope scope, params object[] values);
        void IncrementProfileAttribute(int value, string attribute, XFLLProfileScope scope = XFLLProfileScope.Application);
        void DecrementProfileAttribute(int value, string attribute, XFLLProfileScope scope = XFLLProfileScope.Application);
        void DeleteProfileAttribute(string attribute, XFLLProfileScope scope = XFLLProfileScope.Application);

        void SetCustomerEmail(string email);
        void SetCustomerFirstName(string firstName);
        void SetCustomerLastName(string lastName);
        void SetCustomerFullName(string fullName);

        string PushTokenInfo { get; }

        void RedirectLoggingToDisk();

        bool PrivacyOptedOut { get; set; }

        void DidRegisterUserNotificationSettings();

        /*
        // Not Supported
        */
        void SetInAppMessageDismissButtonImageWithName(string imageName);
        XFLLInAppMessageDismissButtonLocation InAppMessageDismissButtonLocation { get; set; }
        void SetInAppMessageDismissButtonHidden(bool hidden);
        /* End Not Supported */

        void TriggerInAppMessage(string triggerName);
        void TriggerInAppMessage(string triggerName, IDictionary<string, string> attributes);
        void DismissCurrentInAppMessage();

        object[] InboxCampaigns { get; }
        void RefreshInboxCampaigns(InboxCampaignsDelegate inboxCampaignsDelegate);
        void SetInboxCampaign(object campaign, bool read);
        long InboxCampaignsUnreadCount();
        void SetLocationMonitoringEnabled(bool enabled);

        void SetOptions(IDictionary options);

        bool LoggingEnabled { get; set; }

        bool OptedOut { get; set; }

        bool TestModeEnabled { get; set; }

        string InstallId { get; }
        string LibraryVersion { get; }
        string AppKey { get; }

        bool InAppAdIdParameterEnabled { get; set; }

        void PauseDataUploading(bool pause);
        void SetCustomerId(string customerId, bool optedOut);

        void TriggerInAppMessagesForSessionStart();

        object[] AllInboxCampaigns();
        void RefreshAllInboxCampaigns(InboxCampaignsDelegate inboxCampaignsDelegate);

        void TriggerPlacesNotificationForCampaignId(long campaignId, string regionId);

        bool InboxAdIdParameterEnabled { get; set; }


        void TagImpressionForInAppCampaign(object campaign, string customAction);
        void TagImpressionForInboxCampaign(object campaign, string customAction);
        void TagImpressionForPushToInboxCampaign(object campaign, bool success);
        void InboxListItemTapped(object campaign);
        void TagPlacesPushReceived(object campaign);
        void TagPlacesPushOpened(object campaign);
        void TagPlacesPushOpened(object campaign, string identifier);
        void TriggerPlacesNotificationForCampaign(object campaign);

    }
}
