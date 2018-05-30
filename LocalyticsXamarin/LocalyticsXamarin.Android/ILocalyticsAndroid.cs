﻿using System;
using NativeInAppCampaign = LocalyticsXamarin.Android.InAppCampaign;
using NativeInboxCampaign = LocalyticsXamarin.Android.InboxCampaign;
using NativeImpressionType = LocalyticsXamarin.Android.Localytics.ImpressionType;
using NativePlacesCampaign = LocalyticsXamarin.Android.PlacesCampaign;

namespace LocalyticsXamarin.Android
{
    public interface ILocalyticsAndroid
    {
		void RedirectLoggingToDisk(bool writeExternally, object context);
		void TagInAppImpression(NativeInAppCampaign campaign, NativeImpressionType impressionType);
		void TagInAppImpression(NativeInAppCampaign campaign, string customAction);

		void TagImpressionForInboxCampaign(NativeInboxCampaign campaign, NativeImpressionType impressionType);
		//void TagImpressionForInboxCampaign(NativeInboxCampaign campaign, string customAction);

		void TagImpressionForPushToInboxCampaign(NativeInboxCampaign campaign);
		void TagPlacesPushReceived(NativePlacesCampaign campaign);
        // Is this action or identifier?
		void TagPlacesPushOpened(NativePlacesCampaign campaign, string identifier);
		void TriggerPlacesNotificationForCampaign(NativePlacesCampaign campaign);

		//void setInAppMessageDisplayActivity(Activity activity);
		//void clearInAppMessageDisplayActivity();
		//void registerPush();
		//String getPushRegistrationId();
		//void setPushRegistrationId(final String registrationId);
		//void setNotificationsDisabled(final boolean disable);
		//bool areNotificationsDisabled();

		//void handlePushNotificationOpened(final Intent intent);
		//public static boolean handleFirebaseMessage(Map<String, String> messageData);
		//void tagPushReceivedEvent(final Bundle data);
		//boolean displayPushNotification(final Bundle data)
		//void handleTestMode(final Intent intent)
		//void setInAppMessageDismissButtonImage(final Resources resources,
		//                                                 @DrawableRes final int id)
		//void setInAppMessageDismissButtonImage(final Resources resources,
		//final Bitmap image)
		//void SetLocation(Location location);
        //public static void redirectLogsToDisk(final boolean writeExternally, @NonNull final Context context)
		//public static IDictionary<CircularRegion> getGeofencesToMonitor(double latitude, double longitude); 
    }
}
