using System;
using System.Collections.Generic;

namespace LocalyticsXamarin.Android
{
	internal sealed partial class IInboxRefreshListenerImplementor
	{
		Action<object[]> inboxRefresh;
		public IInboxRefreshListenerImplementor() : this(null)
		{
			this.Handler += handleRefresh;
		}

		void handleRefresh(object sender, InboxRefreshEventArgs args)
		{
			Action<object[]> callback = inboxRefresh;
			if (callback != null)
			{
				//IList<InboxCampaign> list = args.P0;
				callback(null);
			}
		}

		public void SetCallback(Action<object[]> inboxCampaignsDelegate)
		{
			inboxRefresh = inboxCampaignsDelegate;
		}
	}
	public static class PlatformUtils
	{
		public static object[] ToArray(this IList<InboxCampaign> campaigns)
    	{
			if (campaigns==null)
			{
				return new object[0];
			}
    		object[] ret = new object[campaigns.Count];
    		int i = 0;
    		foreach (InboxCampaign campaign in campaigns)
    		{
    			ret[i] = campaign;
    		}
			return ret;
    	}
    }

	//public partial class Localytics
	//{
	//	public void RedirectLoggingToDisk()
 //       {
 //           Localytics.RedirectLogsToDisk(true, Xamarin.Android.App.Application.Context);
 //       }
	//}
}
