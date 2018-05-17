using System;
using System.Collections.Generic;

using Foundation;
using UIKit;
using CoreLocation;
using LocalyticsXamarin.Common;
using LocalyticsXamarin.iOS;
using LocalyticsXamarin.iOS.Enums;
using XNLocalytics.Shared;

[assembly: Xamarin.Forms.Dependency(typeof(LocalyticsXamarin.Forms.LocalyticsXamarinForms_iOS))]
namespace LocalyticsXamarin.Forms
{
	public interface ILocalyticIOS
    {
        bool HandleTestModeURL(NSUrl url);
        void SetInAppMessageDismissButtonImage(UIImage image);
        void SetLocation(CLLocationCoordinate2D location);
        LLRegion[] GeofencesToMonitor(CLLocationCoordinate2D currentCoordinate);
        void TriggerRegion(object region, LLRegionEvent regionEvent, CLLocation location);
        void TriggerRegions(object[] regions, LLRegionEvent regionEvent, CLLocation location);
        void TagImpressionForInAppCampaign(object campaign, LLImpressionType impressionType);
        void TagImpressionForInboxCampaign(object campaign, LLImpressionType impressionType);
        LLInboxDetailViewController InboxDetailViewControllerForCampaign(object campaign);
    }

	public class LocalyticsXamarinForms_iOS :  LocalyticsPlatformIOS , ILocalytics
	{
		public LocalyticsXamarinForms_iOS() { }
		public void SetProfileAttribute(object value, string attribute, XFLLProfileScope scope = XFLLProfileScope.Application)
        {
            Localytics.SetProfileAttribute(NSObject.FromObject(value), attribute, ToLLProfileScope(scope));
        }

        public void AddProfileAttributes(string attribute, XFLLProfileScope scope, params object[] values)
        {
            Localytics.AddProfileAttributes(attribute, ToLLProfileScope(scope), values);
        }

        public void RemoveProfileAttributes(string attribute, XFLLProfileScope scope = XFLLProfileScope.Application, params object[] values)
        {
            Localytics.RemoveProfileAttributes(attribute, ToLLProfileScope(scope), values);
        }

        public void IncrementProfileAttribute(int value, string attribute, XFLLProfileScope scope = XFLLProfileScope.Application)
        {
            Localytics.IncrementProfileAttribute(value, attribute, ToLLProfileScope(scope));
        }

        public void DecrementProfileAttribute(int value, string attribute, XFLLProfileScope scope = XFLLProfileScope.Application)
        {
            Localytics.DecrementProfileAttribute(value, attribute, ToLLProfileScope(scope));
        }

        public void DeleteProfileAttribute(string attribute, XFLLProfileScope scope = XFLLProfileScope.Application)
        {
            Localytics.DeleteProfileAttribute(attribute, ToLLProfileScope(scope));
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

        public void TriggerInAppMessage(string triggerName, IDictionary<string, string> attributes)
        {
            Localytics.TriggerInAppMessage(triggerName, attributes.ToNSDictionary());
        }
        
        private LLProfileScope ToLLProfileScope(XFLLProfileScope source)
        {
            if (source == XFLLProfileScope.Organization)
            {
                return LLProfileScope.Organization;
            }

            return LLProfileScope.Application;
        }

		public void RefreshInboxCampaigns(InboxCampaignsDelegate inboxCampaignsDelegate)
        {
            Localytics.RefreshInboxCampaigns(new Action<LLInboxCampaign[]>((LLInboxCampaign[] obj) => {
                inboxCampaignsDelegate(obj);
            }));
        }

		public void RefreshAllInboxCampaigns(InboxCampaignsDelegate inboxCampaignsDelegate)
        {
            Localytics.RefreshAllInboxCampaigns(new Action<LLInboxCampaign[]>((LLInboxCampaign[] obj) => {
                inboxCampaignsDelegate(obj);
            }));
        }
	}
}

