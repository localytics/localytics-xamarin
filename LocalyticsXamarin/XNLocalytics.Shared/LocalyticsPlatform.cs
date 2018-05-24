using System;
using LocalyticsXamarin.Common;
#if __IOS__
#else
using LocalyticsXamarin.Android;
#endif
namespace XNLocalytics.Shared
{
#if __IOS__
#else
    public class LocalyticsPlatform : LocalyticsPlatformCommon
    {
        public XFLLInAppMessageDismissButtonLocation InAppMessageDismissButtonLocation
        {
            get
            {
                return Utils.ToXFLLInAppMessageDismissButtonLocation(Localytics.GetInAppMessageDismissButtonLocation());
            }
            set
            {
                Localytics.SetInAppMessageDismissButtonLocation(Utils.ToLLInAppMessageDismissButtonLocation(value));
            }
        }
      }
#endif
}
