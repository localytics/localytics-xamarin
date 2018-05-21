using System;
using System.Collections;
using System.Collections.Generic;

using Java.Util;
using LocalyticsXamarin.Android;
using LocalyticsXamarin.Common;
using XNLocalytics.Shared;

[assembly: Xamarin.Forms.Dependency(typeof(LocalyticsXamarin.Forms.LocalyticsXamarinForms_Android))]
namespace LocalyticsXamarin.Forms
{
	public class LocalyticsXamarinForms_Android : ILocalytics
	{
		public LocalyticsXamarinForms_Android () {}

		public void onAppStart ()
		{
		}

		//public void SmokeTest() {
		//	Localytics.CustomerId = "XamarinFormAndroid CustomerId";
		//	Localytics.SetProfileAttribute ("Age", 83, Localytics.ProfileScope.Organization);

		//	Localytics.AddProfileAttributesToSet("Android Lucky Number", new long[] { 321,654}, Localytics.ProfileScope.Application);

		//	Localytics.DeleteProfileAttribute("TestDeleteProfileAttribute", Localytics.ProfileScope.Application);

		//	Localytics.SetCustomerEmail("XamarinFormAndroid Email");
		//	Localytics.SetCustomerFirstName("XamarinFormAndroid FirstName");
		//	Localytics.SetCustomerLastName("XamarinFormAndroid LastName");
		//	Localytics.SetCustomerFullName("XamarinFormAndroid Full Name");

		//	Localytics.SetCustomDimension(1, "XamarinFormAndroidCD1");

		//	Localytics.TagEvent ("XamarinFormAndroid Start");
		//	Localytics.TagScreen ("XamarinFormAndroid Landing");
		//	Localytics.Upload();

		//	// Run through some Interface function
		//	this.AddProfileAttributesToSet (new object[] { 234, 345 }, "Android Interface Lucky Number", XFLLProfileScope.Application);
		//}


		public void OpenSession ()
		{
			Localytics.OpenSession ();
		}

		public void CloseSession ()
		{
			Localytics.CloseSession ();
		}

		public void Upload ()
		{
			Localytics.Upload ();
		}

		public void TagEvent (string eventName)
		{
			Localytics.TagEvent (eventName);
		}

		public void TagEvent (string eventName, IDictionary<string, string> attributes)
		{
			Localytics.TagEvent (eventName, attributes);
		}

		public void TagEvent (string eventName, IDictionary<string, string> attributes, long customerValueIncrease)
		{
			Localytics.TagEvent (eventName, attributes, customerValueIncrease);
		}

		public void TagScreen (string screenName)
		{
			Localytics.TagScreen (screenName);
		}

		public void SetCustomDimension (string value, uint dimension)
		{
			Localytics.SetCustomDimension ((int) dimension, value);
		}

		public string GetCustomDimension (uint dimension)
		{
			return Localytics.GetCustomDimension ((int) dimension);
		}

		public void SetIdentifier (string value, string identifier)
		{
			Localytics.SetIdentifier (identifier, value);
		}

		public string GetIdentifier (string identifier)
		{

			return Localytics.GetIdentifier (identifier);
		}

		public string CustomerId {
			get {
				return Localytics.CustomerId;
			}
			set {
				Localytics.CustomerId = value;
			}
		}

		public void SetProfileAttribute (object value, string attribute, XFLLProfileScope scope)
		{
			// TODO FIX ME
			//if (value is long || value is int) {
			//	Localytics.SetProfileAttribute (attribute, Convert.ToInt64(value), ToProfileScope (scope));
			//} else if (value is DateTime) {
			//	Localytics.SetProfileAttribute (attribute, ToJavaDate (value), ToProfileScope (scope));
			//} else {
			//	Localytics.SetProfileAttribute (attribute, value.ToString(), ToProfileScope (scope));
			//}
		}

		public void SetProfileAttribute (object value, string attribute)
		{
			if (value is long || value is int) {
				Localytics.SetProfileAttribute (attribute, Convert.ToInt64(value));
			} else if (value is DateTime) {
				Localytics.SetProfileAttribute (attribute, ToJavaDate (value));
			} else {
				Localytics.SetProfileAttribute (attribute, value.ToString());
			}
		}

