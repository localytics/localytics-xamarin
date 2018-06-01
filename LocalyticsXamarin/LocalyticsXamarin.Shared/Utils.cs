using System;
using LocalyticsXamarin.Common;
#if __IOS__
using NativeInAppMessageDismissButtonLocation = LocalyticsXamarin.IOS.LLInAppMessageDismissButtonLocation;
using NativeProfileScope = LocalyticsXamarin.IOS.LLProfileScope;
using NativeImpressionType = LocalyticsXamarin.IOS.LLImpressionType;
#else
using LocalyticsXamarin.Android;
using NativeInAppMessageDismissButtonLocation = LocalyticsXamarin.Android.Localytics.InAppMessageDismissButtonLocation;
using NativeProfileScope = LocalyticsXamarin.Android.Localytics.ProfileScope;
using NativeImpressionType = LocalyticsXamarin.Android.Localytics.ImpressionType;
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

		// TODO ImpressionType
		public static XFLLImpressionType ToXFLLInAppMessageDismissButtonLocation(NativeImpressionType impressionType)
		{
			if (impressionType == NativeImpressionType.Click)
			{
				return XFLLImpressionType.Click;
			}

			return XFLLImpressionType.Dismiss;
		}

		public static NativeImpressionType ToLLInAppMessageDismissButtonLocation(XFLLImpressionType impressionType)
		{
			if (impressionType == XFLLImpressionType.Click)
			{
				return NativeImpressionType.Click;
			}

			return NativeImpressionType.Dismiss;
		}

		public static XFLLImpressionType? ImpressionType(string impression)
		{
			if ("click".Equals(impression, StringComparison.InvariantCultureIgnoreCase))
			{
				return XFLLImpressionType.Click;
			}
			else if ("dismiss".Equals(impression, StringComparison.InvariantCultureIgnoreCase))
			{
				return XFLLImpressionType.Dismiss;
			}
			return null;
		}
	}
}
