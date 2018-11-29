# Getting Started with Localytics in Xamarin
---
This Xamarin Nuget simplifies the process of integrating Localytics into Xamarin iOS, Android and Forms projects.

The steps to integrate Localytics with this component mirrors the native Localytics SDK, so the following docs for the respective platforms maybe helpful:

* [iOS Localytics Docs](http://docs.localytics.com/dev/ios.html)
* [Android Localytics Docs](http://docs.localytics.com/dev/android.html)


## Getting Started

### Install the SDK
1. Download the latest version of the Nuget package from [here](https://downloads.localytics.com/SDKs/Xamarin/Localytics-Xamarin-Latest.zip).
2. Add a Nuget Package source in Visual Studio Preferences called localytics that points to the folder with the downloaded package.
3. In Projects that need to be integrated with Localytics Xamarin SDK
	* Expand Packages folder
	* Add a Package ![Add Package Menu](/images/AddPackage.png)
	* Select localytics as the package sources ![Add Package Dialog](/images/AddPackageDialog.png)
	* Pick the latest version of LocalyticsXamarin nuget package
	* Repeat the step for each platform (Android and iOS) ![Solution Window](/images/AfterPackagesAdded.png)
	
## Package Names

* LocalyticsXamarin.iOS     - API's available for use on the iOS platform [iOS Localytics Docs](http://docs.localytics.com/dev/ios.html)
* LocalyticsXamarin.Android - API's available for use on the Android platform [Android Localytics Docs](http://docs.localytics.com/dev/android.html)
* LocalyticsXamarin.Shared - Platform specific API's that have been bridged to work from a Shared library project.
* LocalyticsXamarin.Common - class available on Both iOS and Android using .net dependencies only. The Interfaces are the same across platforms offering similar functionality.

## Xamarin Forms and Dependency Service
LocalyticsXamarin.Common.ILocalytics interface is implemented using XamarinForms and can be available to a project using XamarinDependency Service.

Add a file to each of your platforms with the following contents

    using System;
    using LocalyticsXamarin.Common;
    [assembly: Xamarin.Forms.Dependency(typeof(LocalyticsXamarin.Shared.LocalyticsXamarinForms))]
    namespace LocalyticsXamarin.Shared
    {
    public class LocalyticsXamarinForms : LocalyticsSDK, ILocalytics, IPlatform
	    {
	    }
    }

Use the API in common modules using the interface
```
    ILocalytics localytics = DependencyService.Get<ILocalytics>();
```

* Non forms classes can use the same interface using
```
    ILocalytics localytics = LocalyticsSDK.SharedInstance;
``` 

## API Summary

API's follow c# naming conventions and are translation of the API on the native platform.

### Common APIs

| API                    | Description  |
|------------------------|------|
| OpenSession  | Opens a session. Multiple calls are coallesed.  |
| CloseSession | Open Sessions are marked with a pending close. Sessions are extended if there is localytics activity before expiry of Session timer |
| Upload| uploads any data stored on the device by the localytics SDK. Essential to do this early, to ensure upload completes before app is suspended.|
| PauseDataUploading | all data upload is deferred until it is resumed. Calls to the upload API dont perform any action. When data upload is resumed, all locally stored data is immediately uploaded. |
| TagEvent | Tag an event |
| TagPurchased | A standard event to tag a single item purchase event (after the action has occurred) |
| TagAddedToCart | A standard event to tag the addition of a single item to a cart (after the action has occurred) |
| TagStartedCheckout | A standard event to tag the start of the checkout process (after the action has occurred) |
| TagCompletedCheckout | A standard event to tag the conclusions of the checkout process (after the action has occurred) |
| TagContentViewed | A standard event to tag the viewing of content (after the action has occurred) |
| TagSearched | A standard event to tag a search event (after the action has occurred) |
| TagShared | A standard event to tag a share event (after the action has occurred) |
| TagContentRated | A standard event to tag the rating of content (after the action has occurred) |
| TagCustomerRegistered | A standard event to tag the registration of a user (after the action has occurred) |
| TagCustomerLoggedIn | A standard event to tag the logging in of a user (after the action has occurred) |
| TagCustomerLoggedOut | A standard event to tag the logging out of a user (after the action has occurred) |
| TagInvited | A standard event to tag the invitation of a user (after the action has occured) |
| TagScreen | Allows tagging the flow of screens encountered during the session. |
| SetCustomDimension | Sets the value of custom dimension which is user defined data. Customer sensitive data should be hashed or encrypted |
| GetCustomDimension |Gets the custom value for a given dimension. Must not be called from the main thread. |
| SetIdentifier | Sets the value of a custom identifier |
| GetIdentifier | Gets the identifier value for a given identifier. Must not be called form the main thread. |
| CustomerId | property representing a customer Id. Recommended to use SetCustomerId. privacy sensitive data should be hashed or encyrpted |
| SetCustomerId | set customer Id and privacy status automically.|
| SetProfileAttribute | Attribute values can be long, string, Array of long or Array of String |
| AddProfileAttribute | Adds values to a profile attribute that is a set |
| RemoveProfileAttribute | Removes values from a profile attribute that is a set |
| IncrementProfileAttribute | Increment the value of a profile attribute. |
| DecrementProfileAttribute | Decrement the value of a profile attribute. |
| DeleteProfileAttribute | Delete a profile attribute |
| SetCustomerEmail | Convenience method to set a customer's email |
| SetCustomerFirstName | Convenience method to set a customer's first name |
| SetCustomerLastName | Convenience method to set a customer's last name |
| SetCustomerFullName | Convenience method to set a customer's full name |
| SetOptions | Customize the behavior of the SDK by setting custom values for various options.|
| SetOption | Customize the behavior of the SDK by setting custom value for various options.|
| LoggingEnabled |property that controls if the localytics SDK emits logging information. |
| OptedOut | control collection of user data. |
| PrivacyOptedOut | Opts out of data collection and requests a Delete data request to be submitting to the cloud service. |
| InstallId | An Installtion Identifier |
| LibraryVersion | version of the Localytics SDK |
| TestModeEnabled | Controls the Test Mode charactertistics of the Localytics SDK |
| InAppAdIdParameterEnabled | ADID parameter is added to In-App call to action URLs |
| TriggerPlacesNotificationForCampaignId | Trigger a places notification for the given campaign id and regionId |
| InboxAdIdParameterEnabled | ADID parameter is added to Inbox call to action URLs |
| InAppMessageDismissButtonLocation | location of the dismiss button on an In-App msg |
| SetInAppMessageDismissButtonHidden | dismiss button hidden state on an In-App message |
| TriggerInAppMessage | Trigger an In-App message |
| TriggerInAppMessagesForSessionStart | Trigger campaigns as if a Session Start event had just occurred. |
| DismissCurrentInAppMessage | Dismiss a currently displayed In-App message. |
| InboxCampaigns | an array of all Inbox campaigns that are enabled and can be displayed |
| AllInboxCampaigns | an array of all Inbox campaigns that are enabled. |
| RefreshInboxCampaigns | Refresh inbox campaigns from the Localytics server that are enabled and can be displayed. |
| RefreshAllInboxCampaigns | Refresh inbox campaigns from the Localytics server that are enabled. |
| TagImpression | A standard event to tag an In-App impression. |
| SetInboxCampaign | Set an Inbox campaign as read. |
| InboxListItemTapped | Tell the Localytics SDK that an Inbox campaign was tapped in the list view.  |
| InboxCampaignsUnreadCount | count of unread inbox messages |
| SetLocationMonitoringEnabled | Enable or disable location monitoring for geofence monitoring | 
| PushTokenInfo | return a string version of Push Token on all platforms.| 

### Dictionaries

#### Customer Properties Dictionary
Upgrade to using Customer class from the LocalyticsXamarin.Shared to get full C# type support. 
Passing in Customer Properties as a IDictionary is available for backward compatibility. 

| Dictionary Key Name    | Value Description  |
|------------------------|-------|
| customerId | Customer Id |
| firstName  | First Name of the customer |
| lastName   | Last Name of the customer  |
| fullName   | Full Name of the customer  |
| emailAddress | Email Address of the customer |

This Dictionary can be passed to TagCustomerLoggedIn and TagCustomerRegistered API.

### Events

Events are available as static events in the LocalyticsSDK class in the Localytics.Shared namespace.

Event Args for events common to both android and ios share an interface and can be implemented in a Shared PCL project.

| Event Name                    | Args | Description  |
|------------------------|---|---|
| LocalyticsDidTagEvent | LocalyticsDidTagEventEventArgs | fired when an analytics event is tagged |
| LocalyticsSessionWillClose | None | When Session is closed. |
| LocalyticsSessionDidOpen | LocalyticsSessionDidOpenEventArgs | when Session is opened. |
| LocalyticsSessionWillOpen | LocalyticsSessionWillOpenEventArgs | when session will be opened |
| LocalyticsDidTriggerRegions | LocalyticsDidTriggerRegionsEventArgs | when a Geo fence is triggered for a region |
| LocalyticsDidUpdateLocation | LocalyticsDidUpdateLocationEventArgs | when a new location update is received. |
| LocalyticsDidUpdateMonitoredGeofences | LocalyticsDidUpdateMonitoredGeofencesEventArgs | when geofences that are being monitored are changed due to change in campaign or a significant location change |
| InAppDidDisplayEvent | InAppDidDisplayEventArgs | when an In-App is displayed |
| InAppWillDismissEvent | InAppWillDismissEventArgs | when an In-App will be dismissed |
| InAppDidDismissEvent | InAppDidDismissEventArgs | when an In-App is Ddsmissed |

#### IOS Specific Events

| Event Name                    | Args | Description  |
|------------------------|---|---|
| RequestAlwaysAuthorization | CLLocationManager | Action that is invoked when a request for Always Authorization for Location is necessary. |
| RequestWhenInUseAuthorization | CLLocationManager | Action that is invoked when a request for When In Use Authorization for Location is necessary. |


#### Event Args
##### LocalyticsDidTagEventEventArgs
	EventName - string identifying the type of the event.
	Attributes - a dictionary identifying the attributes attached to the event
	CustomerValue - a nullable double that identifies any provided customer value when tagging the event

##### LocalyticsSessionDidOpenEventArgs
	isFirst - bool identifying if this is the first session
	isUpgrade - bool identifying if this session open is following an upgrade
	isResume - bool identifying if this is a session that's being resumed.
	
##### LocalyticsSessionWillOpenEventArgs
   Provides same as properties as LocalyticsSessionDidOpenEventArgs

##### LocalyticsDidTriggerRegionsEventArgs
	Regions providing an array of regions and is of type LLRegion[].
	RegionEvent of type LLRegionEvent identifying the trigger event type 'Enter' or 'Exit'.
	
##### LocalyticsDidUpdateLocationEventArgs
	iOS 
		Location - CLLocation type which reports the current location.
		
##### LocalyticsDidUpdateMonitoredGeofencesEventArgs
   AddedRegions and RemovedRegions are additional properites. They are both of type LLRegion[].
   AddedRegions provides the array of new regions added.
   RemovedRegions provides an array of regions that were removed from monitoring.
   
##### InAppDidDisplayEventArgs, InAppWillDismissEventArgs, InAppDidDismissEventArgs
  These dont define any additional properties other than those in EventArgs and are placeholders for future to minimize signature changes.
  
##### DidOptOutEventArgs
  The properties are 
  	* Current OptOut status (bool)
  	* Campaign

### Delegates

| Delegate Name | Args | Return | Description  |
|---------------|------|--------|--------------|
| InAppDelaySessionStartMessagesDelegate | None | bool | Delay display of Session Start InApps to allow for launch screen and other page transitions including login to complete |
| InAppShouldShowDelegate | InAppCamaign | bool | Determines if an InApp Should be displayed. Default is true, when a delegate is not specified |
| ShouldDeepLinkDelegate | string (absolute url) | bool | Used to determine if the absolute url specified as a string should be displayed by Localytics SDK |
| InAppWillDisplayDelegate | InAppCampaign, InAppConfiguration | InAppConfiguration | Modified InAppConfiguration that is to be used to display the InApp specified by InAppCampaign. |
| PlacesShouldDisplayCampaignDelegate | PlacesCampaign | bool | Determines if a Places Campaign Should be Displayed |
| LocalyticsShouldDeeplink | deeplink (url string), Campaign| bool | Determines if Localytics should deeplink. When false, Application handles any necessary deep link url. |
| LocalyticsShouldPromptForLocationPermissions | Campaign | bool | Determines if there should be a delegate/event to request Permissions for Location, Notifications etc... |
| LocalyticsShouldDeeplinkToSettings | Intent, Campaign | bool | Determines if the Localytics SDK should deeplink to system settings |

### Android Versions

| Type  |  Version    |
|-------|-------------|
| Minimum Android Version | API Level 17 |
| Target Android Version  | API Level 28 |
| Target Framework        | Android 9.0 |

### IOS Versions
* Minimum Deployment Target is IOS 8.0
* CoreLocation - Required for Location Services; Requires implementing the request for Location Permissions in the App


### Known Issues
* LoggingEnabled may not return the current status of the Logger.

### Change Log
* 5.4.0 - Based on Native SDK 5.4.0 for Android and iOS. 
	* Location Services (including Foreground Places support) requires App to request permissions.
	* AddProfileAttribute supports Arrays or params list.
	* Fixed Assembly version for the Common Module to match the release version.
	* Plugin Version now reads Xamarin_<version>
* 5.2.0 - Source only release in github repo. Support for Native SDK 5.2
* 5.1.2 - Native SDK 5.1

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
Anywhere in your application, you can use the Localytics API by calling the class methods/accessors of `Localytics` or `LocalyticsSDK`. Here's a sample of some of the calls.

```
    LocalyticsSDK localytics = LocalyticsSDK.SharedInstance;
    localytics.SetOption("ll_session_timeout_seconds", 10);
    localytics.CustomerId = "Sample Customer";

    localytics.SetProfileAttribute("Sample Attribute", LocalyticsXamarin.Common.XFLLProfileScope.Application,  83);
    localytics.AddProfileAttribute("Sample Set", LocalyticsXamarin.Common.XFLLProfileScope.Organization, new long[] { 321, 654 });

    localytics.TagEvent("Test Event");
    localytics.TagScreen("Test Screen");

    localytics.Upload();
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
3. Receiving Notification in the forground
  when the application is in the foreground, DidReceiveRemoteNotification override in the Application is invoked when a notification is received.
  ```
  NSDictionary apsDict = userInfo.ObjectForKey(new NSString("aps")) as NSDictionary;
  // apsDict[new NSString("alert")]  returns the message.
  // Present the notification using a UIAlert.
  ``` 
  WillFinishLaunching or FinishedLaunching override provide the dictionary when the notification was received in the background.
  
## Xamarin.Android
---
In order to use the Xamarin.Android API in a source file, you will need to add the namespace `LocalyticsXamarin.Android` and `LocalyticsXamarin.Shared`. Before calling anything else on the Localytics API, you will need:

1. call one of the Integrate methods `Integrate` or `AutoIntegrate` within your custom `Application` class
  
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

          // Auto Integrate Localytics
          Localytics.AutoIntegrate (this);

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

   Manifest merging is not supported with Xamarin. 
   Therefore, all AndroidManifest.xml entries need to be made manually. 
   Follow instructions for [manual integration](https://docs.localytics.com/dev/android.html#manual-integration-android)

3.  Configure required parameters using localytics.xml or through setting options
	* Add a localytics.xml in Resources/values. For a sample refer [here](LocalyticsXamarin/Android/Resources/values/localytics.xml)
        

### Usage
---
Anywhere in your application, you can use the Localytics API by calling the class methods/accessors of `Localytics` or instance methods of `LocalyticsSDK`. Here's a sample of some of the calls.

```
            LocalyticsSDK localytics = LocalyticsSDK.SharedInstance;
            Localytics.SessionTimeoutInterval = 10;
            localytics.CustomerId = "Sample Customer";

            localytics.SetProfileAttribute("Sample Attribute", LocalyticsXamarin.Common.XFLLProfileScope.Application,  83);
            localytics.AddProfileAttributesToSet("Sample Set", LocalyticsXamarin.Common.XFLLProfileScope.Organization, new long[] { 321, 654 });

            localytics.TagEvent("Test Event");
            localytics.TagScreen("Test Screen");

            localytics.Upload();
```

The above only demonstrate the syntax of calling the Xamarin.Android API.  For more information about how to use Localytics, please refer to [Android Localytics Docs](http://docs.localytics.com/dev/android.html).


### Push & In-App Messaging
---

1. Play Services Availability
  Check for Play Services Availability as described in [FCM Notifications Walkthrough](https://docs.microsoft.com/en-us/xamarin/android/data-cloud/google-messaging/remote-notifications-with-fcm)
  
2. Push implementation
 Either the [Xamarin instructions](https://docs.microsoft.com/en-us/xamarin/android/data-cloud/google-messaging/) or the Localytics Native SDK [Push Integration] (https://docs.localytics.com/dev/android.html#push-messaging-android) can be used to integrate push.
 
3. Android Manifest changes
  Xamarin has limited support for manifest merging. The changes are best done directly in AndoidManifest.xml
  
4. Sample 
The LocalyticsMessagingSample.Android sample project outlines one way to integrate push.
