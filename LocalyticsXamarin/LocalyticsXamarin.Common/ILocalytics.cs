using System;
using System.Collections;
using System.Collections.Generic;

namespace LocalyticsXamarin.Common
{
    /// <summary>
    /// In app message dismiss button location.
    /// </summary>
    public enum XFLLInAppMessageDismissButtonLocation : ulong
    {
        /// <value>Dismiss button is displayed on the left.</value>
        Left,
        /// <value>Dismiss button is displayed on the right.</value>
        Right
    }

    /// <summary>
    /// Profile scope.
    /// </summary>
    public enum XFLLProfileScope : ulong
    {
        /// <value>The Profile is scoped to the application.</value>
        Application,
        /// <value>The Profile is scoped across the entire organization and all its applications.</value>
        Organization
    }

    /// <summary>
    /// Region event.
    /// </summary>
    public enum XFLLRegionEvent : long
    {
        /// <summary>
        /// Event generated when the geofence region is entered.
        /// </summary>
        Enter,
        /// <summary>
        /// Event generated when the geofence region is exitted.
        /// </summary>
        Exit
    }

    /// <summary>
    /// In app message type.
    /// </summary>
    public enum XFLLInAppMessageType : long
    {
        /// <value>Displayed at the top of the screen.</value>
        Top,
        /// <value>Displayed at the bottom of the screen.</value>
        Bottom,
        /// <value>Displayed at the center of the screen.</value>
        Center,
        /// <value>Displayed as a full screen inapp.</value>
        Full
    }
    /// <summary>
    /// Impression type or conversion event type.
    /// </summary>
    public enum XFLLImpressionType : long
    {
        /// <value>A Click Conversion event type was registered for the campaign.</value>
        Click,
        /// <value>The camapign was dismissed</value>
        Dismiss
    }
    /// <summary>
    /// Campaign type.
    /// </summary>
    public enum XFCampaignType : long
    {
        /// <value>WebView campaign displayed in the application</value>
        InApp,
        /// <value>Push Campaign</value>
        Push,
        /// <value>Inbox Campaign</value>
        Inbox,
        /// <value>Geofence based Places Campaign</value>
        Places
    }

