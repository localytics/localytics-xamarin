using System;
using System.Collections.Generic;

namespace LocalyticsXamarin.Forms
{
	public interface ILocalyticsXamarinForms
	{
		void onAppStart();

		void SmokeTest ();

		void OpenSession ();
		void CloseSession ();
		void Upload ();

		void TagEvent (string eventName);
		void TagEvent (string eventName, IDictionary<string, string> attributes);
		void TagEvent (string eventName, IDictionary<string, string> attributes, long customerValueIncrease);
		void TagScreen (string screenName);

		void SetCustomDimension (string value, uint dimension);
		string GetCustomDimension (uint dimension);

		void SetIdentifier (string value, string identifier);
		string GetIdentifier (string identifier);

		string CustomerId { get; set; }

		void SetProfileAttribute (Object value, string attribute, XFLLProfileScope scope);
		void SetProfileAttribute (Object value, string attribute);
		void AddProfileAttributesToSet (Object[] values, string attribute, XFLLProfileScope scope);
		void AddProfileAttributesToSet (Object[] values, string attribute);
		void RemoveProfileAttributesFromSet (Object[] values, string attribute, XFLLProfileScope scope);
		void RemoveProfileAttributesFromSet (Object[] values, string attribute);
		void IncrementProfileAttribute (int value, string attribute, XFLLProfileScope scope);
		void IncrementProfileAttribute (int value, string attribute);
		void DecrementProfileAttribute (int value, string attribute, XFLLProfileScope scope);
		void DecrementProfileAttribute (int value, string attribute);
		void DeleteProfileAttribute (string attribute, XFLLProfileScope scope);
		void DeleteProfileAttribute (string attribute);

		void SetCustomerEmail (string email);
		void SetCustomerFirstName (string firstName);
		void SetCustomerLastName (string lastName);
		void SetCustomerFullName (string fullName);

		string PushToken { get; set;}
		string PushRegistrationId { get; set;}

		XFLLInAppMessageDismissButtonLocation InAppMessageDismissButtonLocation { get; set; }

		void TriggerInAppMessage (string triggerName);
		void TriggerInAppMessage (string triggerName, IDictionary<string, string> attributes);
		void DismissCurrentInAppMessage ();

		bool LoggingEnabled { get; set; }

		bool OptedOut { get; set; }

		bool TestModeEnabled { get; set;}

		string InstallId { get; }
		string LibraryVersion { get; }
		string AppKey { get; }
	}
}

