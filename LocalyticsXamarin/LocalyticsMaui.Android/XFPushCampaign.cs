using System;
using LocalyticsMaui.Common;

namespace LocalyticsMaui.Android
{
    internal class XFPushCampaign : ICampaignBase
    {
        LocalyticsMaui.Android.PushCampaign campaign;

        public XFPushCampaign(LocalyticsMaui.Android.PushCampaign campaign)
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
}
