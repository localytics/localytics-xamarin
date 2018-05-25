using System;
using LocalyticsXamarin.Common;
using System.Diagnostics;
#if __IOS__
using Foundation;
using CoreLocation;
using UIKit;
using LocalyticsXamarin.IOS;
#else
using Java.Util;
using LocalyticsXamarin.Android;
#endif
namespace LocalyticsXamarin.Shared
{
    public class LocalyticsPlatform : LocalyticsPlatformCommon
    {
		//#pragma region Platform Specific API's
#if __IOS__
        public void RedirectLoggingToDisk()
        {
            Localytics.RedirectLoggingToDisk();
        }

        public void DidRegisterUserNotificationSettings()
        {
            Localytics.DidRegisterUserNotificationSettings();
        }

        public void SetLocation(CLLocationCoordinate2D location)
        {
            Localytics.SetLocation(location);
        }

        public bool HandleTestModeURL(NSUrl url)
        {
            return Localytics.HandleTestModeURL(url);
        }

        public void SetInAppMessageDismissButtonImage(UIImage image)
        {
            Localytics.SetInAppMessageDismissButtonImage(image);
        }

        public LLRegion[] GeofencesToMonitor(CLLocationCoordinate2D currentCoordinate)
        {
            return Localytics.GeofencesToMonitor(currentCoordinate);
        }

        public void TriggerRegion(object region, LLRegionEvent regionEvent, CLLocation location)
        {
            Localytics.TriggerRegion((CLRegion)region, regionEvent, location);
        }

        public void TriggerRegions(object[] regions, LLRegionEvent regionEvent, CLLocation location)
        {
            Localytics.TriggerRegions((CLRegion[])regions, regionEvent, location);
        }
#endif

      

//        public void AddProfileAttributes(string attribute, XFLLProfileScope scope, params string[] values)
//        {
//#if __IOS__
//            Localytics.AddProfileAttributes(attribute, Utils.ToLLProfileScope(scope), values);
//#else
//			Localytics.AddProfileAttributesToSet(attribute, values, Utils.ToLLProfileScope(scope));
//#endif
//        }

//        public void AddProfileAttributes(string attribute, XFLLProfileScope scope, params long[] values)
//        {
//#if __IOS__
//            NSArray ary = Convertor.ToArray(values);
//            Localytics.AddProfileAttributes(attribute, Utils.ToLLProfileScope(scope), ary);
//#else
//			Localytics.AddProfileAttributesToSet(attribute, values, Utils.ToLLProfileScope(scope));
//#endif
        //}

  #if __IOS__

        public XFLLInAppMessageDismissButtonLocation InAppMessageDismissButtonLocation
        {
            get
            {
                return Utils.ToXFLLInAppMessageDismissButtonLocation(Localytics.InAppMessageDismissButtonLocation);
            }
            set
            {
                Localytics.InAppMessageDismissButtonLocation = Utils.ToLLInAppMessageDismissButtonLocation(value);
            }
        }


        public void AddProfileAttributes(string attribute, LLProfileScope scope, params NSDate[] values)
        {
            Localytics.AddProfileAttributes(attribute, scope, values);
        }

        public void TagImpressionForPushToInboxCampaign(LLInboxCampaign campaign, bool success)
        {
            Localytics.TagImpressionForPushToInboxCampaign(campaign, success);
        }

        public LLInboxDetailViewController InboxDetailViewControllerForCampaign(LLInboxCampaign campaign)
        {
            return Localytics.InboxDetailViewControllerForCampaign(campaign);
        }

        public void AddDateProfileAttributes(string attribute, LLProfileScope scope, params object[] values)
        {
            Localytics.AddProfileAttributes(attribute, scope, values);
        }

#else
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

#endif
    }
}
