using System;
using LocalyticsXamarin.Shared;

namespace LocalyticsXamarin.Android
{
	public partial class Localytics
	{
		static Localytics()
		{
			LocalyticsPlatformCommon.UpdatePluginVersion();
			Localytics.SetMessagingListener(new IMessagingListenerV2Implementor());
		}
	}
}
