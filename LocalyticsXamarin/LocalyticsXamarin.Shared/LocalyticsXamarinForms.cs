using LocalyticsXamarin.Common;
#if __IOS__
using LocalyticsXamarin.IOS;
#endif

[assembly: Xamarin.Forms.Dependency(typeof(LocalyticsXamarin.Shared.LocalyticsXamarinForms))]
namespace LocalyticsXamarin.Shared
{
    public class LocalyticsXamarinForms : LocalyticsPlatform, ILocalytics
//#if __IOS__
//    ,ILocalyticsIOS
//#else 
//	.ILocalyticsAndroid
//#endif
    {
		
    }
}
