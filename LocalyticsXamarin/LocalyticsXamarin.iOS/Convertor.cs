using System;
using System.Collections;
using System.Collections.Generic;
using Foundation;
namespace LocalyticsXamarin.iOS
{
	public static class Convertor
    {
        private static Dictionary<Type, Func<object, NSObject>> _Strategies;
        static Convertor()
        {
            // Prepare all available strategies.
            _Strategies = new Dictionary<Type, Func<object, NSObject>>();

            _Strategies.Add(typeof(NSObject), (o) => { return (NSObject)o; });
            _Strategies.Add(typeof(string), (o) => { return new NSString((string)o); });
            _Strategies.Add(typeof(float), (o) => { return new NSNumber((float)o); });
            _Strategies.Add(typeof(double), (o) => { return new NSNumber((double)o); });
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
            List<NSObject> result = new List<NSObject>();
            foreach (object i in objects)
            {
                result.Add(NSObject.FromObject(i));
            }

            return result.ToArray();
        }

        public static NSDictionary ToNSDictionary(this IDictionary<string, string> source)
        {
            NSMutableDictionary result = new NSMutableDictionary();

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
            NSMutableDictionary result = new NSMutableDictionary();

            if (source != null)
            {
                foreach (string key in source.Keys)
                {
					if (source[key] is NSObject) {
						result.Add((NSString)(key), (NSObject)source[key]);
					} else {
						result.Add((NSString)(key), (NSString)(source[key]));
					}
                }
            }

            return result;
        }

        public static NSDictionary ToNSDictionary(this IDictionary dictionary)
        {
            NSMutableDictionary result = new NSMutableDictionary();
            foreach (string key in dictionary.Keys)
            {
                result.Add(new NSString(key), new NSString(dictionary[key].ToString()));
            }
            return result;
        }
        public static NSArray ToDictionary(params object[] values)
        {
            NSMutableArray list = new NSMutableArray();
            foreach (object o in values)
            {
				// Check if we have a matching strategy.
				if (!_Strategies.TryGetValue(o.GetType(), out Func<object, NSObject> action))
				{
					// If not, log error, throw exception, whatever.
					throw new ArgumentException("Unknown object of type " + o.GetType());
				}
				list.Add(action(o));
            }
            return list;
        }

		internal static IDictionary<string, object> ToDictionary(this LLCustomer customer)
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

		internal static LLCustomer toCustomer(IDictionary<string, object> customerProps)
		{
			// TODO handle if the _nativeHandle is present.
			return LLCustomer.CustomerWithBlock((LLCustomerBuilder builder) => {
				builder.CustomerId = (string)customerProps[@"customerId"];
				if (customerProps.ContainsKey(@"firstName")) {
					builder.FirstName = (string)customerProps[@"firstName"];
				}
				if (customerProps.ContainsKey(@"lastName")) {
					builder.LastName = (string)customerProps[@"lastName"];
				}
				if (customerProps.ContainsKey(@"fullName")) {
					builder.FullName = (string)customerProps[@"fullName"];
				}
				if (customerProps.ContainsKey(@"emailAddress"))
				{
					builder.EmailAddress = (string)customerProps[@"emailAddress"];
				}
			});
		}
        
		internal static IDictionary<string, object> ToDictionary(this LLInboxCampaign campaign)
        {
            return new Dictionary<string, object>()
			{
				{ "_nativeHandle", campaign },
				{ "campaignId", campaign.CampaignId },
				{ "name", campaign.Name },
				//{ "attributes", campaign.Attributes },
				//{ "creativeFilePath", campaign.CreativeFilePath },
				{ "read", campaign.Read },
				{ "titleText", campaign.TitleText },
				{ "summaryText", campaign.SummaryText },
				{ "thumbnailUrl", campaign.ThumbnailUrl.ToString() },
				{ "hasCreative", campaign.HasCreative },
				{ "sortOrder", campaign.SortOrder },
				{ "receivedDate", campaign.ReceivedDate },
				{ "deepLinkURL", campaign.DeepLinkURL.ToString() },
				{ "isPushToInboxCampaign", campaign.IsPushToInboxCampaign }
            };
        }
        
		internal static IDictionary<string, object> ToDictionary(this LLPlacesCampaign campaign)
        {
            return new Dictionary<string, object>()
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
                { "attachmentURL", campaign.AttachmentURL },
                { "attachmentURL", campaign.AttachmentType }
            };
        }

		internal static IDictionary<string, object> ToDictionary(this LLInAppCampaign campaign)
        {
            return new Dictionary<string, object>()
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
                { "dismissButtonHidden", campaign.GetInAppMessageDismissButtonHidden() },
                { "dismissButtonLocation", campaign.DismissButtonLocation() }
            };
        }

		internal static IDictionary<string, object> ToDictionary(this LLInAppConfiguration config)
        {
            return new Dictionary<string, object>()
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
			LLInAppConfiguration configuration = (LLInAppConfiguration) props["_nativeHandle"];
			//configuration.DismissButtonLocation = props["dismissButtonLocation"];
			//configuration.DismissButtonImage
			configuration.DismissButtonHidden = Convert.ToBoolean(props["dismissButtonHidden"]);
			configuration.AspectRatio = Convert.ToInt64(props["aspectRatio"]);
			configuration.Offset = Convert.ToInt64(props["offset"]);
			configuration.BackgroundAlpha = Convert.ToInt64(props["backgroundAlpha"]);
			if (props.ContainsKey("setDismissButtonImageWithName")) {
				configuration.SetDismissButtonImageWithName((string)(props["setDismissButtonImageWithName"]));
			}
			return configuration;
        }
	}
}
