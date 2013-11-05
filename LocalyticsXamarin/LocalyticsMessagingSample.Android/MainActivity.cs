using System;
using System.Threading;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V4.App;

using LocalyticsXamarin.Android;

namespace LocalyticsMessagingSample.Android
{
	[Activity (Label = "LocalyticsMessagingSample.Android", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : FragmentActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.Main);

			Localytics.CustomerId = "ms_test_user";

			// Register Push
			Localytics.RegisterPush("YOUR_GCM_PROJECT_NUMBER");
			Localytics.SessionTimeoutInterval = 1; // Shorten for testing purpose only

			Button tagEventButton = FindViewById<Button> (Resource.Id.tagEventButton);
			
			tagEventButton.Click += delegate {
				Localytics.TagEvent("MessagingSample Click");
				Localytics.Upload();
			};

			Button refreshButton = FindViewById<Button> (Resource.Id.refreshButton);
			refreshButton.Click += delegate {
				// Blocking Getters may need to be threaded out
				ThreadPool.QueueUserWorkItem(delegate {
					TextView pushText = FindViewById<TextView> (Resource.Id.pushText);
					string pushRegId = Localytics.PushRegistrationId;

					// Update UI back on UI Thread
					RunOnUiThread(() => {
						pushText.Text = pushRegId;
					});
				});
			};
				
			Localytics.TagScreen ("MessagingSample Landing");
		}


	}
}


