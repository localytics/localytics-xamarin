using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Foundation;

using NativeInboxCampaign = LocalyticsXamarin.IOS.LLInboxCampaign;
using NativeInAppCampaign = LocalyticsXamarin.IOS.LLInAppCampaign;
using NativePlacesCampaign = LocalyticsXamarin.IOS.LLPlacesCampaign;
using NativeInAppMessageDismissButtonLocation = LocalyticsXamarin.IOS.LLInAppMessageDismissButtonLocation;
using NativeBaseCampaign = LocalyticsXamarin.IOS.LLCampaignBase;

using LocalyticsXamarin.Common;
using LocalyticsXamarin.Shared;

namespace LocalyticsXamarin.IOS
{
	public static class Convertor
	{
		static Dictionary<Type, Func<object, NSObject>> _Strategies;
		static Convertor()
		{
			// Prepare all available strategies.
			_Strategies = new Dictionary<Type, Func<object, NSObject>>();

			_Strategies.Add(typeof(NSObject), (o) => { return (NSObject)o; });
			_Strategies.Add(typeof(NSString), (o) => { return (NSString)o; });
			_Strategies.Add(typeof(NSNumber), (o) => { return (NSNumber)o; });
            _Strategies.Add(typeof(NSDate), (o) => { return (NSDate)o; });
            _Strategies.Add(typeof(string), (o) => { return new NSString((string)o); });
			_Strategies.Add(typeof(float), (o) => { return new NSNumber((float)o); });
			_Strategies.Add(typeof(double), (o) => { return new NSNumber((double)o); });
			//_Strategies.Add(typeof(long), (o) => { return new NSNumber((long)o); });
			_Strategies.Add(typeof(UInt16), (o) => { return new NSNumber((UInt16)o); });
			_Strategies.Add(typeof(UInt32), (o) => { return new NSNumber((UInt32)o); });
			_Strategies.Add(typeof(UInt64), (o) => { return new NSNumber((UInt64)o); });
			_Strategies.Add(typeof(Int16), (o) => { return new NSNumber((Int16)o); });
			_Strategies.Add(typeof(Int32), (o) => { return new NSNumber((Int32)o); });
			_Strategies.Add(typeof(Int64), (o) => { return new NSNumber((Int64)o); });
			_Strategies.Add(typeof(byte), (o) => { return new NSNumber((byte)o); });
        }

		public static NSObject[] ToNSObjects(object[] objects)
		{
			if (objects == null)
			{
				return null;
			}
			var result = new List<NSObject>();
			foreach (object i in objects)
			{
				result.Add(NSObject.FromObject(i));
			}

			return result.ToArray();
		}

		public static NSDictionary ToNSDictionary(this IDictionary<string, string> source)
		{
			if (source == null)
			{
				return null;
			}
			Debug.WriteLine("Calling s:s to Dictionary");
			var result = new NSMutableDictionary();

			if (source != null)
			{
				foreach (string key in source.Keys)
				{
					result.Add((NSString)(key), (NSString)(source[key]));
				}
			}

			return result;
		}

		public static NSDictionary ToNSDictionary(this IDictionary<string, object> source)
		{
			if (source == null)
			{
				return null;
			}
			Debug.WriteLine("Calling s:o to Dictionary");
			var result = new NSMutableDictionary();

			if (source != null)
			{
				foreach (string key in source.Keys)
				{
					object o = source[key];
					if (!_Strategies.TryGetValue(o.GetType(), out Func<object, NSObject> action))
					{
						Debug.WriteLine("Unknown Object Type " + o.GetType());
						throw new ArgumentException("Unknown object of type " + o.GetType());
					}
					result.Add((NSString)(key), action(o));
				}
			}

			return result;
		}

		public static NSDictionary ToNSDictionary(this IDictionary dictionary)
		{
			var result = new NSMutableDictionary();
			foreach (string key in dictionary.Keys)
			{
				result.Add(new NSString(key), new NSString(dictionary[key].ToString()));
			}
			return result;
		}

		public static NSArray ToArray(long[] values)
		{
			var list = new NSMutableArray();
			foreach (object o in values)
			{
				// Check if we have a matching strategy.
				if (!_Strategies.TryGetValue(o.GetType(), out Func<object, NSObject> action))
				{
					Debug.WriteLine("Unknown Object Type " + o.GetType());
					throw new ArgumentException("Unknown object of type " + o.GetType());
				}
				list.Add(action(o));
			}
			return list;
		}

