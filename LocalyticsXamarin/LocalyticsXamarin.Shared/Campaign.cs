using System;
using System.Collections.Generic;
using System.Diagnostics;
using LocalyticsXamarin.Common;
#if __IOS__
using NativeInboxCampaign = LocalyticsXamarin.IOS.LLInboxCampaign;
using NativeInAppCampaign = LocalyticsXamarin.IOS.LLInAppCampaign;
using NativePlacesCampaign = LocalyticsXamarin.IOS.LLPlacesCampaign;
using NativeInAppMessageDismissButtonLocation = LocalyticsXamarin.IOS.LLInAppMessageDismissButtonLocation;
#else
using NativeInboxCampaign = LocalyticsXamarin.Android.InboxCampaign;
using NativeInAppCampaign = LocalyticsXamarin.Android.InAppCampaign;
using NativePlacesCampaign = LocalyticsXamarin.Android.PlacesCampaign;
using NativeInAppMessageDismissButtonLocation = LocalyticsXamarin.Android.Localytics.InAppMessageDismissButtonLocation;
#endif
namespace LocalyticsXamarin.Shared
{

    public class XFInboxCampaign : LocalyticsXamarin.Common.IInboxCampaign
    {
#if __IOS__
        public static IInboxCampaign[] From(NativeInboxCampaign[] inboxCampaigns)
        {

            IInboxCampaign[] campaigns = new XFInboxCampaign[inboxCampaigns.Length];
            int i = 0;
            foreach (var item in inboxCampaigns)
            {
                campaigns[i] = new XFInboxCampaign(item);
                i += 1;
            }
            //Debug.WriteLine("campaigns {0} => {1}", inboxCampaigns.Length, campaigns.Length);
            return campaigns;
        }
#else
        public static IInboxCampaign[] From(IList<NativeInboxCampaign> inboxCampaigns)
        {
            IInboxCampaign[] campaigns = new XFInboxCampaign[inboxCampaigns.Count];
            int i = 0;
            foreach (var item in inboxCampaigns)
            {
                campaigns[i] = new XFInboxCampaign(item);
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
 "\n\t IsDeleted:{9}" +
 "\n\t CampaignId:{10}" +
 "\n\t HasCreative:{11}" +
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
                                 , this.IsDeleted
                                 , this.CampaignId
                                 , this.HasCreative
                                 , this.SortOrder);

        }

        NativeInboxCampaign campaign;
        public XFInboxCampaign(NativeInboxCampaign campaign)
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

        public bool IsDeleted => campaign.IsDeleted;

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

        public bool IsDeleted => campaign.IsDeleted;

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

    public class XFInAppCampaign : LocalyticsXamarin.Common.IInAppCampaign
    {

        public override string ToString()
        {
            return string.Format("\t CampaignId:{0}" +
                          "\n\t Name:{1}" +
                          "\n\t CreativeFilePath:{2}" +
                          "\n\t EventName:{3}" +
                          "\n\t DismissButtonHidden:{4}" +
                          "\n\t InAppMessageDismissButtonLocation:{5}" +
                          "\n\t IsResponsive:{6}" +
                          "\n\t BackgroundAlpha:{7}" +
                          "\n\t Offset:{8}" +
                          "\n\t AspectRatio:{9}"
                                 , this.CampaignId
                                 , this.Name
                                 , this.CreativeFilePath ?? ""
                                 , this.EventName ?? ""
                                 , this.DismissButtonHidden
                                 , this.DismissButtonLocation
                                 , this.IsResponsive
                                 , this.BackgroundAlpha
                                 , this.Offset
                                 , this.AspectRatio);

        }

        NativeInAppCampaign campaign;
        public XFInAppCampaign(NativeInAppCampaign campaign)
        {
            this.campaign = campaign;
        }

        public object Handle()
        {
            return campaign;
        }

        public float AspectRatio =>
#if __IOS__
        (float)campaign.AspectRatio;
#else
        campaign.AspectRatio;
#endif

        public float Offset =>
#if __IOS__
        (float)campaign.Offset;
#else
        campaign.Offset;
#endif

        public float BackgroundAlpha =>
#if __IOS__
        (float)campaign.BackgroundAlpha;
#else
        campaign.BackgroundAlpha;
#endif

