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
		// CLLocation vs Location
		void TriggerRegion(LLRegionEvent regionEvent, CLLocation location, params object[] region);

		void TagInAppImpression(LLInAppCampaign campaign, LLImpressionType impressionType);
		void TagInAppImpression(LLInAppCampaign campaign, string customAction);
		void TagPlacesPushReceived(LLPlacesCampaign campaign);

		void TagPlacesPushOpened(LLPlacesCampaign campaign, string identifier);
		void TriggerPlacesNotificationForCampaign(LLPlacesCampaign campaign);

		void TagImpressionForPushToInboxCampaign(LLInboxCampaign campaign, bool success);
		LLInboxDetailViewController InboxDetailViewControllerForCampaign(LLInboxCampaign campaign);
		void TagImpressionForInboxCampaign(LLInboxCampaign campaign, LLImpressionType impressionType);

		void SetLocationMonitoringEnabled(bool enabled);

		/*
          * These are to be accessed in platform specific code.
         + (void) setPushToken:(nullable NSData *)pushToken;
         + (void) handleNotification:(nonnull NSDictionary *)notificationInfo;
         + (void) handleNotification:(nonnull NSDictionary *)notificationInfo withActionIdentifier:(nullable NSString *)identifier;
         + (void) didReceiveNotificationResponseWithUserInfo:(nonnull NSDictionary *)userInfo;
         + (void) didReceiveNotificationResponseWithUserInfo:(nonnull NSDictionary *)userInfo andActionIdentifier:(nullable NSString *)identifier;
         + (void) didRequestUserNotificationAuthorizationWithOptions:(NSUInteger) options granted:(BOOL) granted;
        */
	}
}
