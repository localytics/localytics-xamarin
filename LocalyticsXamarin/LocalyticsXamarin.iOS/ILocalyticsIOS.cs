using System;
using CoreLocation;
using Foundation;
using UIKit;
using LocalyticsXamarin.IOS;

namespace LocalyticsXamarin.IOS
{
	public interface ILocalyticsIOS
    {
		void AddProfileAttributes(string attribute, LLProfileScope scope, params NSDate[] values);

		void RedirectLoggingToDisk();
		void DidRegisterUserNotificationSettings();
		bool HandleTestModeURL(NSUrl url);
		void SetInAppMessageDismissButtonImageWithName(string imageName);
        void SetInAppMessageDismissButtonImage(UIImage image);
        void SetLocation(CLLocationCoordinate2D location);
        LLRegion[] GeofencesToMonitor(CLLocationCoordinate2D currentCoordinate);
        void TriggerRegion(object region, LLRegionEvent regionEvent, CLLocation location);
        void TriggerRegions(object[] regions, LLRegionEvent regionEvent, CLLocation location);
        
		void TagImpressionForInAppCampaign(LLInAppCampaign campaign, LLImpressionType impressionType);
		void TagImpressionForInAppCampaign(LLInAppCampaign campaign, string customAction);
        
		void TagImpressionForInboxCampaign(LLInboxCampaign campaign, LLImpressionType impressionType);
		void TagImpressionForInboxCampaign(LLInboxCampaign campaign, string customAction);

		void TagImpressionForPushToInboxCampaign(LLInboxCampaign campaign, bool success);
		LLInboxDetailViewController InboxDetailViewControllerForCampaign(LLInboxCampaign campaign);
          void InboxListItemTapped(LLInboxCampaign campaign);
  
		void TagPlacesPushReceived(LLPlacesCampaign campaign);
        void TagPlacesPushOpened(LLPlacesCampaign campaign, string identifier);
        void TriggerPlacesNotificationForCampaign(object campaign);
		void SetLocationMonitoringEnabled(bool enabled);

       /*
         * 
         * TODO FIXME
        + (void) setAnalyticsDelegate:(nullable id<LLAnalyticsDelegate>)delegate;
        + (void) setPushToken:(nullable NSData *)pushToken;
        + (void) handleNotification:(nonnull NSDictionary *)notificationInfo;
        + (void) handleNotification:(nonnull NSDictionary *)notificationInfo withActionIdentifier:(nullable NSString *)identifier;
        + (void) didReceiveNotificationResponseWithUserInfo:(nonnull NSDictionary *)userInfo;
        + (void) didReceiveNotificationResponseWithUserInfo:(nonnull NSDictionary *)userInfo andActionIdentifier:(nullable NSString *)identifier;
        + (void) didRequestUserNotificationAuthorizationWithOptions:(NSUInteger) options granted:(BOOL) granted;
 */
        //+ (void) setMessagingDelegate:(nullable id<LLMessagingDelegate>)delegate;
        //+ (void) setLocationDelegate:(nullable id<LLLocationDelegate>)delegate;
        
        // On Android the Date are of Type Date and on iOS they are of type NSDate
		void AddDateProfileAttributes(string attribute, LLProfileScope scope, params object[] values);
    }
}