		public static NSArray ToArray(Array array)
		{
			var list = new NSMutableArray();
			for (int j = 0; j < array.Length; j++)
			{
				object o = array.GetValue(j);
				if (o is NSMutableArray)
				{
					var ary = (NSMutableArray)o;
					nuint i;
					nuint max = ary.Count;
					for (i = 0; i < max; i++)
					{
						list.Add(ary.GetItem<NSObject>(i));
					}
				}
				// Check if we have a matching strategy.
				else
				{
					if (!_Strategies.TryGetValue(o.GetType(), out Func<object, NSObject> action))
					{
						Debug.WriteLine("Unknown Object Type " + o.GetType());
						throw new ArgumentException("Unknown object of type " + o.GetType());
					}
					list.Add(action(o));
				}
			}
			return list;
		}

		public static NSArray ToArray(object[] values)
		{
			var list = new NSMutableArray();
			foreach (object o in values)
			{
				if (o is NSMutableArray)
				{
					var ary = (NSMutableArray)o;
					nuint i;
					nuint max = ary.Count;
					for (i = 0; i < max; i++)
					{
						list.Add(ary.GetItem<NSObject>(i));
					}
				}
				// Check if we have a matching strategy.
				else
				{
					if (!_Strategies.TryGetValue(o.GetType(), out Func<object, NSObject> action))
					{
						Debug.WriteLine("Unknown Object Type " + o.GetType());
						throw new ArgumentException("Unknown object of type " + o.GetType());
					}
					list.Add(action(o));
				}
			}
			return list;
		}

		internal static IDictionary<string, object> ToDictionary(this LLCustomer customer)
		{
			return new Dictionary<string, object>
			{
				{ "_nativeHandle", customer },
				{ "customerId", customer.CustomerId},
				{ "firstName", customer.FirstName},
				{ "lastName", customer.LastName},
				{ "fullName", customer.FullName},
				{ "emailAddress", customer.EmailAddress}
			};
		}

		public static void toBuilder(this LLCustomer customer, LLCustomerBuilder builder)
		{
			builder.CustomerId = customer.CustomerId;
			builder.EmailAddress = customer.EmailAddress;
			builder.FirstName = customer.FirstName;
			builder.FullName = customer.FullName;
			builder.LastName = customer.LastName;
		}


		public static LLCustomer toCustomer(IDictionary<string, object> customerProps)
		{
			var customer = new LLCustomer();
			customer = LLCustomer.CustomerWithBlock((LLCustomerBuilder builder) =>
			{
				if (customerProps.ContainsKey("_nativeHandle"))
				{
					toBuilder((LLCustomer)customerProps[@"_nativeHandle"], builder);
					//customer = (LLCustomer)customerProps[@"_nativeHandle"];
				}
				if (customerProps.ContainsKey(@"customerId"))
				{
					builder.CustomerId = (string)customerProps[@"customerId"];
				}
				if (customerProps.ContainsKey(@"firstName"))
				{
					builder.FirstName = (string)customerProps[@"firstName"];
				}
				if (customerProps.ContainsKey(@"lastName"))
				{
					builder.LastName = (string)customerProps[@"lastName"];
				}
				if (customerProps.ContainsKey(@"fullName"))
				{
					builder.FullName = (string)customerProps[@"fullName"];
				}
				if (customerProps.ContainsKey(@"emailAddress"))
				{
					builder.EmailAddress = (string)customerProps[@"emailAddress"];
				}
			});
			return customer;
		}

        public static LLCustomer toCustomer(IXLCustomer customer)
        {
            return LLCustomer.CustomerWithBlock((LLCustomerBuilder builder) =>
            {
                builder.CustomerId = customer.CustomerId;
                builder.EmailAddress = customer.EmailAddress;
                builder.FirstName = customer.FirstName;
                builder.FullName = customer.FullName;
                builder.LastName = customer.LastName;
            });
        }

		//    internal static IDictionary<string, object> ToDictionary(this LLInboxCampaign campaign)
		//    {
		//        return new Dictionary<string, object>
		//        {
		//            { "_nativeHandle", campaign },
		//            { "campaignId", campaign.CampaignId },
		//            { "name", campaign.Name },
		////{ "attributes", campaign.Attributes },
		////{ "creativeFilePath", campaign.CreativeFilePath },
		//{ "read", campaign.Read },
		//        { "titleText", campaign.TitleText },
		//        { "summaryText", campaign.SummaryText },
		//        { "thumbnailUrl", campaign.ThumbnailUrl.ToString() },
		//        { "hasCreative", campaign.HasCreative },
		//        { "sortOrder", campaign.SortOrder },
		//        { "receivedDate", campaign.ReceivedDate },
		//        { "deepLinkURL", campaign.DeepLinkURL.ToString() },
		//        { "isPushToInboxCampaign", campaign.IsPushToInboxCampaign }
        //        { "isDeleted", campaign.IsDeleted }
		//    };
		//}

