package com.localytics.androidpatch;

import android.location.Location;

import com.localytics.android.CircularRegion;
import com.localytics.android.Region;

import java.util.List;

public interface ILocationProxyListener {
    void localyticsDidUpdateLocation(Location location);

    void localyticsDidTriggerRegions(List<Region> regions, LLRegionEvent event);

    void localyticsDidUpdateMonitoredGeofences(List<CircularRegion> added, List<CircularRegion> removed);
}
