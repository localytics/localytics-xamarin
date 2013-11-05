package com.localytics.androidpatch;

import com.localytics.android.AnalyticsListener;
import com.localytics.android.MessagingListener;

import java.util.Map;

class LocalyticsListener implements AnalyticsListener, MessagingListener{

    IAnalyticsProxyListener analyticsProxyListener;
    IMessagingProxyListener messagingProxyListener;

    protected void addAnalyticsProxyListener(IAnalyticsProxyListener listener) {
        analyticsProxyListener = listener;

    }

    protected void addMessagingProxyListener(IMessagingProxyListener listener) {
        messagingProxyListener = listener;
    }

    @Override
    public void localyticsSessionWillOpen(boolean b, boolean b1, boolean b2) {
        if (analyticsProxyListener != null) analyticsProxyListener.localyticsSessionWillOpen(b, b1, b2);
    }

    @Override
    public void localyticsSessionDidOpen(boolean b, boolean b1, boolean b2) {
        if (analyticsProxyListener != null) analyticsProxyListener.localyticsSessionDidOpen(b, b1, b2);
    }

    @Override
    public void localyticsSessionWillClose() {
        if (analyticsProxyListener != null) analyticsProxyListener.localyticsSessionWillClose();
    }

    @Override
    public void localyticsDidTagEvent(String s, Map<String, String> map, long l) {
        if (analyticsProxyListener != null) analyticsProxyListener.localyticsDidTagEvent(s, map, l);
    }

    @Override
    public void localyticsWillDisplayInAppMessage() {
        if (messagingProxyListener != null) messagingProxyListener.localyticsWillDisplayInAppMessage();
    }

    @Override
    public void localyticsDidDisplayInAppMessage() {
        if (messagingProxyListener != null) messagingProxyListener.localyticsDidDisplayInAppMessage();
    }

    @Override
    public void localyticsWillDismissInAppMessage() {
        if (messagingProxyListener != null) messagingProxyListener.localyticsWillDismissInAppMessage();
    }

    @Override
    public void localyticsDidDismissInAppMessage() {
        if (messagingProxyListener != null) messagingProxyListener.localyticsDidDismissInAppMessage();
    }
}
