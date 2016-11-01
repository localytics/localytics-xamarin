package com.localytics.androidpatch;

import com.localytics.android.PlacesCampaign;
import com.localytics.android.PushCampaign;

public interface IMessagingProxyListener {
    void localyticsWillDisplayInAppMessage();

    void localyticsDidDisplayInAppMessage();

    void localyticsWillDismissInAppMessage();

    void localyticsDidDismissInAppMessage();

    boolean localyticsShouldShowPushNotification(PushCampaign campaign);

    // NotificationCompat.Builder throws errors when referenced here
    Object localyticsWillShowPushNotification(Object builder, PushCampaign pushCampaign);

    boolean localyticsShouldShowPlacesPushNotification(PlacesCampaign campaign);

    // NotificationCompat.Builder throws errors when referenced here
    Object localyticsWillShowPlacesPushNotification(Object builder, PlacesCampaign placesCampaign);
}
