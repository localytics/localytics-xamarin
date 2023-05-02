using System;
using System.Collections.Generic;
using System.Diagnostics;
using LocalyticsMaui.Common;
#if __IOS__
using NativeInboxCampaign = LocalyticsMaui.IOS.LLInboxCampaign;
using NativeInAppCampaign = LocalyticsMaui.IOS.LLInAppCampaign;
using NativePlacesCampaign = LocalyticsMaui.IOS.LLPlacesCampaign;
using NativeInAppMessageDismissButtonLocation = LocalyticsMaui.IOS.LLInAppMessageDismissButtonLocation;
#else
using NativeInboxCampaign = LocalyticsMaui.Android.InboxCampaign;
using NativeInAppCampaign = LocalyticsMaui.Android.InAppCampaign;
using NativePlacesCampaign = LocalyticsMaui.Android.PlacesCampaign;
using NativeInAppMessageDismissButtonLocation = LocalyticsMaui.Android.Localytics.InAppMessageDismissButtonLocation;
#endif
namespace LocalyticsMaui.Shared
{

    internal class XFInboxCampaign : LocalyticsMaui.Common.IInboxCampaign
    {
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

    internal class XFInAppCampaign : LocalyticsMaui.Common.IInAppCampaign
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

        public NativeInAppMessageDismissButtonLocation DismissButtonLocation => campaign.DismissButtonLocation;

        public bool DismissButtonHidden => campaign.IsDismissButtonHidden;

        public string EventName => campaign.EventName;

        public string CreativeFilePath =>
#if __IOS__
            campaign.CreativeFilePath;
#else
            campaign.CreativeFilePath.ToString();
#endif

        public long CampaignId => campaign.CampaignId;

        public string Name => campaign.Name;

        XFLLInAppMessageDismissButtonLocation IInAppCampaign.DismissButtonLocation =>
            Utils.ToXFLLInAppMessageDismissButtonLocation(campaign.DismissButtonLocation);
    }

    internal class XFPlacesCampaign : LocalyticsMaui.Common.IPlacesCampaign
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

        public string AttachmentURL => campaign.AttachmentUrl;
        }
}


