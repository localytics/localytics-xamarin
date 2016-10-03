package com.localytics.androidpatch;

import com.localytics.android.Localytics;

public class LocalyticsProxyListener {
    private LocalyticsListener mLocalyticsListener = new LocalyticsListener();

    public LocalyticsProxyListener() {
        Localytics.setAnalyticsListener(mLocalyticsListener);
        Localytics.setMessagingListener(mLocalyticsListener);
        Localytics.setLocationListener(mLocalyticsListener);
    }

    public void setAnalyticsProxyListener(IAnalyticsProxyListener listener) {
        mLocalyticsListener.setAnalyticsProxyListener(listener);
    }

    public void setMessagingProxyListener(IMessagingProxyListener listener) {
        mLocalyticsListener.setMessagingProxyListener(listener);
    }

    public void setLocationProxyListener(ILocationProxyListener listener) {
        mLocalyticsListener.setLocationProxyListener(listener);
    }
}
