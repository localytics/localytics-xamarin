using System;
using CoreLocation;

namespace LocalyticsMaui.IOS
{
    public class LocalyticsDidTriggerRegionsEventArgs : EventArgs
    {
        public LLRegion[] Regions;
        public LLRegionEvent RegionEvent;

        public LocalyticsDidTriggerRegionsEventArgs(LLRegion[] regions, LLRegionEvent regionEvent)
        {
            this.Regions = regions;
            this.RegionEvent = regionEvent;
        }
    }

    public class LocalyticsDidUpdateLocationEventArgs : EventArgs
    {
        public CLLocation Location;
        public LocalyticsDidUpdateLocationEventArgs(CLLocation location)
        {
            this.Location = location;
        }
    }

    public class LocalyticsDidUpdateMonitoredGeofencesEventArgs : EventArgs
    {
        public LLRegion[] AddedRegions, RemovedRegions;

        public LocalyticsDidUpdateMonitoredGeofencesEventArgs(LLRegion[] addedRegions, LLRegion[] removedRegions)
        {
            this.AddedRegions = addedRegions;
            this.RemovedRegions = removedRegions;
        }
    }

}
