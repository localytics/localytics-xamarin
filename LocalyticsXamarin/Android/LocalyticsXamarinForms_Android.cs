using System;
using System.Collections;
using System.Collections.Generic;

using Java.Util;
using LocalyticsXamarin.Common;
using LocalyticsXamarin.Android;
using XNLocalytics.Shared;
using System.Diagnostics;

[assembly: Xamarin.Forms.Dependency(typeof(LocalyticsXamarin.Forms.LocalyticsXamarinForms_Android))]
namespace LocalyticsXamarin.Forms
{
	public class LocalyticsXamarinForms_Android : LocalyticsPlatform, ILocalytics
	{
		public void IncrementProfileAttribute(Int64 value, string attribute, XFLLProfileScope scope = XFLLProfileScope.Application)
		{
			Localytics.IncrementProfileAttribute(attribute, value, Utils.ToLLProfileScope(scope));
		}

		public void DecrementProfileAttribute(Int64 value, string attribute, XFLLProfileScope scope = XFLLProfileScope.Application)
		{
			Localytics.DecrementProfileAttribute(attribute, value, Utils.ToLLProfileScope(scope));
		}

		public void SetProfileAttribute (object value, string attribute, XFLLProfileScope scope)
		{
			if (value is long || value is int) {
				Localytics.SetProfileAttribute (attribute, Convert.ToInt64(value), Utils.ToLLProfileScope(scope));
			} else if (value is DateTime) {
				DateTime dateTime = (DateTime)value;
				Localytics.SetProfileAttribute (attribute, new Java.Util.Date(dateTime.Ticks), Utils.ToLLProfileScope(scope));
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
	}
}
