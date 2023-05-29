using Foundation;
using LocalyticsMaui.iOS;
using UIKit;

namespace LocalyticsSample;

[Register("AppDelegate")]
public class AppDelegate : MauiUIApplicationDelegate
{

    public override bool FinishedLaunching(UIApplication uiApplication, NSDictionary launchOptions)
    {
        // Localytics Integrate
        Localytics.LoggingEnabled = true;
        Localytics.Integrate("b70c948d304fc756d8b6e63-ecd3437a-a073-11e6-c6e3-008d99911bee", launchOptions ?? new NSDictionary());

        // Register for remote notifications
        var pushSettings = UIUserNotificationSettings.GetSettingsForTypes(
            UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound,
            new NSSet());

        UIApplication.SharedApplication.RegisterUserNotificationSettings(pushSettings);
        UIApplication.SharedApplication.RegisterForRemoteNotifications();

        return base.FinishedLaunching(uiApplication, launchOptions);
    }

    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}

