using System;
using LocalyticsXamarin.Common;
using System.Diagnostics;
#if __IOS__
using Foundation;
using LocalyticsXamarin.IOS;
#else
using Java.Util;
using LocalyticsXamarin.Android;
#endif
namespace XNLocalytics.Shared
{
    public class LocalyticsPlatform : LocalyticsPlatformCommon
    {
        public void SetProfileAttribute(object value, string attribute, XFLLProfileScope scope = XFLLProfileScope.Application)
        {
#if __IOS__
            Localytics.SetProfileAttribute(NSObject.FromObject(value), attribute, Utils.ToLLProfileScope(scope));
#else
			if (value is long || value is int)
            {
                Localytics.SetProfileAttribute(attribute, Convert.ToInt64(value), Utils.ToLLProfileScope(scope));
            }
            else if (value is DateTime)
            {
                DateTime dateTime = (DateTime)value;
                Localytics.SetProfileAttribute(attribute, new Java.Util.Date(dateTime.Ticks), Utils.ToLLProfileScope(scope));
            }
            else
            {
                Localytics.SetProfileAttribute(attribute, value.ToString(), Utils.ToLLProfileScope(scope));
            }
#endif
        }

        public void RemoveProfileAttributes(string attribute, XFLLProfileScope scope = XFLLProfileScope.Application, params object[] values)
        {
#if __IOS__
            Localytics.RemoveProfileAttributes(attribute, Utils.ToLLProfileScope(scope), values);
#else
			RemoveProfileAttributesFromSet(values, attribute, scope);
#endif
        }

        public void IncrementProfileAttribute(Int64 value, string attribute, XFLLProfileScope scope = XFLLProfileScope.Application)
        {
#if __IOS__
            Localytics.IncrementProfileAttribute((System.nint)value, attribute, Utils.ToLLProfileScope(scope));
#else
			Localytics.IncrementProfileAttribute(attribute, value, Utils.ToLLProfileScope(scope));
#endif
        }

        public void DecrementProfileAttribute(Int64 value, string attribute, XFLLProfileScope scope = XFLLProfileScope.Application)
        {
#if __IOS__
            Localytics.DecrementProfileAttribute((System.nint)value, attribute, Utils.ToLLProfileScope(scope));
#else
			Localytics.DecrementProfileAttribute(attribute, value, Utils.ToLLProfileScope(scope));
#endif
        }

        public void DeleteProfileAttribute(string attribute, XFLLProfileScope scope = XFLLProfileScope.Application)
        {
#if __IOS__
            Localytics.DeleteProfileAttribute(attribute, Utils.ToLLProfileScope(scope));
#else
        Localytics.DeleteProfileAttribute(attribute, Utils.ToLLProfileScope(scope));
#endif
        }

        // object must be Date (Android) or NSDate (iOS)
        public void AddProfileAttributes(string attribute, XFLLProfileScope scope, params object[] values)
        {
#if __IOS__
            Localytics.AddProfileAttributes(attribute, Utils.ToLLProfileScope(scope), values);
#else
				AddProfileAttributesToSet(values, attribute, scope);
#endif
        }

        public void AddProfileAttributes(string attribute, XFLLProfileScope scope, params string[] values)
        {
#if __IOS__
            Localytics.AddProfileAttributes(attribute, Utils.ToLLProfileScope(scope), values);
#else
			Localytics.AddProfileAttributesToSet(attribute, values, Utils.ToLLProfileScope(scope));
#endif
        }

        public void AddProfileAttributes(string attribute, XFLLProfileScope scope, params long[] values)
        {
#if __IOS__
            NSArray ary = Convertor.ToArray(values);
            Localytics.AddProfileAttributes(attribute, Utils.ToLLProfileScope(scope), ary);
#else
			Localytics.AddProfileAttributesToSet(attribute, values, Utils.ToLLProfileScope(scope));
#endif
        }





#if __IOS__
        private void test()
        {
#if __IOS__
#else
#endif
        }

        public XFLLInAppMessageDismissButtonLocation InAppMessageDismissButtonLocation
        {
            get
            {
                return Utils.ToXFLLInAppMessageDismissButtonLocation(Localytics.InAppMessageDismissButtonLocation);
            }
            set
            {
                Localytics.InAppMessageDismissButtonLocation = Utils.ToLLInAppMessageDismissButtonLocation(value);
            }
        }


