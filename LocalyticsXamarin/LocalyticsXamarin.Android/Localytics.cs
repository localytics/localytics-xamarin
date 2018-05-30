using System;
using System.Collections.Generic;
using LocalyticsXamarin.Shared;

namespace LocalyticsXamarin.Android
{
	public partial class Localytics
	{
		static Localytics() {
			LocalyticsPlatformCommon.UpdatePluginVersion();
		}
	}
	internal sealed partial class IInboxRefreshListenerImplementor
	{
		Action<LocalyticsXamarin.Android.InboxCampaign[]> inboxRefresh;
		public IInboxRefreshListenerImplementor() : this(null)
		{
			this.Handler += handleRefresh;
		}

		void handleRefresh(object sender, InboxRefreshEventArgs args)
		{
			Action<LocalyticsXamarin.Android.InboxCampaign[]> callback = inboxRefresh;
			if (callback != null)
			{
				//IList<InboxCampaign> list = args.P0;
				callback(null);
			}
		}

		public void SetCallback(Action<LocalyticsXamarin.Android.InboxCampaign[]> inboxCampaignsDelegate)
		{
			inboxRefresh = inboxCampaignsDelegate;
		}
	}

    public sealed class InboxRefreshImplementationPlatform
    {
        readonly IInboxRefreshListenerImplementor implementor = new IInboxRefreshListenerImplementor();
		public void SetCallback(Action<LocalyticsXamarin.Android.InboxCampaign[]> inboxCampaignsDelegate)
        {
            implementor.SetCallback(inboxCampaignsDelegate);
        }
    }
}
