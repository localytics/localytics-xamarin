using System;

using LocalyticsXamarin.iOS;

namespace LocalyticsSample.iOS
{
	public class LocalyticsAnalyticsListener_iOS : LLAnalyticsDelegate
	{
		public LocalyticsAnalyticsListener_iOS ()
		{
		}

		public override void LocalyticsSessionDidOpen (bool isFirst, bool isUpgrade, bool isResume)
		{
			Console.WriteLine ("LocalyticsSessionDidOpen: " + isFirst + ", " + isUpgrade + ", " + isResume);
		}

		public override void LocalyticsDidTagEvent (string eventName, Foundation.NSDictionary attributes, Foundation.NSNumber customerValueIncrease)
		{
			Console.WriteLine ("LocalyticsDidTagEvent: " + eventName);
		}

		public override void LocalyticsSessionWillOpen (bool isFirst, bool isUpgrade, bool isResume)
		{
			Console.WriteLine ("LocalyticsSessionWillOpen: " + isFirst + ", " + isUpgrade + ", " + isResume);
		}

		public override void LocalyticsSessionWillClose ()
		{
			Console.WriteLine ("LocalyticsSessionWillClose");
		}
	}
}

