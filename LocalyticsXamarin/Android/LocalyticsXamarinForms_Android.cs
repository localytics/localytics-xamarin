using System;
using System.Collections.Generic;

using System.Threading.Tasks;
using System.Threading;

using Android.App;

using Java.Util;

using LocalyticsXamarin.Android;

[assembly: Xamarin.Forms.Dependency (typeof (LocalyticsXamarin.Forms.LocalyticsXamarinForms_Android))]
namespace LocalyticsXamarin.Forms
{
	public class LocalyticsXamarinForms_Android : ILocalyticsXamarinForms
	{
		public LocalyticsXamarinForms_Android () {}

		public void onAppStart ()
		{
		}

		public void SmokeTest() {
			Localytics.CustomerId = "XamarinFormAndroid CustomerId";
			Localytics.SetProfileAttribute ("Age", 83, Localytics.ProfileScope.Organization);

			Localytics.AddProfileAttributesToSet("Android Lucky Number", new long[] { 321,654}, Localytics.ProfileScope.Application);

			Localytics.DeleteProfileAttribute("TestDeleteProfileAttribute", Localytics.ProfileScope.Application);

			Localytics.SetCustomerEmail("XamarinFormAndroid Email");
			Localytics.SetCustomerFirstName("XamarinFormAndroid FirstName");
			Localytics.SetCustomerLastName("XamarinFormAndroid LastName");
			Localytics.SetCustomerFullName("XamarinFormAndroid Full Name");

			Localytics.SetCustomDimension(1, "XamarinFormAndroidCD1");

			Localytics.TagEvent ("XamarinFormAndroid Start");
			Localytics.TagScreen ("XamarinFormAndroid Landing");
			Localytics.Upload();

			// Run through some Interface function
			this.AddProfileAttributesToSet (new object[] { 234, 345 }, "Android Interface Lucky Number", XFLLProfileScope.Application);
		}


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
			if (value is long || value is int) {
				Localytics.SetProfileAttribute (attribute, Convert.ToInt64(value), ToProfileScope (scope));
			} else if (value is DateTime) {
				Localytics.SetProfileAttribute (attribute, ToJavaDate (value), ToProfileScope (scope));
			} else {
				Localytics.SetProfileAttribute (attribute, value.ToString(), ToProfileScope (scope));
			}
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
			if (values.Length > 0) {
				object firstValue = values [0];

				if (firstValue is long || firstValue is int) {
					Localytics.AddProfileAttributesToSet (attribute, ToLongArray(values), ToProfileScope (scope));
				} else if (firstValue is DateTime) {
					Localytics.AddProfileAttributesToSet (attribute, ToJavaDateArray (values), ToProfileScope (scope));
				} else {
					Localytics.AddProfileAttributesToSet (attribute, ToStringArray(values), ToProfileScope (scope));
				}
			}
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
			if (values.Length > 0) {
				object firstValue = values [0];

				if (firstValue is long || firstValue is int) {
					Localytics.RemoveProfileAttributesFromSet (attribute, ToLongArray(values), ToProfileScope (scope));
				} else if (firstValue is DateTime) {
					Localytics.RemoveProfileAttributesFromSet (attribute, ToJavaDateArray (values), ToProfileScope (scope));
				} else {
					Localytics.RemoveProfileAttributesFromSet (attribute, ToStringArray(values), ToProfileScope (scope));
				}
			}
		}

		public void RemoveProfileAttributesFromSet (object[] values, string attribute)
		{
			if (values.Length > 0) {
				object firstValue = values [0];

				if (firstValue is long || firstValue is int) {
					Localytics.RemoveProfileAttributesFromSet (attribute, ToLongArray(values));
				} else if (firstValue is DateTime) {
					Localytics.RemoveProfileAttributesFromSet (attribute, ToJavaDateArray (values));
				} else {
					Localytics.RemoveProfileAttributesFromSet (attribute, ToStringArray(values));
				}
			}
		}

		public void IncrementProfileAttribute (int value, string attribute, XFLLProfileScope scope)
		{
			Localytics.IncrementProfileAttribute (attribute, (long)(value), ToProfileScope(scope));
		}

		public void IncrementProfileAttribute (int value, string attribute)
		{
			Localytics.IncrementProfileAttribute (attribute, (long)(value));
		}

		public void DecrementProfileAttribute (int value, string attribute, XFLLProfileScope scope)
		{
			Localytics.DecrementProfileAttribute (attribute, (long)(value), ToProfileScope(scope));
		}

		public void DecrementProfileAttribute (int value, string attribute)
		{
			Localytics.DecrementProfileAttribute (attribute, (long)(value));
		}

		public void DeleteProfileAttribute (string attribute, XFLLProfileScope scope)
		{
			Localytics.DeleteProfileAttribute (attribute, ToProfileScope(scope));
		}

		public void DeleteProfileAttribute (string attribute)
		{
			Localytics.DeleteProfileAttribute (attribute);
		}

		public void SetCustomerEmail (string email)
		{
			Localytics.SetCustomerEmail (email);
		}

		public void SetCustomerFirstName (string firstName)
		{
			Localytics.SetCustomerFirstName (firstName);
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
				return ToXFLLInAppMessageDismissButtonLocation(Localytics.GetInAppMessageDismissButtonLocation());
			}
			set {
				Localytics.SetInAppMessageDismissButtonLocation(ToLLInAppMessageDismissButtonLocation(value));
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

		private Localytics.InAppMessageDismissButtonLocation ToLLInAppMessageDismissButtonLocation(XFLLInAppMessageDismissButtonLocation source) {
			if (source == XFLLInAppMessageDismissButtonLocation.Right) {
				return Localytics.InAppMessageDismissButtonLocation.Right;
			}

			return Localytics.InAppMessageDismissButtonLocation.Left;
		}

		private XFLLInAppMessageDismissButtonLocation ToXFLLInAppMessageDismissButtonLocation(Localytics.InAppMessageDismissButtonLocation source) {
			if (source == Localytics.InAppMessageDismissButtonLocation.Right) {
				return XFLLInAppMessageDismissButtonLocation.Right;
			}

			return XFLLInAppMessageDismissButtonLocation.Left;
		}

		private Localytics.ProfileScope ToProfileScope(XFLLProfileScope source) {
			if (source == XFLLProfileScope.Organization) {
				return Localytics.ProfileScope .Organization;
			}

			return Localytics.ProfileScope .Application;
		}

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
	}
}

