using System;
using ObjCRuntime;

namespace LocalyticsXamarin.iOS.Enums
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

    [Native]
    public enum LLInAppMessageType : long
    {
        Top,
        Bottom,
        Center,
        Full
    }

    [Native]
    public enum LLImpressionType : long
    {
        Click,
        Dismiss
    }

    [Native]
    public enum CampaignType : long
    {
        InApp,
        Push,
        Inbox,
        Places
    }
}

