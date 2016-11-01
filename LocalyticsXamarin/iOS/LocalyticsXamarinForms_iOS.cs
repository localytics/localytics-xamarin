
using System;
using System.Collections.Generic;

using Foundation;

using LocalyticsXamarin.iOS;

[assembly: Xamarin.Forms.Dependency (typeof (LocalyticsXamarin.Forms.LocalyticsXamarinForms_iOS))]
namespace LocalyticsXamarin.Forms
{
	public class LocalyticsXamarinForms_iOS : ILocalyticsXamarinForms
	{
		public LocalyticsXamarinForms_iOS () {}

		public void onAppStart ()
		{
		}

		public void SmokeTest ()
		{
			Localytics.CustomerId = "XamarinFormIOS CustomerId";
			Localytics.SetProfileAttribute ((NSString)("Age"), "83", LLProfileScope.Organization);

			Localytics.AddProfileAttributesToSet(new NSObject[] { (NSNumber)(222), (NSString)("333") }, "Lucky numbers", LLProfileScope.Application);

			Localytics.DeleteProfileAttribute("TestDeleteProfileAttribute", LLProfileScope.Application);

			Localytics.SetCustomerEmail("XamarinFormIOS Email");
			Localytics.SetCustomerFirstName("XamarinFormIOS FirstName");
			Localytics.SetCustomerLastName("XamarinFormIOS LastName");
			Localytics.SetCustomerFullName("XamarinFormIOS Full Name");

			Localytics.SetCustomDimension("XamarinFormIOSCD1", 1);

			Localytics.TagEvent ("XamarinFormIOS Start");
			Localytics.TagScreen ("XamarinFormIOS Landing");

			Localytics.Upload ();


			// Run through some Interface function
			this.AddProfileAttributesToSet (new object[] { 234, 345 }, "Android Interface Lucky Number", XFLLProfileScope.Application);
		}

		public void OpenSession ()
		{
			Localytics.OpenSession();
		}

		public void CloseSession ()
		{
			Localytics.CloseSession();
		}

		public void Upload ()
		{
			Localytics.Upload();
		}

		public void TagEvent (string eventName)
		{
			Localytics.TagEvent(eventName);
		}

		public void TagEvent (string eventName, System.Collections.Generic.IDictionary<string, string> attributes)
		{
			Localytics.TagEvent(eventName, ToNSDictionary(attributes));
		}

		public void TagEvent (string eventName, System.Collections.Generic.IDictionary<string, string> attributes, long customerValueIncrease)
		{
			Localytics.TagEvent(eventName, ToNSDictionary(attributes), customerValueIncrease);
		}

		public void TagScreen (string screenName)
		{
			Localytics.TagScreen(screenName);
		}

		public void SetCustomDimension (string value, uint dimension)
		{
			Localytics.SetCustomDimension (value, dimension);
		}

		public string GetCustomDimension (uint dimension)
		{
			return Localytics.GetCustomDimension (dimension);
		}

		public void SetIdentifier (string value, string identifier)
		{
			Localytics.SetIdentifier (value, identifier);
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
			Localytics.SetProfileAttribute (NSObject.FromObject(value), attribute, ToLLProfileScope (scope));
		}

		public void SetProfileAttribute (object value, string attribute)
		{
			Localytics.SetProfileAttribute (NSObject.FromObject(value), attribute);
		}

		public void AddProfileAttributesToSet (object[] values, string attribute, XFLLProfileScope scope)
		{
			Localytics.AddProfileAttributesToSet (ToNSObjects(values), attribute, ToLLProfileScope(scope));
		}

		public void AddProfileAttributesToSet (object[] values, string attribute)
		{
			Localytics.AddProfileAttributesToSet (ToNSObjects(values), attribute);
		}

		public void RemoveProfileAttributesFromSet (object[] values, string attribute, XFLLProfileScope scope)
		{
			Localytics.RemoveProfileAttributesFromSet (ToNSObjects(values), attribute, ToLLProfileScope(scope));
		}

