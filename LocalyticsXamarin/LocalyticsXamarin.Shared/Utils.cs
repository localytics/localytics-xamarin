using System;
using LocalyticsXamarin.Common;
#if __IOS__
using NativeInAppMessageDismissButtonLocation = LocalyticsXamarin.IOS.LLInAppMessageDismissButtonLocation;
using NativeProfileScope = LocalyticsXamarin.IOS.LLProfileScope;
#else
using LocalyticsXamarin.Android;
using NativeInAppMessageDismissButtonLocation = LocalyticsXamarin.Android.Localytics.InAppMessageDismissButtonLocation;
using NativeProfileScope = LocalyticsXamarin.Android.Localytics.ProfileScope;
#endif
namespace LocalyticsXamarin.Shared
{
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
