using LocalyticsXamarin.Common;
using XNLocalytics.Shared;
#if __IOS__
using LocalyticsXamarin.IOS;
#endif

[assembly: Xamarin.Forms.Dependency(typeof(XNLocalytics.Shared.LocalyticsXamarinForms))]
namespace XNLocalytics.Shared
{
    public class LocalyticsXamarinForms : LocalyticsPlatform, ILocalytics
#if __IOS__
    , ILocalyticsIOS
#endif
    {
    }
}
