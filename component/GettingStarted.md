# Getting Started with Localytics in Xamarin
---
This Xamarin Component simplifies the process of integrating Localytics into Xamarin iOS, Android and Forms projects.

The steps to integrate Localytics with this component mirrors the native Localytics SDK, so the following docs for the respective platforms maybe helpful:

* [iOS Localytics Docs](http://docs.localytics.com/dev/ios.html)
* [Android Localytics Docs](http://docs.localytics.com/dev/android.html)

## Xamarin.iOS
---
In order to use the Xamarin.iOS API in a source file, you will need to add the namespace `LocalyticsXamarin.iOS`. Before calling anything else on the Localytics API, override the `FinishedLaunching` in your app delegate to auto integrate with your Localytics App Key.

```
using LocalyticsXamarin.iOS;

...

[Register ("AppDelegate")]
public class AppDelegate : UIApplicationDelegate
{
    ...

    public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
    {
        ...

        // Localytics Auto Integrate with App Key
        Localytics.AutoIntegrate ("xxxxxxxxxxxxxxx-xxxxxxx-xxxxx-xxxx-xxxx-xxxxxxxxxxx", launchOptions != null? launchOptions : new NSDictionary());

        ...

        return true;
    }

    ...
}
```

### Usage
---
All native iOS Library (v3.5.x) calls are available including `LLInAppMessageDismissButtonLocation`, `LLProfileScope`, `LLAnalyticsDelegate` and `LLMessagingDelegate`. For details about each functionality, please refer to documentations for the native API.

Anywhere in your application, you can use the Localytics API by calling the class methods/accessors of `Localytics`. Here's a sample of some of the calls.

```
Localytics.SessionTimeoutInterval = 10;
Localytics.CustomerId = "Sample Customer";
Localytics.SetProfileAttribute ((NSString)("Sample Attribute"), "83", LLProfileScope.Organization);

Localytics.AddProfileAttributesToSet(new NSObject[] { (NSNumber)(222), (NSString)("333") }, "Sample Set", LLProfileScope.Application);

Localytics.TagEvent ("Test Event");
Localytics.TagScreen ("Test Screen");

Localytics.Upload ();
```

The above only demonstrate the syntax of calling the Xamarin.iOS API.  For more information about how to use Localytics, please refer to [iOS Localytics Docs](http://docs.localytics.com/dev/ios.html).

### Push & In-App Messaging
---
1. Enable background modes

  * Under Project Options -> Build -> iOS Application -> Background Modes, turn on Enable Background Modes and Remote notfication. You can also edit this in the `info.plist`.

2. Register for remote notifications

  Add the following in your main AppDelegate inside `FinishedLaunching` where the `AutoIntegrate` call is

  ```
  if ([application respondsToSelector:@selector(registerUserNotificationSettings:)])
  {
      UIUserNotificationType types = (UIUserNotificationTypeAlert | UIUserNotificationTypeBadge | UIUserNotificationTypeSound);
      UIUserNotificationSettings *settings = [UIUserNotificationSettings settingsForTypes:types categories:nil];
      [application registerUserNotificationSettings:settings];
      [application registerForRemoteNotifications];
  }
  else
  {
      [application registerForRemoteNotificationTypes:(UIRemoteNotificationTypeAlert | UIRemoteNotificationTypeBadge | UIRemoteNotificationTypeSound)];
  }
  ```

3. Add ATS exception

  Add the following NSAppTransportSecurity exception to unblock HTTP use for some in app and push creatives.

  ```
  <key>NSAppTransportSecurity</key>
  <dict>
      <key>NSExceptionDomains</key>
      <dict>
          <key>public.localytics.s3.amazonaws.com</key>
          <dict>
              <key>NSExceptionAllowsInsecureHTTPLoads</key>
              <true/>
          </dict>
          <key>pushapi.localytics.com</key>
          <dict>
              <key>NSExceptionAllowsInsecureHTTPLoads</key>
              <true/>
          </dict>
      </dict>
  </dict>
  ```

For more information on setting up Push Notification, please refer to [Localytics Push Messaging for iOS](http://docs.localytics.com/dev/ios.html#push-messaging-ios)

### Analytics and Messaging Listeners
---
1. Subclass and override functions for `LLAnalyticsDelegate` and `LLMessagingDelegate`. Refer to `LocalyticsAnalyticsListener_iOS.cs` and `LocalyticsMessagingListener_iOS.cs` in LocalyticsSample.iOS.
2. Add instance of the subclass through `Localytics.AddAnalyticsDelegate(delegate)` `Localytics.AddMessagingDelegate(delegate)`




## Xamarin.Android
---
In order to use the Xamarin.Android API in a source file, you will need to add the namespace `LocalyticsXamarin.Android`. Before calling anything else on the Localytics API, you will need:

1. call `RegisterActivityLifecycleCallbacks` within your custom `Application` class
  
  ```
  using LocalyticsXamarin.Android;

  ...

  [Application]
  public class YourApplication : Application
  {
      public YourApplication (IntPtr handle, JniHandleOwnership ownerShip) : base (handle, ownerShip)
      {
      }

      override public void OnCreate() {
          base.OnCreate ();

          #if DEBUG
          Localytics.LoggingEnabled = true;
          #endif

          // RegisterActivityLifecycleCallbacks to auto integrate Localytics
          RegisterActivityLifecycleCallbacks (new LocalyticsActivityLifecycleCallbacks (this));

      }
  }
  ```

2. Modify the AndroidManifest.xml to add App Key, receivers and permissions.
  
  ```
  <application android:label="LocalyticsSample" android:icon="@drawable/icon">
      <meta-data android:name="LOCALYTICS_APP_KEY" android:value="xxxxxxxxxxxxxxxxxxxxxxx-xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" />
      <receiver android:name="com.localytics.android.ReferralReceiver" android:exported="true">
          <intent-filter>
              <action android:name="com.android.vending.INSTALL_REFERRER" />
          </intent-filter>
      </receiver>
  </application>
  <uses-permission android:name="android.permission.INTERNET" />
  <uses-permission android:name="android.permission.WAKE_LOCK" />
  ```

### Usage
---
Most native Android Library (v3.5.x) calls are available. However, `AnalyticsListener` and `MessagingListener` are currently not available. For details about each functionality, please refer to documentations for the native API.

Anywhere in your application, you can use the Localytics API by calling the class methods/accessors of `Localytics`. Here's a sample of some of the calls.

```
Localytics.SessionTimeoutInterval = 10;
Localytics.CustomerId = "Sample Customer";

Localytics.SetProfileAttribute ("Sample Attribute", 83, Localytics.ProfileScope.Organization);
Localytics.AddProfileAttributesToSet("Sample Set", new long[] { 321,654}, Localytics.ProfileScope.Application);

Localytics.TagEvent ("Test Event");
Localytics.TagScreen ("Test Screen");

Localytics.Upload ();
```

The above only demonstrate the syntax of calling the Xamarin.Android API.  For more information about how to use Localytics, please refer to [Android Localytics Docs](http://docs.localytics.com/dev/android.html).


### Push & In-App Messaging
---

1. Modify AndroidManifest.xml

  * Push permissions above the `application` tag.

    ```
    <uses-permission
        android:name="com.google.android.c2dm.permission.RECEIVE" />
    <permission
        android:name="YOUR-PACKAGE-NAME.permission.C2D_MESSAGE"
        android:protectionLevel="signature" />
    <uses-permission android:name="YOUR-PACKAGE-NAME.permission.C2D_MESSAGE" />
    ```

  * Add `PushReciever` inside the `application` tag.

    ```
    <receiver
        android:name="com.localytics.android.PushReceiver"
        android:permission="com.google.android.c2dm.permission.SEND" >
        <intent-filter>
            <action android:name="com.google.android.c2dm.intent.REGISTRATION" />
            <action android:name="com.google.android.c2dm.intent.RECEIVE" />
            <category android:name="YOUR-PACKAGE-NAME" />
        </intent-filter>
    </receiver>
    ```

  * Add PushTrackingActivity within the `application` tag.

    ```
    <activity android:name="com.localytics.android.PushTrackingActivity"/>
    ```

2. Register for Push in the main activity

  ```
  Localytics.RegisterPush("YOUR_GCM_PROJECT_NUMBER");
  ```

3. If not already, the main activity should extend `FragmentActivity`.

The LocalyticsMessagingSample.Android sample project will further illustrate the above.


### Analytics and Messaging Listeners
---

After initializing the SDK, call the following the subscribe to all SDK events:

```
LocalyticsEvents.SubscribeToAll ();
```

You can then add delegates to events:

```
LocalyticsEvents.OnLocalyticsSessionDidOpen += Some_Function;
```

Below are all the delegate and corresponding event names:

```
public delegate void LocalyticsDidTagEvent(string eventName, IDictionary<string, string> attributes, long customerValueIncrease);
public delegate void LocalyticsSessionDidOpen(bool isFirst, bool isUpgrade, bool isResume);
public delegate void LocalyticsSessionWillClose();
public delegate void LocalyticsSessionWillOpen(bool isFirst, bool isUpgrade, bool isResume);

public delegate void LocalyticsDidDismissInAppMessage();
public delegate void LocalyticsDidDisplayInAppMessage();
public delegate void LocalyticsWillDismissInAppMessage();
public delegate void LocalyticsWillDisplayInAppMessage();

public static event LocalyticsDidTagEvent OnLocalyticsDidTagEvent;
public static event LocalyticsSessionDidOpen OnLocalyticsSessionDidOpen;
public static event LocalyticsSessionWillClose OnLocalyticsSessionWillClose;
public static event LocalyticsSessionWillOpen OnLocalyticsSessionWillOpen;

public static event LocalyticsDidDismissInAppMessage OnLocalyticsDidDismissInAppMessage;
public static event LocalyticsDidDisplayInAppMessage OnLocalyticsDidDisplayInAppMessage;
public static event LocalyticsWillDismissInAppMessage OnLocalyticsWillDismissInAppMessage;
public static event LocalyticsWillDisplayInAppMessage OnLocalyticsWillDisplayInAppMessage;
```

The LocalyticsMessagingSample.Android sample project will further illustrate the above.