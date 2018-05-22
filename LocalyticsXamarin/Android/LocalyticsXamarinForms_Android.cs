using System;
using System.Collections;
using System.Collections.Generic;

using Java.Util;
using LocalyticsXamarin.Android;
using LocalyticsXamarin.Common;
using XNLocalytics.Shared;

[assembly: Xamarin.Forms.Dependency(typeof(LocalyticsXamarin.Forms.LocalyticsXamarinForms_Android))]
namespace LocalyticsXamarin.Forms
{
	public class LocalyticsXamarinForms_Android : LocalyticsPlatform, ILocalytics
	{
		public void SetProfileAttribute (object value, string attribute, XFLLProfileScope scope)
		{
			if (value is long || value is int) {
				Localytics.SetProfileAttribute (attribute, Convert.ToInt64(value), Utils.ToLLProfileScope(scope));
			} else if (value is DateTime) {
				Localytics.SetProfileAttribute (attribute, ToJavaDate (value), Utils.ToLLProfileScope(scope));
			} else {
				Localytics.SetProfileAttribute (attribute, value.ToString(), Utils.ToLLProfileScope(scope));
			}
		}
  
        // Provided for backward compatibility
		public void AddProfileAttributesToSet (object[] values, string attribute, XFLLProfileScope scope)
		{
			if (values == null)
            {
                return;
            }
            object firstValue = values[0];
            if (firstValue is Java.Util.Date)
            {
                Localytics.AddProfileAttributesToSet(attribute, ToJavaDateArray(values), Utils.ToLLProfileScope(scope));
            }
            else if (firstValue is string || firstValue is Java.Lang.String)
            {
                Localytics.AddProfileAttributesToSet(attribute, ToStringArray(values), Utils.ToLLProfileScope(scope));
            }
            else if (firstValue is DateTime || firstValue is Date)
            {
                Localytics.AddProfileAttributesToSet(attribute, ToJavaDateArray(values), Utils.ToLLProfileScope(scope));
            }
            else
            {
                throw new InvalidCastException();
            }
		}

		public void AddProfileAttributes(string attribute, XFLLProfileScope scope, params object[] values)
        {
			AddProfileAttributesToSet(values, attribute, scope);
        }

        public void AddProfileAttributes(string attribute, XFLLProfileScope scope, params string[] values)
        {
			Localytics.AddProfileAttributesToSet(attribute, values, Utils.ToLLProfileScope(scope));
       }

        public void AddProfileAttributes(string attribute, XFLLProfileScope scope, params long[] values)
        {
			Localytics.AddProfileAttributesToSet(attribute, values, Utils.ToLLProfileScope(scope));
        }

  		public void RemoveProfileAttributesFromSet (object[] values, string attribute, XFLLProfileScope scope)
		{
			if (values == null)
            {
                return;
            }
            object firstValue = values[0];
            if (firstValue is Java.Util.Date)
            {
				Localytics.RemoveProfileAttributesFromSet(attribute, ToJavaDateArray(values), Utils.ToLLProfileScope(scope));
            }
            else if (firstValue is string || firstValue is Java.Lang.String)
            {
				Localytics.RemoveProfileAttributesFromSet(attribute, ToStringArray(values), Utils.ToLLProfileScope(scope));
            }
            else if (firstValue is DateTime || firstValue is Date)
            {
				Localytics.RemoveProfileAttributesFromSet(attribute, ToJavaDateArray(values), Utils.ToLLProfileScope(scope));
            }
            else
            {
                throw new InvalidCastException();
            }
		}

		public void RemoveProfileAttributes(string attribute, XFLLProfileScope scope, params object[] values)
        {
			RemoveProfileAttributesFromSet(values, attribute, scope);
        }      

		public void IncrementProfileAttribute (int value, string attribute, XFLLProfileScope scope)
		{
			Localytics.IncrementProfileAttribute (attribute, (long)(value), Utils.ToLLProfileScope(scope));
		}

		public void DecrementProfileAttribute (int value, string attribute, XFLLProfileScope scope)
		{
			Localytics.DecrementProfileAttribute (attribute, (long)(value), Utils.ToLLProfileScope(scope));
		}

		public void DeleteProfileAttribute (string attribute, XFLLProfileScope scope)
		{
			Localytics.DeleteProfileAttribute (attribute, Utils.ToLLProfileScope(scope));
		}

		public string PushRegistrationId {
			get {
				return Localytics.PushRegistrationId;
			}
			set {
				Localytics.PushRegistrationId = value;
			}
		}

		public XFLLInAppMessageDismissButtonLocation InAppMessageDismissButtonLocation {
			get {
				return Utils.ToXFLLInAppMessageDismissButtonLocation(Localytics.GetInAppMessageDismissButtonLocation());
			}
			set {
				Localytics.SetInAppMessageDismissButtonLocation(Utils.ToLLInAppMessageDismissButtonLocation(value));
			}
		}

		private Date ToJavaDate(object source)
		{
			if (source is DateTime)
			{
				DateTime sourceDateTime = (DateTime)(source);

				TimeSpan t = sourceDateTime - new DateTime(1970, 1, 1);
				double epochMilliseconds = t.TotalMilliseconds;
				return new Date(Convert.ToInt64(epochMilliseconds));
			}
			else if (source is Date)
			{
				return (Date)source;
			}
			else
			{
				return null;
			}
		}

		private long[] ToLongArray(object[] source)
		{
			return Array.ConvertAll<object, long>(source, Convert.ToInt64);
		}

		private Date[] ToJavaDateArray(object[] source)
		{
			return Array.ConvertAll<object, Date>(source, ToJavaDate);
		}

		private string[] ToStringArray(object[] source)
		{
			return Array.ConvertAll<object, string>(source, x => x.ToString());
		}

		//public void RedirectLoggingToDisk(object context)
		//{
		//    Localytics.RedirectLogsToDisk(true, context);
		//}
	}
}

