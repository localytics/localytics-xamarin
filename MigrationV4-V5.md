# Migrating from SDK v4 to SDK v5
---

## Android
SDK 5.0 and above require a minimum SDK version of at least 19. (SDK 5.2 reduces this requirement to OS version 17)

### Download the Localytics.xml file
Localytics Android SDK 5.0 includes a major upgrade in how the SDK is integrated. There is now a new and easier format for generating your integration files, which takes advantage of [manifest merging](https://developer.android.com/studio/build/manifest-merge.html) in Android.

To use manifest merging, the Localytics SDK now relies on the presence of a `localytics.xml` file in the `res/values` directory of your project. You can download a sample `localytics.xml` file [here](https://docs.localytics.com/files/localytics.xml).  For a full list of keys available in the `localytics.xml` please consult the [Android documentation](https://docs.localytics.com/dev/android.html#localytics-xml-keys)

When you compile your app, a section of the manifest will be modified by the Localytics SDK to include a number of services, receivers, activities, permissions and metadata elements. If you previously had these elements in your SDK then merge conflicts can arise and cause compiler errors. To avoid these merge conflicts you can do the following:
1.  If there is nothing custom about your Localytics integration, you can simply remove all the Localytics specific elements from your `AndroidManifest.xml` except for your test mode scheme and manifest merging should work automatically.
2. If you are using Localytics elements in your manifest, but have modified some of the attributes on an element, consider adding `tools:replace="THE_MODIFIED_ATTRIBUTE"` on the element that is in question. This will ensure that the element you created is what is used in your app (and will ignore the Localytics value).

### Push Messaging
##### Notification Channels Updates
SDK v5 has built in support for setting default Notification Channels. If you were previously setting options for a default notification channel with `LocalyticsXamarin.Android.Localytics.setDefaultNotificationChannel(...)`, this method is removed and the new way to set one is through the use of the key `ll_default_push_channel_id` and its counterparts available in the `localytics.xml`.

##### Firebase Cloud Messaging Updates
- If you were calling `LocalyticsXamarin.Android.Localytics.registerPush(YOUR_SENDER_ID)`, the method has been updated to remove the Sender ID argument.

- If you are using Localytics to send all your push notifications and have not customized the Firebase Service classes, you can remove any receivers in your `AndroidManifest.xml` and set `ll_fcm_push_services_enabled` to `true` in your `localytics.xml`.

- If you are using another push provider and you have customized the Firebase Service classes to handle pushes sent by them, you should set `ll_fcm_push_services_enabled` to `false`.

##### Google Cloud Messaging Updates
- If you were calling `LocalyticsXamarin.Android.Localytics.registerPush(YOUR_SENDER_ID)`, the method has been updated to remove the Sender ID argument, and that ID now belongs in `localytics.xml` as the value for `ll_gcm_sender_id`.

- For integrations that use or override the **Localytics** `GcmListenerService` or `InstanceIDListenerService` you should instead use or override `com.localytics.android.GcmReceiver`. Since this is a `BroadcastReceiver`, you should override the method `onReceive(...)` instead of `onMessageReceived(...)`.

- For integrations that override the **original GCM-provided** `GcmListenerService` or `InstanceIDListenerService`, you should be able to continue using your own services.

### Places Messaging
For customers who are using Places and had the `GeofenceTransitionService` or `BackgroundService` in their `AndroidManifest.xml`, these can now be removed. Also, please set `ll_places_enabled` to `true` in your `localytics.xml`,
and Localytics will insert `BootReceiver` and `LocationUpdateReceiver` into the final app manifest.

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