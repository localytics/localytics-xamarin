Localytics Xamarin Component
---
This repository contains the element necessary to build the Localytics Xamarin Component (*.xam*).  For instruction on how to use the Component, refer to /component/GettingStarted.md

##Contents
* **/components** contains metadata and files for packaging .xam (used by `xamarin-component.exe` when you call `rake`)
* **/LocalyticsXamarin** contains the entire solution for the libraries and sample applications
* **/AndroidPatchTest** Android Studio Project that have a module for bridging localytics.jar. It helps generate the c#/JNI bindings for the Listeners.

## Building the Xamarin Component
You will need Xcode, and Xamarin Studio (with Android API 15). Simply call `make` to build the .dll and then `rake` to package the .xam.
```
$ make
...
$ rake
```
Please refer to [Xamarin Component Submission Guide](https://developer.xamarin.com/guides/cross-platform/advanced/submitting_components/component_submission_guide/)
for more details about `xamarin-component` calls within the Rakefile.

## Projects in LocalyticsXamarin Solution
The **/LocalyticsXamarin** folder contain a solution that includes projects for the main libraries and sample/test applications.

1. LocalyticsXamarin Library Projects
   
  These projects deal with bindings to the respective Localytics native SDK.
  * **LocalyticsXamarin.Android** (Xamarin.Android Library Binding)
    
    This project mainly derived from going through possible Transform to fix C# vs Java issues that the tools couldn't dealt with automatically.
  * **LocalyticsXamarin.iOS** for (Xamarin.iOS Unified Library Binding)
    
    This project mainly derived from generating bindings through Objective Sharpie with subsequent tweaks.
  * **LocalyticsXamarin.iOS-Classic** (Xamarin.iOS Classic Library Binding)
    
    This project mainly derived from copying LocalyticsXamarin.iOS and editing namespace.

2. LocalyticsSample Xamarin.Forms Projects
  
  This is the main sample/test UI application. It uses DependencyService to call the respective Xamarin.Android or Xamarin.iOS Localytics Library. `ILocalyticsXamarinForms.cs` and its implementations (i.e. `LocalyticsXamarinForms_Android.cs` and `LocalyticsXamarinForms_iOS.cs`) can be useful in other Xamarin.Forms applications. The implementations also demonstrate how to call most of the API functions and Object Conversions.
  * **LocalyticsSample** contains the Xamarin.Forms UI
  * **LocalyticsSample.iOS** deals with native setup, mostly in `AppDelegate.cs` and `Info.plist`
  * **LocalyticsSample.Android** deals with native setup, mostly in `LocalyticsAutoIntegrateApplication.cs`, `MainActivity.cs` and `AndroidManifest.xml`

3. Other Sample and Smoke Test Application
  * **LocalyticsiOSClassicTest** was used to smoke test the LocalyticsXamarin.iOS-Classic Builds
  * **LocalyticsMessagingSample.Android** is an Xamarin.Android application used to test Android Push and InApp Messaging. Currently, InApp messaging most likely won't work in Xamarin.Forms, which does not support Fragments. This project requires the `Xamarin.GooglePlayServices.Gcm` Package.
