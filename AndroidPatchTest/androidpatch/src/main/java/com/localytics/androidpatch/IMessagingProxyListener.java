package com.localytics.androidpatch;

public interface IMessagingProxyListener {
    void localyticsWillDisplayInAppMessage();

    void localyticsDidDisplayInAppMessage();

    void localyticsWillDismissInAppMessage();

    void localyticsDidDismissInAppMessage();
}
