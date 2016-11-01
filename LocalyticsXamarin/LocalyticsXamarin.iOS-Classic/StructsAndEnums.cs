using System;
using ObjCRuntime;

namespace LocalyticsXamarin.iOS
{
	[Native]
	public enum LLInAppMessageDismissButtonLocation : ulong
	{
		Left,
		Right
	}

	[Native]
	public enum LLProfileScope : long
	{
		Application,
		Organization
	}

	[Native]
	public enum LLRegionEvent : long
	{
		Enter,
		Exit
	}
}

