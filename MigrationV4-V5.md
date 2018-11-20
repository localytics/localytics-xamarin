# Migrating from SDK v4 to SDK v5
---

## Android
SDK 5.0 and above require a minimum SDK version of at least 19. (SDK 5.2 reduces this requirement to OS version 17)

### Download the Localytics.xml file
You can download a sample `localytics.xml` file [here](https://docs.localytics.com/files/localytics.xml).

This file should be inserted into the `res/values` directory of your Android project. Open the `localytics.xml` and configure any values that you prefer to use. Some important ones to consider:
- `ll_app_key` Specify the app key for your project
- `ll_wifi_upload_interval_seconds` Configure the interval at which the Localytics SDK will attempt to upload data in the case of a WiFi connection. Having a WiFi connection will supersede any mobile data connection. Default value is 5 seconds.
- `ll_great_network_upload_interval_seconds` Configure the interval at which the Localytics SDK will attempt to upload data in the case of 4G or LTE connections. Default value is 10 seconds.
- `ll_decent_network_upload_interval_seconds` Configure the interval at which the Localytics SDK will attempt to upload data in the case of a 3G connection. Default value is 30 seconds.
- `ll_bad_network_upload_interval_seconds` Configure the interval at which the Localytics SDK will attempt to upload data in the case of 2G or EDGE connections. Default value is 90 seconds.

For a full list of keys available in the `localytics.xml` please consult the [Android documentation](https://docs.localytics.com/dev/android.html#localytics-xml-keys)

**Note:** The main purpose of the `localytics.xml` file is to use manifest merging to make integration easier.  However, because Xamarin doesn't rely on the same build processes as native Android, manifest merging does not work with Xamarin. As a result a if you see any mention of manifest merging in the main documentation, please opt for the alternative suggestion (often described as manual installation) that does not use it. However, even without manifest merging the `localytics.xml` file can still be useful for specifying many configuration values such as the app key as described above.

### Push Messaging
##### Notification Channels Updates
SDK v5 has built in support for setting default Notification Channels. If you were previously setting options for a default notification channel with `LocalyticsXamarin.Android.Localytics.setDefaultNotificationChannel(...)`, this method is removed and the new way to set one is through the use of the key `ll_default_push_channel_id` and its counterparts available in the `localytics.xml`.

##### Firebase Cloud Messaging Updates
- If you were calling `LocalyticsXamarin.Android.Localytics.registerPush(YOUR_SENDER_ID)`, the method has been updated to remove the Sender ID argument.

- If you are using Localytics to send all your push notifications and have not customized the Firebase Service classes, you can continue to use your existing receivers, or if you prefer, you can use the Localytics `FirebaseService` by adding the following to your `AndroidManifest.xml`:
```xml
<service android:name="com.localytics.android.FirebaseTokenService"
    android:exported="true"
    android:enabled="true">
  <intent-filter>
    <action android:name="com.google.firebase.INSTANCE_ID_EVENT"/>
  </intent-filter>
</service>

<service android:name="com.localytics.android.FirebaseService"
    android:exported="true"
    android:enabled="true">
  <intent-filter>
    <action android:name="com.google.firebase.MESSAGING_EVENT"/>
  </intent-filter>
</service>
```

- If you are using another push provider, and you have customized the Firebase Service classes to handle pushes sent by them, feel free to continue to use the same receivers.

##### Google Cloud Messaging Updates
- If you were calling `LocalyticsXamarin.Android.Localytics.registerPush(YOUR_SENDER_ID)`, the method has been updated to remove the Sender ID argument, and that ID now belongs in `localytics.xml` as the value for `ll_gcm_sender_id`.

- For integrations that use or override the **Localytics** `GcmListenerService` or `InstanceIDListenerService` you should instead use or override `com.localytics.android.GcmReceiver`. Since this is a `BroadcastReceiver`, you should override the method `onReceive(...)` instead of `onMessageReceived(...)`.

- For integrations that override the **original GCM-provided** `GcmListenerService` or `InstanceIDListenerService`, feel free to continue using your own services.

### Places Messaging
For customers who are using Places and had the `GeofenceTransitionService` in their `AndroidManifest.xml`, please replace this service with the `LocationUpdateReceiver`
as follows: 
```xml
<receiver android:name="com.localytics.android.LocationUpdateReceiver">
```
### API Changes
```
LocalyticsXamarin.Android.Localytics.RegisterPush(senderId); -> LocalyticsXamarin.Android.Localytics.RegisterPush();
LocalyticsXamarin.Android.Localytics.HandlePushNotificationReceived(data); -> LocalyticsXamarin.Android.TagPushReceivedEvent(data);
LocalyticsXamarin.Android.Localytics.SetInboxCampaignRead(campaignId, read); -> LocalyticsXamarin.Android.Localytics.SetInboxCampaignRead(campaign, read);
LocalyticsXamarin.Android.Localytics.TriggerRegion(region, event); -> LocalyticsXamarin.Android.Localytics.TriggerRegion(region, event, location);
LocalyticsXamarin.Android.Localytics.TriggerRegions(regions, event); -> LocalyticsXamarin.Android.Localytics.TriggerRegions(regions, event, location);
LocalyticsXamarin.Android.Localytics.SetMessagingListener(new IMessagingListener() { ... }); -> LocalyticsXamarin.Android.Localytics.SetMessagingListener(new IMessagingListenerV2() { ... });
```

## iOS
### Data Flushing
SDK v5 updates the SDK to use data flushing to ensure the timely uploading of data.  As a result calls to `upload` are no longer required to ensure data reaches the Localytics backend.  Instead, simply specify the intervals with which Localytics can automatically upload data under certain conditions in your call to integrate: 
```
LocalyticsXamarin.iOS.Localytics.AutoIntegrate ("YOUR_APP_KEY",  { 
                'll_wifi_upload_interval_seconds': '5', 
                'll_great_network_upload_interval_seconds', '10' 
                'll_decent_network_upload_interval_seconds', '30'
                'll_bad_network_upload_interval_seconds', '90'
            }, launchOptions != null? launchOptions : new NSDictionary());
```
Passing in `null` for the dictionary or any of the keys will revert to the defaults (listed above). If you would like to suppress data flushing under a specific type of network connectivity, please pass a value of `-1`.

### API Changes
```
LocalyticsXamarin.iOS.Localytics.DidRegisterUserNotificationSettings(notificationSettings); -> LocalyticsXamarin.iOS.Localytics.DidRegisterUserNotificationSettings();
Localytics.SetInboxCampaignRead(campaignId, read); -> Localytics.SetInboxCampaignRead(campaign, read);
Localytics.TriggerRegion(region, event); -> Localytics.TriggerRegion(region, event, location);
Localytics.TriggerRegions(regions, event); -> Localytics.TriggerRegions(regions, event, location);
```