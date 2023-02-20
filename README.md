Localytics Xamarin SDK
---
This repository contains the open source Xamarin SDK  to build the Localytics Xamarin Nuget package (*.nuget). The Localytics Xamarin SDK is a Xamarin wrapper on the native [Localytics Android SDK](https://github.com/localytics/Android-Client-Library) and [Localytics iOS SDK](https://github.com/localytics/Localytics-iOS). For instruction on how to use the Nuget package, refer to [Getting Started](GettingStarted.md)

## Contents
* **/Localytics-Android-Latest** contains the latest Android Release that has been bound to the Xamarin SDK (v6.3.7).
* **/Localytics-iOS-Latest** contains the latest iOS Release that has been bound to the Xamarin SDK (v6.2.9).
* **/LocalyticsXamarin** contains the entire solution for the Xamarin SDK and sample applications


## Building the Nuget Package
This and the following sections are for Developers wishing to contribute to the XamarinSDK.
You will need Xcode, and Visual Studio (with Android API 33) and java 8.Simply call make VER=0.0.0 release to build.
Localytics recommends using the prebuilt nuget package for integrating Localytics in a production app. Instructions can be found at LocalyticsXamarin/LocalyticsXamarin.NuGet/GettingStarted.md

**Build**
```
$ cd LocalyticsXamarin
$ make VER=0.0.0 release
```

**Install locally**
```
$ copy the built nuget package to an appropriate folder and add this folder as a nuget source
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

   
  These projects deal with bindings to the respective Localytics native SDK. To change code in the binding, the native SDK needs to be changed first then updated in the Xamarin   project.
  * **LocalyticsXamarin.Android** (Xamarin.Android Library Binding)
    
    This project mainly derived from going through possible Transform to fix C# vs Java issues that the tools couldn't dealt with automatically.
  * **LocalyticsXamarin.iOS** for (Xamarin.iOS Unified Library Binding)
    
    This project mainly derived from generating bindings through Objective Sharpie with subsequent tweaks.
  
### LocalyticsSample Xamarin.Forms Projects
  
  
| LocalyticsXamarin SDK Sample |  Sample to verify the Xamarin SDK API |
|------------------------------|---|
| Android    | Android Platform project  |
| iOS        | IOS Platform project      |

  * **LocalyticsSample.iOS** deals with native setup, mostly in `AppDelegate.cs` and `Info.plist`
  * **LocalyticsSample.Android** deals with native setup, mostly in `LocalyticsAutoIntegrateApplication.cs`, `MainActivity.cs` and `AndroidManifest.xml`
