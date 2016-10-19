using System;
using ObjCRuntime;

[assembly: LinkWith ("libLocalytics.a",
	LinkTarget.Arm64 | LinkTarget.ArmV7 | LinkTarget.ArmV7s| LinkTarget.Simulator, 
	"-lsqlite3 -lz",
	SmartLink = true,
	ForceLoad = true,
	Frameworks="SystemConfiguration AdSupport CoreLocation")]
