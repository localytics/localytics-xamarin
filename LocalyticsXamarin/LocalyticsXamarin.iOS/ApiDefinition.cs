using System;
using CoreLocation;
using Foundation;
using UIKit;

namespace LocalyticsXamarin.iOS
{
	// @interface Localytics : NSObject
	[BaseType (typeof(NSObject))]
	interface Localytics
	{
		// +(void)autoIntegrate:(NSString *)appKey launchOptions:(NSDictionary *)launchOptions;
		[Static]
		[Export ("autoIntegrate:launchOptions:")]
		void AutoIntegrate (string appKey, NSDictionary launchOptions);

		// +(void)integrate:(NSString *)appKey;
		[Static]
		[Export ("integrate:")]
		void Integrate (string appKey);

		// +(void)openSession;
		[Static]
		[Export ("openSession")]
		void OpenSession ();

		// +(void)closeSession;
		[Static]
		[Export ("closeSession")]
		void CloseSession ();

		// +(void)upload;
		[Static]
		[Export ("upload")]
		void Upload ();

		// +(void)tagEvent:(NSString *)eventName;
		[Static]
		[Export ("tagEvent:")]
		void TagEvent (string eventName);

		// +(void)tagEvent:(NSString *)eventName attributes:(NSDictionary *)attributes;
		[Static]
		[Export ("tagEvent:attributes:")]
		void TagEvent (string eventName, NSDictionary attributes);

		// +(void)tagEvent:(NSString *)eventName attributes:(NSDictionary *)attributes customerValueIncrease:(NSNumber *)customerValueIncrease;
		[Static]
		[Export ("tagEvent:attributes:customerValueIncrease:")]
		void TagEvent (string eventName, NSDictionary attributes, NSNumber customerValueIncrease);

		// +(void)tagScreen:(NSString *)screenName;
		[Static]
		[Export ("tagScreen:")]
		void TagScreen (string screenName);

		// +(void)setValue:(NSString *)value forCustomDimension:(NSUInteger)dimension;
		// Rename to avoid ambiguity
		[Static]
		[Export ("setValue:forCustomDimension:")]
		void SetCustomDimension (string value, nuint dimension);

		// +(NSString *)valueForCustomDimension:(NSUInteger)dimension;
		// Rename to avoid ambiguity
		[Static]
		[Export ("valueForCustomDimension:")]
		string GetCustomDimension (nuint dimension);

		// +(void)setValue:(NSString *)value forIdentifier:(NSString *)identifier;
		// Rename to avoid ambiguity
		[Static]
		[Export ("setValue:forIdentifier:")]
		void SetIdentifier (string value, string identifier);

		// +(NSString *)valueForIdentifier:(NSString *)identifier;
		// Rename to avoid ambiguity
		[Static]
		[Export ("valueForIdentifier:")]
		string GetIdentifier (string identifier);

		// +(NSString *)customerId;
		// +(void)setCustomerId:(NSString *)customerId;
		[Static]
		[Export ("customerId")]
		//[Verify (MethodToProperty)]
		string CustomerId { get; [NullAllowed] set; }

		// +(void)setLocation:(CLLocationCoordinate2D)location;
		[Static]
		[Export ("setLocation:")]
		void SetLocation (CLLocationCoordinate2D location);

		// +(void)setValue:(NSObject *)value forProfileAttribute:(NSString *)attribute withScope:(LLProfileScope)scope;
		// Rename to avoid ambiguity
		[Static]
		[Export ("setValue:forProfileAttribute:withScope:")]
		void SetProfileAttribute (NSObject value, string attribute, LLProfileScope scope);

		// +(void)setValue:(NSObject *)value forProfileAttribute:(NSString *)attribute;
		// Rename to avoid ambiguity
		[Static]
		[Export ("setValue:forProfileAttribute:")]
		void SetProfileAttribute (NSObject value, string attribute);

		// +(void)addValues:(NSArray *)values toSetForProfileAttribute:(NSString *)attribute withScope:(LLProfileScope)scope;
		// Rename to avoid ambiguity
		[Static]
		[Export ("addValues:toSetForProfileAttribute:withScope:")]
		//[Verify (StronglyTypedNSArray)]
		void AddProfileAttributesToSet (NSObject[] values, string attribute, LLProfileScope scope);

