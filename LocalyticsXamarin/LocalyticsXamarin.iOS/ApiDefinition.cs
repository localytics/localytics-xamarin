using System;
using CoreLocation;
using Foundation;
using ObjCRuntime;
using UIKit;
using UserNotifications;

namespace LocalyticsXamarin.iOS
{
	partial interface Constants
	{
		// extern double LocalyticsVersionNumber;
		[Field("LocalyticsVersionNumber", "__Internal")]
		double LocalyticsVersionNumber { get; }

		// extern const unsigned char [] LocalyticsVersionString;
		[Field("LocalyticsVersionString", "__Internal")]
		byte[] LocalyticsVersionString { get; }
	}

	// @interface LLCustomerBuilder : NSObject
	[BaseType(typeof(NSObject))]
	interface LLCustomerBuilder
	{
		// @property (nonatomic, strong) NSString * _Nullable customerId;
		[NullAllowed, Export("customerId", ArgumentSemantic.Strong)]
		string CustomerId { get; set; }

		// @property (nonatomic, strong) NSString * _Nullable firstName;
		[NullAllowed, Export("firstName", ArgumentSemantic.Strong)]
		string FirstName { get; set; }

		// @property (nonatomic, strong) NSString * _Nullable lastName;
		[NullAllowed, Export("lastName", ArgumentSemantic.Strong)]
		string LastName { get; set; }

		// @property (nonatomic, strong) NSString * _Nullable fullName;
		[NullAllowed, Export("fullName", ArgumentSemantic.Strong)]
		string FullName { get; set; }

		// @property (nonatomic, strong) NSString * _Nullable emailAddress;
		[NullAllowed, Export("emailAddress", ArgumentSemantic.Strong)]
		string EmailAddress { get; set; }
	}

