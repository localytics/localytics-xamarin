using System;
using System.Collections.Generic;
using System.Diagnostics;
using Java.Util;
using NativeInboxCampaign = LocalyticsXamarin.Android.InboxCampaign;
using NativeInAppCampaign = LocalyticsXamarin.Android.InAppCampaign;
using NativePlacesCampaign = LocalyticsXamarin.Android.PlacesCampaign;
using NativeInAppMessageDismissButtonLocation = LocalyticsXamarin.Android.Localytics.InAppMessageDismissButtonLocation;
using NativeBaseCampaign = LocalyticsXamarin.Android.Campaign;

using LocalyticsXamarin.Common;
using LocalyticsXamarin.Shared;

namespace LocalyticsXamarin.Android
{
	public static class Convertor
    {
		public static IDictionary<string, object> ToDictionary(Customer customer)
        {
            return new Dictionary<string, object>()
            {
                { "_nativeHandle", customer },
                { "customerId", customer.CustomerId},
                { "firstName", customer.FirstName},
                { "lastName", customer.LastName},
                { "fullName", customer.FullName},
                { "emailAddress", customer.EmailAddress}
            };
        }
        
		public static void toBuilder(this Customer customer, Customer.Builder builder)
        {
			
			builder.SetCustomerId(customer.CustomerId);
			builder.SetEmailAddress(customer.EmailAddress);
			builder.SetFirstName(customer.FirstName);
			builder.SetFullName(customer.FullName);
			builder.SetLastName(customer.LastName);
        }

		public static Customer toCustomer(IDictionary<string, object> customerProps)
        {
			Customer.Builder builder = new Customer.Builder();
			if (customerProps.ContainsKey("_nativeHandle"))
            {
                toBuilder((Customer)customerProps[@"_nativeHandle"], builder);
            }
			if (customerProps.ContainsKey(@"customerId")) 
			{
				builder.SetCustomerId((string)customerProps[@"customerId"]);
			}
            if (customerProps.ContainsKey(@"firstName"))
            {
				builder.SetFirstName((string)customerProps[@"firstName"]);
            }
            if (customerProps.ContainsKey(@"lastName"))
            {
				builder.SetLastName((string)customerProps[@"lastName"]);
            }
            if (customerProps.ContainsKey(@"fullName"))
            {
				builder.SetFullName((string)customerProps[@"fullName"]);
            }
            if (customerProps.ContainsKey(@"emailAddress"))
            {
				builder.SetEmailAddress((string)customerProps[@"emailAddress"]);
            }
			return builder.Build();
        }

		public static IDictionary<string, Java.Lang.Object> ToGenericDictionary(IDictionary<string, object> source) {
			if (source == null)
			{
				return new Dictionary<string, Java.Lang.Object>();
			}
			IDictionary<string, Java.Lang.Object> result = new Dictionary<string, Java.Lang.Object>();
			foreach (string key in source.Keys)
            {
				// TODO - improve see IOS for sample 5.x+
				if (source[key] is Java.Lang.Object) {
					result.Add(key, (Java.Lang.Object)(source[key]));
				} else if (source[key] is string){
					result.Add(key, (Java.Lang.String)(source[key]));
				} else if (source[key] is int) {
					result.Add(key, new Java.Lang.Long((int)(source[key])));
				}
                else if ( source[key] is long)
                {
					result.Add(key, new Java.Lang.Long((long)(source[key])));
				} else {
					Debug.WriteLine("Unknown Object Type " + source[key].GetType());
 					throw new ArgumentException("Invalid Type converting to Object " + source[key].GetType());
				}
            }
           
			return result;
		}

		public static Date ToJavaDate(object source)
        {
            if (source is DateTime)
            {
                DateTime sourceDateTime = (DateTime)(source);

                TimeSpan t = sourceDateTime - new DateTime(1970, 1, 1);
                double epochMilliseconds = t.TotalMilliseconds;
                return new Date(Convert.ToInt64(epochMilliseconds));
            }
            else
            {
                return null;
            }
        }
        
		public static long[] ToLongArray(object[] source)
        {
            return Array.ConvertAll<object, long>(source, Convert.ToInt64);
        }

		public static Date[] ToJavaDateArray(object[] source)
        {
            return Array.ConvertAll<object, Date>(source, ToJavaDate);
        }

		public static string[] ToStringArray(object[] source)
        {
            return Array.ConvertAll<object, string>(source, x => x.ToString());
        }
        public static IInboxCampaign[] From(IList<NativeInboxCampaign> inboxCampaigns)
        {
            IInboxCampaign[] campaigns = new XFInboxCampaign[inboxCampaigns.Count];
            int i = 0;
            foreach (var item in inboxCampaigns)
            {
                campaigns[i] = new XFInboxCampaign(item);
                i += 1;
            }
            return campaigns;
        }
        public static ICampaignBase CampaignFrom(NativeBaseCampaign campaign)
        {
            if (campaign is LocalyticsXamarin.Android.InboxCampaign)
            {
                return new XFInboxCampaign((LocalyticsXamarin.Android.InboxCampaign)campaign);
            }
            else if (campaign is LocalyticsXamarin.Android.InAppCampaign)
            {
                return new XFInAppCampaign((LocalyticsXamarin.Android.InAppCampaign)campaign);
            }
            else if (campaign is LocalyticsXamarin.Android.PlacesCampaign)
            {
                return new XFPlacesCampaign((LocalyticsXamarin.Android.PlacesCampaign)campaign);
            }
            else if (campaign is LocalyticsXamarin.Android.PushCampaign)
            {
                return new XFPushCampaign((LocalyticsXamarin.Android.PushCampaign)campaign);
            }
            else
            {
                return null;
            }
        }
    }
}
