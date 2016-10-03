package com.localytics.androidpatch;

import android.location.Location;
import android.support.annotation.NonNull;
import android.support.annotation.Nullable;
import android.support.v4.app.NotificationCompat;

import com.localytics.android.AnalyticsListener;
import com.localytics.android.CircularRegion;
import com.localytics.android.LocationListener;
import com.localytics.android.MessagingListener;
import com.localytics.android.PlacesCampaign;
import com.localytics.android.PushCampaign;
import com.localytics.android.Region;

import java.util.List;
import java.util.Map;

class LocalyticsListener implements AnalyticsListener, MessagingListener, LocationListener {

    IAnalyticsProxyListener mAnalyticsProxyListener;
    IMessagingProxyListener mMessagingProxyListener;
    ILocationProxyListener mLocationProxyListener;

    protected void setAnalyticsProxyListener(IAnalyticsProxyListener listener) {
        mAnalyticsProxyListener = listener;
    }

    protected void setMessagingProxyListener(IMessagingProxyListener listener) {
        mMessagingProxyListener = listener;
    }

    protected void setLocationProxyListener(ILocationProxyListener listener) {
        mLocationProxyListener = listener;
    }

    @Override
    public void localyticsSessionWillOpen(final boolean isFirst, final boolean isUpgrade, final boolean isResume) {
        if (mAnalyticsProxyListener != null) {
            mAnalyticsProxyListener.localyticsSessionWillOpen(isFirst, isUpgrade, isResume);
        }
    }

    @Override
    public void localyticsSessionDidOpen(final boolean isFirst, final boolean isUpgrade, final boolean isResume) {
        if (mAnalyticsProxyListener != null) {
            mAnalyticsProxyListener.localyticsSessionDidOpen(isFirst, isUpgrade, isResume);
        }
    }

    @Override
    public void localyticsSessionWillClose() {
        if (mAnalyticsProxyListener != null) {
            mAnalyticsProxyListener.localyticsSessionWillClose();
        }
    }

    @Override
    public void localyticsDidTagEvent(final String eventName, final Map<String, String> attributes, final long customerValueIncrease) {
        if (mAnalyticsProxyListener != null) {
            mAnalyticsProxyListener.localyticsDidTagEvent(eventName, attributes, customerValueIncrease);
        }
    }

    @Override
    public void localyticsWillDisplayInAppMessage() {
        if (mMessagingProxyListener != null) {
            mMessagingProxyListener.localyticsWillDisplayInAppMessage();
        }
    }

    @Override
    public void localyticsDidDisplayInAppMessage() {
        if (mMessagingProxyListener != null) {
            mMessagingProxyListener.localyticsDidDisplayInAppMessage();
        }
    }

    @Override
    public void localyticsWillDismissInAppMessage() {
        if (mMessagingProxyListener != null) {
            mMessagingProxyListener.localyticsWillDismissInAppMessage();
        }
    }

    @Override
    public void localyticsDidDismissInAppMessage() {
        if (mMessagingProxyListener != null) {
            mMessagingProxyListener.localyticsDidDismissInAppMessage();
        }
    }

    @Override
    public boolean localyticsShouldShowPushNotification(PushCampaign pushCampaign) {
        if (mMessagingProxyListener != null) {
            return mMessagingProxyListener.localyticsShouldShowPushNotification(pushCampaign);
        }
        return true;
    }

    @Override
    public boolean localyticsShouldShowPlacesPushNotification(PlacesCampaign placesCampaign) {
        if (mMessagingProxyListener != null) {
            return mMessagingProxyListener.localyticsShouldShowPlacesPushNotification(placesCampaign);
        }
        return true;
    }

    @Override
    public NotificationCompat.Builder localyticsWillShowPushNotification(NotificationCompat.Builder builder, PushCampaign pushCampaign) {
        if (mMessagingProxyListener != null) {
            return (NotificationCompat.Builder) mMessagingProxyListener.localyticsWillShowPushNotification(builder, pushCampaign);
        }
        return builder;
    }

    @Override
    public NotificationCompat.Builder localyticsWillShowPlacesPushNotification(NotificationCompat.Builder builder, PlacesCampaign placesCampaign) {
        if (mMessagingProxyListener != null) {
            return (NotificationCompat.Builder) mMessagingProxyListener.localyticsWillShowPlacesPushNotification(builder, placesCampaign);
        }
        return builder;
    }

    @Override
    public void localyticsDidUpdateLocation(@Nullable Location location) {
        if (mLocationProxyListener != null) {
            mLocationProxyListener.localyticsDidUpdateLocation(location);
        }
    }

    @Override
    public void localyticsDidTriggerRegions(@NonNull List<Region> regions, @NonNull Region.Event event) {
        if (mLocationProxyListener != null) {
            mLocationProxyListener.localyticsDidTriggerRegions(regions, toLLRegionEvent(event));
        }
    }

    @Override
    public void localyticsDidUpdateMonitoredGeofences(@NonNull List<CircularRegion> added, @NonNull List<CircularRegion> removed) {
        if (mLocationProxyListener != null) {
            mLocationProxyListener.localyticsDidUpdateMonitoredGeofences(added, removed);
        }
    }

    private LLRegionEvent toLLRegionEvent(@NonNull Region.Event event) {
        if (event == Region.Event.ENTER) {
            return LLRegionEvent.ENTER;
        } else {
            return LLRegionEvent.EXIT;
        }
    }
}