	// @interface LLCustomer : NSObject
	[BaseType(typeof(NSObject))]
	interface LLCustomer
	{
		// @property (readonly, nonatomic, strong) NSString * _Nullable customerId;
		[NullAllowed, Export("customerId", ArgumentSemantic.Strong)]
		string CustomerId { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nullable firstName;
		[NullAllowed, Export("firstName", ArgumentSemantic.Strong)]
		string FirstName { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nullable lastName;
		[NullAllowed, Export("lastName", ArgumentSemantic.Strong)]
		string LastName { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nullable fullName;
		[NullAllowed, Export("fullName", ArgumentSemantic.Strong)]
		string FullName { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nullable emailAddress;
		[NullAllowed, Export("emailAddress", ArgumentSemantic.Strong)]
		string EmailAddress { get; }

		// +(instancetype _Nullable)customerWithBlock:(void (^ _Nonnull)(LLCustomerBuilder * _Nonnull))block;
		[Static]
		[Export("customerWithBlock:")]
		[return: NullAllowed]
		LLCustomer CustomerWithBlock(Action<LLCustomerBuilder> block);
	}

	// @interface LLCampaignBase : NSObject
	[BaseType(typeof(NSObject))]
	interface LLCampaignBase
	{
		// @property (readonly, assign, nonatomic) NSInteger campaignId;
		[Export("campaignId")]
		nint CampaignId { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull name;
		[Export("name")]
		string Name { get; }

		// @property (readonly, copy, nonatomic) NSDictionary<NSString *,NSString *> * _Nullable attributes;
		[NullAllowed, Export("attributes", ArgumentSemantic.Copy)]
		NSDictionary Attributes { get; }
	}


	// @interface LLWebViewCampaign : LLCampaignBase
	[BaseType(typeof(LLCampaignBase))]
	interface LLWebViewCampaign
	{
	}

	// @interface LLInboxCampaign : LLWebViewCampaign
	[BaseType(typeof(LLWebViewCampaign))]
	interface LLInboxCampaign
	{
		// @property (getter = isRead, assign, nonatomic) BOOL read;
		[Export("read")]
		bool Read { [Bind("isRead")] get; set; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable titleText;
		[NullAllowed, Export("titleText")]
		string TitleText { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable summaryText;
		[NullAllowed, Export("summaryText")]
		string SummaryText { get; }

		// @property (readonly, copy, nonatomic) NSURL * _Nullable thumbnailUrl;
		[NullAllowed, Export("thumbnailUrl", ArgumentSemantic.Copy)]
		NSUrl ThumbnailUrl { get; }

		// @property (readonly, assign, nonatomic) BOOL hasCreative;
		[Export("hasCreative")]
		bool HasCreative { get; }

		// @property (readonly, assign, nonatomic) NSInteger sortOrder;
		[Export("sortOrder")]
		nint SortOrder { get; }

		// @property (readonly, assign, nonatomic) NSTimeInterval receivedDate;
		[Export("receivedDate")]
		double ReceivedDate { get; }
	}


	// @interface LLPlacesCampaign : LLCampaignBase
	[BaseType(typeof(LLCampaignBase))]
	interface LLPlacesCampaign
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull message;
		[Export("message")]
		string Message { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable soundFilename;
		[NullAllowed, Export("soundFilename")]
		string SoundFilename { get; }

		// @property (readonly, copy, nonatomic) LLRegion * _Nonnull region;
		[Export("region", ArgumentSemantic.Copy)]
		LLRegion Region { get; }

		// @property (readonly, assign, nonatomic) LLRegionEvent event;
		[Export("event", ArgumentSemantic.Assign)]
		LLRegionEvent Event { get; }
	}

	// @interface LLRegion : NSObject
	[BaseType(typeof(NSObject))]
	interface LLRegion
	{
		// @property (readonly, copy, nonatomic) NSString * _Nullable name;
		[NullAllowed, Export("name")]
		string Name { get; }

		// @property (readonly, copy, nonatomic) NSDictionary<NSString *,NSString *> * _Nullable attributes;
		[NullAllowed, Export("attributes", ArgumentSemantic.Copy)]
		NSDictionary Attributes { get; }

		// @property (readonly, copy, nonatomic) CLRegion * _Nonnull region;
		[Export("region", ArgumentSemantic.Copy)]
		CLRegion Region { get; }
	}

	// @interface LLGeofence : LLRegion
	[BaseType(typeof(LLRegion))]
	interface LLGeofence
	{
		// @property (readonly, copy, nonatomic) CLCircularRegion * _Nonnull region;
		[Export("region", ArgumentSemantic.Copy)]
		CLCircularRegion Region { get; }
	}

	public interface ILLInboxCampaignsRefreshingDelegate { }

	// @protocol LLInboxCampaignsRefreshingDelegate <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface LLInboxCampaignsRefreshingDelegate
	{
		// @optional -(void)localyticsDidBeginRefreshingInboxCampaigns;
		[Export("localyticsDidBeginRefreshingInboxCampaigns")]
		void LocalyticsDidBeginRefreshingInboxCampaigns();

		// @optional -(void)localyticsDidFinishRefreshingInboxCampaigns;
		[Export("localyticsDidFinishRefreshingInboxCampaigns")]
		void LocalyticsDidFinishRefreshingInboxCampaigns();
	}

	// @interface LLInboxViewController : UIViewController <UITableViewDelegate, UITableViewDataSource, LLInboxCampaignsRefreshingDelegate>
	[BaseType(typeof(UIViewController))]
	interface LLInboxViewController : IUITableViewDelegate, IUITableViewDataSource, ILLInboxCampaignsRefreshingDelegate
	{
		// @property (nonatomic, strong) UITableView * _Nonnull tableView;
		[Export("tableView", ArgumentSemantic.Strong)]
		UITableView TableView { get; set; }

		// @property (nonatomic, strong) UIView * _Nonnull emptyCampaignsView;
		[Export("emptyCampaignsView", ArgumentSemantic.Strong)]
		UIView EmptyCampaignsView { get; set; }

		// @property (assign, nonatomic) BOOL showsActivityIndicatorView;
		[Export("showsActivityIndicatorView")]
		bool ShowsActivityIndicatorView { get; set; }

		// @property (assign, nonatomic) BOOL downloadsThumbnails;
		[Export("downloadsThumbnails")]
		bool DownloadsThumbnails { get; set; }

		// @property (nonatomic, strong) UIFont * _Nonnull textLabelFont;
		[Export("textLabelFont", ArgumentSemantic.Strong)]
		UIFont TextLabelFont { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull textLabelColor;
		[Export("textLabelColor", ArgumentSemantic.Strong)]
		UIColor TextLabelColor { get; set; }

		// @property (nonatomic, strong) UIFont * _Nonnull detailTextLabelFont;
		[Export("detailTextLabelFont", ArgumentSemantic.Strong)]
		UIFont DetailTextLabelFont { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull detailTextLabelColor;
		[Export("detailTextLabelColor", ArgumentSemantic.Strong)]
		UIColor DetailTextLabelColor { get; set; }

		// @property (nonatomic, strong) UIFont * _Nonnull timeTextLabelFont;
		[Export("timeTextLabelFont", ArgumentSemantic.Strong)]
		UIFont TimeTextLabelFont { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull timeTextLabelColor;
		[Export("timeTextLabelColor", ArgumentSemantic.Strong)]
		UIColor TimeTextLabelColor { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull unreadIndicatorColor;
		[Export("unreadIndicatorColor", ArgumentSemantic.Strong)]
		UIColor UnreadIndicatorColor { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull cellBackgroundColor;
		[Export("cellBackgroundColor", ArgumentSemantic.Strong)]
		UIColor CellBackgroundColor { get; set; }

		// @property (nonatomic, strong) UIView * _Nullable creativeLoadErrorView;
		[NullAllowed, Export("creativeLoadErrorView", ArgumentSemantic.Strong)]
		UIView CreativeLoadErrorView { get; set; }

		// -(LLInboxCampaign * _Nullable)campaignForRowAtIndexPath:(NSIndexPath * _Nonnull)indexPath;
		[Export("campaignForRowAtIndexPath:")]
		[return: NullAllowed]
		LLInboxCampaign CampaignForRowAtIndexPath(NSIndexPath indexPath);
	}

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
		void TagEvent (string eventName, [NullAllowed] NSDictionary attributes);

		// +(void)tagEvent:(NSString * _Nonnull)eventName attributes:(NSDictionary<NSString *,NSString *> * _Nullable)attributes customerValueIncrease:(NSNumber * _Nullable)customerValueIncrease;
		[Static]
		[Export("tagEvent:attributes:customerValueIncrease:")]
		void TagEvent(string eventName, [NullAllowed] NSDictionary attributes, [NullAllowed] NSNumber customerValueIncrease);

		// +(void)tagPurchased:(NSString * _Nullable)itemName itemId:(NSString * _Nullable)itemId itemType:(NSString * _Nullable)itemType itemPrice:(NSNumber * _Nullable)itemPrice attributes:(NSDictionary<NSString *,NSString *> * _Nullable)attributes;
		[Static]
		[Export("tagPurchased:itemId:itemType:itemPrice:attributes:")]
		void TagPurchased([NullAllowed] string itemName, [NullAllowed] string itemId, [NullAllowed] string itemType, [NullAllowed] NSNumber itemPrice, [NullAllowed] NSDictionary attributes);

		// +(void)tagAddedToCart:(NSString * _Nullable)itemName itemId:(NSString * _Nullable)itemId itemType:(NSString * _Nullable)itemType itemPrice:(NSNumber * _Nullable)itemPrice attributes:(NSDictionary<NSString *,NSString *> * _Nullable)attributes;
		[Static]
		[Export("tagAddedToCart:itemId:itemType:itemPrice:attributes:")]
		void TagAddedToCart([NullAllowed] string itemName, [NullAllowed] string itemId, [NullAllowed] string itemType, [NullAllowed] NSNumber itemPrice, [NullAllowed] NSDictionary attributes);

		// +(void)tagStartedCheckout:(NSNumber * _Nullable)totalPrice itemCount:(NSNumber * _Nullable)itemCount attributes:(NSDictionary<NSString *,NSString *> * _Nullable)attributes;
		[Static]
		[Export("tagStartedCheckout:itemCount:attributes:")]
		void TagStartedCheckout([NullAllowed] NSNumber totalPrice, [NullAllowed] NSNumber itemCount, [NullAllowed] NSDictionary attributes);

		// +(void)tagCompletedCheckout:(NSNumber * _Nullable)totalPrice itemCount:(NSNumber * _Nullable)itemCount attributes:(NSDictionary<NSString *,NSString *> * _Nullable)attributes;
		[Static]
		[Export("tagCompletedCheckout:itemCount:attributes:")]
		void TagCompletedCheckout([NullAllowed] NSNumber totalPrice, [NullAllowed] NSNumber itemCount, [NullAllowed] NSDictionary attributes);

		// +(void)tagContentViewed:(NSString * _Nullable)contentName contentId:(NSString * _Nullable)contentId contentType:(NSString * _Nullable)contentType attributes:(NSDictionary<NSString *,NSString *> * _Nullable)attributes;
		[Static]
		[Export("tagContentViewed:contentId:contentType:attributes:")]
		void TagContentViewed([NullAllowed] string contentName, [NullAllowed] string contentId, [NullAllowed] string contentType, [NullAllowed] NSDictionary attributes);

		// +(void)tagSearched:(NSString * _Nullable)queryText contentType:(NSString * _Nullable)contentType resultCount:(NSNumber * _Nullable)resultCount attributes:(NSDictionary<NSString *,NSString *> * _Nullable)attributes;
		[Static]
		[Export("tagSearched:contentType:resultCount:attributes:")]
		void TagSearched([NullAllowed] string queryText, [NullAllowed] string contentType, [NullAllowed] NSNumber resultCount, [NullAllowed] NSDictionary attributes);

		// +(void)tagShared:(NSString * _Nullable)contentName contentId:(NSString * _Nullable)contentId contentType:(NSString * _Nullable)contentType methodName:(NSString * _Nullable)methodName attributes:(NSDictionary<NSString *,NSString *> * _Nullable)attributes;
		[Static]
		[Export("tagShared:contentId:contentType:methodName:attributes:")]
		void TagShared([NullAllowed] string contentName, [NullAllowed] string contentId, [NullAllowed] string contentType, [NullAllowed] string methodName, [NullAllowed] NSDictionary attributes);

		// +(void)tagContentRated:(NSString * _Nullable)contentName contentId:(NSString * _Nullable)contentId contentType:(NSString * _Nullable)contentType rating:(NSNumber * _Nullable)rating attributes:(NSDictionary<NSString *,NSString *> * _Nullable)attributes;
		[Static]
		[Export("tagContentRated:contentId:contentType:rating:attributes:")]
		void TagContentRated([NullAllowed] string contentName, [NullAllowed] string contentId, [NullAllowed] string contentType, [NullAllowed] NSNumber rating, [NullAllowed] NSDictionary attributes);

		// +(void)tagCustomerRegistered:(LLCustomer * _Nullable)customer methodName:(NSString * _Nullable)methodName attributes:(NSDictionary<NSString *,NSString *> * _Nullable)attributes;
		[Static]
		[Export("tagCustomerRegistered:methodName:attributes:")]
		void TagCustomerRegistered([NullAllowed] LLCustomer customer, [NullAllowed] string methodName, [NullAllowed] NSDictionary attributes);

		// +(void)tagCustomerLoggedIn:(LLCustomer * _Nullable)customer methodName:(NSString * _Nullable)methodName attributes:(NSDictionary<NSString *,NSString *> * _Nullable)attributes;
		[Static]
		[Export("tagCustomerLoggedIn:methodName:attributes:")]
		void TagCustomerLoggedIn([NullAllowed] LLCustomer customer, [NullAllowed] string methodName, [NullAllowed] NSDictionary attributes);

		// +(void)tagCustomerLoggedOut:(NSDictionary<NSString *,NSString *> * _Nullable)attributes;
		[Static]
		[Export("tagCustomerLoggedOut:")]
		void TagCustomerLoggedOut([NullAllowed] NSDictionary attributes);

		// +(void)tagInvited:(NSString * _Nullable)methodName attributes:(NSDictionary<NSString *,NSString *> * _Nullable)attributes;
		[Static]
		[Export("tagInvited:attributes:")]
		void TagInvited([NullAllowed] string methodName, [NullAllowed] NSDictionary attributes);

		// +(void)tagScreen:(NSString *)screenName;
		[Static]
		[Export ("tagScreen:")]
		void TagScreen (string screenName);

		// +(void)setValue:(NSString *)value forCustomDimension:(NSUInteger)dimension;
		// Rename to avoid ambiguity
		[Static]
		[Export ("setValue:forCustomDimension:")]
		void SetCustomDimension ([NullAllowed]string value, nuint dimension);

		// +(NSString *)valueForCustomDimension:(NSUInteger)dimension;
		// Rename to avoid ambiguity
		[Static]
		[Export ("valueForCustomDimension:")]
		string GetCustomDimension (nuint dimension);

		// +(void)setValue:(NSString *)value forIdentifier:(NSString *)identifier;
		// Rename to avoid ambiguity
		[Static]
		[Export ("setValue:forIdentifier:")]
		void SetIdentifier ([NullAllowed]string value, string identifier);

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
		string CustomerId { get; set; }

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

		// +(void)handleNotification:(NSDictionary * _Nonnull)notificationInfo;
		[Static]
		[Export("handleNotification:")]
		void HandleNotification(NSDictionary notificationInfo);

		// +(void)didReceiveNotificationResponseWithUserInfo:(nonnull NSDictionary *)userInfo;
		[Static]
		[Export("didReceiveNotificationResponseWithUserInfo:")]
		void DidReceiveNotificationResponseWithUserInfo(NSDictionary userInfo);

		// +(void)didRegisterUserNotificationSettings:(nonnull UIUserNotificationSettings *)notificationSettings;
		[Static]
		[Export("didRegisterUserNotificationSettings:")]
		void DidRegisterUserNotificationSettings(UIUserNotificationSettings notificationSettings);

		// +(void)didRequestUserNotificationAuthorizationWithOptions:(NSUInteger)options granted:(BOOL)granted;
		[Static]
		[Export("didRequestUserNotificationAuthorizationWithOptions:granted:")]
		void DidRequestUserNotificationAuthorizationWithOptions(nuint options, bool granted);

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

		// +(NSArray<LLInboxCampaign *> * _Nonnull)inboxCampaigns;
		[Static]
		[Export("inboxCampaigns")]
		//[Verify(MethodToProperty)]
		LLInboxCampaign[] InboxCampaigns { get; }

		// +(void)refreshInboxCampaigns:(void (^ _Nonnull)(NSArray<LLInboxCampaign *> * _Nullable))completionBlock;
		[Static]
		[Export("refreshInboxCampaigns:")]
		void RefreshInboxCampaigns(Action<NSArray<NSObject>> completionBlock);
		//void RefreshInboxCampaigns(Action<NSArray<LLInboxCampaign>> completionBlock); // to check

		// +(void)setInboxCampaignId:(NSInteger)campaignId asRead:(BOOL)read;
		[Static]
		[Export("setInboxCampaignId:asRead:")]
		void SetInboxCampaignId(nint campaignId, bool read);

		// +(NSInteger)inboxCampaignsUnreadCount;
		[Static]
		[Export("inboxCampaignsUnreadCount")]
		//[Verify(MethodToProperty)]
		nint InboxCampaignsUnreadCount { get; }

		// +(LLInboxDetailViewController * _Nonnull)inboxDetailViewControllerForCampaign:(LLInboxCampaign * _Nonnull)campaign;
		[Static]
		[Export("inboxDetailViewControllerForCampaign:")]
		LLInboxDetailViewController InboxDetailViewControllerForCampaign(LLInboxCampaign campaign);

		// +(void)setLocationMonitoringEnabled:(BOOL)enabled;
		[Static]
		[Export("setLocationMonitoringEnabled:")]
		void SetLocationMonitoringEnabled(bool enabled);

		// +(NSArray<LLRegion *> * _Nonnull)geofencesToMonitor:(CLLocationCoordinate2D)currentCoordinate;
		[Static]
		[Export("geofencesToMonitor:")]
		LLRegion[] GeofencesToMonitor(CLLocationCoordinate2D currentCoordinate);

		// +(void)triggerRegion:(CLRegion * _Nonnull)region withEvent:(LLRegionEvent)event;
		[Static]
		[Export("triggerRegion:withEvent:")]
		void TriggerRegion(CLRegion region, LLRegionEvent @event);

		// +(void)triggerRegions:(NSArray<CLRegion *> * _Nonnull)regions withEvent:(LLRegionEvent)event;
		[Static]
		[Export("triggerRegions:withEvent:")]
		void TriggerRegions(CLRegion[] regions, LLRegionEvent @event);

		// +(void)setOptions:(NSDictionary<NSString *,NSObject *> * _Nullable)options;
		[Static]
		[Export("setOptions:")]
		void SetOptions([NullAllowed] NSDictionary<NSString, NSObject> options);

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

		// +(NSString *)installId;
		[Static]
		[Export("installId")]
		string InstallId();

		// +(NSString *)libraryVersion;
		[Static]
		[Export("libraryVersion")]
		string LibraryVersion();

		// +(NSString *)appKey;
		[Static]
		[Export("appKey")]
		string AppKey();

		// +(void)setMessagingDelegate:(id<LLMessagingDelegate> _Nullable)delegate;
		[Static]
		[Export("setMessagingDelegate:")]
		void SetMessagingDelegate([NullAllowed] LLMessagingDelegate @delegate);

		// +(BOOL)isInAppAdIdParameterEnabled;
		[Static]
		[Export("isInAppAdIdParameterEnabled")]
		bool IsInAppAdIdParameterEnabled { get; }

		// +(void)setInAppAdIdParameterEnabled:(BOOL)enabled;
		[Static]
		[Export("setInAppAdIdParameterEnabled:")]
		void SetInAppAdIdParameterEnabled(bool enabled);

		// +(void)setAnalyticsDelegate:(id<LLAnalyticsDelegate> _Nullable)delegate;
		[Static]
		[Export("setAnalyticsDelegate:")]
		void SetAnalyticsDelegate([NullAllowed] LLAnalyticsDelegate @delegate);

		// +(void)setLocationDelegate:(id<LLLocationDelegate> _Nullable)delegate;
		[Static]
		[Export("setLocationDelegate:")]
		void SetLocationDelegate([NullAllowed] LLLocationDelegate @delegate);
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

		// @optional -(void)localyticsDidTagEvent:(NSString * _Nonnull)eventName attributes:(NSDictionary<NSString *,NSString *> * _Nullable)attributes customerValueIncrease:(NSNumber * _Nullable)customerValueIncrease;
		[Export("localyticsDidTagEvent:attributes:customerValueIncrease:")]
		void LocalyticsDidTagEvent(string eventName, [NullAllowed] NSDictionary attributes, [NullAllowed] NSNumber customerValueIncrease);

		// @optional -(void)localyticsSessionWillClose;
		[Export ("localyticsSessionWillClose")]
		void LocalyticsSessionWillClose ();
	}

	// @protocol LLMessagingDelegate <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface LLMessagingDelegate
	{
		// @optional -(void)localyticsWillDisplayInAppMessage;
		[Export("localyticsWillDisplayInAppMessage")]
		void LocalyticsWillDisplayInAppMessage();

		// @optional -(void)localyticsDidDisplayInAppMessage;
		[Export("localyticsDidDisplayInAppMessage")]
		void LocalyticsDidDisplayInAppMessage();

		// @optional -(void)localyticsWillDismissInAppMessage;
		[Export("localyticsWillDismissInAppMessage")]
		void LocalyticsWillDismissInAppMessage();

		// @optional -(void)localyticsDidDismissInAppMessage;
		[Export("localyticsDidDismissInAppMessage")]
		void LocalyticsDidDismissInAppMessage();

		// @optional -(BOOL)localyticsShouldDisplayPlacesCampaign:(LLPlacesCampaign * _Nonnull)campaign;
		[Export("localyticsShouldDisplayPlacesCampaign:")]
		bool LocalyticsShouldDisplayPlacesCampaign(LLPlacesCampaign campaign);

		// @optional -(UILocalNotification * _Nonnull)localyticsWillDisplayNotification:(UILocalNotification * _Nonnull)notification forPlacesCampaign:(LLPlacesCampaign * _Nonnull)campaign;
		[Export("localyticsWillDisplayNotification:forPlacesCampaign:")]
		UILocalNotification LocalyticsWillDisplayNotification(UILocalNotification notification, LLPlacesCampaign campaign);

		// @optional -(UNMutableNotificationContent *)localyticsWillDisplayNotificationContent:(nonnull UNMutableNotificationContent *)notification forPlacesCampaign:(nonnull LLPlacesCampaign *)campaign;
		[Export("localyticsWillDisplayNotificationContent:forPlacesCampaign:")]
		UNMutableNotificationContent LocalyticsWillDisplayNotificationContent(UNMutableNotificationContent notification, LLPlacesCampaign campaign);
	}

	// @protocol LLLocationDelegate <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface LLLocationDelegate
	{
		// @optional -(void)localyticsDidUpdateLocation:(CLLocation * _Nonnull)location;
		[Export("localyticsDidUpdateLocation:")]
		void LocalyticsDidUpdateLocation(CLLocation location);

		// @optional -(void)localyticsDidUpdateMonitoredRegions:(NSArray<LLRegion *> * _Nonnull)addedRegions removeRegions:(NSArray<LLRegion *> * _Nonnull)removedRegions;
		[Export("localyticsDidUpdateMonitoredRegions:removeRegions:")]
		void LocalyticsDidUpdateMonitoredRegions(LLRegion[] addedRegions, LLRegion[] removedRegions);

		// @optional -(void)localyticsDidTriggerRegions:(NSArray<LLRegion *> * _Nonnull)regions withEvent:(LLRegionEvent)event;
		[Export("localyticsDidTriggerRegions:withEvent:")]
		void LocalyticsDidTriggerRegions(LLRegion[] regions, LLRegionEvent @event);
	}

	// @interface LLInboxDetailViewController : UIViewController
	[BaseType(typeof(UIViewController))]
	interface LLInboxDetailViewController
	{
		// @property (readonly, nonatomic, strong) LLInboxCampaign * _Nonnull campaign;
		[Export("campaign", ArgumentSemantic.Strong)]
		LLInboxCampaign Campaign { get; }

		// @property (nonatomic, strong) UIView * _Nullable creativeLoadErrorView;
		[NullAllowed, Export("creativeLoadErrorView", ArgumentSemantic.Strong)]
		UIView CreativeLoadErrorView { get; set; }
	}

}
