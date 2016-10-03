
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
	[Activity(Label = "InboxActivity")]
	public class InboxActivity : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.Inbox);

			ListView listView = FindViewById<ListView>(Resource.Id.lv_inbox);
			InboxListAdapter listAdapter = new InboxListAdapter(this);
			listView.Adapter = listAdapter;
			listView.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs e)
			{
				InboxCampaign campaign = (InboxCampaign)listAdapter.GetItem(e.Position);
				campaign.Read = true;

				listAdapter.NotifyDataSetChanged();

				if (campaign.HasCreative)
				{
					Intent intent = new Intent(this, typeof(InboxDetailActivity));
					intent.PutExtra("campaign", campaign);
					StartActivity(intent);
				}
			};

			listAdapter.GetData(null);
		}

		protected override void OnResume()
		{
			base.OnResume();

			Localytics.TagScreen("Inbox");
		}
	}
}