    /// <summary>
    /// Campaign interface representing all campaign types.
    /// </summary>
    public interface ICampaignBase
    {
        /// <value>Cmapaign Identifier</value>
        long CampaignId { get; }
        /// <value>Campaign Name</value>
        string Name { get; }
    }
    /// <summary>
    /// Web view campaign.
    /// </summary>
    public interface IWebViewCampaign : ICampaignBase
    {
        /// <value>local path with the </value>
        string CreativeFilePath { get; }
    }
    /// <summary>
    /// In app campaign.
    /// </summary>
    public interface IInAppCampaign : IWebViewCampaign
    {
        /// <summary>
        /// Gets a value indicating whether this <see cref="T:LocalyticsXamarin.Common.IInAppCampaign"/> is responsive.
        /// </summary>
        /// <value><c>true</c> if it's a responsive creative; otherwise, <c>false</c>.</value>
        bool IsResponsive { get; }
        /// <value>The aspect ratio of the campaign.</value>
        float AspectRatio { get; }
        /// <value>The offset to be applied to display the inapp Campaign.</value>
        float Offset { get; }
        /// <value>The background alpha to be applied to the campaign.</value>
        float BackgroundAlpha { get; }
        /// <value><c>true</c> if the dismiss button should be hidden; otherwise, <c>false</c>.</value>
        bool DismissButtonHidden { get; }
        /// <value>The dismiss button location.</value>
        XFLLInAppMessageDismissButtonLocation DismissButtonLocation { get; }

    }
    /// <summary>
    /// Inbox campaign.
    /// </summary>
    public interface IInboxCampaign : IWebViewCampaign
    {
        /// <summary>
        /// Reserved Field. Not be used. Would be removed in a future release.
        /// </summary>
        /// <returns>opaque object for debugging only.</returns>
        object Handle();
        /// <value><c>true</c> if the campaign has been marked read; otherwise, <c>false</c>.</value>
        bool Read { get; }
        /// <value>The title text.</value>
        string TitleText { get; }
        /// <value>The summary text.</value>
        string SummaryText { get; }
        /// <value><c>true</c> if the campaign has an associated creative; otherwise, <c>false</c>.</value>
        bool HasCreative { get; }
        /// <value><c>true</c> if this is a push to inbox campaign; otherwise, <c>false</c>.</value>
        bool IsPushToInboxCampaign { get; }
        /// <value><c>true</c> if the campaign has been marked deleted; otherwise, <c>false</c>.</value>
        bool IsDeleted { get; }
        /// <value>The received date as an time since epoch (NStimeInterval).</value>
        double ReceivedDate { get; }
        /// <value>The thumbnail Absolute URL.</value>
        string ThumbnailUrl { get; }
        /// <summary>
        /// Gets the sort order.
        /// </summary>
        /// <value>The sort order ?.</value>
        long SortOrder { get; }
        /// <value>The deep link URL.</value>
        string DeepLinkURL { get; }
    }
    /// <summary>
    /// Places campaign.
    /// </summary>
    public interface IPlacesCampaign : ICampaignBase
    {
        /// <returns>Opaque object for internal use and debugging. Shall be removed without notice.</returns>
        object Handle();
        /// <value>The message text.</value>
        string Message { get; }
        /// <value>The sound filename.</value>
        string SoundFilename { get; }
        /// <value>The attachment URL.</value>
        string AttachmentURL { get; }
    }
    /// <summary>
    /// Customer.
    /// </summary>
    public interface IXLCustomer
    {
        /// <value>The customer identifier.</value>
        string CustomerId { get; }
        /// <value>The first name.</value>
        string FirstName { get; }
        /// <value>The last name.</value>
        string LastName { get; }
        /// <value>The full name.</value>
        string FullName { get; }
        /// <value>The email address.</value>
        string EmailAddress { get; }
    }

    /// <summary>
    /// Localytics Common API Interface
    /// </summary>
    public interface ILocalytics
    {
        /// <summary>
        /// Did tag event occurs when localytics API to tag a event is invoked..
        /// </summary>
        event LocalyticsDidTagDelegate DidTagEvent;
        /// <summary>
        /// Event is triggered if a Localytics Session is Opened.
        /// </summary>
        event LocalyticsSessionDidOpenDelegate SessionDidOpen;
        /// <summary>
        /// Event is triggered if a Localytics Session will be Opened.
        /// </summary>
        event LocalyticsSessionWillOpenDelegate SessionWillOpen;

