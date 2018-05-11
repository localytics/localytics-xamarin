using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

using Xamarin.Forms;
using LocalyticsXamarin.Shared;
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
				string value0 = "AppKey: " + DependencyService.Get<ILocalytics>().AppKey;
				string value1 = "CustomerId: " + DependencyService.Get<ILocalytics>().CustomerId;
				string value2 = "InstallId: " + DependencyService.Get<ILocalytics>().InstallId;
				string value3 = "LibraryVersion: " + DependencyService.Get<ILocalytics>().LibraryVersion;
				string value4 = "OptedOut: " + DependencyService.Get<ILocalytics>().OptedOut;
				string value5 = "TestModeEnabled: " + DependencyService.Get<ILocalytics>().TestModeEnabled;
				string value6 = "Push Token/RegID: " + DependencyService.Get<ILocalytics>().PushTokenInfo;
				string value7 = "LoggingEnabled: " + DependencyService.Get<ILocalytics>().LoggingEnabled;


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
			DependencyService.Get<ILocalytics> ().OpenSession ();
		}

		void OnCloseSession(object sender, EventArgs e) {
			DependencyService.Get<ILocalytics> ().CloseSession ();
		}

		void OnUpload(object sender, EventArgs e) {
			DependencyService.Get<ILocalytics> ().Upload ();
		}

		void OnTagEvent(object sender, EventArgs e) {
			DependencyService.Get<ILocalytics> ().TagEvent (eventText.Text);
		}

		void OnTagScreen(object sender, EventArgs e) {
			DependencyService.Get<ILocalytics> ().TagScreen (screenText.Text);
		}

		void OnGetCD(object sender, EventArgs e) {
			System.Threading.Tasks.Task.Factory.StartNew (() => {
				string cd = DependencyService.Get<ILocalytics> ().GetCustomDimension (Convert.ToUInt32(cdNumber.Text));

				Device.BeginInvokeOnMainThread(delegate {
					cdValue.Text = cd;
				});
			});
		}

		void OnSetCD(object sender, EventArgs e) {
			DependencyService.Get<ILocalytics> ().SetCustomDimension (cdValue.Text, Convert.ToUInt32 (cdNumber.Text));
		}

		void OnSetProfile(object sender, EventArgs e) {
			DependencyService.Get<ILocalytics> ().SetProfileAttribute (profileValue.Text, profileAttribute.Text);
		}

		void OnGetIdentifier(object sender, EventArgs e) {
			System.Threading.Tasks.Task.Factory.StartNew (() => {
				string id = DependencyService.Get<ILocalytics> ().GetIdentifier (identifier.Text);

				Device.BeginInvokeOnMainThread(delegate {
					identifierValue.Text = id;
				});
			});
		}

		void OnSetIdentifier(object sender, EventArgs e) {
			DependencyService.Get<ILocalytics> ().SetIdentifier (identifierValue.Text, identifier.Text);
		}
	}
}

