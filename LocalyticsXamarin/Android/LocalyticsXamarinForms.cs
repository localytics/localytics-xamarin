using System;
using LocalyticsSample.Shared;
using LocalyticsMaui.Common;
using LocalyticsMaui.Shared;


[assembly: Xamarin.Forms.Dependency(typeof(LocalyticsSample.Shared.LocalyticsXamarinForms))]
namespace LocalyticsSample.Shared
{
    public class LocalyticsXamarinForms : LocalyticsSDK, ILocalytics, IPlatform
    {
        protected bool inappShouldDisplay = true;
        protected bool placesShouldDisplay = true;
        protected bool shouldDeepLink = true;

        public void SetPlacesShouldDisplay(bool display)
        {
            placesShouldDisplay = display;
        }

        public void SetInAppShouldDisplay(bool display)
        {
            inappShouldDisplay = display;
        }

        public void SetShouldDeeplink(bool display)
        {
            shouldDeepLink = display;
        }


        public virtual bool InAppShouldShowHandler(object inAppCampaign) { return true;  }
        public virtual bool PlacesShouldDisplay(object placesCampaign) { return true; }

        public bool ShouldDeepLinkHandler(string url)
        {
            // Console.WriteLine("XamarinEvent ShouldDeepLink Url:{0}", url);
            return shouldDeepLink;
        }

        public virtual void RegisterEvents()
        {
            LocalyticsSDK.LocalyticsDidTriggerRegions += (sender, e) =>
            {
                System.Diagnostics.Debug.WriteLine("XamarinEvent LocalyticsDidTriggerRegions " + e);
            };

            LocalyticsSDK.LocalyticsDidUpdateLocation += (sender, e) =>
            {
                System.Diagnostics.Debug.WriteLine("XamarinEvent LocalyticsDidUpdateLocation " + e);
            };

            LocalyticsSDK.LocalyticsDidUpdateMonitoredGeofences += (sender, e) =>
            {
                System.Diagnostics.Debug.WriteLine("XamarinEvent LocalyticsDidUpdateMonitoredGeofences " + e);
            };

            // Analytics Events
            LocalyticsSDK.LocalyticsSessionDidOpen += (sender, e) =>
            {
                System.Diagnostics.Debug.WriteLine("XamarinEvent SessionDidOpenEvent: " + e);
            };

            LocalyticsSDK.LocalyticsDidTagEvent += (sender, e) =>
            {
                System.Diagnostics.Debug.WriteLine("XamarinEvent SessionDidTagEvent: " + e);
            };

            LocalyticsSDK.LocalyticsSessionWillClose += (sender, e) =>
            {
                System.Diagnostics.Debug.WriteLine("XamarinEvent SessionWillCloseEvent: " + e);
            };

            LocalyticsSDK.LocalyticsSessionWillOpen += (sender, e) =>
            {
                System.Diagnostics.Debug.WriteLine("XamarinEvent SessionWillOpenEvent: " + e);
            };

            LocalyticsSDK.InAppDidDismissEvent += (sender, e) =>
            {
                System.Diagnostics.Debug.WriteLine("XamarinEvent InAppDidDismissEvent " + e);
            };

            LocalyticsSDK.InAppDidDisplayEvent += (sender, e) =>
            {
                System.Diagnostics.Debug.WriteLine("XamarinEvent InAppDidDisplayEvent " + e);
            };

            LocalyticsSDK.InAppWillDismissEvent += (sender, e) =>
            {
                System.Diagnostics.Debug.WriteLine("XamarinEvent InAppWillDismissEvent " + e);
            };

            LocalyticsSDK.InAppWillDisplayDelegate = (campaign, configuration) =>
            {
                System.Diagnostics.Debug.WriteLine("XamarinEvent LocalyticsWillDisplayInAppMessage " + campaign + "," + configuration);
                return configuration;
            };

            LocalyticsSDK.CallToActionShouldDeepLinkDelegate = (string deeplink, ICampaignBase campaign) =>
            {
                System.Diagnostics.Debug.WriteLine("XamarinEvent LocalyticsCallToActionShouldDeepLinkDelegate " + deeplink + "," + campaign);
                return true;
            };

            LocalyticsSDK.DidOptOut = (object sender, DidOptOutEventArgs optOutEventArgs) =>
            {
                System.Diagnostics.Debug.WriteLine("XamarinEvent LocalyticsDidOptOut " + optOutEventArgs);
            };

            LocalyticsSDK.DidPrivacyOptOut = (object sender, DidOptOutEventArgs optOutEventArgs) =>
            {
                System.Diagnostics.Debug.WriteLine("XamarinEvent LocalyticsDidPrivacyOptOut " + optOutEventArgs);
            };
        }
    }
}