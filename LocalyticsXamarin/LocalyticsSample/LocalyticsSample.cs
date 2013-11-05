using System;

using Xamarin.Forms;

using LocalyticsXamarin.Forms;

namespace LocalyticsSample
{
	public class App : Application
	{
		public App ()
		{
			// The root page of your application
			MainPage = new NavigationPage(new LandingPage());
		}

		protected override void OnStart ()
		{
			DependencyService.Get<ILocalyticsXamarinForms> ().onAppStart ();

			DependencyService.Get<ILocalyticsXamarinForms> ().SmokeTest ();
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