        public void AddProfileAttributes(string attribute, LLProfileScope scope, params NSDate[] values)
        {
            Localytics.AddProfileAttributes(attribute, scope, values);
        }

        public void TagImpressionForPushToInboxCampaign(LLInboxCampaign campaign, bool success)
        {
            Localytics.TagImpressionForPushToInboxCampaign(campaign, success);
        }

        public LLInboxDetailViewController InboxDetailViewControllerForCampaign(LLInboxCampaign campaign)
        {
            return Localytics.InboxDetailViewControllerForCampaign(campaign);
        }

        public void AddDateProfileAttributes(string attribute, LLProfileScope scope, params object[] values)
        {
            Localytics.AddProfileAttributes(attribute, scope, values);
        }

#else
		public XFLLInAppMessageDismissButtonLocation InAppMessageDismissButtonLocation
        {
            get
            {
                return Utils.ToXFLLInAppMessageDismissButtonLocation(Localytics.GetInAppMessageDismissButtonLocation());
            }
            set
            {
                Localytics.SetInAppMessageDismissButtonLocation(Utils.ToLLInAppMessageDismissButtonLocation(value));
            }
        }

        // Provided for backward compatibility
        public void AddProfileAttributesToSet(object[] values, string attribute, XFLLProfileScope scope)
        {
            if (values == null)
            {
                return;
            }
            object firstValue = values[0];
            if (firstValue is Java.Util.Date)
            {
                Localytics.AddProfileAttributesToSet(attribute, Convertor.ToJavaDateArray(values), Utils.ToLLProfileScope(scope));
            }
            else if (firstValue is string || firstValue is Java.Lang.String)
            {
                Localytics.AddProfileAttributesToSet(attribute, Convertor.ToStringArray(values), Utils.ToLLProfileScope(scope));
            }
            else if (firstValue is DateTime || firstValue is Date)
            {
                Localytics.AddProfileAttributesToSet(attribute, Convertor.ToJavaDateArray(values), Utils.ToLLProfileScope(scope));
            }
            else
            {
                Debug.WriteLine("Unknown Object Type " + firstValue.GetType());
                throw new ArgumentException("Unknown Array Object Type " + firstValue.GetType());
            }
        }

        public void RemoveProfileAttributesFromSet(object[] values, string attribute, XFLLProfileScope scope)
        {
            if (values == null)
            {
                return;
            }
            object firstValue = values[0];
            if (firstValue is Java.Util.Date)
            {
                Localytics.RemoveProfileAttributesFromSet(attribute, Convertor.ToJavaDateArray(values), Utils.ToLLProfileScope(scope));
            }
            else if (firstValue is string || firstValue is Java.Lang.String)
            {
                Localytics.RemoveProfileAttributesFromSet(attribute, Convertor.ToStringArray(values), Utils.ToLLProfileScope(scope));
            }
            else if (firstValue is DateTime || firstValue is Date)
            {
                Localytics.RemoveProfileAttributesFromSet(attribute, Convertor.ToJavaDateArray(values), Utils.ToLLProfileScope(scope));
            }
            else if (firstValue is Int16 || firstValue is Int32 || firstValue is Int64)
            {
                Localytics.RemoveProfileAttributesFromSet(attribute, Convertor.ToLongArray(values), Utils.ToLLProfileScope(scope));
            }
            else
            {
                Debug.WriteLine("Invalid Object type " + firstValue.GetType());
                throw new ArgumentException("Invalid Object type " + firstValue.GetType());
            }
        }

        public void IncrementProfileAttribute(int value, string attribute, XFLLProfileScope scope)
        {
            Localytics.IncrementProfileAttribute(attribute, (long)(value), Utils.ToLLProfileScope(scope));
        }

        public void DecrementProfileAttribute(int value, string attribute, XFLLProfileScope scope)
        {
            Localytics.DecrementProfileAttribute(attribute, (long)(value), Utils.ToLLProfileScope(scope));
        }

        public string PushRegistrationId
        {
            get
            {
                return Localytics.PushRegistrationId;
            }
            set
            {
                Localytics.PushRegistrationId = value;
            }
        }
#endif
    }
}
