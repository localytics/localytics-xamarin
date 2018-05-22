using System;
using System.Collections.Generic;

namespace LocalyticsXamarin.Android
{
	public class LocalyticsPlatform
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

		public void TagEvent(string eventName, IDictionary<string, string> attributes)
		{
			Localytics.TagEvent(eventName, attributes);
		}

		public void TagEvent(string eventName, IDictionary<string, string> attributes, long customerValueIncrease)
		{
			Localytics.TagEvent(eventName, attributes, customerValueIncrease);
		}

		public void TagScreen(string screenName)
		{
			Localytics.TagScreen(screenName);
		}

		public void SetCustomDimension(string value, uint dimension)
		{
			Localytics.SetCustomDimension((int)dimension, value);
		}

		public string GetCustomDimension(uint dimension)
		{
			return Localytics.GetCustomDimension((int)dimension);
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
				return Localytics.PushRegistrationId;
			}
		}

		public void TriggerInAppMessage(string triggerName)
		{
			Localytics.TriggerInAppMessage(triggerName);
		}

		public void TriggerInAppMessage(string triggerName, IDictionary<string, string> attributes)
		{
			Localytics.TriggerInAppMessage(triggerName, attributes);
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
				return Localytics.InstallId;
			}
		}

		public string LibraryVersion
		{
			get
			{
				return Localytics.LibraryVersion;
			}
		}

		public string AppKey
		{
			get
			{
				return Localytics.AppKey;
			}
		}

		public bool PrivacyOptedOut { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public object[] InboxCampaigns => throw new NotImplementedException();

		public bool InAppAdIdParameterEnabled { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public bool InboxAdIdParameterEnabled { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public void TagPurchased(string itemName, string itemId, string itemType, Int64 itemPrice, IDictionary<string, string> attributes)
		{
			Localytics.TagPurchased(itemName, itemId, itemType, new Java.Lang.Long(itemPrice), attributes);
		}

		public void TagAddedToCart(string itemName, string itemId, string itemType, Int64 itemPrice, IDictionary<string, string> attributes)
		{
			Localytics.TagAddedToCart(itemName, itemId, itemType, new Java.Lang.Long(itemPrice), attributes);
		}
		public void TagStartedCheckout(Int64 totalPrice, Int64 itemCount, IDictionary<string, string> attributes)
		{
			Localytics.TagStartedCheckout(new Java.Lang.Long(totalPrice), new Java.Lang.Long(itemCount), attributes);
		}

		public void TagCompletedCheckout(Int64 totalPrice, Int64 itemCount, IDictionary<string, string> attributes)
		{
			Localytics.TagCompletedCheckout(new Java.Lang.Long(totalPrice), new Java.Lang.Long(itemCount), attributes);
		}

		public void TagContentViewed(string contentName, string contentId, string contentType, IDictionary<string, string> attributes)
		{
			Localytics.TagContentViewed(contentName, contentId, contentType, attributes);
		}

		public void TagSearched(string queryText, string contentType, Int64 resultCount, IDictionary<string, string> attributes)
		{
			Localytics.TagSearched(queryText, contentType, new Java.Lang.Long(resultCount), attributes);
		}

		public void TagShared(string contentName, string contentId, string contentType, string methodName, IDictionary<string, string> attributes)
		{
			Localytics.TagShared(contentName, contentId, contentType, methodName, attributes);
		}

		public void TagContentRated(string contentName, string contentId, string contentType, Int64 rating, IDictionary<string, string> attributes)
		{
			Localytics.TagContentRated(contentName, contentId, contentType, new Java.Lang.Long(rating), attributes);
		}

		public void TagCustomerRegistered(IDictionary<string, object> customerProps, string methodName, IDictionary<string, string> attributes)
		{
			var cust = Convertor.toCustomer(customerProps);
			Localytics.TagCustomerRegistered(cust, methodName, attributes);
		}

		public void TagCustomerLoggedIn(IDictionary<string, object> customerProps, string methodName, IDictionary<string, string> attributes)
		{
			var cust = Convertor.toCustomer(customerProps);
			Localytics.TagCustomerLoggedIn(cust, methodName, attributes);
		}

		public void TagCustomerLoggedOut(IDictionary<string, string> attributes)
		{
			Localytics.TagCustomerLoggedOut(attributes);
		}

		public void TagInvited(string methodName, IDictionary<string, string> attributes)
		{
			Localytics.TagInvited(methodName, attributes);
		}

		public void SetInAppMessageDismissButtonHidden(bool hidden)
		{
			// View.INVISBLE or 4 hides  it.
			Localytics.SetInAppMessageDismissButtonVisibility(hidden ? 4 : 1);
		}

		public void SetInboxCampaign(object campaign, bool read)
		{
			Localytics.SetInboxCampaignRead((InboxCampaign)campaign, read);
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
			Localytics.SetOptions(Convertor.ToGenericDictionary(options));
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

		public void TagImpressionForInAppCampaign(object campaign, string customAction)
		{
			Localytics.TagInAppImpression((InAppCampaign)campaign, customAction);
		}

		public object[] AllInboxCampaigns()
		{
			return Localytics.AllInboxCampaigns.ToArray();
		}

		public void TagImpressionForInboxCampaign(object campaign, string customAction)
		{
			if ("click".Equals(customAction, StringComparison.InvariantCultureIgnoreCase))
			{
				Localytics.TagInboxImpression((InboxCampaign)campaign, Localytics.ImpressionType.Click);
			}
			else if ("dismiss".Equals(customAction, StringComparison.InvariantCultureIgnoreCase))
			{
				Localytics.TagInboxImpression((InboxCampaign)campaign, Localytics.ImpressionType.Dismiss);
			}
			else
			{
				Localytics.TagInboxImpression((InboxCampaign)campaign, customAction);
			}
		}

		public void TagImpressionForPushToInboxCampaign(object campaign, bool success)
		{
			// FIXME Native doesnt support Deeplink Success on Android.
			Localytics.TagPushToInboxImpression((InboxCampaign)campaign);
		}

		public void InboxListItemTapped(object campaign)
		{
			Localytics.InboxListItemTapped((InboxCampaign)campaign);
		}

		public void TagPlacesPushReceived(object campaign)
		{
			Localytics.TagPlacesPushReceived((PlacesCampaign)campaign);
		}

		public void TagPlacesPushOpened(object campaign)
		{
			Localytics.TagPlacesPushOpened((PlacesCampaign)campaign);
		}

		public void TagPlacesPushOpened(object campaign, string identifier)
		{
			Localytics.TagPlacesPushOpened((PlacesCampaign)campaign, identifier);
		}

		public void TriggerPlacesNotificationForCampaign(object campaign)
		{
			Localytics.TriggerPlacesNotification((PlacesCampaign)campaign);
		}

		public void TriggerPlacesNotificationForCampaignId(long campaignId, string regionId)
		{
			Localytics.TriggerPlacesNotification(campaignId, regionId);
		}

		IInboxRefreshListenerImplementor inboxAllRefreshListener = new IInboxRefreshListenerImplementor();
		public void RefreshAllInboxCampaigns(Action<object[]> inboxCampaignsDelegate)
		{
			inboxAllRefreshListener.SetCallback(inboxCampaignsDelegate);
        }
        
		IInboxRefreshListenerImplementor inboxRefreshListener = new IInboxRefreshListenerImplementor();
        public void RefreshInboxCampaigns(Action<object[]> inboxCampaignsDelegate)
        {
			inboxRefreshListener.SetCallback(inboxCampaignsDelegate);
		}
    }
}
