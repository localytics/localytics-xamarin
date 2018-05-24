using System;
using LocalyticsXamarin.Common;
#if __IOS__
using NativeInAppMessageDismissButtonLocation = LocalyticsXamarin.IOS.LLInAppMessageDismissButtonLocation;
using NativeProfileScope = LocalyticsXamarin.IOS.LLProfileScope;
#else
using LocalyticsXamarin.Android;
using NativeInAppMessageDismissButtonLocation = LocalyticsXamarin.Android.InAppMessageDismissButtonLocation;
using NativeProfileScope = LocalyticsXamarin.Android.Localytics.ProfileScope;
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
	public static class Utils
    {
		public static XFLLInAppMessageDismissButtonLocation ToXFLLInAppMessageDismissButtonLocation(NativeInAppMessageDismissButtonLocation source)
        {
			if (source == NativeInAppMessageDismissButtonLocation.Right)
            {
                return XFLLInAppMessageDismissButtonLocation.Right;
            }

            return XFLLInAppMessageDismissButtonLocation.Left;
        }

		public static NativeInAppMessageDismissButtonLocation ToLLInAppMessageDismissButtonLocation(XFLLInAppMessageDismissButtonLocation source)
        {
            if (source == XFLLInAppMessageDismissButtonLocation.Right)
            {
				return NativeInAppMessageDismissButtonLocation.Right;
            }

			return NativeInAppMessageDismissButtonLocation.Left;
        }

		public static NativeProfileScope ToLLProfileScope(XFLLProfileScope source)
        {
            if (source == XFLLProfileScope.Organization)
            {
				return NativeProfileScope.Organization;
            }

			return NativeProfileScope.Application;
        }
    }
}
