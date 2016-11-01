
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using LocalyticsXamarin.Android;

namespace LocalyticsMessagingSample.Android
{
	[Activity(Label = "InboxDetailActivity")]
	public class InboxDetailActivity : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.InboxDetail);

			if (savedInstanceState == null)
			{
				InboxCampaign campaign = (InboxCampaign)Intent.GetParcelableExtra("campaign");
				InboxDetailFragment fragment = InboxDetailFragment.NewInstance(campaign);
				FragmentTransaction transaction = FragmentManager.BeginTransaction();
				transaction.Add(Resource.Id.container, fragment);
				transaction.Commit();
			}
		}

		protected override void OnResume()
		{
			base.OnResume();

			Localytics.TagScreen("Inbox Detail");
		}
	}
}
