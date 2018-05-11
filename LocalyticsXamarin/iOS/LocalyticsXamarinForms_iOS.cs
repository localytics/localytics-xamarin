using System;
using System.Collections.Generic;

using Foundation;

using LocalyticsXamarin.Shared;
using LocalyticsXamarin.iOS;
using LocalyticsXamarin.iOS.Enums;
using UIKit;
using CoreLocation;
using System.Collections;

[assembly: Xamarin.Forms.Dependency (typeof (LocalyticsXamarin.Forms.LocalyticsXamarinForms_iOS))]
namespace LocalyticsXamarin.Forms
{
	public interface ILocalyticIOS
    {
        bool HandleTestModeURL(NSUrl url);
        void SetInAppMessageDismissButtonImage(UIImage image);
        void SetLocation(CLLocationCoordinate2D location);
        LLRegion[] GeofencesToMonitor(CLLocationCoordinate2D currentCoordinate);
        void TriggerRegion(object region, LLRegionEvent regionEvent, CLLocation location);
        void TriggerRegions(object[] regions, LLRegionEvent regionEvent, CLLocation location);
        void TagImpressionForInAppCampaign(object campaign, LLImpressionType impressionType);
        void TagImpressionForInboxCampaign(object campaign, LLImpressionType impressionType);
        LLInboxDetailViewController InboxDetailViewControllerForCampaign(object campaign);
    }

	public class LocalyticsXamarinForms_iOS : ILocalytics , ILocalyticsXamarinForms
	{
		public LocalyticsXamarinForms_iOS() { }

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

		public void SetProfileAttribute(object value, string attribute, XFLLProfileScope scope = XFLLProfileScope.Application)
		{
			Localytics.SetProfileAttribute(NSObject.FromObject(value), attribute, ToLLProfileScope(scope));
		}

		public void AddProfileAttributes(string attribute, XFLLProfileScope scope, params object[] values)
		{
			Localytics.AddProfileAttributes(attribute, ToLLProfileScope(scope), values);
		}
        
		public void RemoveProfileAttributes(string attribute, XFLLProfileScope scope = XFLLProfileScope.Application, params object[] values)
		{
			Localytics.RemoveProfileAttributes(attribute, ToLLProfileScope(scope), values);
		}

		public void IncrementProfileAttribute(int value, string attribute, XFLLProfileScope scope = XFLLProfileScope.Application)
		{
			Localytics.IncrementProfileAttribute(value, attribute, ToLLProfileScope(scope));
		}

		public void DecrementProfileAttribute(int value, string attribute, XFLLProfileScope scope = XFLLProfileScope.Application)
		{
			Localytics.DecrementProfileAttribute(value, attribute, ToLLProfileScope(scope));
		}

		public void DeleteProfileAttribute(string attribute, XFLLProfileScope scope = XFLLProfileScope.Application)
		{
			Localytics.DeleteProfileAttribute(attribute, ToLLProfileScope(scope));
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

		public XFLLInAppMessageDismissButtonLocation InAppMessageDismissButtonLocation
		{
			get
			{
				return ToXFLLInAppMessageDismissButtonLocation(Localytics.InAppMessageDismissButtonLocation);
			}
			set
			{
				Localytics.InAppMessageDismissButtonLocation = ToLLInAppMessageDismissButtonLocation(value);
			}
		}

		public void TriggerInAppMessage(string triggerName)
		{
			Localytics.TriggerInAppMessage(triggerName);
		}

		public void TriggerInAppMessage(string triggerName, IDictionary<string, string> attributes)
		{
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
        
		private LLInAppMessageDismissButtonLocation ToLLInAppMessageDismissButtonLocation(XFLLInAppMessageDismissButtonLocation source) {
			if (source == XFLLInAppMessageDismissButtonLocation.Right) {
				return LLInAppMessageDismissButtonLocation.Right;
			}

			return LLInAppMessageDismissButtonLocation.Left;
		}

		private XFLLInAppMessageDismissButtonLocation ToXFLLInAppMessageDismissButtonLocation(LLInAppMessageDismissButtonLocation source) {
			if (source == LLInAppMessageDismissButtonLocation.Right) {
				return XFLLInAppMessageDismissButtonLocation.Right;
			}

			return XFLLInAppMessageDismissButtonLocation.Left;
		}

		private LLProfileScope ToLLProfileScope(XFLLProfileScope source) {
			if (source == XFLLProfileScope.Organization) {
				return LLProfileScope.Organization;
			}

			return LLProfileScope.Application;
		}

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

		public void RefreshInboxCampaigns(InboxCampaignsDelegate inboxCampaignsDelegate)
		{
			Localytics.RefreshInboxCampaigns(new Action<LLInboxCampaign[]>((LLInboxCampaign[] obj) => {
				inboxCampaignsDelegate(obj);
            }));
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

		public void RefreshAllInboxCampaigns(InboxCampaignsDelegate inboxCampaignsDelegate)
		{
			Localytics.RefreshAllInboxCampaigns(new Action<LLInboxCampaign[]>((LLInboxCampaign[] obj) => {
				inboxCampaignsDelegate(obj);
			}));
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

