using LocalyticsXamarin.Common;
using XNLocalytics.Shared;

[assembly: Xamarin.Forms.Dependency(typeof(LocalyticsXamarin.Forms.LocalyticsXamarinForms_Android))]
namespace LocalyticsXamarin.Forms
{
	public class LocalyticsXamarinForms_Android : LocalyticsPlatform, ILocalytics
	{
	}
}