		// +(void)addValues:(NSArray *)values toSetForProfileAttribute:(NSString *)attribute;
		// Rename to avoid ambiguity
		[Static]
		[Export ("addValues:toSetForProfileAttribute:")]
		//[Verify (StronglyTypedNSArray)]
		void AddProfileAttributesToSet (NSObject[] values, string attribute);

		// +(void)removeValues:(NSArray *)values fromSetForProfileAttribute:(NSString *)attribute withScope:(LLProfileScope)scope;
		// Rename to avoid ambiguity
		[Static]
		[Export ("removeValues:fromSetForProfileAttribute:withScope:")]
		//[Verify (StronglyTypedNSArray)]
		void RemoveProfileAttributesFromSet (NSObject[] values, string attribute, LLProfileScope scope);

		// +(void)removeValues:(NSArray *)values fromSetForProfileAttribute:(NSString *)attribute;
		// Rename to avoid ambiguity
		[Static]
		[Export ("removeValues:fromSetForProfileAttribute:")]
		//[Verify (StronglyTypedNSArray)]
		void RemoveProfileAttributesFromSet (NSObject[] values, string attribute);

		// +(void)incrementValueBy:(NSInteger)value forProfileAttribute:(NSString *)attribute withScope:(LLProfileScope)scope;
		// Rename to avoid ambiguity
		[Static]
		[Export ("incrementValueBy:forProfileAttribute:withScope:")]
		void IncrementProfileAttribute (nint value, string attribute, LLProfileScope scope);

		// +(void)incrementValueBy:(NSInteger)value forProfileAttribute:(NSString *)attribute;
		// Rename to avoid ambiguity
		[Static]
		[Export ("incrementValueBy:forProfileAttribute:")]
		void IncrementProfileAttribute (nint value, string attribute);

		// +(void)decrementValueBy:(NSInteger)value forProfileAttribute:(NSString *)attribute withScope:(LLProfileScope)scope;
		// Rename to avoid ambiguity
		[Static]
		[Export ("decrementValueBy:forProfileAttribute:withScope:")]
		void DecrementProfileAttribute (nint value, string attribute, LLProfileScope scope);

		// +(void)decrementValueBy:(NSInteger)value forProfileAttribute:(NSString *)attribute;
		// Rename to avoid ambiguity
		[Static]
		[Export ("decrementValueBy:forProfileAttribute:")]
		void DecrementProfileAttribute (nint value, string attribute);

		// +(void)deleteProfileAttribute:(NSString *)attribute withScope:(LLProfileScope)scope;
		[Static]
		[Export ("deleteProfileAttribute:withScope:")]
		void DeleteProfileAttribute (string attribute, LLProfileScope scope);

		// +(void)deleteProfileAttribute:(NSString *)attribute;
		[Static]
		[Export ("deleteProfileAttribute:")]
		void DeleteProfileAttribute (string attribute);

		// +(void)setCustomerEmail:(NSString *)email;
		[Static]
		[Export ("setCustomerEmail:")]
		void SetCustomerEmail (string email);

		// +(void)setCustomerFirstName:(NSString *)firstName;
		[Static]
		[Export ("setCustomerFirstName:")]
		void SetCustomerFirstName (string firstName);

		// +(void)setCustomerLastName:(NSString *)lastName;
		[Static]
		[Export ("setCustomerLastName:")]
		void SetCustomerLastName (string lastName);

		// +(void)setCustomerFullName:(NSString *)fullName;
		[Static]
		[Export ("setCustomerFullName:")]
		void SetCustomerFullName (string fullName);

		// +(NSString *)pushToken;
		[Static]
		[Export ("pushToken")]
		//[Verify (MethodToProperty)]
		string PushToken { get; }

		// +(void)setPushToken:(NSData *)pushToken;
		[Static]
		[Export ("setPushToken:")]
		void SetPushToken (NSData pushToken);

		// +(void)handlePushNotificationOpened:(NSDictionary *)notificationInfo;
		[Static]
		[Export ("handlePushNotificationOpened:")]
		void HandlePushNotificationOpened (NSDictionary notificationInfo);

		// +(BOOL)handleTestModeURL:(NSURL *)url;
		[Static]
		[Export ("handleTestModeURL:")]
		bool HandleTestModeURL (NSUrl url);

