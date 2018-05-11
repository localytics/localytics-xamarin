using System;

using Xamarin.Forms;

using LocalyticsXamarin.Forms;
using LocalyticsXamarin.Shared;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace LocalyticsSample
{
	public class App : Application
	{
		void HandleInboxCampaignsDelegate(object[] campaigns)
		{
			foreach (object a in campaigns)
            {
                Debug.WriteLine("inbox campaign " + a.ToString());
            }
		}


		public App ()
		{
			// The root page of your application
			MainPage = new NavigationPage(new LandingPage());
		}

		protected override void OnStart ()
		{
			CommonSmokeTest();
		}

		private void CommonSmokeTest()
        {
			ILocalytics localytics = DependencyService.Get<ILocalytics>();

			localytics.OpenSession();
			localytics.Upload();
			localytics.TagEvent("TagEvent");
			localytics.TagEvent("TagEventWithEmptyAttribs", new Dictionary<string, string>());
			Dictionary<string, string> dict = new Dictionary<string, string>
			{
				{ "attr1", "1" }
			};
			localytics.TagEvent("TagEventWithAttribs", dict);
			localytics.TagEvent("TagEventWithAttribsWithValue", dict, 0);
			localytics.TagEvent("TagEventWithAttribsWithValue", dict, 10);

			localytics.TagPurchased("item1", "1", "item", 100.0, new Dictionary<string, string>());
			localytics.TagAddedToCart("item1", "1", "item", 100.0, new Dictionary<string, string>());
			localytics.TagStartedCheckout(100.0, 5, new Dictionary<string, string>());
			localytics.TagCompletedCheckout(100.0, 5, new Dictionary<string, string>());
			localytics.TagContentViewed("name", "is", "type", new Dictionary<string, string>());
			localytics.TagSearched("query", "type", 5, new Dictionary<string, string>());
			localytics.TagShared("name", "id", "type", "method", new Dictionary<string, string>());
			localytics.TagContentRated("name", "id", "type", 1.0, new Dictionary<string, string>());
			localytics.TagCustomerRegistered(new Dictionary<string, object>() {
				{"customerId", "1234"},
				{"firstName", "Anand"},
				{"lastName", "B"},
				{"fullName", "A B"},
				{"emailAddress", "ab@localytics.com"}
			}, "method", new Dictionary<string, string>());
			localytics.TagInvited("method", new Dictionary<string, string>());

			localytics.CloseSession();



			localytics.CustomerId = "XamarinFormIOS CustomerId";
			//localytics.TagCustomerLoggedIn(null, "method", new Dictionary<string, string>());
			localytics.SetProfileAttribute("Age", "83", XFLLProfileScope.Organization);
			localytics.SetProfileAttribute("MyAge", "3", XFLLProfileScope.Application);

			localytics.AddProfileAttributes("Lucky numbers", XFLLProfileScope.Application, new object[] { 222, "333",  });
			localytics.AddProfileAttributes("Lucky numbers", XFLLProfileScope.Application, 222, "333" );
            localytics.AddProfileAttributes("Android Interface Lucky Number", XFLLProfileScope.Application, new object[] { 234, 345 });
			localytics.RemoveProfileAttributes("Lucky numbers", XFLLProfileScope.Application, 222);
			localytics.IncrementProfileAttribute(1, "Age");
			localytics.IncrementProfileAttribute(1, "MyAge");
			localytics.DecrementProfileAttribute(2, "Age", XFLLProfileScope.Organization);

			localytics.DeleteProfileAttribute("TestDeleteProfileAttribute", XFLLProfileScope.Application);

			localytics.SetCustomerEmail("XamarinFormIOS Email");
			localytics.SetCustomerFirstName("XamarinFormIOS FirstName");
			localytics.SetCustomerLastName("XamarinFormIOS LastName");
			localytics.SetCustomerFullName("XamarinFormIOS Full Name");

			localytics.SetCustomDimension("XamarinFormIOSCD1", 1);
			Debug.WriteLine("Dimension 1:" + localytics.GetCustomDimension(1));

			localytics.RedirectLoggingToDisk();

			localytics.SetIdentifier("test", "id1");
			Debug.WriteLine("Identifier 1:" + localytics.GetIdentifier("id1"));


			localytics.TagEvent("XamarinFormIOS Start");
			localytics.TagScreen("XamarinFormIOS Landing");
			localytics.TagCustomerLoggedOut(new Dictionary<string, string>());
			localytics.Upload();

			localytics.PrivacyOptedOut = true;
			localytics.PrivacyOptedOut = false;
            // This should be platform specific
			localytics.DidRegisterUserNotificationSettings();
			localytics.SetInAppMessageDismissButtonImageWithName(null);
			localytics.SetInAppMessageDismissButtonHidden(true);
			localytics.SetInAppMessageDismissButtonHidden(false);

			localytics.TriggerInAppMessage("javascript");
			localytics.TriggerInAppMessagesForSessionStart();
			localytics.DismissCurrentInAppMessage();
            
			foreach (object a in localytics.InboxCampaigns) {
				Debug.WriteLine("inbox campaign " + a.ToString());
			}
			localytics.RefreshInboxCampaigns(HandleInboxCampaignsDelegate);
			localytics.RefreshAllInboxCampaigns(HandleInboxCampaignsDelegate);

			localytics.InboxAdIdParameterEnabled = true;
			localytics.InAppAdIdParameterEnabled = true;
            
			localytics.InboxListItemTapped(null);

			localytics.TagImpressionForInAppCampaign(null, "custom");
            localytics.TagImpressionForInboxCampaign(null, "custom");
            localytics.TagImpressionForPushToInboxCampaign(null, true);

			localytics.TagPlacesPushReceived(null);
			localytics.TagPlacesPushOpened(null);
			localytics.TagPlacesPushOpened(null, "123");
			localytics.TriggerPlacesNotificationForCampaign(null);
			localytics.TriggerPlacesNotificationForCampaignId(1, "1");
       }

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