		internal static IDictionary<string, object> ToDictionary(this LLPlacesCampaign campaign)
		{
			return new Dictionary<string, object>
			{
				{ "_nativeHandle", campaign },
				{ "campaignId", campaign.CampaignId },
				{ "name", campaign.Name },
                //{ "attributes", campaign.Attributes },
                { "message", campaign.Message },
				{ "soundFilename", campaign.SoundFilename },
				{ "region", campaign.Region },
				{ "event", (ulong)campaign.Event },
				{ "category", campaign.Category },
                { "attachmentURL", campaign.AttachmentUrl },
				{ "attachmentURL", campaign.AttachmentType }
			};
		}

		internal static IDictionary<string, object> ToDictionary(this LLInAppCampaign campaign)
		{
			return new Dictionary<string, object>
			{
				{ "_nativeHandle", campaign },
				{ "campaignId", campaign.CampaignId },
				{ "name", campaign.Name },
                //{ "attributes", campaign.Attributes },
                //{ "creativeFilePath", campaign.CreativeFilePath },
                { "type", (int)campaign.Type },
				{ "isResponsive", campaign.IsResponsive },
				{ "aspectRatio", campaign.AspectRatio },
				{ "offset", (ulong)campaign.Offset },
				{ "backgroundAlpha", campaign.BackgroundAlpha },
                { "dismissButtonHidden", campaign.IsDismissButtonHidden },
                { "dismissButtonLocation", campaign.DismissButtonLocation }
			};
		}

		internal static IDictionary<string, object> ToDictionary(this LLInAppConfiguration config)
		{
			return new Dictionary<string, object>
			{
				{ "dismissButtonLocation", config.DismissButtonLocation },
				//{ "dismissButtonImage", config.DismissButtonImage },
				{ "dismissButtonHidden", config.DismissButtonHidden },
				{ "aspectRatio", config.AspectRatio },
				{ "offset", config.Offset },
				{ "backgroundAlpha", config.BackgroundAlpha },
				{ "isCenterCampaign", config.IsCenterCampaign() },
				{ "isTopBannerCampaign", config.IsTopBannerCampaign() },
				{ "isBottomBannerCampaign", config.IsTopBannerCampaign() },
				{ "isFullScreenCampaign", config.IsFullScreenCampaign() },
                // Address image Name deficiency.
				{ "_nativeHandle", config }
		   };
		}

		internal static LLInAppConfiguration toInAppConfiguration(IDictionary<string, object> props)
		{
			var configuration = (LLInAppConfiguration)props["_nativeHandle"];
			//configuration.DismissButtonLocation = props["dismissButtonLocation"];
			//configuration.DismissButtonImage
			configuration.DismissButtonHidden = Convert.ToBoolean(props["dismissButtonHidden"]);
			configuration.AspectRatio = Convert.ToInt64(props["aspectRatio"]);
			configuration.Offset = Convert.ToInt64(props["offset"]);
			configuration.BackgroundAlpha = Convert.ToInt64(props["backgroundAlpha"]);
			if (props.ContainsKey("setDismissButtonImageWithName"))
			{
				configuration.SetDismissButtonImageWithName((string)(props["setDismissButtonImageWithName"]));
			}
			return configuration;
		}
        internal static IInboxCampaign[] From(NativeInboxCampaign[] inboxCampaigns)
        {

            IInboxCampaign[] campaigns = new XFInboxCampaign[inboxCampaigns.Length];
            int i = 0;
            foreach (var item in inboxCampaigns)
            {
                campaigns[i] = new XFInboxCampaign(item);
                i += 1;
            }
            //Debug.WriteLine("campaigns {0} => {1}", inboxCampaigns.Length, campaigns.Length);
            return campaigns;
        }
        internal static ICampaignBase CampaignFrom(NativeBaseCampaign campaign)
        {
            if (campaign is LocalyticsXamarin.IOS.LLInboxCampaign)
            {
                return new XFInboxCampaign((LocalyticsXamarin.IOS.LLInboxCampaign)campaign);
            }
            else if (campaign is LocalyticsXamarin.IOS.LLInAppCampaign)
            {
                return new XFInAppCampaign((LocalyticsXamarin.IOS.LLInAppCampaign)campaign);
            }
            else if (campaign is LocalyticsXamarin.IOS.LLPlacesCampaign)
            {
                return new XFPlacesCampaign((LocalyticsXamarin.IOS.LLPlacesCampaign)campaign);
            }
            else
            {
                return null;
            }
        }
	}
}
