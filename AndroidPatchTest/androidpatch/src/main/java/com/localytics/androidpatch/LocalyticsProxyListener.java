package com.localytics.androidpatch;

import com.localytics.android.Localytics;

public class LocalyticsProxyListener {
    private LocalyticsListener localyticsListener = new LocalyticsListener();

    public LocalyticsProxyListener() {
        Localytics.addAnalyticsListener(localyticsListener);
        Localytics.addMessagingListener(localyticsListener);
    }

    public void addAnalyticsProxyListener(IAnalyticsProxyListener listener) {
        localyticsListener.addAnalyticsProxyListener(listener);
    }

    public void addMessagingProxyListener(IMessagingProxyListener listener) {
        localyticsListener.addMessagingProxyListener(listener);

    }
}
