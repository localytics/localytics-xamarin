using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using LocalyticsXamarin.Android;

namespace LocalyticsSample.Android
{
	[Activity (Label = "LocalyticsSample.Android", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			Localytics.RegisterPush("YOUR_GCM_PROJECT_NUMBER");

			global::Xamarin.Forms.Forms.Init (this, bundle);

			LoadApplication (new App ());
		}

		protected override void OnNewIntent (Intent intent)
		{
			base.OnNewIntent (intent);
			this.Intent = intent;
		}
	}
}