        /// <summary>
        /// Opens a session. Multiple calls are coallesed.
        /// </summary>
        void OpenSession();
        /// <summary>
        /// Closes the session.
        /// </summary>
        /// <remarks>Open Sessions are marked with a pending close. Sessions are extended if there is localytics activity before expiry of Session timer</remarks>
        void CloseSession();
        /// <summary>
        /// Uploads any data stored on the device by the localytics SDK. Essential to do this early, to ensure upload completes before app is suspended.
        /// </summary>
        void Upload();
        /// <summary>
        /// All data upload is deferred until it is resumed. Calls to the upload API dont perform any action. When data upload is resumed, all locally stored data is immediately uploaded.
        /// </summary>
        /// <param name="pause">If set to <c>true</c> pause.</param>
        void PauseDataUploading(bool pause);
        /// <summary>
        /// Tags the event.
        /// </summary>
        /// <param name="eventName">Event name.</param>
        /// <param name="attributes">Attributes.</param>
        /// <param name="customerValueIncrease">Customer value increase.</param>
        void TagEvent(string eventName, IDictionary<string, string> attributes = null, long? customerValueIncrease = null);
        /// <summary>
        /// A standard event to tag a single item purchase event (after the action has occurred)
        /// </summary>
        /// <param name="itemName">Item name.</param>
        /// <param name="itemId">Item identifier.</param>
        /// <param name="itemType">Item type.</param>
        /// <param name="itemPrice">Item price.</param>
        /// <param name="attributes">Attributes.</param>
        void TagPurchased(string itemName, string itemId, string itemType, Int64? itemPrice, IDictionary<string, string> attributes);
        /// <summary>
        /// A standard event to tag the addition of a single item to a cart (after the action has occurred)
        /// </summary>
        /// <param name="itemName">Item name.</param>
        /// <param name="itemId">Item identifier.</param>
        /// <param name="itemType">Item type.</param>
        /// <param name="itemPrice">Item price.</param>
        /// <param name="attributes">Attributes.</param>
        void TagAddedToCart(string itemName, string itemId, string itemType, Int64? itemPrice, IDictionary<string, string> attributes);
        /// <summary>
        /// A standard event to tag the start of the checkout process (after the action has occurred)
        /// </summary>
        /// <param name="totalPrice">Total price.</param>
        /// <param name="itemCount">Item count.</param>
        /// <param name="attributes">Attributes.</param>
        void TagStartedCheckout(Int64? totalPrice, Int64? itemCount, IDictionary<string, string> attributes);
        /// <summary>
        /// A standard event to tag the conclusions of the checkout process (after the action has occurred)
        /// </summary>
        /// <param name="totalPrice">Total price.</param>
        /// <param name="itemCount">Item count.</param>
        /// <param name="attributes">Attributes.</param>
        void TagCompletedCheckout(Int64? totalPrice, Int64? itemCount, IDictionary<string, string> attributes);
        /// <summary>
        /// A standard event to tag the viewing of content (after the action has occurred)
        /// </summary>
        /// <param name="contentName">Content name.</param>
        /// <param name="contentId">Content identifier.</param>
        /// <param name="contentType">Content type.</param>
        /// <param name="attributes">Attributes.</param>
        void TagContentViewed(string contentName, string contentId, string contentType, IDictionary<string, string> attributes);
        /// <summary>
        /// A standard event to tag a search event (after the action has occurred)
        /// </summary>
        /// <param name="queryText">Query text.</param>
        /// <param name="contentType">Content type.</param>
        /// <param name="resultCount">Result count.</param>
        /// <param name="attributes">Attributes.</param>
        void TagSearched(string queryText, string contentType, Int64? resultCount, IDictionary<string, string> attributes);
        /// <summary>
        /// A standard event to tag a share event (after the action has occurred)
        /// </summary>
        /// <param name="contentName">Content name.</param>
        /// <param name="contentId">Content identifier.</param>
        /// <param name="contentType">Content type.</param>
        /// <param name="methodName">Method name.</param>
        /// <param name="attributes">Attributes.</param>
        void TagShared(string contentName, string contentId, string contentType, string methodName, IDictionary<string, string> attributes);
        /// <summary>
        /// A standard event to tag the rating of content (after the action has occurred)
        /// </summary>
        /// <param name="contentName">Content name.</param>
        /// <param name="contentId">Content identifier.</param>
        /// <param name="contentType">Content type.</param>
        /// <param name="rating">Rating.</param>
        /// <param name="attributes">Attributes.</param>
        void TagContentRated(string contentName, string contentId, string contentType, Int64? rating, IDictionary<string, string> attributes);
        /// <summary>
        /// Tags the customer registered.
        /// </summary>
        [Obsolete("TagCustomerRegistered with a dictionary has been deprecated, please use the variant with IXLCustomer instead")]
        void TagCustomerRegistered(IDictionary<string, object> customer, string methodName, IDictionary<string, string> attributes);
        /// <summary>
        /// Tags the customer logged in.
        /// </summary>
         [Obsolete("TagCustomerLoggedIn with a dictionary has been deprecated, please use the variant with IXLCustomer instead")]
        void TagCustomerLoggedIn(IDictionary<string, object> customer, string methodName, IDictionary<string, string> attributes);
        /// <summary>
        /// A standard event to tag the registration of a user (after the action has occurred)
        /// </summary>
        /// <param name="customer">Customer.</param>
        /// <param name="methodName">Method name.</param>
        /// <param name="attributes">Attributes.</param>
        void TagCustomerRegistered(IXLCustomer customer, string methodName, IDictionary<string, string> attributes);
        /// <summary>
        /// A standard event to tag the logging in of a user (after the action has occurred)
        /// </summary>
        /// <param name="customer">Customer.</param>
        /// <param name="methodName">Method name.</param>
        /// <param name="attributes">Attributes.</param>
        void TagCustomerLoggedIn(IXLCustomer customer, string methodName, IDictionary<string, string> attributes);
        /// <summary>
        /// A standard event to tag the logging out of a user (after the action has occurred)
        /// </summary>
        /// <param name="attributes">Attributes.</param>
        void TagCustomerLoggedOut(IDictionary<string, string> attributes);
        /// <summary>
        /// A standard event to tag the invitation of a user (after the action has occured)
        /// </summary>
        /// <param name="methodName">Method name.</param>
        /// <param name="attributes">Attributes.</param>
        void TagInvited(string methodName, IDictionary<string, string> attributes);
        /// <summary>
        /// Allows tagging the flow of screens encountered during the session.
        /// </summary>
        /// <param name="screenName">Screen name.</param>
        void TagScreen(string screenName);
        /// <summary>
        /// Sets the value of custom dimension(user defined data).
        /// </summary>
        /// <remarks>Customer sensitive data should be hashed or encrypted</remarks>
        /// <param name="value">Value.</param>
        /// <param name="dimension">Dimension.</param>
        void SetCustomDimension(string value, uint dimension);
        /// <summary>
        /// Gets the custom value for a given dimension.
        /// </summary>
        /// <remarks>Must not be called from the main thread.</remarks>
        /// <returns>The custom dimension.</returns>
        /// <param name="dimension">Dimension.</param>
        string GetCustomDimension(uint dimension);
        /// <summary>
        /// Sets the value of a custom identifier
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="identifier">Identifier.</param>
        void SetIdentifier(string value, string identifier);
        /// <summary>
        /// Gets the identifier value for a given identifier. Must not be called form the main thread.
        /// </summary>
        /// <returns>The identifier.</returns>
        /// <param name="identifier">Identifier.</param>
        string GetIdentifier(string identifier);
        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        /// <remarks>Recommended to use SetCustomerId. privacy sensitive data should be hashed or encyrpted</remarks>
        /// <value>The customer identifier.</value>
        string CustomerId { get; set; }
        /// <summary>
        /// Sets the customer identifier and privacy status automically.
        /// </summary>
        /// <param name="customerId">Customer identifier.</param>
        /// <param name="privacyOptedOut">If set to <c>true</c> privacy opted out.</param>
        void SetCustomerId(string customerId, bool privacyOptedOut);
        /// <summary>
        /// Sets the profile attribute.
        /// </summary>
        /// <param name="attribute">Attribute.</param>
        /// <param name="scope">Scope.</param>
        /// <param name="values">Values can be long, long[], string, string[], Date[], Date.</param>
        void SetProfileAttribute(string attribute, XFLLProfileScope scope, params object[] values);
        /// <summary>
        /// Adds the profile attribute.
        /// </summary>
        /// <param name="attribute">Attribute.</param>
        /// <param name="scope">Scope.</param>
        /// <param name="values">Values can be long, string, Array of long or Array of String.</param>
        void AddProfileAttribute(string attribute, XFLLProfileScope scope, params object[] values);
        /// <summary>
        /// Removes the profile attribute from a set.
        /// </summary>
        /// <param name="attribute">Attribute.</param>
        /// <param name="scope">Scope.</param>
        /// <param name="values">Values.</param>
        void RemoveProfileAttribute(string attribute, XFLLProfileScope scope, params object[] values);
        /// <summary>
        /// Increments the value of a profile attribute.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="attribute">Attribute.</param>
        /// <param name="scope">Scope.</param>
        void IncrementProfileAttribute(Int64 value, string attribute, XFLLProfileScope scope = XFLLProfileScope.Application);
        /// <summary>
        /// Decrements the value of a profile attribute.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="attribute">Attribute.</param>
        /// <param name="scope">Scope.</param>
        void DecrementProfileAttribute(Int64 value, string attribute, XFLLProfileScope scope = XFLLProfileScope.Application);
        /// <summary>
        /// Deletes the profile attribute.
        /// </summary>
        /// <param name="attribute">Attribute.</param>
        /// <param name="scope">Scope.</param>
        void DeleteProfileAttribute(string attribute, XFLLProfileScope scope = XFLLProfileScope.Application);
        /// <summary>
        /// Sets the customer email.
        /// </summary>
        /// <param name="email">Email.</param>
        void SetCustomerEmail(string email);
        /// <summary>
        /// Sets the name of the customer first.
        /// </summary>
        /// <param name="firstName">First name.</param>
        void SetCustomerFirstName(string firstName);
        /// <summary>
        /// Sets the name of the customer last.
        /// </summary>
        /// <param name="lastName">Last name.</param>
        void SetCustomerLastName(string lastName);
        /// <summary>
        /// Sets the name of the customer full.
        /// </summary>
        /// <param name="fullName">Full name.</param>
        void SetCustomerFullName(string fullName);
        /// <summary>
        /// Customize the behavior of the SDK by setting custom values for various options.
        /// </summary>
        /// <param name="options">Options.</param>
        void SetOptions(IDictionary<string, object> options);
        /// <summary>
        /// Customize the behavior of the SDK by setting custom values for various options.
        /// </summary>
        /// <param name="key">Key.</param>
        /// <param name="value">Value.</param>
        void SetOption(string key, object value);
        /// <summary>
        /// Change the SDK Logging Behavior
        /// </summary>
        /// <value><c>true</c> if logging enabled; otherwise, <c>false</c>.</value>
        bool LoggingEnabled { get; set; }
        /// <summary>
        /// control collection of user data.
        /// </summary>
        /// <value><c>true</c> if opted out; otherwise, <c>false</c>.</value>
        bool OptedOut { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:LocalyticsXamarin.Common.ILocalytics"/> privacy
        /// opted out.
        /// </summary>
        /// <value><c>true</c> if privacy opted out; otherwise, <c>false</c>.</value>
        bool PrivacyOptedOut { get; set; }
        /// <summary>
        /// Gets the installation identifier.
        /// </summary>
        /// <value>The install identifier.</value>
        string InstallId { get; }
        /// <summary>
        /// Gets the version of the Localytics SDK.
        /// </summary>
        /// <value>The library version.</value>
        string LibraryVersion { get; }
        /// <summary>
        /// Gets the app key.
        /// </summary>
        /// <value>The app key.</value>
        string AppKey { get; }
        /// <summary>
        /// Controls the Test Mode charactertistics of the Localytics SDK.
        /// </summary>
        /// <value><c>true</c> if test mode enabled; otherwise, <c>false</c>.</value>
        bool TestModeEnabled { get; set; }
        /// <summary>
        /// Platform specific Push token identifier.
        /// </summary>
        /// <value>The push token info.</value>
        string PushTokenInfo { get; }
        /// <summary>
        /// Gets or sets a value indicating whether ADID parameter is added to In-App call to action URLs.
        /// </summary>
        /// <value><c>true</c> if inapp advertising identifier parameter enabled; otherwise, <c>false</c>.</value>
        bool InAppAdIdParameterEnabled { get; set; }

        /// <summary>
        /// Triggers the places notification for campaign identifier and region identifier.
        /// </summary>
        /// <param name="campaignId">Campaign identifier.</param>
        /// <param name="regionId">Region identifier.</param>
        void TriggerPlacesNotificationForCampaignId(long campaignId, string regionId);
        /// <summary>
        /// Gets or sets a value indicating whether ADID parameter is added to Inbox call to action URLs.
        /// </summary>
        /// <value><c>true</c> if inbox ad identifier parameter enabled; otherwise, <c>false</c>.</value>
        bool InboxAdIdParameterEnabled { get; set; }
        /// <summary>
        /// Gets or sets the dismiss button location for inapp messages.
        /// </summary>
        /// <value>The in app message dismiss button location.</value>
        XFLLInAppMessageDismissButtonLocation InAppMessageDismissButtonLocation { get; set; }
        /// <summary>
        /// Sets the in app message dismiss button hidden.
        /// </summary>
        /// <param name="hidden">If set to <c>true</c> hidden.</param>
        void SetInAppMessageDismissButtonHidden(bool hidden);

        /// <summary>
        /// Triggers the in app message.
        /// </summary>
        /// <param name="triggerName">Trigger name.</param>
        /// <param name="attributes">Attributes.</param>
        void TriggerInAppMessage(string triggerName, IDictionary<string, string> attributes = null);
        /// <summary>
        /// Triggers the session start inapp messages.
        /// </summary>
        /// <remarks>? what happens if they were already fired?</remarks>
        void TriggerInAppMessagesForSessionStart();
        /// <summary>
        /// Dismisses the currently displayed inapp message.
        /// </summary>
        void DismissCurrentInAppMessage();
        /// <summary>
        /// Inboxs campaigns list.
        /// </summary>
        /// <see cref="DisplayableInboxCampaigns"/>
        [Obsolete("InboxCampaigns is deprecated, please use DisplayableInboxCampaigns instead.")]
        IInboxCampaign[] InboxCampaigns();
        /// <summary>
        /// Inbox campaigns that are available for display.
        /// </summary>
        /// <returns>The inbox campaigns.</returns>
        IInboxCampaign[] DisplayableInboxCampaigns();
        /// <summary>
        /// Alls the inbox campaigns.
        /// </summary>
        /// <returns>The inbox campaigns.</returns>
        IInboxCampaign[] AllInboxCampaigns();
        /// <summary>
        /// Fetches the inbox campaigns if necessary and provides an update list.
        /// </summary>
        /// <param name="inboxCampaignsDelegate">Inbox campaigns delegate.</param>
        void RefreshInboxCampaigns(Action<IInboxCampaign[]> inboxCampaignsDelegate);
        /// <summary>
        /// Refresh inbox campaigns from the Localytics server that are enabled.
        /// </summary>
        /// <param name="inboxAllCampaignsDelegate">Inbox all campaigns delegate.</param>
        void RefreshAllInboxCampaigns(Action<IInboxCampaign[]> inboxAllCampaignsDelegate);
        /// <summary>
        /// A standard event to tag an In-App impression.
        /// </summary>
        /// <param name="campaign">Campaign.</param>
        /// <param name="customAction">Custom action.</param>
        void TagImpression(IInboxCampaign campaign, string customAction);
        /// <summary>
        /// Marks the inbox campaign as Read.
        /// </summary>
        /// <param name="campaign">Campaign.</param>
        /// <param name="read">If set to <c>true</c> read.</param>
        void SetInboxCampaign(IInboxCampaign campaign, bool read);
        /// <summary>
        /// Informs the the Localytics SDK that an Inbox campaign was tapped in the list view.
        /// </summary>
        /// <param name="campaign">Campaign.</param>
        void InboxListItemTapped(IInboxCampaign campaign);
        /// <summary>
        /// Delets an Inbox Campaign
        /// </summary>
        /// <param name="campaign">Campaign.</param>
        void DeleteInboxCampaign(IInboxCampaign campaign);
        /// <summary>
        /// Number of unread Inbox Campaigns.
        /// </summary>
        /// <returns>The campaigns unread count.</returns>
        long InboxCampaignsUnreadCount();
        /// <summary>
        /// Control location monitoring including geofences.
        /// </summary>
        /// <param name="enabled">If set to <c>true</c> enabled.</param>
        void SetLocationMonitoringEnabled(bool enabled);
    }

}
