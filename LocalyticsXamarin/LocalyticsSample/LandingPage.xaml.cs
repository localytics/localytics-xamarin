using System;
using System.Collections.Generic;


using System.Threading.Tasks;
using System.Threading;

using Xamarin.Forms;

using LocalyticsXamarin.Forms;

namespace LocalyticsSample
{
	public partial class LandingPage : ContentPage
	{
		public LandingPage ()
		{
			InitializeComponent ();
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

		void RefreshInfo() {
			System.Threading.Tasks.Task.Factory.StartNew (() => {
				string value0 = "AnalyticsHost: not supported";
				string value1 = "AppKey: " + DependencyService.Get<ILocalyticsXamarinForms>().AppKey;
				string value2 = "CustomerId: " + DependencyService.Get<ILocalyticsXamarinForms>().CustomerId;
				string value3 = "InstallId: " + DependencyService.Get<ILocalyticsXamarinForms>().InstallId;
				string value4 = "LibraryVersion: " + DependencyService.Get<ILocalyticsXamarinForms>().LibraryVersion;
				string value5 = "MessagingHost: not supported";
				string value6 = "ProfilesHost: not supported";
				string value7 = "SessionTimeout: not supported";
				string value8 = "OptedOut: " + DependencyService.Get<ILocalyticsXamarinForms>().OptedOut;
				string value9 = "TestModeEnabled: " + DependencyService.Get<ILocalyticsXamarinForms>().TestModeEnabled;
				string value10= "Push Token/RegID: " + DependencyService.Get<ILocalyticsXamarinForms>().PushToken;
				string value11 = "LoggingEnabled: " + DependencyService.Get<ILocalyticsXamarinForms>().LoggingEnabled;


				Device.BeginInvokeOnMainThread(delegate {
					info0.Text = value0;
					info1.Text = value1;
					info2.Text = value2;
					info3.Text = value3;
					info4.Text = value4;
					info5.Text = value5;
					info6.Text = value6;
					info7.Text = value7;
					info8.Text = value8;
					info9.Text = value9;
					info10.Text = value10;
					info11.Text = value11;
				});
			});
		}
			
		void OnOpenSession(object sender, EventArgs e) {
			DependencyService.Get<ILocalyticsXamarinForms> ().OpenSession ();
		}

		void OnCloseSession(object sender, EventArgs e) {
			DependencyService.Get<ILocalyticsXamarinForms> ().CloseSession ();
		}

		void OnUpload(object sender, EventArgs e) {
			DependencyService.Get<ILocalyticsXamarinForms> ().Upload ();
		}

		void OnTagEvent(object sender, EventArgs e) {
			DependencyService.Get<ILocalyticsXamarinForms> ().TagEvent (eventText.Text);
		}

		void OnTagScreen(object sender, EventArgs e) {
			DependencyService.Get<ILocalyticsXamarinForms> ().TagScreen (screenText.Text);
		}

		void OnGetCD(object sender, EventArgs e) {
			System.Threading.Tasks.Task.Factory.StartNew (() => {
				string cd = DependencyService.Get<ILocalyticsXamarinForms> ().GetCustomDimension (Convert.ToUInt32(cdNumber.Text));

				Device.BeginInvokeOnMainThread(delegate {
					cdValue.Text = cd;
				});
			});
		}

		void OnSetCD(object sender, EventArgs e) {
			DependencyService.Get<ILocalyticsXamarinForms> ().SetCustomDimension (cdValue.Text, Convert.ToUInt32 (cdNumber.Text));
		}

		void OnSetProfile(object sender, EventArgs e) {
			DependencyService.Get<ILocalyticsXamarinForms> ().SetProfileAttribute (profileValue.Text, profileAttribute.Text);
		}

		void OnGetIdentifier(object sender, EventArgs e) {
			System.Threading.Tasks.Task.Factory.StartNew (() => {
				string id = DependencyService.Get<ILocalyticsXamarinForms> ().GetIdentifier (identifier.Text);

				Device.BeginInvokeOnMainThread(delegate {
					identifierValue.Text = id;
				});
			});
		}

		void OnSetIdentifier(object sender, EventArgs e) {
			DependencyService.Get<ILocalyticsXamarinForms> ().SetIdentifier (identifierValue.Text, identifier.Text);
		}

	}
}

