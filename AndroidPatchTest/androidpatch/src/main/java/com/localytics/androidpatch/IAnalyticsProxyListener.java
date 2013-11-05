package com.localytics.androidpatch;

import java.util.Map;

public interface IAnalyticsProxyListener {
    void localyticsSessionWillOpen(boolean var1, boolean var2, boolean var3);

    void localyticsSessionDidOpen(boolean var1, boolean var2, boolean var3);

    void localyticsSessionWillClose();

    void localyticsDidTagEvent(String var1, Map<String, String> var2, long var3);
}
