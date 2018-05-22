using System;
using System.Collections.Generic;

using Foundation;
using UIKit;
using CoreLocation;
using LocalyticsXamarin.Common;
using LocalyticsXamarin.IOS;
using XNLocalytics.Shared;

[assembly: Xamarin.Forms.Dependency(typeof(LocalyticsXamarin.Forms.LocalyticsXamarinForms_iOS))]
namespace LocalyticsXamarin.Forms
{
	// TODO Entire implementation should be provided by Localytics
	public class LocalyticsXamarinForms_iOS :  LocalyticsPlatformCommon, ILocalytics, ILocalyticsIOS
	{
		public void SetProfileAttribute(object value, string attribute, XFLLProfileScope scope = XFLLProfileScope.Application)
        {
            Localytics.SetProfileAttribute(NSObject.FromObject(value), attribute, Utils.ToLLProfileScope(scope));
        }

        public void RemoveProfileAttributes(string attribute, XFLLProfileScope scope = XFLLProfileScope.Application, params object[] values)
        {
			Localytics.RemoveProfileAttributes(attribute, Utils.ToLLProfileScope(scope), values);
        }
        
		public void IncrementProfileAttribute(Int64 value, string attribute, XFLLProfileScope scope = XFLLProfileScope.Application)
        {
			Localytics.IncrementProfileAttribute((System.nint)value, attribute, Utils.ToLLProfileScope(scope));
        }

		public void DecrementProfileAttribute(Int64 value, string attribute, XFLLProfileScope scope = XFLLProfileScope.Application)
        {
			Localytics.DecrementProfileAttribute((System.nint)value, attribute, Utils.ToLLProfileScope(scope));
        }

        public void DeleteProfileAttribute(string attribute, XFLLProfileScope scope = XFLLProfileScope.Application)
        {
			Localytics.DeleteProfileAttribute(attribute, Utils.ToLLProfileScope(scope));
        }
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
        
		// object must be Date (Android) or NSDate (iOS)
        public void AddProfileAttributes(string attribute, XFLLProfileScope scope, params object[] values)
        {
            Localytics.AddProfileAttributes(attribute, Utils.ToLLProfileScope(scope), values);
        }

        public void AddProfileAttributes(string attribute, XFLLProfileScope scope, params string[] values)
        {
            Localytics.AddProfileAttributes(attribute, Utils.ToLLProfileScope(scope), values);
        }

        public void AddProfileAttributes(string attribute, XFLLProfileScope scope, params long[] values)
        {
			NSArray ary = Convertor.ToArray(values);
			Localytics.AddProfileAttributes(attribute, Utils.ToLLProfileScope(scope), ary);
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
	}
}