        public bool IsResponsive =>
#if __IOS__
        campaign.IsResponsive;
#else
        true;
#endif

        public NativeInAppMessageDismissButtonLocation DismissButtonLocation =>
#if __IOS__
        campaign.DismissButtonLocation();
#else
        campaign.DismissButtonLocation;
#endif

#if __IOS__
        public bool DismissButtonHidden => campaign.DismissButtonHidden;
#else
        public bool DismissButtonHidden => campaign.IsDismissButtonHidden;
#endif

        public string EventName => campaign.EventName;

        //public IDictionary<string, string> EventAttributes => campaign.EventAttributes;

        public string CreativeFilePath =>
#if __IOS__
            campaign.CreativeFilePath;
#else
            campaign.CreativeFilePath.ToString();
#endif

        public long CampaignId => campaign.CampaignId;

        public string Name => campaign.Name;

        XFLLInAppMessageDismissButtonLocation IInAppCampaign.DismissButtonLocation =>
#if __IOS__
            Utils.ToXFLLInAppMessageDismissButtonLocation(campaign.DismissButtonLocation());
#else
            Utils.ToXFLLInAppMessageDismissButtonLocation(campaign.DismissButtonLocation);
#endif
        //public IDictionary<string, string> Attributes => throw new NotImplementedException()
    }

    public class XFPlacesCampaign : LocalyticsXamarin.Common.IPlacesCampaign
    {

        public override string ToString()
        {
            return string.Format("\t CampaignId:{0}" +
                          "\n\t Name:{1}" +
                          "\n\t Message:{2}" +
                          "\n\t SoundFile:{3}" +
                          "\n\t AttachmentUrl:{4}" +
#if __IOS__
                         "\n\t AttachmentType:{5}" +
                          "\n\t Category:{6}"
#else
                         "\n\t Title:{5}"
#endif
                                 , this.CampaignId
                                 , this.Name
                                 , this.Message ?? ""
                                 , this.SoundFilename ?? ""
                                 , this.AttachmentURL ?? ""
#if __IOS__
                                 , this.AttachmentType ?? ""
                                 , this.Category
#else
                                 , this.Title ?? ""
#endif
                                 );

        }

        NativePlacesCampaign campaign;
        public XFPlacesCampaign(NativePlacesCampaign campaign)
        {
            this.campaign = campaign;
        }

        public object Handle()
        {
            return campaign;
        }

        public long CampaignId => campaign.CampaignId;

        public string Name => campaign.Name;

        public string Message => campaign.Message;

#if __IOS__
        public string AttachmentType => campaign.AttachmentType;

        public string Category => campaign.Category;
#else
        public string Title => campaign.Title;
#endif

        public string SoundFilename => campaign.SoundFilename;

        public string AttachmentURL =>
#if __IOS__
            campaign.AttachmentURL;
#else
            campaign.AttachmentUrl;
#endif

        //public IDictionary<string, string> Attributes => throw new NotImplementedException()
    }

#if !__IOS__
    public class XFPushCampaign : ICampaignBase
    {
        LocalyticsXamarin.Android.PushCampaign campaign;

        public XFPushCampaign(LocalyticsXamarin.Android.PushCampaign campaign)
        {
            this.campaign = campaign;
        }

        public override string ToString()
        {
            return string.Format("\t CampaignId:{0}" +
                          "\n\t Name:{1}" +
                          "\n\t Message:{2}" +
                          "\n\t SoundFile:{3}" +
                          "\n\t AttachmentUrl:{4}" +
                          "\n\t Title:{5}"
                                 , this.CampaignId
                                 , this.Name
                                 , this.Message ?? ""
                                 , this.SoundFilename ?? ""
                                 , this.AttachmentURL ?? ""
                                 , this.Title ?? ""
                                 );

        }

        public long CampaignId => campaign.CampaignId;

        public string Name => campaign.Name;

        public string Message => campaign.Message;

        public string Title => campaign.Title;

        public string SoundFilename => campaign.SoundFilename;

        public string AttachmentURL => campaign.AttachmentUrl;

        //public IDictionary<string, string> Attributes => throw new NotImplementedException()
    }
#endif
}


