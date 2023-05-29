using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using LocalyticsMaui.Android;
using LocalyticsMaui.Common;
using LocalyticsMaui.Shared;

namespace LocalyticsSample;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
[IntentFilter(new[] { Intent.ActionView },
              Categories = new[] { Intent.CategoryBrowsable, Intent.CategoryDefault },
              DataScheme = "ampb70c948d304fc756d8b6e63-ecd3437a-a073-11e6-c6e3-008d99911bee",
              DataHost = "testMode")]
public class MainActivity : MauiAppCompatActivity
{
    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        Platform.Init(this, savedInstanceState);

        LocalyticsSDK localytics = LocalyticsMauiShared.SharedInstance;
        Localytics.RegisterPush();

        localytics.SetOption("ll_session_timeout_seconds", 10);
        localytics.CustomerId = "Sample Customer";
        localytics.SetProfileAttribute("Sample Attribute", XFLLProfileScope.Application, 83);
        localytics.AddProfileAttribute("Sample Set", XFLLProfileScope.Organization, 321, 654);
        localytics.TagEvent("Test Event");
        localytics.TagScreen("Test Screen");
        localytics.Upload();
    }


    protected override void OnNewIntent(Intent intent)
    {
        base.OnNewIntent(intent);
        this.Intent = intent;
    }
}