		public void AddProfileAttributesToSet (object[] values, string attribute, XFLLProfileScope scope)
		{
			// TODO FIXME
			//if (values.Length > 0) {
			//	object firstValue = values [0];

			//	if (firstValue is long || firstValue is int) {
			//		Localytics.AddProfileAttributesToSet (attribute, ToLongArray(values), ToProfileScope (scope));
			//	} else if (firstValue is DateTime) {
			//		Localytics.AddProfileAttributesToSet (attribute, ToJavaDateArray (values), ToProfileScope (scope));
			//	} else {
			//		Localytics.AddProfileAttributesToSet (attribute, ToStringArray(values), ToProfileScope (scope));
			//	}
			//}
		}

		public void AddProfileAttributesToSet (object[] values, string attribute)
		{
			if (values.Length > 0) {
				object firstValue = values [0];

				if (firstValue is long || firstValue is int) {
					Localytics.AddProfileAttributesToSet (attribute, ToLongArray(values));
				} else if (firstValue is DateTime) {
					Localytics.AddProfileAttributesToSet (attribute, ToJavaDateArray (values));
				} else {
					Localytics.AddProfileAttributesToSet (attribute, ToStringArray(values));
				}
			}
		}

		public void RemoveProfileAttributesFromSet (object[] values, string attribute, XFLLProfileScope scope)
		{
			//if (values.Length > 0) {
			//	object firstValue = values [0];

			//	if (firstValue is long || firstValue is int) {
			//		Localytics.RemoveProfileAttributesFromSet (attribute, ToLongArray(values), ToProfileScope (scope));
			//	} else if (firstValue is DateTime) {
			//		Localytics.RemoveProfileAttributesFromSet (attribute, ToJavaDateArray (values), ToProfileScope (scope));
			//	} else {
			//		Localytics.RemoveProfileAttributesFromSet (attribute, ToStringArray(values), ToProfileScope (scope));
			//	}
			//}
		}

		public void RemoveProfileAttributesFromSet (object[] values, string attribute)
		{
			//if (values.Length > 0) {
			//	object firstValue = values [0];

			//	if (firstValue is long || firstValue is int) {
			//		Localytics.RemoveProfileAttributesFromSet (attribute, ToLongArray(values));
			//	} else if (firstValue is DateTime) {
			//		Localytics.RemoveProfileAttributesFromSet (attribute, ToJavaDateArray (values));
			//	} else {
			//		Localytics.RemoveProfileAttributesFromSet (attribute, ToStringArray(values));
			//	}
			//}
		}

		public void IncrementProfileAttribute (int value, string attribute, XFLLProfileScope scope)
		{
			//Localytics.IncrementProfileAttribute (attribute, (long)(value), ToProfileScope(scope));
		}

		public void IncrementProfileAttribute (int value, string attribute)
		{
			//Localytics.IncrementProfileAttribute (attribute, (long)(value));
		}

		public void DecrementProfileAttribute (int value, string attribute, XFLLProfileScope scope)
		{
			//Localytics.DecrementProfileAttribute (attribute, (long)(value), ToProfileScope(scope));
		}

		public void DecrementProfileAttribute (int value, string attribute)
		{
			//Localytics.DecrementProfileAttribute (attribute, (long)(value));
		}

		public void DeleteProfileAttribute (string attribute, XFLLProfileScope scope)
		{
			//Localytics.DeleteProfileAttribute (attribute, ToProfileScope(scope));
		}

		public void DeleteProfileAttribute (string attribute)
		{
			//Localytics.DeleteProfileAttribute (attribute);
		}

		public void SetCustomerEmail (string email)
		{
			//Localytics.SetCustomerEmail (email);
		}

		public void SetCustomerFirstName (string firstName)
		{
			//Localytics.SetCustomerFirstName (firstName);
		}

		public void SetCustomerLastName (string lastName)
		{
			Localytics.SetCustomerLastName (lastName);
		}

		public void SetCustomerFullName (string fullName)
		{
			Localytics.SetCustomerFullName (fullName);
		}

		public string PushToken {
			get {
				return Localytics.PushRegistrationId;
			}
			set {
				Localytics.PushRegistrationId = value;
			}
		}

		public string PushRegistrationId {
			get {
				return Localytics.PushRegistrationId;
			}
			set {
				Localytics.PushRegistrationId = value;
			}
		}

