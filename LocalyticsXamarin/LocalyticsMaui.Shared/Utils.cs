using System;
using LocalyticsMaui.Common;
#if __IOS__
using NativeInAppMessageDismissButtonLocation = LocalyticsMaui.iOS.LLInAppMessageDismissButtonLocation;
using NativeProfileScope = LocalyticsMaui.iOS.LLProfileScope;
using NativeImpressionType = LocalyticsMaui.iOS.LLImpressionType;
using NativeBaseCampaign = LocalyticsMaui.iOS.LLCampaignBase;
#else
using LocalyticsMaui.Android;
using NativeInAppMessageDismissButtonLocation = LocalyticsMaui.Android.Localytics.InAppMessageDismissButtonLocation;
using NativeProfileScope = LocalyticsMaui.Android.Localytics.ProfileScope;
using NativeImpressionType = LocalyticsMaui.Android.Localytics.ImpressionType;
using NativeBaseCampaign = LocalyticsMaui.Android.Campaign;
#endif
namespace LocalyticsMaui.Shared
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
