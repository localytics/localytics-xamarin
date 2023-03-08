using System;
using System.Collections.Generic;
using LocalyticsXamarin.Shared;
using LocalyticsXamarin.Common;
using NativeInAppCampaign = LocalyticsMaui.Android.InAppCampaign;
using NativeInboxCampaign = LocalyticsMaui.Android.InboxCampaign;
using NativeImpressionType = LocalyticsMaui.Android.Localytics.ImpressionType;
using NativePlacesCampaign = LocalyticsMaui.Android.PlacesCampaign;
using NativePushCampaign = LocalyticsMaui.Android.PushCampaign;
using Android.Runtime;

namespace LocalyticsMaui.Android
{
	internal sealed partial class IInboxRefreshListenerImplementor
	{
		Action<LocalyticsMaui.Android.InboxCampaign[]> inboxRefresh;
		public IInboxRefreshListenerImplementor() : this(null)
		{
			this.Handler += handleRefresh;
		}

		void handleRefresh(object sender, InboxRefreshEventArgs args)
		{
			Action<LocalyticsMaui.Android.InboxCampaign[]> callback = inboxRefresh;
			if (callback != null)
			{
				//IList<InboxCampaign> list = args.P0;
				callback(null);
			}
		}

		public void SetCallback(Action<LocalyticsMaui.Android.InboxCampaign[]> inboxCampaignsDelegate)
		{
			inboxRefresh = inboxCampaignsDelegate;
		}
	}

	public sealed class InboxRefreshImplementationPlatform
	{
		readonly IInboxRefreshListenerImplementor implementor = new IInboxRefreshListenerImplementor();
		public void SetCallback(Action<LocalyticsMaui.Android.InboxCampaign[]> inboxCampaignsDelegate)
		{
			implementor.SetCallback(inboxCampaignsDelegate);
		}
	}
}