		public XFLLInAppMessageDismissButtonLocation InAppMessageDismissButtonLocation {
			get {
				return Utils.ToXFLLInAppMessageDismissButtonLocation(Localytics.GetInAppMessageDismissButtonLocation());
			}
			set {
				Localytics.SetInAppMessageDismissButtonLocation(Utils.ToLLInAppMessageDismissButtonLocation(value));
			}
		}

		public void TriggerInAppMessage (string triggerName)
		{
			Localytics.TriggerInAppMessage (triggerName);
		}

		public void TriggerInAppMessage (string triggerName, IDictionary<string, string> attributes)
		{
			Localytics.TriggerInAppMessage (triggerName, attributes);
		}

		public void DismissCurrentInAppMessage ()
		{
			Localytics.DismissCurrentInAppMessage ();
		}

		public bool LoggingEnabled {
			get {
				return Localytics.LoggingEnabled;
			}
			set {
				Localytics.LoggingEnabled = value;
			}
		}

		public bool OptedOut {
			get {
				return Localytics.OptedOut;
			}
			set {
				Localytics.OptedOut = value;
			}
		}

		public bool TestModeEnabled {
			get {
				return Localytics.TestModeEnabled;
			}
			set {
				Localytics.TestModeEnabled = value;
			}
		}

		public string InstallId {
			get {
				return Localytics.InstallId;
			}
		}

		public string LibraryVersion {
			get {
				return Localytics.LibraryVersion;
			}
		}

		public string AppKey {
			get {
				return Localytics.AppKey;
			}
		}

		public string PushTokenInfo => throw new NotImplementedException();

