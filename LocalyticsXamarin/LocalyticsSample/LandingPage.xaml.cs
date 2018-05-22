using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

using Xamarin.Forms;
using LocalyticsXamarin.Common;

namespace LocalyticsSample.Shared
{
	public partial class LandingPage : ContentPage
	{
		void OnPauseDataUpload(object sender, System.EventArgs e)
		{
			localytics.PauseDataUploading(true);
		}

		void OnResumeDataUpload(object sender, System.EventArgs e)
		{
			localytics.PauseDataUploading(false);
		}

		void OnPrivacyOptOut(object sender, System.EventArgs e)
        {
			localytics.PrivacyOptedOut = true;
        }

		void OnPrivacyOptIn(object sender, System.EventArgs e)
        {
			localytics.PrivacyOptedOut = false;
        }

		void OnTriggerInApp(object sender, System.EventArgs e)
		{
			localytics.TriggerInAppMessage(this.triggerName.Text);
		}

		void OnInboxAdidDisable(object sender, System.EventArgs e)
		{
			localytics.InboxAdIdParameterEnabled = false;
		}

		void OnInboxAdidEnable(object sender, System.EventArgs e)
		{
			localytics.InboxAdIdParameterEnabled = true;
		}

		void OnInappAdidDisable(object sender, System.EventArgs e)
		{
			localytics.InAppAdIdParameterEnabled = false;
		}
        
		void OnInappAdidEnable(object sender, System.EventArgs e)
		{
			localytics.InAppAdIdParameterEnabled = true;
		}

		void OnOptOut(object sender, System.EventArgs e)
		{
			localytics.OptedOut = true;
		}

		void OnOptIn(object sender, System.EventArgs e)
		{
			localytics.OptedOut = false;
		}

		public LandingPage ()
		{
			InitializeComponent ();
			localytics = DependencyService.Get<ILocalytics>();
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();

			RefreshInfo ();
		}

		void OnRefresh(object sender, EventArgs e)
		{
			RefreshInfo ();
		}
		ILocalytics localytics;

		void RefreshInfo() {
			localytics.LoggingEnabled = true;
			System.Threading.Tasks.Task.Factory.StartNew (() => {
				string value0 = "AppKey: " + localytics.AppKey;
				string value1 = "CustomerId: " + localytics.CustomerId;
				string value2 = "InstallId: " + localytics.InstallId;
				string value3 = "LibraryVersion: " + localytics.LibraryVersion;
				string value4 = "OptedOut: " + localytics.OptedOut;
				string value5 = "TestModeEnabled: " + localytics.TestModeEnabled;
				string value6 = "Push Token/RegID: " + localytics.PushTokenInfo;
				string value7 = "LoggingEnabled: " + localytics.LoggingEnabled;


				Device.BeginInvokeOnMainThread(delegate {
					info0.Text = value0;
					info1.Text = value1;
					info2.Text = value2;
					info3.Text = value3;
					info4.Text = value4;
					info5.Text = value5;
					info6.Text = value6;
					info7.Text = value7;
				});
			});
		}
			
		void OnOpenSession(object sender, EventArgs e) {
			localytics.OpenSession ();
		}

		void OnCloseSession(object sender, EventArgs e) {
			localytics.CloseSession ();
		}

		void OnUpload(object sender, EventArgs e) {
			localytics.Upload ();
		}

		void OnTagEvent(object sender, EventArgs e) {
			localytics.TagEvent (eventText.Text);
		}

		void OnTagScreen(object sender, EventArgs e) {
			localytics.TagScreen (screenText.Text);
		}

		void OnGetCD(object sender, EventArgs e) {
			System.Threading.Tasks.Task.Factory.StartNew (() => {
				string cd = localytics.GetCustomDimension (Convert.ToUInt32(cdNumber.Text));

				Device.BeginInvokeOnMainThread(delegate {
					cdValue.Text = cd;
				});
			});
		}

		void OnSetCD(object sender, EventArgs e) {
			localytics.SetCustomDimension (cdValue.Text, Convert.ToUInt32 (cdNumber.Text));
		}

		void OnSetProfile(object sender, EventArgs e) {
			localytics.SetProfileAttribute (profileValue.Text, profileAttribute.Text);
		}

		void OnGetIdentifier(object sender, EventArgs e) {
			System.Threading.Tasks.Task.Factory.StartNew (() => {
				string id = localytics.GetIdentifier (identifier.Text);

				Device.BeginInvokeOnMainThread(delegate {
					identifierValue.Text = id;
				});
			});
		}

		void OnSetIdentifier(object sender, EventArgs e) {
			localytics.SetIdentifier (identifierValue.Text, identifier.Text);
		}
	}
}

