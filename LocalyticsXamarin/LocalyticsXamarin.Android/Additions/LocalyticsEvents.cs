using System;
using System.Collections.Generic;

using LocalyticsXamarin.AndroidPatch;

namespace LocalyticsXamarin.Android
{
	public class LocalyticsEvents
	{
		public delegate void LocalyticsDidTagEvent(string eventName, IDictionary<string, string> attributes, long customerValueIncrease);
		public delegate void LocalyticsSessionDidOpen(bool isFirst, bool isUpgrade, bool isResume);
		public delegate void LocalyticsSessionWillClose();
		public delegate void LocalyticsSessionWillOpen(bool isFirst, bool isUpgrade, bool isResume);

		public delegate void LocalyticsDidDismissInAppMessage();
		public delegate void LocalyticsDidDisplayInAppMessage();
		public delegate void LocalyticsWillDismissInAppMessage();
		public delegate void LocalyticsWillDisplayInAppMessage();

		public static event LocalyticsDidTagEvent OnLocalyticsDidTagEvent;
		public static event LocalyticsSessionDidOpen OnLocalyticsSessionDidOpen;
		public static event LocalyticsSessionWillClose OnLocalyticsSessionWillClose;
		public static event LocalyticsSessionWillOpen OnLocalyticsSessionWillOpen;

		public static event LocalyticsDidDismissInAppMessage OnLocalyticsDidDismissInAppMessage;
		public static event LocalyticsDidDisplayInAppMessage OnLocalyticsDidDisplayInAppMessage;
		public static event LocalyticsWillDismissInAppMessage OnLocalyticsWillDismissInAppMessage;
		public static event LocalyticsWillDisplayInAppMessage OnLocalyticsWillDisplayInAppMessage;

		private static LocalyticsProxyListener llProxyListener;

		private static AnalyticsProxyListener analyticsListener;
		private static MessagingProxyListener messagingListener;

		public static void SubscribeToAll() {
			llProxyListener = new LocalyticsProxyListener ();
			analyticsListener = new AnalyticsProxyListener ();
			messagingListener = new MessagingProxyListener ();

			llProxyListener.AddAnalyticsProxyListener (analyticsListener);
			llProxyListener.AddMessagingProxyListener (messagingListener);
		}

		class AnalyticsProxyListener : Java.Lang.Object, IAnalyticsProxyListener
		{
			public void LocalyticsDidTagEvent (string eventName, IDictionary<string, string> attributes, long customerValueIncrease)
			{
				if (LocalyticsEvents.OnLocalyticsDidTagEvent != null) {
					LocalyticsEvents.OnLocalyticsDidTagEvent (eventName, attributes, customerValueIncrease);
				}
			}

			public void LocalyticsSessionDidOpen (bool isFirst, bool isUpgrade, bool isResume)
			{
				if (LocalyticsEvents.OnLocalyticsSessionDidOpen != null) {
					LocalyticsEvents.OnLocalyticsSessionDidOpen (isFirst, isUpgrade, isResume);
				}
			}

			public void LocalyticsSessionWillClose ()
			{
				if (LocalyticsEvents.OnLocalyticsSessionWillClose != null) {
					LocalyticsEvents.OnLocalyticsSessionWillClose ();
				}
			}

			public void LocalyticsSessionWillOpen (bool isFirst, bool isUpgrade, bool isResume)
			{
				if (LocalyticsEvents.OnLocalyticsSessionWillOpen != null) {
					LocalyticsEvents.OnLocalyticsSessionWillOpen (isFirst, isUpgrade, isResume);
				}
			}
		}

		class MessagingProxyListener : Java.Lang.Object, IMessagingProxyListener
		{
			public void LocalyticsDidDismissInAppMessage ()
			{
				if (LocalyticsEvents.OnLocalyticsDidDismissInAppMessage != null)
					LocalyticsEvents.OnLocalyticsDidDismissInAppMessage ();
			}

			public void LocalyticsDidDisplayInAppMessage ()
			{
				if (LocalyticsEvents.OnLocalyticsDidDisplayInAppMessage != null)
					LocalyticsEvents.OnLocalyticsDidDisplayInAppMessage ();
			}

			public void LocalyticsWillDismissInAppMessage ()
			{
				if (LocalyticsEvents.OnLocalyticsWillDismissInAppMessage != null)
					LocalyticsEvents.OnLocalyticsWillDismissInAppMessage ();
			}

			public void LocalyticsWillDisplayInAppMessage ()
			{
				if (LocalyticsEvents.OnLocalyticsWillDisplayInAppMessage != null)
					LocalyticsEvents.OnLocalyticsWillDisplayInAppMessage ();
			}
		}

	}
}

