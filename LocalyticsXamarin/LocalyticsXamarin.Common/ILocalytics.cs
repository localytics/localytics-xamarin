using System;
using System.Collections;
using System.Collections.Generic;

namespace LocalyticsXamarin.Common
{
    // To accomodate need to change c
    public interface LocalyticsSessionDidOpenEventArgs
    {
        bool First { get; }
        bool Upgrade { get; }
        bool Resume { get; }
    }

    public interface LocalyticsSessionWillOpenEventArgs
    {
        bool First { get; }
        bool Upgrade { get; }
        bool Resume { get; }
    }

    public interface LocalyticsDidTagEventEventArgs
    {
        string EventName { get; }
        IDictionary<string, string> Attributes { get; }
        double? CustomerValue { get; }
    }

    public class InAppEventArgs : EventArgs { } // No Extra Args.
    public class InAppDidDisplayEventArgs : EventArgs { } // No Extra Args.
    public class InAppWillDismissEventArgs : EventArgs { } // No Extra Args.
    public class InAppDidDismissEventArgs : EventArgs { } // No Extra Args.

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

    public enum XFLLRegionEvent : long
    {
        Enter,
        Exit
    }

    public enum XFLLInAppMessageType : long
    {
        Top,
        Bottom,
        Center,
        Full
    }

    public enum XFLLImpressionType : long
    {
        Click,
        Dismiss
    }

    public enum XFCampaignType : long
    {
        InApp,
        Push,
        Inbox,
        Places
    }

    public interface ICampaignBase
    {
        //nint
        long CampaignId { get; }
        string Name { get; }
        //NSDictionary
        //IDictionary<string, string> Attributes { get; }
    }
    public interface IWebViewCampaign : ICampaignBase
    {
        string CreativeFilePath { get; }
    }

    public interface IInAppCampaign : IWebViewCampaign
    {
        int ImpressionType { get; }
        bool IsResponsive { get; }
        //nfloat
        float AspectRatop { get; }
        //nfloat
        float Offset { get; }
        //nfloat 
        float BackgroundAlpha { get; }

        bool DismissButtonHidden { get; }
        XFLLInAppMessageDismissButtonLocation DismissButtonLocation { get; }
    }

    public interface IInboxCampaign : IWebViewCampaign
    {
        object Handle();
        // IOS allows set.
        bool Read { get; }
        string TitleText { get; }
        string SummaryText { get; }
        bool HasCreative { get; }
        bool IsPushToInboxCampaign { get; }

        //NSTimeInterval
        double ReceivedDate { get; }
        // NSUrl ThumbnailUrl
        string ThumbnailUrl { get; }
        //nint
        long SortOrder { get; }
        //NSUrl DeepLinkURL 
        string DeepLinkURL { get; }
    }

    public interface ILocalytics
    {
        void OpenSession();
        void CloseSession();
        void Upload();
        void PauseDataUploading(bool pause);

        //void TagEvent(string eventName);
        //void TagEvent(string eventName, IDictionary<string, string> attributes);
        void TagEvent(string eventName, IDictionary<string, string> attributes = null, long? customerValueIncrease = null);

        void TagPurchased(string itemName, string itemId, string itemType, Int64? itemPrice, IDictionary<string, string> attributes);
        void TagAddedToCart(string itemName, string itemId, string itemType, Int64? itemPrice, IDictionary<string, string> attributes);
        void TagStartedCheckout(Int64? totalPrice, Int64? itemCount, IDictionary<string, string> attributes);
        void TagCompletedCheckout(Int64? totalPrice, Int64? itemCount, IDictionary<string, string> attributes);
        void TagContentViewed(string contentName, string contentId, string contentType, IDictionary<string, string> attributes);
        void TagSearched(string queryText, string contentType, Int64? resultCount, IDictionary<string, string> attributes);
        void TagShared(string contentName, string contentId, string contentType, string methodName, IDictionary<string, string> attributes);
        void TagContentRated(string contentName, string contentId, string contentType, Int64? rating, IDictionary<string, string> attributes);
        void TagCustomerRegistered(IDictionary<string, object> customer, string methodName, IDictionary<string, string> attributes);
        void TagCustomerLoggedIn(IDictionary<string, object> customer, string methodName, IDictionary<string, string> attributes);
        void TagCustomerLoggedOut(IDictionary<string, string> attributes);
        void TagInvited(string methodName, IDictionary<string, string> attributes);

        void TagScreen(string screenName);

        void SetCustomDimension(string value, uint dimension);
        string GetCustomDimension(uint dimension);

        void SetIdentifier(string value, string identifier);
        string GetIdentifier(string identifier);

        string CustomerId { get; set; }
        void SetCustomerId(string customerId, bool privacyOptedOut);

        // object can be long, long[], string, string[], Date[], Date
        void SetProfileAttribute(string attribute, XFLLProfileScope scope, params object[] values);
        void AddProfileAttribute(string attribute, XFLLProfileScope scope, params object[] values);
        void RemoveProfileAttribute(string attribute, XFLLProfileScope scope, params object[] values);
        void IncrementProfileAttribute(Int64 value, string attribute, XFLLProfileScope scope = XFLLProfileScope.Application);
        void DecrementProfileAttribute(Int64 value, string attribute, XFLLProfileScope scope = XFLLProfileScope.Application);
        void DeleteProfileAttribute(string attribute, XFLLProfileScope scope = XFLLProfileScope.Application);

        void SetCustomerEmail(string email);
        void SetCustomerFirstName(string firstName);
        void SetCustomerLastName(string lastName);
        void SetCustomerFullName(string fullName);

        void SetOptions(IDictionary<string, object> options);
        void SetOption(string key, object value);

        bool LoggingEnabled { get; set; }

        bool OptedOut { get; set; }
        bool PrivacyOptedOut { get; set; }

        string InstallId { get; }
        string LibraryVersion { get; }
        string AppKey { get; }

        bool TestModeEnabled { get; set; }

        string PushTokenInfo { get; }

        bool InAppAdIdParameterEnabled { get; set; }


        void TriggerPlacesNotificationForCampaignId(long campaignId, string regionId);

        bool InboxAdIdParameterEnabled { get; set; }

        XFLLInAppMessageDismissButtonLocation InAppMessageDismissButtonLocation { get; set; }
        void SetInAppMessageDismissButtonHidden(bool hidden);

        //void TriggerInAppMessage(string triggerName);
        void TriggerInAppMessage(string triggerName, IDictionary<string, string> attributes = null);
        void TriggerInAppMessagesForSessionStart();

        void DismissCurrentInAppMessage();

        IInboxCampaign[] InboxCampaigns();
        IInboxCampaign[] AllInboxCampaigns();
        void RefreshInboxCampaigns(Action<IInboxCampaign[]> inboxCampaignsDelegate);
        void RefreshAllInboxCampaigns(Action<IInboxCampaign[]> inboxAllCampaignsDelegate);
        void TagImpression(IInboxCampaign campaign, string customAction);
        void SetInboxCampaign(IInboxCampaign campaign, bool read);
        void InboxListItemTapped(IInboxCampaign campaign);

        long InboxCampaignsUnreadCount();

        void SetLocationMonitoringEnabled(bool enabled);
    }
}
