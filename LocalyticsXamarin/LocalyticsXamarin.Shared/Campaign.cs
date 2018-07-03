using System;
using System.Collections.Generic;
using System.Diagnostics;
using LocalyticsXamarin.Common;
#if __IOS__
using NativeInboxCampaign = LocalyticsXamarin.IOS.LLInboxCampaign;
#else
using NativeInboxCampaign = LocalyticsXamarin.Android.InboxCampaign;
#endif
namespace LocalyticsXamarin.Shared
{
	public class InboxCampaign : LocalyticsXamarin.Common.IInboxCampaign
	{
#if __IOS__
		public static IInboxCampaign[] From(NativeInboxCampaign[] inboxCampaigns)
        {
			
            IInboxCampaign[] campaigns = new InboxCampaign[inboxCampaigns.Length];
            int i = 0;
            foreach (var item in inboxCampaigns)
            {
                campaigns[i] = new InboxCampaign(item);
				i += 1;
            }
			//Debug.WriteLine("campaigns {0} => {1}", inboxCampaigns.Length, campaigns.Length);
            return campaigns;
        }
#else
		public static IInboxCampaign[] From(IList<NativeInboxCampaign> inboxCampaigns)
		{
			IInboxCampaign[] campaigns = new InboxCampaign[inboxCampaigns.Count];
			int i = 0;
			foreach (var item in inboxCampaigns)
			{
				campaigns[i] = new InboxCampaign(item);
				i += 1;
			}
			return campaigns;
		}
#endif

		public override string ToString()
		{
			return string.Format("\t Read:{0}" +
						  "\n\t ReceivedDate:{1}" +
						  "\n\t CreativeFilePath:{2}" +
						  "\n\t DeepLinkURL:{3}" +
"\n\t Name:{4}" +
"\n\t SummaryText:{5}" +
 "\n\t ThumnmailUrl:{6}" +
"\n\t TitleText:{7}" +
 "\n\t IsPushToInboxCampaign:{8}" +
 "\n\t CampaignId:{9}" +
 "\n\t HasCreative:{10}" +
								 "\n\t SortOrder:{11}"

									, this.Read
								 , this.ReceivedDate
								 , this.CreativeFilePath ?? ""
								 , this.DeepLinkURL ?? ""
								 , this.Name
								 , this.SummaryText ?? ""
								 , this.ThumbnailUrl ?? ""
								 , this.TitleText ?? ""
								 , this.IsPushToInboxCampaign
								 , this.CampaignId
								 , this.HasCreative
								 , this.SortOrder);

		}

		NativeInboxCampaign campaign;
		public InboxCampaign(NativeInboxCampaign campaign)
		{
			this.campaign = campaign;
		}

		public object Handle()
		{
			return campaign;
		}
#if __IOS__
		public bool Read { get => campaign.Read; set => campaign.Read = value; }

		public string TitleText => campaign.TitleText;

		public string SummaryText => campaign.SummaryText;

		public bool HasCreative => campaign.HasCreative;

		public bool IsPushToInboxCampaign => campaign.IsPushToInboxCampaign;

		public double ReceivedDate => campaign.ReceivedDate;

		public string ThumbnailUrl => campaign.ThumbnailUrl?.AbsoluteString;

		public long SortOrder => (long)campaign.SortOrder;

		public string DeepLinkURL => campaign.DeepLinkURL?.AbsoluteString;

		public string CreativeFilePath => campaign.CreativeFilePath;

		public long CampaignId => campaign.CampaignId;
        
		public string Name => campaign.Name;

		//public IDictionary<string, string> Attributes => throw new NotImplementedException();
#else
		public bool Read { get => campaign.Read; set => campaign.Read = value; }

		public string TitleText => campaign.Title;

		public string SummaryText => campaign.Summary;

		public bool HasCreative => campaign.HasCreative;

		public bool IsPushToInboxCampaign => campaign.IsPushToInboxCampaign;

		// Platform Specific double vs Date
		public double ReceivedDate => campaign.ReceivedDate.Time / 1000;

		//hasThumbnail()

		public string ThumbnailUrl => campaign.DeepLinkUrl;

		public long SortOrder => campaign.SortOrder;

		public string DeepLinkURL => campaign.DeepLinkUrl;

		public string CreativeFilePath => campaign.CreativeFilePath.ToString();

		public long CampaignId => campaign.CampaignId;

		public string Name => campaign.Name;

		//public IDictionary<string, string> Attributes => throw new NotImplementedException();
#endif
	}
}