		// +(void)setInAppMessageDismissButtonImage:(UIImage *)image;
		[Static]
		[Export ("setInAppMessageDismissButtonImage:")]
		void SetInAppMessageDismissButtonImage (UIImage image);

		// +(void)setInAppMessageDismissButtonImageWithName:(NSString *)imageName;
		[Static]
		[Export ("setInAppMessageDismissButtonImageWithName:")]
		void SetInAppMessageDismissButtonImageWithName (string imageName);

		// +(LLInAppMessageDismissButtonLocation)inAppMessageDismissButtonLocation;
		// +(void)setInAppMessageDismissButtonLocation:(LLInAppMessageDismissButtonLocation)location;
		[Static]
		[Export ("inAppMessageDismissButtonLocation")]
		//[Verify (MethodToProperty)]
		LLInAppMessageDismissButtonLocation InAppMessageDismissButtonLocation { get; set; }

		// +(void)triggerInAppMessage:(NSString *)triggerName;
		[Static]
		[Export ("triggerInAppMessage:")]
		void TriggerInAppMessage (string triggerName);

		// +(void)triggerInAppMessage:(NSString *)triggerName withAttributes:(NSDictionary *)attributes;
		[Static]
		[Export ("triggerInAppMessage:withAttributes:")]
		void TriggerInAppMessage (string triggerName, NSDictionary attributes);

		// +(void)dismissCurrentInAppMessage;
		[Static]
		[Export ("dismissCurrentInAppMessage")]
		void DismissCurrentInAppMessage ();

		// +(BOOL)isLoggingEnabled;
		[Static]
		[Export ("isLoggingEnabled")]
		//[Verify (MethodToProperty)]
		bool IsLoggingEnabled { get; }

		// +(void)setLoggingEnabled:(BOOL)loggingEnabled;
		[Static]
		[Export ("setLoggingEnabled:")]
		void SetLoggingEnabled (bool loggingEnabled);

		// +(BOOL)isCollectingAdvertisingIdentifier;
		[Static]
		[Export ("isCollectingAdvertisingIdentifier")]
		//[Verify (MethodToProperty)]
		bool IsCollectingAdvertisingIdentifier { get; }

		// +(void)setCollectAdvertisingIdentifier:(BOOL)collectAdvertisingIdentifier;
		[Static]
		[Export ("setCollectAdvertisingIdentifier:")]
		void SetCollectAdvertisingIdentifier (bool collectAdvertisingIdentifier);

		// +(BOOL)isOptedOut;
		[Static]
		[Export ("isOptedOut")]
		//[Verify (MethodToProperty)]
		bool IsOptedOut { get; }

		// +(void)setOptedOut:(BOOL)optedOut;
		[Static]
		[Export ("setOptedOut:")]
		void SetOptedOut (bool optedOut);

		// +(BOOL)isTestModeEnabled;
		[Static]
		[Export ("isTestModeEnabled")]
		//[Verify (MethodToProperty)]
		bool IsTestModeEnabled { get; }

		// +(void)setTestModeEnabled:(BOOL)enabled;
		[Static]
		[Export ("setTestModeEnabled:")]
		void SetTestModeEnabled (bool enabled);

		// +(NSTimeInterval)sessionTimeoutInterval;
		// +(void)setSessionTimeoutInterval:(NSTimeInterval)timeoutInterval;
		[Static]
		[Export ("sessionTimeoutInterval")]
		//[Verify (MethodToProperty)]
		double SessionTimeoutInterval { get; set; }

		// +(NSString *)installId;
		[Static]
		[Export ("installId")]
		string InstallId ();

		// +(NSString *)libraryVersion;
		[Static]
		[Export ("libraryVersion")]
		string LibraryVersion ();

		// +(NSString *)appKey;
		[Static]
		[Export ("appKey")]
		string AppKey ();

		// +(NSString *)analyticsHost;
		[Static]
		[Export ("analyticsHost")]
		string AnalyticsHost ();

		// +(void)setAnalyticsHost:(NSString *)analyticsHost;
		[Static]
		[Export ("setAnalyticsHost:")]
		void SetAnalyticsHost (string analyticsHost);

		// +(NSString *)messagingHost;
		[Static]
		[Export ("messagingHost")]
		string MessagingHost ();

