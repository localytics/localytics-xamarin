using System;
using UIKit;

using LocalyticsXamarin.iOS;

namespace LocalyticsSample.iOS
{
	public class LocalyticsMessagingListener_iOS :LLMessagingDelegate
	{
		public LocalyticsMessagingListener_iOS ()
		{
		}

		public override void LocalyticsDidDismissInAppMessage ()
		{
			Console.WriteLine ("LocalyticsDidDismissInAppMessage");
		}

		public override void LocalyticsDidDisplayInAppMessage ()
		{
			Console.WriteLine ("LocalyticsDidDisplayInAppMessage");
		}

		public override void LocalyticsWillDismissInAppMessage ()
		{
			Console.WriteLine ("LocalyticsWillDismissInAppMessage");
		}

		public override void LocalyticsWillDisplayInAppMessage ()
		{
			Console.WriteLine ("LocalyticsWillDisplayInAppMessage");
		}

		public override bool LocalyticsShouldDisplayPlacesCampaign(LLPlacesCampaign campaign)
		{
			Console.Write("LocalyticsShouldDisplayPlacesCampaign");
			return true;
		}

		UILocalNotification LocalyticsWillDisplayNotification(UILocalNotification notification, LLPlacesCampaign campaign)
		{
			Console.Write("LocalyticsWillDisplayNotification");
			return notification;
		}
	}
}

