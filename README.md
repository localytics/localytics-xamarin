Localytics Xamarin SDK
---
This repository contains the open source Xamarin SDK  to build the Localytics Xamarin Nuget package (*.nuget).  For instruction on how to use the Nuget package, refer to [Getting Started](GettingStarted.md)

## Contents
* **/Localytics-Android-Latest** contains the latest Android Release that has been bound to the Xamarin SDK.
* **/Localytics-iOS-Latest** contains the latest iOS Release that has been bound to the Xamarin SDK.
* **/LocalyticsXamarin** contains the entire solution for the Xamarin SDK and sample applications


## Building the Nuget Package
This and the following sections are for Developers wishing to contribute to the XamarinSDK.
You will need Xcode, and Xamarin Studio (with Android API 19) and java 8.Simply call make VER=0.0.0 release to build.
Localytics recommends using the prebuilt nuget package for integrating Localytics in a production app. Instructions can be found at LocalyticsXamarin/LocalyticsXamarin.NuGet/GettingStarted.md

**Build**
```
$ cd LocalyticsXamarin
$ make VER=0.0.0 release
```

**Install locally**
```
$ copy the built nuget package to an appropriate folder and dd this folder as a nuget source
```

## Projects in LocalyticsXamarin Solution
The **/LocalyticsXamarin** folder contain a solution that includes projects for the main libraries and sample/test applications.


### LocalyticsXamarin Library Projects


| LocalyticsXamarin SDK     |   |
|---------------------------|---|
| LocalyticsXamarin.iOS     | IOS Xamarin SDK Binding project  |
| LocalyticsXamarin.Android | Android Xamarin SDK Binding project  |
| LocalyticsXamarin.Shared  | Shared Project with code shared between Android and IOS Binding Project  |
| LocalyticsXamarin.Common  | Common Project that allows access of Xamarin SDK from a Shared project using dependency service.  |

   
  These projects deal with bindings to the respective Localytics native SDK.
  * **LocalyticsXamarin.Android** (Xamarin.Android Library Binding)
    
    This project mainly derived from going through possible Transform to fix C# vs Java issues that the tools couldn't dealt with automatically.
  * **LocalyticsXamarin.iOS** for (Xamarin.iOS Unified Library Binding)
    
    This project mainly derived from generating bindings through Objective Sharpie with subsequent tweaks.
  
### LocalyticsSample Xamarin.Forms Projects
  
  
| LocalyticsXamarin SDK Sample |  Sample to verify the Xamarin SDK API |
|------------------------------|---|
| Android    | Android Platform project  |
| iOS        | IOS Platform project      |
| LocalyticsSample | Shared project used by the Android and IOS sample project |
| LocalyticsMessagingSample.Android | Test Sample for Inbox and android messaging listeners. |


  This is the main sample/test UI application. It uses DependencyService to call the respective Xamarin.Android or Xamarin.iOS Localytics Library. `ILocalyticsXamarinForms.cs` and its implementations (i.e. `LocalyticsXamarinForms_Android.cs` and `LocalyticsXamarinForms_iOS.cs`) can be useful in other Xamarin.Forms applications. The implementations also demonstrate how to call most of the API functions and Object Conversions.
  * **LocalyticsSample** contains the Xamarin.Forms UI
  * **LocalyticsSample.iOS** deals with native setup, mostly in `AppDelegate.cs` and `Info.plist`
  * **LocalyticsSample.Android** deals with native setup, mostly in `LocalyticsAutoIntegrateApplication.cs`, `MainActivity.cs` and `AndroidManifest.xml`

### Other Sample and Smoke Test Application
 
  * **LocalyticsMessagingSample.Android** is an Xamarin.Android application used to test Android Push and InApp Messaging. Currently, InApp messaging most likely won't work in Xamarin.Forms, which does not support Fragments. This project requires the `Xamarin.GooglePlayServices.Gcm` Package.
