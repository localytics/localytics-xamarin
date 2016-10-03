using System;
using System.Threading;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V4.App;
using Android;
using Android.Content.PM;

using LocalyticsXamarin.Android;

namespace LocalyticsMessagingSample.Android
{
	[Activity (Label = "LocalyticsMessagingSample.Android", MainLauncher = true, Icon = "@drawable/icon")]
	[IntentFilter(new[] { Intent.ActionView }, DataScheme="ampYOUR-LOCALYTICS-APP-KEY", Categories = new[]{Intent.CategoryDefault, Intent.CategoryBrowsable})]
	public class MainActivity : FragmentActivity
	{

		readonly string[] PermissionsLocation = {
			Manifest.Permission.AccessCoarseLocation,
			Manifest.Permission.AccessFineLocation
		};

		const int RequestLocationId = 1;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.Main);

			Localytics.CustomerId = "ms_test_user";

			// Register Push
			Localytics.RegisterPush("YOUR_GCM_PROJECT_NUMBER");
			Localytics.SetOption("session_timeout", 1); // Shorten for testing purpose only

			Button tagEventButton = FindViewById<Button> (Resource.Id.tagEventButton);
			
			tagEventButton.Click += delegate {
				Localytics.TagEvent("MessagingSample Click");
				Localytics.Upload();
			};

			Button showRegistrationIdButton = FindViewById<Button> (Resource.Id.showRegistrationId);
			showRegistrationIdButton.Click += delegate {
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

			Button openInboxButton = FindViewById<Button>(Resource.Id.openInbox);
			openInboxButton.Click += delegate {
				StartActivity(typeof(InboxActivity));
			};

			Button startPlacesButton = FindViewById<Button>(Resource.Id.startPlaces);
			startPlacesButton.Click += delegate {
				if ((int)Build.VERSION.SdkInt < 23)
				{
					Localytics.SetLocationMonitoringEnabled(true);
				}
				else
				{
					const string permission = Manifest.Permission.AccessFineLocation;
					if (ActivityCompat.CheckSelfPermission(this, permission) == (int)Permission.Granted)
					{
						Localytics.SetLocationMonitoringEnabled(true);
					}
					else
					{
						ActivityCompat.RequestPermissions(this, PermissionsLocation, RequestLocationId);
					}
				}
			};
		}

		protected override void OnResume()
		{
			base.OnResume();

			Localytics.TagScreen("MessagingSample Landing");
		}

		public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
		{
			switch (requestCode)
			{
				case RequestLocationId:
					{
						if (grantResults[0] == Permission.Granted)
						{
							Localytics.SetLocationMonitoringEnabled(true);
						}
						else
						{
							Toast.MakeText(this, "Must accept location permission to use Places", ToastLength.Long).Show();
						}
					}
					break;
			}
		}
	}
}


