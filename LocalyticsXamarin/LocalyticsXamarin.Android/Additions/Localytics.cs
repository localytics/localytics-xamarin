using System;
using System.Runtime.CompilerServices;
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

		static Localytics _instance;

		[MethodImpl(MethodImplOptions.Synchronized)]
		public static Localytics SharedInstance()
		{
			if (_instance == null) {
				_instance = new Localytics();
			}
			return _instance;
		}
	}
}
