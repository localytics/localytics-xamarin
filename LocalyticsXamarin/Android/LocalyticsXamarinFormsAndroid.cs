using System;
using LocalyticsXamarin.Android;

[assembly: Xamarin.Forms.Dependency(typeof(LocalyticsSample.Shared.LocalyticsXamarinForms))]
namespace LocalyticsSample.Shared
{
    public class LocalyticsXamarinFormsAndroid : LocalyticsXamarinForms
    {

        public bool InAppShouldShowHandler(InAppCampaign inAppCampaign)
        {
            Console.WriteLine("XamarinEvent LLInAppCampaign campaign:{0}", (InAppCampaign)inAppCampaign);
            return inappShouldDisplay;
        }

        public bool PlacesShouldDisplay(PlacesCampaign placesCampaign)
        {
            Console.WriteLine("XamarinEvent PlacesShouldDisplay campaign:{0}", (PlacesCampaign)placesCampaign);
            return placesShouldDisplay;
        }


        public override void RegisterEvents()
        {
            base.RegisterEvents();

            // LocalyticsSDK.InAppShouldShowDelegate = InAppShouldShowHandler;
            // LocalyticsSDK.ShouldDeepLinkDelegate = ShouldDeepLinkHandler;

            Localytics.ShouldPromptForLocationPermission = (Campaign campaign) => {
                Console.WriteLine("XamarinEvent LocalyticsShouldPromptForLocationPermission " + campaign);
                return true;
            };
        }
    }
}