		public bool PrivacyOptedOut { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public object[] InboxCampaigns => throw new NotImplementedException();

		public bool InAppAdIdParameterEnabled { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public bool InboxAdIdParameterEnabled { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		// TODO fix me
		//private Localytics.InAppMessageDismissButtonLocation ToLLInAppMessageDismissButtonLocation(XFLLInAppMessageDismissButtonLocation source) {
		//	if (source == XFLLInAppMessageDismissButtonLocation.Right) {
		//		return Localytics.InAppMessageDismissButtonLocation.Right;
		//	}

		//	return Localytics.InAppMessageDismissButtonLocation.Left;
		//}

		//private XFLLInAppMessageDismissButtonLocation ToXFLLInAppMessageDismissButtonLocation(Localytics.InAppMessageDismissButtonLocation source) {
		//	if (source == Localytics.InAppMessageDismissButtonLocation.Right) {
		//		return XFLLInAppMessageDismissButtonLocation.Right;
		//	}

		//	return XFLLInAppMessageDismissButtonLocation.Left;
		//}

		//private Localytics.ProfileScope ToProfileScope(XFLLProfileScope source) {
		//	if (source == XFLLProfileScope.Organization) {
		//		return Localytics.ProfileScope .Organization;
		//	}

		//	return Localytics.ProfileScope .Application;
		//}

		private Date ToJavaDate(object source) {
			if (source is DateTime) {
				DateTime sourceDateTime = (DateTime)(source);

				TimeSpan t = sourceDateTime - new DateTime (1970, 1, 1);
				double epochMilliseconds = t.TotalMilliseconds;
				return new Date (Convert.ToInt64 (epochMilliseconds));
			} else {
				return null;
			}
		}

		private long[] ToLongArray(object[] source) {
			return Array.ConvertAll<object, long>(source, Convert.ToInt64);
		}

		private Date[] ToJavaDateArray(object[] source) {
			return Array.ConvertAll<object, Date>(source, ToJavaDate);
		}

		private string[] ToStringArray(object[] source) {
			return Array.ConvertAll<object, string>(source, x=>x.ToString());
		}

		public void TagPurchased(string itemName, string itemId, string itemType, double itemPrice, IDictionary<string, string> attributes)
		{
			// TODO FIXME Type of itemPrice
			Localytics.TagPurchased(itemName, itemId, itemType, new Java.Lang.Long((Int64)itemPrice), attributes);
		}

		public void TagAddedToCart(string itemName, string itemId, string itemType, double itemPrice, IDictionary<string, string> attributes)
		{
			throw new NotImplementedException();
		}

		public void TagStartedCheckout(double totalPrice, double itemCount, IDictionary<string, string> attributes)
		{
			throw new NotImplementedException();
		}

		public void TagCompletedCheckout(double totalPrice, double itemCount, IDictionary<string, string> attributes)
		{
			throw new NotImplementedException();
		}

		public void TagContentViewed(string contentName, string contentId, string contentType, IDictionary<string, string> attributes)
		{
			throw new NotImplementedException();
		}

		public void TagSearched(string queryText, string contentType, double resultCount, IDictionary<string, string> attributes)
		{
			throw new NotImplementedException();
		}

		public void TagShared(string contentName, string contentId, string contentType, string methodName, IDictionary<string, string> attributes)
		{
			throw new NotImplementedException();
		}

		public void TagContentRated(string contentName, string contentId, string contentType, double rating, IDictionary<string, string> attributes)
		{
			throw new NotImplementedException();
		}

		public void TagCustomerRegistered(IDictionary<string, object> customer, string methodName, IDictionary<string, string> attributes)
		{
			throw new NotImplementedException();
		}

		public void TagCustomerLoggedIn(IDictionary<string, object> customer, string methodName, IDictionary<string, string> attributes)
		{
			throw new NotImplementedException();
		}

		public void TagCustomerLoggedOut(IDictionary<string, string> attributes)
		{
			throw new NotImplementedException();
		}

		public void TagInvited(string methodName, IDictionary attributes)
		{
			throw new NotImplementedException();
		}

		public void AddProfileAttributes(string attribute, XFLLProfileScope scope, params object[] values)
		{
			throw new NotImplementedException();
		}

		public void RemoveProfileAttributes(string attribute, XFLLProfileScope scope, params object[] values)
		{
			throw new NotImplementedException();
		}

		public void RedirectLoggingToDisk()
		{
			throw new NotImplementedException();
		}

		public void DidRegisterUserNotificationSettings()
		{
			throw new NotImplementedException();
		}

		public void SetInAppMessageDismissButtonImageWithName(string imageName)
		{
			throw new NotImplementedException();
		}

		public void SetInAppMessageDismissButtonHidden(bool hidden)
		{
			throw new NotImplementedException();
		}

		public void RefreshInboxCampaigns(InboxCampaignsDelegate inboxCampaignsDelegate)
		{
			throw new NotImplementedException();
		}

		public void SetInboxCampaign(object campaign, bool read)
		{
			throw new NotImplementedException();
		}

		public long InboxCampaignsUnreadCount()
		{
			return Localytics.InboxCampaignsUnreadCount;
		}

		public void SetLocationMonitoringEnabled(bool enabled)
		{
			Localytics.SetLocationMonitoringEnabled(enabled);
		}

		public void SetOptions(IDictionary options)
		{
			throw new NotImplementedException();
			//Localytics.SetOptions(options);
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

		public object[] AllInboxCampaigns()
		{
			throw new NotImplementedException();
			//return Localytics.AllInboxCampaigns;
		}

		public void RefreshAllInboxCampaigns(InboxCampaignsDelegate inboxCampaignsDelegate)
		{
			throw new NotImplementedException();
			//Localytics.RefreshAllInboxCampaigns(new IInboxRefreshListener())
		}

		public void TriggerPlacesNotificationForCampaignId(long campaignId, string regionId)
		{
			Localytics.TriggerPlacesNotification(campaignId, regionId);
		}

		public void TagImpressionForInAppCampaign(object campaign, string customAction)
		{
			//Localytics.TagInAppImpression(campaign, customAction);
			throw new NotImplementedException();
		}

		public void TagImpressionForInboxCampaign(object campaign, string customAction)
		{
			
			throw new NotImplementedException();
		}

		public void TagImpressionForPushToInboxCampaign(object campaign, bool success)
		{
			throw new NotImplementedException();
		}

		public void InboxListItemTapped(object campaign)
		{
			throw new NotImplementedException();
		}

		public void TagPlacesPushReceived(object campaign)
		{
			throw new NotImplementedException();
		}

		public void TagPlacesPushOpened(object campaign)
		{
			throw new NotImplementedException();
		}

		public void TagPlacesPushOpened(object campaign, string identifier)
		{
			throw new NotImplementedException();
		}

		public void TriggerPlacesNotificationForCampaign(object campaign)
		{
			throw new NotImplementedException();
		}
	}
}

