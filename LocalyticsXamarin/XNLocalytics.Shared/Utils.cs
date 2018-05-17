using System;
using LocalyticsXamarin.Common;
#if __IOS__
using LocalyticsXamarin.iOS.Enums;
#else
using LLInAppMessageDismissButtonLocation= LocalyticsXamarin.Android.Localytics.InAppMessageDismissButtonLocation; 
#endif
namespace XNLocalytics.Shared
{
    public class Utils
    {
		public static XFLLInAppMessageDismissButtonLocation ToXFLLInAppMessageDismissButtonLocation(LLInAppMessageDismissButtonLocation source)
        {
            if (source == LLInAppMessageDismissButtonLocation.Right)
            {
                return XFLLInAppMessageDismissButtonLocation.Right;
            }

            return XFLLInAppMessageDismissButtonLocation.Left;
        }

		public static LLInAppMessageDismissButtonLocation ToLLInAppMessageDismissButtonLocation(XFLLInAppMessageDismissButtonLocation source)
        {
            if (source == XFLLInAppMessageDismissButtonLocation.Right)
            {
                return LLInAppMessageDismissButtonLocation.Right;
            }

            return LLInAppMessageDismissButtonLocation.Left;
        }      
    }
}
