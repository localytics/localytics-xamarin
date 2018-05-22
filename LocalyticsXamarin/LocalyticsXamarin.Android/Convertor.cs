using System;
using System.Collections.Generic;

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
				if (source[key] is Java.Lang.Object) {
					result.Add(key, (Java.Lang.Object)(source[key]));
				} else if (source[key] is string){
					result.Add(key, (Java.Lang.String)(source[key]));
				} else {
					throw new InvalidCastException();
				}
            }
           
			return result;
		}
    }

	//public static LocalyticsXamarin.Android.ImpressionType ImpressionType(string impression)
	//{
	//	if ("click".Equals(impression, StringComparison.InvariantCultureIgnoreCase)) {
	//		return LocalyticsXamarin.Android.ImpressionType.Click;
	//	} else if ("dismiss".Equals(impression, StringComparison.InvariantCultureIgnoreCase)) {
	//		return LocalyticsXamarin.Android.ImpressionType.Dismiss;
	//	}
	//	return null;
	//}
}
