package com.localytics.androidpatch;

import java.util.Map;

public interface IAnalyticsProxyListener {
    void localyticsSessionWillOpen(boolean isFirst, boolean isUpgrade, boolean isResume);

    void localyticsSessionDidOpen(boolean isFirst, boolean isUpgrade, boolean isResume);

    void localyticsSessionWillClose();

    void localyticsDidTagEvent(String eventName, Map<String, String> attributes, long customerValueIncrease);
}