		// +(void)setMessagingHost:(NSString *)messagingHost;
		[Static]
		[Export ("setMessagingHost:")]
		void SetMessagingHost (string messagingHost);

		// +(NSString *)profilesHost;
		[Static]
		[Export ("profilesHost")]
		string ProfilesHost ();

		// +(void)setProfilesHost:(NSString *)profilesHost;
		[Static]
		[Export ("setProfilesHost:")]
		void SetProfilesHost (string profilesHost);

		// +(void)addMessagingDelegate:(id<LLMessagingDelegate>)delegate;
		[Static]
		[Export ("addMessagingDelegate:")]
		void AddMessagingDelegate (LLMessagingDelegate @delegate);

		// +(void)removeMessagingDelegate:(id<LLMessagingDelegate>)delegate;
		[Static]
		[Export ("removeMessagingDelegate:")]
		void RemoveMessagingDelegate (LLMessagingDelegate @delegate);

		// +(BOOL)isInAppAdIdParameterEnabled;
		[Static]
		[Export ("isInAppAdIdParameterEnabled")]
		bool IsInAppAdIdParameterEnabled ();

		// +(void)setInAppAdIdParameterEnabled:(BOOL)enabled;
		[Static]
		[Export ("setInAppAdIdParameterEnabled:")]
		void SetInAppAdIdParameterEnabled (bool enabled);

		// +(void)addAnalyticsDelegate:(id<LLAnalyticsDelegate>)delegate;
		[Static]
		[Export ("addAnalyticsDelegate:")]
		void AddAnalyticsDelegate (LLAnalyticsDelegate @delegate);

		// +(void)removeAnalyticsDelegate:(id<LLAnalyticsDelegate>)delegate;
		[Static]
		[Export ("removeAnalyticsDelegate:")]
		void RemoveAnalyticsDelegate (LLAnalyticsDelegate @delegate);

		// +(BOOL)handleWatchKitExtensionRequest:(NSDictionary *)userInfo reply:(void (^)(NSDictionary *))reply;
		[Static]
		[Export ("handleWatchKitExtensionRequest:reply:")]
		bool HandleWatchKitExtensionRequest (NSDictionary userInfo, Action<NSDictionary> reply);
	}

	// @protocol LLAnalyticsDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface LLAnalyticsDelegate
	{
		// @optional -(void)localyticsSessionWillOpen:(BOOL)isFirst isUpgrade:(BOOL)isUpgrade isResume:(BOOL)isResume;
		[Export ("localyticsSessionWillOpen:isUpgrade:isResume:")]
		void LocalyticsSessionWillOpen (bool isFirst, bool isUpgrade, bool isResume);

		// @optional -(void)localyticsSessionDidOpen:(BOOL)isFirst isUpgrade:(BOOL)isUpgrade isResume:(BOOL)isResume;
		[Export ("localyticsSessionDidOpen:isUpgrade:isResume:")]
		void LocalyticsSessionDidOpen (bool isFirst, bool isUpgrade, bool isResume);

		// @optional -(void)localyticsDidTagEvent:(NSString *)eventName attributes:(NSDictionary *)attributes customerValueIncrease:(NSNumber *)customerValueIncrease;
		[Export ("localyticsDidTagEvent:attributes:customerValueIncrease:")]
		void LocalyticsDidTagEvent (string eventName, NSDictionary attributes, NSNumber customerValueIncrease);

		// @optional -(void)localyticsSessionWillClose;
		[Export ("localyticsSessionWillClose")]
		void LocalyticsSessionWillClose ();
	}

	// @protocol LLMessagingDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface LLMessagingDelegate
	{
		// @optional -(void)localyticsWillDisplayInAppMessage;
		[Export ("localyticsWillDisplayInAppMessage")]
		void LocalyticsWillDisplayInAppMessage ();

		// @optional -(void)localyticsDidDisplayInAppMessage;
		[Export ("localyticsDidDisplayInAppMessage")]
		void LocalyticsDidDisplayInAppMessage ();

		// @optional -(void)localyticsWillDismissInAppMessage;
		[Export ("localyticsWillDismissInAppMessage")]
		void LocalyticsWillDismissInAppMessage ();

		// @optional -(void)localyticsDidDismissInAppMessage;
		[Export ("localyticsDidDismissInAppMessage")]
		void LocalyticsDidDismissInAppMessage ();
	}
}