		public void RemoveProfileAttributesFromSet (object[] values, string attribute)
		{
			Localytics.RemoveProfileAttributesFromSet (ToNSObjects(values), attribute);
		}

		public void IncrementProfileAttribute (int value, string attribute, XFLLProfileScope scope)
		{
			Localytics.IncrementProfileAttribute (value, attribute, ToLLProfileScope (scope));
		}

		public void IncrementProfileAttribute (int value, string attribute)
		{
			Localytics.IncrementProfileAttribute (value, attribute);
		}

		public void DecrementProfileAttribute (int value, string attribute, XFLLProfileScope scope)
		{
			Localytics.DecrementProfileAttribute (value, attribute, ToLLProfileScope (scope));
		}

		public void DecrementProfileAttribute (int value, string attribute)
		{
			Localytics.DecrementProfileAttribute (value, attribute);
		}

		public void DeleteProfileAttribute (string attribute, XFLLProfileScope scope)
		{
			Localytics.DeleteProfileAttribute (attribute, ToLLProfileScope (scope));
		}

		public void DeleteProfileAttribute (string attribute)
		{
			Localytics.DeleteProfileAttribute (attribute);
		}

		public void SetCustomerEmail (string email)
		{
			Localytics.SetCustomerEmail(email);
		}

		public void SetCustomerFirstName (string firstName)
		{
			Localytics.SetCustomerFirstName(firstName);
		}

		public void SetCustomerLastName (string lastName)
		{
			Localytics.SetCustomerLastName(lastName);
		}

		public void SetCustomerFullName (string fullName)
		{
			Localytics.SetCustomerFullName(fullName);
		}

		public string PushToken {
			get {
				return Localytics.PushToken;
			}
			set {
				Localytics.SetPushToken(NSData.FromString(value));
			}
		}

		public string PushRegistrationId {
			get {
				return Localytics.PushToken;
			}
			set {
				Localytics.SetPushToken(NSData.FromString(value));
			}
		}

		public XFLLInAppMessageDismissButtonLocation InAppMessageDismissButtonLocation {
			get {
				return ToXFLLInAppMessageDismissButtonLocation(Localytics.InAppMessageDismissButtonLocation);
			}
			set {
				Localytics.InAppMessageDismissButtonLocation = ToLLInAppMessageDismissButtonLocation(value);
			}
		}

		public void TriggerInAppMessage (string triggerName)
		{
			Localytics.TriggerInAppMessage (triggerName);
		}

		public void TriggerInAppMessage (string triggerName, IDictionary<string, string> attributes)
		{
			Localytics.TriggerInAppMessage (triggerName, ToNSDictionary(attributes));
		}

		public void DismissCurrentInAppMessage ()
		{
			Localytics.DismissCurrentInAppMessage ();
		}

		public bool LoggingEnabled {
			get {
				return Localytics.IsLoggingEnabled;
			}
			set {
				Localytics.SetLoggingEnabled(value);
			}
		}

		public bool OptedOut {
			get {
				return Localytics.IsOptedOut;
			}
			set {
				Localytics.SetOptedOut(value);
			}
		}

		public bool TestModeEnabled {
			get {
				return Localytics.IsTestModeEnabled;
			}
			set {
				Localytics.SetTestModeEnabled (value);
			}
		}

		public string InstallId {
			get {
				return Localytics.InstallId();
			}
		}

		public string LibraryVersion {
			get {
				return Localytics.LibraryVersion();
			}
		}

		public string AppKey {
			get {
				return Localytics.AppKey();
			}
		}

		private NSDictionary ToNSDictionary(IDictionary<string,string> source) {
			NSMutableDictionary result = new NSMutableDictionary();

			if (source != null) {
				foreach (string key in source.Keys)
				{
					result.Add ((NSString)(key), (NSString)(source[key]));
				}
			}

			return result;
		}

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

		private NSObject[] ToNSObjects(object[] objects) {
			List<NSObject> result = new List<NSObject>();
			foreach (object i in objects)
			{
				result.Add(NSObject.FromObject(i));
			}

			return result.ToArray ();
		}
	}
}

