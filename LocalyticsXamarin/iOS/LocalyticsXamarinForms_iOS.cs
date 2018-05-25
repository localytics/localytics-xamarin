using LocalyticsXamarin.Common;
using XNLocalytics.Shared;

[assembly: Xamarin.Forms.Dependency(typeof(LocalyticsXamarin.Forms.LocalyticsXamarinForms_iOS))]
namespace LocalyticsXamarin.Forms
{
	public class LocalyticsXamarinForms_iOS :  LocalyticsPlatform, ILocalytics, ILocalyticsIOS
	{
	}
}

