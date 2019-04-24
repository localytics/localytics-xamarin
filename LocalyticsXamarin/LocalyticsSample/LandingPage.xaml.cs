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
		void LoggingToggled(object sender, Xamarin.Forms.ToggledEventArgs e)
		{
			Task.Run(() =>
			{
				localytics.LoggingEnabled = ((Switch)sender).IsToggled;
				RefreshBackgroundProperties(1);
			});
		}

		void InboxAdidToggled(object sender, Xamarin.Forms.ToggledEventArgs e)
		{
			localytics.InboxAdIdParameterEnabled = ((Switch)sender).IsToggled;
			RefreshBackgroundProperties();
		}

		void InappAdidToggled(object sender, Xamarin.Forms.ToggledEventArgs e)
		{
			localytics.InAppAdIdParameterEnabled = ((Switch)sender).IsToggled;
			RefreshBackgroundProperties();
		}

		void OptOutToggled(object sender, Xamarin.Forms.ToggledEventArgs e)
		{
			App.localytics.OptedOut = ((Switch)sender).IsToggled;
			RefreshBackgroundProperties();
		}

		void TestModeToggled(object sender, Xamarin.Forms.ToggledEventArgs e)
		{
			Task.Run(() =>
			{
				var t = ((Switch)sender).IsToggled;
				App.localytics.TestModeEnabled = t;
				RefreshBackgroundProperties(1);
			});
		}

		void PlacesDisplayToggled(object sender, Xamarin.Forms.ToggledEventArgs e)
		{
			App.platform.SetPlacesShouldDisplay(((Switch)sender).IsToggled);
		}

		void InappDisplayToggled(object sender, Xamarin.Forms.ToggledEventArgs e)
		{
			App.platform.SetInAppShouldDisplay(((Switch)sender).IsToggled);
		}

		void DeepLinkToggled(object sender, Xamarin.Forms.ToggledEventArgs e)
		{
			App.platform.SetShouldDeeplink(((Switch)sender).IsToggled);
		}

		void OnTestMode(object sender, System.EventArgs e)
		{
			Task.Run(() =>
			{
				App.localytics.TestModeEnabled = true;
			});
		}

		void OffTestMode(object sender, System.EventArgs e)
		{
			App.localytics.TestModeEnabled = false;
		}

		void TriggerInAppSessionStart(object sender, System.EventArgs e)
		{
			App.localytics.TriggerInAppMessagesForSessionStart();
		}

		void TriggerInAppLang(object sender, System.EventArgs e)
		{
			App.localytics.TriggerInAppMessage("lang");
		}

		void OnDismissButtonRight(object sender, System.EventArgs e)
		{
			localytics.InAppMessageDismissButtonLocation = XFLLInAppMessageDismissButtonLocation.Right;
			this.dismissBtnLocation.Text = localytics.InAppMessageDismissButtonLocation.ToString();
		}

		void OnDismissButtonLeft(object sender, System.EventArgs e)
		{
			localytics.InAppMessageDismissButtonLocation = XFLLInAppMessageDismissButtonLocation.Left;
			this.dismissBtnLocation.Text = localytics.InAppMessageDismissButtonLocation.ToString();
		}

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
			RefreshBackgroundProperties();
		}

		void OnPrivacyOptIn(object sender, System.EventArgs e)
		{
			localytics.PrivacyOptedOut = false;
			RefreshBackgroundProperties();
		}

		void OnTriggerInApp(object sender, System.EventArgs e)
		{
			localytics.TriggerInAppMessage(this.triggerName.Text);
		}

		public LandingPage()
		{
			InitializeComponent();
			localytics = DependencyService.Get<ILocalytics>();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			RefreshInfo();
		}

		void OnRefresh(object sender, EventArgs e)
		{
			RefreshInfo();
		}

        void OnDelete(object sender, System.EventArgs e)
        {
            Task.Run(() =>
            {
                var campaigns = localytics.DisplayableInboxCampaigns();
                foreach (IInboxCampaign campaign in campaigns)
                {
                    localytics.DeleteInboxCampaign(campaign);
                    break;
                }
            });
        }

		ILocalytics localytics;

		void RefreshBackgroundProperties(int delay = 0)
		{
			Task.Run(() =>
			{
				if (delay != 0)
				{
					Task.Delay(10000);
				}
				var privacyOptout = localytics.PrivacyOptedOut;
				var optout = localytics.OptedOut;
				var testMode = localytics.TestModeEnabled;
				var logging = localytics.LoggingEnabled;
				var inboxAdid = localytics.InboxAdIdParameterEnabled;
				var inappAdid = localytics.InAppAdIdParameterEnabled;
				Device.BeginInvokeOnMainThread(delegate
				{
					this.privacyoptout.Text = privacyOptout.ToString();
					if (this.OptOut.IsToggled != optout)
					{
						this.OptOut.IsToggled = optout;
					}
					if (this.InboxAdid.IsToggled != inboxAdid)
					{
						this.InboxAdid.IsToggled = inboxAdid;
					}
					if (this.InappAdid.IsToggled != inappAdid)
					{
						this.InappAdid.IsToggled = inappAdid;
					}
					if (this.TestMode.IsToggled != testMode)
					{
						this.TestMode.IsToggled = testMode;
					}
					if (this.Logging.IsToggled != logging)
					{
						this.Logging.IsToggled = logging;
					}
				});
			});
		}
		void RefreshInfo()
		{
			localytics.LoggingEnabled = true;
			System.Threading.Tasks.Task.Factory.StartNew(() =>
			{
				string value0 = "AppKey: " + localytics.AppKey;
				string value1 = "CustomerId: " + localytics.CustomerId;
				string value2 = "InstallId: " + localytics.InstallId;
				string value3 = "LibraryVersion: " + localytics.LibraryVersion;
				string value4 = "";
				string value5 = "";
				string value6 = "Push Token/RegID: " + localytics.PushTokenInfo;
				string value7 = "";

				RefreshBackgroundProperties();
				var btnLoc = localytics.InAppMessageDismissButtonLocation;

				Device.BeginInvokeOnMainThread(delegate
				{
					this.dismissBtnLocation.Text = btnLoc.ToString();
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

		void OnOpenSession(object sender, EventArgs e)
		{
			localytics.OpenSession();
		}

		void OnCloseSession(object sender, EventArgs e)
		{
			localytics.CloseSession();
		}

		void OnUpload(object sender, EventArgs e)
		{
			localytics.Upload();
		}

        void OnEnableLoguana(object sender, EventArgs e)
        {
            localytics.EnableLiveDeviceLogging();
        }


        void OnTagEvent(object sender, EventArgs e)
		{
			localytics.TagEvent(eventText.Text);
		}

		void OnTagScreen(object sender, EventArgs e)
		{
			localytics.TagScreen(screenText.Text);
		}

		void OnGetCD(object sender, EventArgs e)
		{
			System.Threading.Tasks.Task.Factory.StartNew(() =>
			{
				string cd = localytics.GetCustomDimension(Convert.ToUInt32(cdNumber.Text));

				Device.BeginInvokeOnMainThread(delegate
				{
					cdValue.Text = cd;
				});
			});
		}

		void OnSetCD(object sender, EventArgs e)
		{
			localytics.SetCustomDimension(cdValue.Text, Convert.ToUInt32(cdNumber.Text));
		}

		void OnSetProfile(object sender, EventArgs e)
		{
			localytics.SetProfileAttribute(profileAttribute.Text, XFLLProfileScope.Application, profileValue.Text);
			localytics.SetProfileAttribute(profileAttribute.Text + "_ORG", XFLLProfileScope.Organization, profileValue.Text);
		}

		void OnGetIdentifier(object sender, EventArgs e)
		{
			System.Threading.Tasks.Task.Factory.StartNew(() =>
			{
				string id = localytics.GetIdentifier(identifier.Text);

				Device.BeginInvokeOnMainThread(delegate
				{
					identifierValue.Text = id;
				});
			});
		}

		void OnSetIdentifier(object sender, EventArgs e)
		{
			localytics.SetIdentifier(identifierValue.Text, identifier.Text);
		}
	}
}

