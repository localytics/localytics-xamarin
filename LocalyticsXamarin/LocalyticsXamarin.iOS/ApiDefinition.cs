using System;
using CoreLocation;
using Foundation;
using ObjCRuntime;
using UIKit;
using UserNotifications;

namespace LocalyticsXamarin.IOS
{
    // @interface LLCustomerBuilder : NSObject
    [BaseType(typeof(NSObject))]
    public interface LLCustomerBuilder
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
	//[Model]
    public interface LLCustomer
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
        [Export("customerWithBlock:")]
        [return: NullAllowed]
		[Static]
        LLCustomer CustomerWithBlock(Action<LLCustomerBuilder> block);
    }

    // @interface LLCampaignBase : NSObject
    [BaseType(typeof(NSObject))]
    public interface LLCampaignBase
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
    public interface LLWebViewCampaign
    {
        // @property (readonly, copy, nonatomic) NSString * _Nullable creativeFilePath;
        [NullAllowed, Export("creativeFilePath")]
        string CreativeFilePath { get; }
    }

    // @interface LLInboxCampaign : LLWebViewCampaign
    [BaseType(typeof(LLWebViewCampaign))]
    public interface LLInboxCampaign
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

        // @property (readonly, copy, nonatomic) NSURL * _Nullable deepLinkURL;
        [NullAllowed, Export("deepLinkURL", ArgumentSemantic.Copy)]
        NSUrl DeepLinkURL { get; }

        // @property (readonly, assign, nonatomic) BOOL isPushToInboxCampaign;
        [Export("isPushToInboxCampaign")]
        bool IsPushToInboxCampaign { get; }
    }

    // @interface LLPlacesCampaign : LLCampaignBase
    [BaseType(typeof(LLCampaignBase))]
    public interface LLPlacesCampaign
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

        // @property (readonly, copy, nonatomic) NSString * _Nullable category;
        [NullAllowed, Export("category")]
        string Category { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nullable attachmentURL;
        [NullAllowed, Export("attachmentURL")]
        string AttachmentURL { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nullable attachmentType;
		[NullAllowed, Export("attachmentType")]
        string AttachmentType { get; }
    }

    // @interface LLInAppCampaign : LLWebViewCampaign
    [BaseType(typeof(LLWebViewCampaign))]
    public interface LLInAppCampaign
    {
        // @property (readonly, assign, nonatomic) LLInAppMessageType type;
        [Export("type", ArgumentSemantic.Assign)]
        LLInAppMessageType Type { get; }

        // @property (readonly, assign, nonatomic) BOOL isResponsive;
        [Export("isResponsive")]
        bool IsResponsive { get; }

        // @property (readonly, assign, nonatomic) CGFloat aspectRatio;
        [Export("aspectRatio")]
        nfloat AspectRatio { get; }

        // @property (readonly, assign, nonatomic) CGFloat offset;
        [Export("offset")]
        nfloat Offset { get; }

        // @property (readonly, assign, nonatomic) CGFloat backgroundAlpha;
        [Export("backgroundAlpha")]
        nfloat BackgroundAlpha { get; }

        // @property (readonly, getter = isDismissButtonHidden, assign, nonatomic) BOOL dismissButtonHidden;
        [Export("dismissButtonHidden")]
		bool GetInAppMessageDismissButtonHidden();
		//bool DismissButtonHidden { [Bind("isDismissButtonHidden")] get; }

        // @property (readonly, assign, nonatomic) LLInAppMessageDismissButtonLocation dismissButtonLocation;
        [Export("dismissButtonLocation", ArgumentSemantic.Assign)]
        LLInAppMessageDismissButtonLocation DismissButtonLocation();

        //// @property (readonly, copy, nonatomic) NSString * _Nonnull eventName;
        //[Export ("eventName")]
        //string EventName { get; }
        //      DismissButtonLocation
        //// @property (readonly, copy, nonatomic) NSDictionary * _Nullable eventAttributes;
        //[NullAllowed, Export ("eventAttributes", ArgumentSemantic.Copy)]
        //NSDictionary EventAttributes { get; }
    }

    // @interface LLRegion : NSObject
    [BaseType(typeof(NSObject))]
    public interface LLRegion
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
    public interface LLGeofence
    {
        // @property (readonly, copy, nonatomic) CLCircularRegion * _Nonnull region;
        [Export("region", ArgumentSemantic.Copy)]
        CLCircularRegion CircularRegion { get; }
    }

    // @protocol LLInboxCampaignsRefreshingDelegate <NSObject>
    [Model]
    [BaseType(typeof(NSObject))]
    public interface LLInboxCampaignsRefreshingDelegate
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
    [Model]
    public interface LLInboxViewController : IUITableViewDelegate, IUITableViewDataSource, LLInboxCampaignsRefreshingDelegate
    {
        // @property (nonatomic, strong) UITableView * _Nonnull tableView;
        [Export("tableView", ArgumentSemantic.Strong)]
        UITableView TableView { get; set; }

        // @property (nonatomic, strong) NSArray * _Nullable tableData;
        [NullAllowed, Export("tableData", ArgumentSemantic.Strong)]
        NSObject[] TableData { get; set; }

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
    [BaseType(typeof(NSObject), Name = "Localytics")]
    partial interface Localytics
    {
        // @required +(void)autoIntegrate:(NSString * _Nonnull)appKey withLocalyticsOptions:(NSDictionary * _Nullable)localyticsOptions launchOptions:(NSDictionary * _Nullable)launchOptions;
        [Static]
        [Export("autoIntegrate:withLocalyticsOptions:launchOptions:")]
        [Protected]
        void AutoIntegratePrivate(string appKey,  NSDictionary localyticsOptions,  NSDictionary launchOptions);

        // @required +(void)integrate:(NSString * _Nonnull)appKey withLocalyticsOptions:(NSDictionary * _Nullable)localyticsOptions;
        [Static]
		[Export("integrate:withLocalyticsOptions:")]
        [Protected]
        void IntegratePrivate(string appKey,  NSDictionary localyticsOptions);
 
        // @required +(void)openSession;
        [Static]
        [Export("openSession")]
        void OpenSession();

        // @required +(void)closeSession;
        [Static]
        [Export("closeSession")]
        void CloseSession();

        // @required +(void)upload;
        [Static]
        [Export("upload")]
        void Upload();

        // @required +(void)tagEvent:(NSString * _Nonnull)eventName;
        [Static]
        [Export("tagEvent:")]
        void TagEvent(string eventName);

        // @required +(void)tagEvent:(NSString * _Nonnull)eventName attributes:(NSDictionary<NSString *,NSString *> * _Nullable)attributes;
        [Static]
        [Export("tagEvent:attributes:")]
        void TagEvent(string eventName,  NSDictionary attributes);

        // @required +(void)tagEvent:(NSString * _Nonnull)eventName attributes:(NSDictionary<NSString *,NSString *> * _Nullable)attributes customerValueIncrease:(NSNumber * _Nullable)customerValueIncrease;
        [Static]
        [Export("tagEvent:attributes:customerValueIncrease:")]
        void TagEvent(string eventName,  NSDictionary attributes,  NSNumber customerValueIncrease);

        // @required +(void)tagPurchased:(NSString * _Nullable)itemName itemId:(NSString * _Nullable)itemId itemType:(NSString * _Nullable)itemType itemPrice:(NSNumber * _Nullable)itemPrice attributes:(NSDictionary<NSString *,NSString *> * _Nullable)attributes;
        [Static]
        [Export("tagPurchased:itemId:itemType:itemPrice:attributes:")]
        void TagPurchased( string itemName,  string itemId,  string itemType,  NSNumber itemPrice,  NSDictionary attributes);

        // @required +(void)tagAddedToCart:(NSString * _Nullable)itemName itemId:(NSString * _Nullable)itemId itemType:(NSString * _Nullable)itemType itemPrice:(NSNumber * _Nullable)itemPrice attributes:(NSDictionary<NSString *,NSString *> * _Nullable)attributes;
        [Static]
        [Export("tagAddedToCart:itemId:itemType:itemPrice:attributes:")]
        void TagAddedToCart( string itemName,  string itemId,  string itemType,  NSNumber itemPrice,  NSDictionary attributes);

        // @required +(void)tagStartedCheckout:(NSNumber * _Nullable)totalPrice itemCount:(NSNumber * _Nullable)itemCount attributes:(NSDictionary<NSString *,NSString *> * _Nullable)attributes;
        [Static]
        [Export("tagStartedCheckout:itemCount:attributes:")]
        void TagStartedCheckout( NSNumber totalPrice,  NSNumber itemCount,  NSDictionary attributes);
        
        // @required +(void)tagCompletedCheckout:(NSNumber * _Nullable)totalPrice itemCount:(NSNumber * _Nullable)itemCount attributes:(NSDictionary<NSString *,NSString *> * _Nullable)attributes;
        [Static]
        [Export("tagCompletedCheckout:itemCount:attributes:")]
        void TagCompletedCheckout( NSNumber totalPrice,  NSNumber itemCount,  NSDictionary attributes);

        // @required +(void)tagContentViewed:(NSString * _Nullable)contentName contentId:(NSString * _Nullable)contentId contentType:(NSString * _Nullable)contentType attributes:(NSDictionary<NSString *,NSString *> * _Nullable)attributes;
        [Static]
        [Export("tagContentViewed:contentId:contentType:attributes:")]
        void TagContentViewed( string contentName,  string contentId,  string contentType,  NSDictionary attributes);

        // @required +(void)tagSearched:(NSString * _Nullable)queryText contentType:(NSString * _Nullable)contentType resultCount:(NSNumber * _Nullable)resultCount attributes:(NSDictionary<NSString *,NSString *> * _Nullable)attributes;
        [Static]
        [Export("tagSearched:contentType:resultCount:attributes:")]
        void TagSearched( string queryText,  string contentType,  NSNumber resultCount,  NSDictionary attributes);

        // @required +(void)tagShared:(NSString * _Nullable)contentName contentId:(NSString * _Nullable)contentId contentType:(NSString * _Nullable)contentType methodName:(NSString * _Nullable)methodName attributes:(NSDictionary<NSString *,NSString *> * _Nullable)attributes;
        [Static]
        [Export("tagShared:contentId:contentType:methodName:attributes:")]
		void TagShared( string contentName,  string contentId,  string contentType,  [NullAllowed]string methodName,  [NullAllowed]NSDictionary attributes);

        // @required +(void)tagContentRated:(NSString * _Nullable)contentName contentId:(NSString * _Nullable)contentId contentType:(NSString * _Nullable)contentType rating:(NSNumber * _Nullable)rating attributes:(NSDictionary<NSString *,NSString *> * _Nullable)attributes;
        [Static]
        [Export("tagContentRated:contentId:contentType:rating:attributes:")]
        void TagContentRated( string contentName,  string contentId,  string contentType,  NSNumber rating,  NSDictionary attributes);

        // @required +(void)tagCustomerRegistered:(LLCustomer * _Nullable)customer methodName:(NSString * _Nullable)methodName attributes:(NSDictionary<NSString *,NSString *> * _Nullable)attributes;
        [Static]
        [Export("tagCustomerRegistered:methodName:attributes:")]
		[Protected]
        void TagCustomerRegisteredPrivate( LLCustomer customer,  string methodName,  NSDictionary attributes);

        // @required +(void)tagCustomerLoggedIn:(LLCustomer * _Nullable)customer methodName:(NSString * _Nullable)methodName attributes:(NSDictionary<NSString *,NSString *> * _Nullable)attributes;
        [Static]
        [Export("tagCustomerLoggedIn:methodName:attributes:")]
		[Protected]
		void TagCustomerLoggedInPrivate( LLCustomer customer, [NullAllowed]string methodName,  [NullAllowed]NSDictionary attributes);

        // @required +(void)tagCustomerLoggedOut:(NSDictionary<NSString *,NSString *> * _Nullable)attributes;
        [Static]
        [Export("tagCustomerLoggedOut:")]
        void TagCustomerLoggedOut(NSDictionary attributes);

        // @required +(void)tagInvited:(NSString * _Nullable)methodName attributes:(NSDictionary<NSString *,NSString *> * _Nullable)attributes;
        [Static]
        [Export("tagInvited:attributes:")]
		void TagInvited( [NullAllowed]string methodName,  [NullAllowed]NSDictionary attributes);

        // @required +(void)tagScreen:(NSString * _Nonnull)screenName;
        [Static]
        [Export("tagScreen:")]
        void TagScreen(string screenName);

        // @required +(void)setValue:(NSString * _Nullable)value forCustomDimension:(NSUInteger)dimension;
        [Static]
        [Export("setValue:forCustomDimension:")]
		void SetCustomDimension([NullAllowed] string value, nuint dimension);

        // @required +(NSString * _Nullable)valueForCustomDimension:(NSUInteger)dimension;
        [Static]
        [Export("valueForCustomDimension:")]
        [return: NullAllowed]
        string GetCustomDimension(nuint dimension);

        // @required +(void)setValue:(NSString * _Nullable)value forIdentifier:(NSString * _Nonnull)identifier;
        [Static]
        [Export("setValue:forIdentifier:")]
        [Protected]
        void SetIdentifierPrivate(string identifier, [NullAllowed] string value);

        // @required +(NSString * _Nullable)valueForIdentifier:(NSString * _Nonnull)identifier;
        [Static]
        [Export("valueForIdentifier:")]
        [return: NullAllowed]
        string GetIdentifier(string identifier);

        // @required +(NSString * _Nullable)customerId;
        // @required +(void)setCustomerId:(NSString * _Nullable)customerId;
        [Static]
        [NullAllowed, Export("customerId")]
		string CustomerId { get;  set; }

        // @required +(void)setLocation:(CLLocationCoordinate2D)location;
        [Static]
        [Export("setLocation:")]
        void SetLocation(CLLocationCoordinate2D location);

        // @required +(void)setValue:(id _Nonnull)value forProfileAttribute:(NSString * _Nonnull)attribute withScope:(LLProfileScope)scope;
        [Static]
        [Export("setValue:forProfileAttribute:withScope:")]
        void SetProfileAttribute(NSObject value, string attribute, LLProfileScope scope);

        // @required +(void)setValue:(id _Nonnull)value forProfileAttribute:(NSString * _Nonnull)attribute;
        //[Static]
        //[Export("setValue:forProfileAttribute:")]
        //void SetProfileAttribute(NSObject value, string attribute);

        // @required +(void)addValues:(NSArray * _Nonnull)values toSetForProfileAttribute:(NSString * _Nonnull)attribute withScope:(LLProfileScope)scope;
        [Static]
        [Export("addValues:toSetForProfileAttribute:withScope:")]
		void AddProfileAttributesToSetPrivate(NSArray values, string attribute, LLProfileScope scope);

        // @required +(void)addValues:(NSArray * _Nonnull)values toSetForProfileAttribute:(NSString * _Nonnull)attribute;
        //[Static]
        //[Export("addValues:toSetForProfileAttribute:")]
		//void AddProfileAttributesToSet(NSArray values, string attribute);

        // @required +(void)removeValues:(NSArray * _Nonnull)values fromSetForProfileAttribute:(NSString * _Nonnull)attribute withScope:(LLProfileScope)scope;
        [Static]
        [Export("removeValues:fromSetForProfileAttribute:withScope:")]
		[Protected]
		void RemoveProfileAttributesFromSetPrivate(NSArray values, string attribute, LLProfileScope scope);

        // @required +(void)removeValues:(NSArray * _Nonnull)values fromSetForProfileAttribute:(NSString * _Nonnull)attribute;
        //[Static]
        //[Export("removeValues:fromSetForProfileAttribute:")]
        //void RemoveProfileAttributesFromSet(NSObject[] values, string attribute);

        // @required +(void)incrementValueBy:(NSInteger)value forProfileAttribute:(NSString * _Nonnull)attribute withScope:(LLProfileScope)scope;
        [Static]
        [Export("incrementValueBy:forProfileAttribute:withScope:")]
        void IncrementProfileAttribute(nint value, string attribute, LLProfileScope scope);

        // @required +(void)incrementValueBy:(NSInteger)value forProfileAttribute:(NSString * _Nonnull)attribute;
        //[Static]
        //[Export("incrementValueBy:forProfileAttribute:")]
        //void IncrementProfileAttribute(nint value, string attribute);

        // @required +(void)decrementValueBy:(NSInteger)value forProfileAttribute:(NSString * _Nonnull)attribute withScope:(LLProfileScope)scope;
        [Static]
        [Export("decrementValueBy:forProfileAttribute:withScope:")]
        void DecrementProfileAttribute(nint value, string attribute, LLProfileScope scope);

        // @required +(void)decrementValueBy:(NSInteger)value forProfileAttribute:(NSString * _Nonnull)attribute;
        //[Static]
        //[Export("decrementValueBy:forProfileAttribute:")]
        //void DecrementProfileAttribute(nint value, string attribute);

        // @required +(void)deleteProfileAttribute:(NSString * _Nonnull)attribute withScope:(LLProfileScope)scope;
        [Static]
        [Export("deleteProfileAttribute:withScope:")]
        void DeleteProfileAttribute(string attribute, LLProfileScope scope);

        // @required +(void)deleteProfileAttribute:(NSString * _Nonnull)attribute;
        //[Static]
        //[Export("deleteProfileAttribute:")]
        //void DeleteProfileAttribute(string attribute);

        // @required +(void)setCustomerEmail:(NSString * _Nullable)email;
        [Static]
        [Export("setCustomerEmail:")]
		void SetCustomerEmail([NullAllowed] string email);

        // @required +(void)setCustomerFirstName:(NSString * _Nullable)firstName;
        [Static]
        [Export("setCustomerFirstName:")]
		void SetCustomerFirstName([NullAllowed] string firstName);

        // @required +(void)setCustomerLastName:(NSString * _Nullable)lastName;
        [Static]
        [Export("setCustomerLastName:")]
		void SetCustomerLastName([NullAllowed] string lastName);

        // @required +(void)setCustomerFullName:(NSString * _Nullable)fullName;
        [Static]
        [Export("setCustomerFullName:")]
		void SetCustomerFullName([NullAllowed] string fullName);

		// @required +(NSString * _Nullable)pushToken;
		[Static]
		[Export("pushToken")]
		string PushToken();

        // @required +(void)setPushToken:(NSData * _Nullable)pushToken;
        [Static]
        [Export("setPushToken:")]
		void SetPushToken([NullAllowed] NSData pushToken);

        // @required +(void)redirectLoggingToDisk;
        [Static]
        [Export("redirectLoggingToDisk")]
        void RedirectLoggingToDisk();

        // @required +(BOOL)isPrivacyOptedOut;
        [Static]
        [Export("isPrivacyOptedOut")]
		[Protected]
        bool IsPrivacyOptedOutPrivate();

        // @required +(void)setPrivacyOptedOut:(BOOL)optedOut;
        [Static]
        [Export("setPrivacyOptedOut:")]
		[Protected]
        void SetPrivacyOptedOutPrivate(bool optedOut);

        // @required +(void)handleNotification:(NSDictionary * _Nonnull)notificationInfo;
        [Static]
        [Export("handleNotification:")]
        void HandleNotification(NSDictionary notificationInfo);

        // @required +(void)handleNotification:(NSDictionary * _Nonnull)notificationInfo withActionIdentifier:(NSString * _Nullable)identifier;
        [Static]
        [Export("handleNotification:withActionIdentifier:")]
        void HandleNotification(NSDictionary notificationInfo,  string identifier);

        // @required +(void)didReceiveNotificationResponseWithUserInfo:(NSDictionary * _Nonnull)userInfo;
        [Static]
        [Export("didReceiveNotificationResponseWithUserInfo:")]
        void DidReceiveNotificationResponseWithUserInfo(NSDictionary userInfo);

        // @required +(void)didReceiveNotificationResponseWithUserInfo:(NSDictionary * _Nonnull)userInfo andActionIdentifier:(NSString * _Nullable)identifier;
        [Static]
        [Export("didReceiveNotificationResponseWithUserInfo:andActionIdentifier:")]
        void DidReceiveNotificationResponseWithUserInfo(NSDictionary userInfo,  string identifier);

        // @required +(void)didRegisterUserNotificationSettings;
        [Static]
        [Export("didRegisterUserNotificationSettings")]
        void DidRegisterUserNotificationSettings();

        // @required +(void)didRequestUserNotificationAuthorizationWithOptions:(NSUInteger)options granted:(BOOL)granted;
        [Static]
        [Export("didRequestUserNotificationAuthorizationWithOptions:granted:")]
        void DidRequestUserNotificationAuthorizationWithOptions(nuint options, bool granted);

        // @required +(BOOL)handleTestModeURL:(NSURL * _Nonnull)url;
        [Static]
        [Export("handleTestModeURL:")]
        bool HandleTestModeURL(NSUrl url);

        // @required +(void)setInAppMessageDismissButtonImage:(UIImage * _Nullable)image;
        [Static]
        [Export("setInAppMessageDismissButtonImage:")]
		void SetInAppMessageDismissButtonImage([NullAllowed] UIImage image);

        // @required +(void)setInAppMessageDismissButtonImageWithName:(NSString * _Nullable)imageName;
        [Static]
        [Export("setInAppMessageDismissButtonImageWithName:")]
		void SetInAppMessageDismissButtonImageWithName([NullAllowed] string imageName);

        // @required +(LLInAppMessageDismissButtonLocation)inAppMessageDismissButtonLocation;
        // @required +(void)setInAppMessageDismissButtonLocation:(LLInAppMessageDismissButtonLocation)location;
        [Static]
        [Export("inAppMessageDismissButtonLocation")]
        LLInAppMessageDismissButtonLocation InAppMessageDismissButtonLocation { get; set; }

        // @required +(void)setInAppMessageDismissButtonHidden:(BOOL)hidden;
        [Static]
        [Export("setInAppMessageDismissButtonHidden:")]
        void SetInAppMessageDismissButtonHidden(bool hidden);

        // @required +(void)triggerInAppMessage:(NSString * _Nonnull)triggerName;
        [Static]
        [Export("triggerInAppMessage:")]
		void TriggerInAppMessageInternal(string triggerName);

        // @required +(void)triggerInAppMessage:(NSString * _Nonnull)triggerName withAttributes:(NSDictionary<NSString *,NSString *> * _Nonnull)attributes;
        [Static]
        [Export("triggerInAppMessage:withAttributes:")]
        void TriggerInAppMessage(string triggerName, NSDictionary attributes);

        // @required +(void)dismissCurrentInAppMessage;
        [Static]
        [Export("dismissCurrentInAppMessage")]
        void DismissCurrentInAppMessage();

        // @required +(NSArray<LLInboxCampaign *> * _Nonnull)inboxCampaigns;
        [Static]
        [Export("inboxCampaigns")]
        LLInboxCampaign[] InboxCampaigns { get; }

        // @required +(void)refreshInboxCampaigns:(void (^ _Nonnull)(NSArray<LLInboxCampaign *> * _Nullable))completionBlock;
        [Static]
        [Export("refreshInboxCampaigns:")]
        void RefreshInboxCampaigns(Action<LLInboxCampaign[]> completionBlock);

        // @required +(void)setInboxCampaign:(LLInboxCampaign * _Nonnull)campaign asRead:(BOOL)read;
        [Static]
        [Export("setInboxCampaign:asRead:")]
        void SetInboxCampaignRead(LLInboxCampaign campaign, bool read);

		// @required +(NSInteger)inboxCampaignsUnreadCount;
		[Static]
		[Export("inboxCampaignsUnreadCount")]
		nint InboxCampaignsUnreadCount { get; }

        // @required +(LLInboxDetailViewController * _Nonnull)inboxDetailViewControllerForCampaign:(LLInboxCampaign * _Nonnull)campaign;
        [Static]
        [Export("inboxDetailViewControllerForCampaign:")]
        LLInboxDetailViewController InboxDetailViewControllerForCampaign(LLInboxCampaign campaign);

        // @required +(void)setLocationMonitoringEnabled:(BOOL)enabled;
        [Static]
        [Export("setLocationMonitoringEnabled:")]
        void SetLocationMonitoringEnabled(bool enabled);

        // @required +(NSArray<LLRegion *> * _Nonnull)geofencesToMonitor:(CLLocationCoordinate2D)currentCoordinate;
        [Static]
        [Export("geofencesToMonitor:")]
        LLRegion[] GeofencesToMonitor(CLLocationCoordinate2D currentCoordinate);

        // @required +(void)triggerRegion:(CLRegion * _Nonnull)region withEvent:(LLRegionEvent)event atLocation:(CLLocation * _Nullable)location;
        [Static]
        [Export("triggerRegion:withEvent:atLocation:")]
		void TriggerRegion(CLRegion region, LLRegionEvent regionEvent,  CLLocation location);

        // @required +(void)triggerRegions:(NSArray<CLRegion *> * _Nonnull)regions withEvent:(LLRegionEvent)event atLocation:(CLLocation * _Nullable)location;
        [Static]
        [Export("triggerRegions:withEvent:atLocation:")]
		void TriggerRegions(CLRegion[] regions, LLRegionEvent regionEvent,  CLLocation location);

        // @required +(void)setOptions:(NSDictionary<NSString *,NSObject *> * _Nullable)options;
        [Static]
        [Export("setOptions:")]
		void SetOptions([NullAllowed] NSDictionary options);

        // @required +(BOOL)isLoggingEnabled;
        [Static]
        [Export("isLoggingEnabled")]
		[Protected]
        bool IsLoggingEnabledPrivate { get; }

        // @required +(void)setLoggingEnabled:(BOOL)loggingEnabled;
        [Static]
        [Export("setLoggingEnabled:")]
		[Protected]
		void SetLoggingEnabledPrivate(bool loggingEnabled);

        /*
         //+(BOOL)isCollectingAdvertisingIdentifier;
        [Static]
        [Export ("isCollectingAdvertisingIdentifier")]
        bool IsCollectingAdvertisingIdentifier { get; }

        // +(void)setCollectAdvertisingIdentifier:(BOOL)collectAdvertisingIdentifier;
        [Static]
        [Export ("setCollectAdvertisingIdentifier:")]
        void SetCollectAdvertisingIdentifier (bool collectAdvertisingIdentifier);

        */
        // @required +(BOOL)isOptedOut;
        [Static]
        [Export("isOptedOut")]
        bool IsOptedOut { get; }

        // @required +(void)setOptedOut:(BOOL)optedOut;
        [Static]
        [Export("setOptedOut:")]
        void SetOptedOut(bool optedOut);

        // @required +(BOOL)isTestModeEnabled;
        [Static]
        [Export("isTestModeEnabled")]
		[Protected]
        bool IsTestModeEnabled { get; }

        // @required +(void)setTestModeEnabled:(BOOL)enabled;
        [Static]
        [Export("setTestModeEnabled:")]
		[Protected]
        void SetTestModeEnabled(bool enabled);

        // @required +(NSString * _Nullable)installId;
        [Static]
        [NullAllowed, Export("installId")]
        //string InstallId();
        string InstallId { get; }

        // @required +(NSString * _Nonnull)libraryVersion;
        [Static]
        [Export("libraryVersion")]
        string LibraryVersion { get; }

        // @required +(NSString * _Nullable)appKey;
        [Static]
        [NullAllowed, Export("appKey")]
        string AppKey { get; }

        // @required +(void)setMessagingDelegate:(id<LLMessagingDelegate> _Nullable)delegate;
        [Static]
        [Export("setMessagingDelegate:")]
        [Protected]
		void SetMessagingDelegatePrivate([NullAllowed] LLMessagingDelegate @delegate);

		// @required +(BOOL)isInAppAdIdParameterEnabled;
		[Static]
		[Export("isInAppAdIdParameterEnabled")]
        bool IsAdidAppendedToInAppUrls { get; }

        // @required +(void)setInAppAdIdParameterEnabled:(BOOL)enabled;
        [Static]
        [Export("setInAppAdIdParameterEnabled:")]
        void AppendAdidToInAppUrls(bool enabled);

        // @required +(void)setAnalyticsDelegate:(id<LLAnalyticsDelegate> _Nullable)delegate;
        [Static]
        [Export("setAnalyticsDelegate:")]
		[Protected]
		void SetAnalyticsDelegatePrivate([NullAllowed] LLAnalyticsDelegate @delegate);

        // @required +(void)setLocationDelegate:(id<LLLocationDelegate> _Nullable)delegate;
        [Static]
        [Export("setLocationDelegate:")]
		[Protected]
		void SetLocationDelegatePrivate([NullAllowed] LLLocationDelegate @delegate);

        // @required +(void)pauseDataUploading:(BOOL)pause;
        [Static]
        [Export("pauseDataUploading:")]
        void PauseDataUploading(bool pause);

        // @required +(void)setCustomerId:(NSString * _Nullable)customerId privacyOptedOut:(BOOL)optedOut;
        [Static]
        [Export("setCustomerId:privacyOptedOut:")]
        void SetCustomerIdWithPrivacyOptedOut([NullAllowed] string customerId, bool optedOut);

        // @required +(void)triggerInAppMessagesForSessionStart;
        [Static]
        [Export("triggerInAppMessagesForSessionStart")]
        void TriggerInAppMessagesForSessionStart();

        // @required +(void)tagImpressionForInAppCampaign:(LLInAppCampaign * _Nonnull)campaign withType:(LLImpressionType)impressionType;
        [Static]
        [Export("tagImpressionForInAppCampaign:withType:")]
        void TagInAppImpression(LLInAppCampaign campaign, LLImpressionType impressionType);

        // @required +(void)tagImpressionForInAppCampaign:(LLInAppCampaign * _Nonnull)campaign withCustomAction:(NSString * _Nonnull)customAction;
        [Static]
        [Export("tagImpressionForInAppCampaign:withCustomAction:")]
        void TagInAppImpression(LLInAppCampaign campaign, string customAction);

        // @required +(NSArray<LLInboxCampaign *> * _Nonnull)allInboxCampaigns;
        [Static]
		[Export("allInboxCampaigns")]
		LLInboxCampaign[] AllInboxCampaigns { get; }

        // @required +(void)refreshAllInboxCampaigns:(void (^ _Nonnull)(NSArray<LLInboxCampaign *> * _Nullable))completionBlock;
        [Static]
        [Export("refreshAllInboxCampaigns:")]
		void RefreshAllInboxCampaigns(Action<LLInboxCampaign[]> completionBlock);

        // @required +(void)tagImpressionForInboxCampaign:(LLInboxCampaign * _Nonnull)campaign withType:(LLImpressionType)impressionType;
        [Static]
        [Export("tagImpressionForInboxCampaign:withType:")]
		void TagInboxImpression(LLInboxCampaign campaign, LLImpressionType impressionType);

        // @required +(void)tagImpressionForInboxCampaign:(LLInboxCampaign * _Nonnull)campaign withCustomAction:(NSString * _Nonnull)customAction;
        [Static]
        [Export("tagImpressionForInboxCampaign:withCustomAction:")]
		void TagInboxImpression(LLInboxCampaign campaign, string customAction);

        // @required +(void)tagImpressionForPushToInboxCampaign:(LLInboxCampaign * _Nonnull)campaign success:(BOOL)success;
        [Static]
        [Export("tagImpressionForPushToInboxCampaign:success:")]
        void TagImpressionForPushToInboxCampaign(LLInboxCampaign campaign, bool success);

        // @required +(void)inboxListItemTapped:(LLInboxCampaign * _Nonnull)campaign;
        [Static]
        [Export("inboxListItemTapped:")]
        void InboxListItemTapped(LLInboxCampaign campaign);

        // @required +(void)tagPlacesPushReceived:(LLPlacesCampaign * _Nonnull)campaign;
        [Static]
        [Export("tagPlacesPushReceived:")]
		[Protected]
        void TagPlacesPushReceivedPrivate(LLPlacesCampaign campaign);

        // @required +(void)tagPlacesPushOpened:(LLPlacesCampaign * _Nonnull)campaign;
        [Static]
        [Export("tagPlacesPushOpened:")]
		[Protected]
		void TagPlacesPushOpenedPrivate(LLPlacesCampaign campaign);

        // @required +(void)tagPlacesPushOpened:(LLPlacesCampaign * _Nonnull)campaign withActionIdentifier:(NSString * _Nonnull)identifier;
        [Static]
        [Export("tagPlacesPushOpened:withActionIdentifier:")]
		[Protected]
		void TagPlacesPushOpenedPrivate(LLPlacesCampaign campaign, string identifier);

        // @required +(void)triggerPlacesNotificationForCampaign:(LLPlacesCampaign * _Nonnull)campaign;
        [Static]
        [Export("triggerPlacesNotificationForCampaign:")]
		void TriggerPlacesNotification(LLPlacesCampaign campaign);

        // @required +(void)triggerPlacesNotificationForCampaignId:(NSInteger)campaignId regionIdentifier:(NSString * _Nonnull)regionId;
        [Static]
        [Export("triggerPlacesNotificationForCampaignId:regionIdentifier:")]
		void TriggerPlacesNotification(nint campaignId, string regionId);

        // @required +(BOOL)isInboxAdIdParameterEnabled;
        [Static]
        [Export("isInboxAdIdParameterEnabled")]
        bool IsAdidAppendedToInboxUrls { get; }

        // @required +(void)setInboxAdIdParameterEnabled:(BOOL)enabled;
        [Static]
        [Export("setInboxAdIdParameterEnabled:")]
        void AppendAdidToInboxUrls(bool enabled);
    }

    // @protocol LLAnalyticsDelegate <NSObject>
    [BaseType(typeof(NSObject))]
    [Protocol]
    interface LLAnalyticsDelegate
    {
        // @optional -(void)localyticsSessionWillOpen:(BOOL)isFirst isUpgrade:(BOOL)isUpgrade isResume:(BOOL)isResume;
        [Export("localyticsSessionWillOpen:isUpgrade:isResume:")]
        void LocalyticsSessionWillOpen(bool isFirst, bool isUpgrade, bool isResume);

        // @optional -(void)localyticsSessionDidOpen:(BOOL)isFirst isUpgrade:(BOOL)isUpgrade isResume:(BOOL)isResume;
        [Export("localyticsSessionDidOpen:isUpgrade:isResume:")]
        void LocalyticsSessionDidOpen(bool isFirst, bool isUpgrade, bool isResume);

        // @optional -(void)localyticsDidTagEvent:(NSString * _Nonnull)eventName attributes:(NSDictionary<NSString *,NSString *> * _Nullable)attributes customerValueIncrease:(NSNumber * _Nullable)customerValueIncrease;
        [Export("localyticsDidTagEvent:attributes:customerValueIncrease:")]
		void LocalyticsDidTagEvent(string eventName, [NullAllowed] NSDictionary attributes,  NSNumber customerValueIncrease);

        // @optional -(void)localyticsSessionWillClose;
        [Export("localyticsSessionWillClose")]
        void LocalyticsSessionWillClose();
    }

    // @protocol LLMessagingDelegate <NSObject>
    [Model] [Protocol]
    [BaseType(typeof(NSObject))]
    interface LLMessagingDelegate
    {
        // @optional -(BOOL)localyticsShouldShowInAppMessage:(LLInAppCampaign * _Nonnull)campaign;
        //[Export("localyticsShouldShowInAppMessage:"), DelegateName("InAppShouldShowCondition"), DefaultValue("true")]
        [Export("localyticsShouldShowInAppMessage:")]
        bool LocalyticsShouldShowInAppMessage(LLInAppCampaign campaign);

        // @optional -(BOOL)localyticsShouldDelaySessionStartInAppMessages;
        [Export("localyticsShouldDelaySessionStartInAppMessages"), DelegateName("InAppShouldBeDelayedCondition"), DefaultValue("false")]
        bool LocalyticsShouldDelaySessionStartInAppMessages();

        // @optional -(LLInAppConfiguration * _Nonnull)localyticsWillDisplayInAppMessage:(LLInAppCampaign * _Nonnull)campaign withConfiguration:(LLInAppConfiguration * _Nonnull)configuration;
        [Export ("localyticsWillDisplayInAppMessage:withConfiguration:")]
		LLInAppConfiguration LocalyticsWillDisplayInAppMessage (LLInAppCampaign campaign, LLInAppConfiguration configuration);

        // @optional -(void)localyticsDidDisplayInAppMessage;
        [Export("localyticsDidDisplayInAppMessage")]
        void LocalyticsDidDisplayInAppMessage();

        // @optional -(void)localyticsWillDismissInAppMessage;
        [Export("localyticsWillDismissInAppMessage")]
        void LocalyticsWillDismissInAppMessage();

        // @optional -(void)localyticsDidDismissInAppMessage;
        [Export("localyticsDidDismissInAppMessage")]
        void LocalyticsDidDismissInAppMessage();

        // @optional -(void)localyticsWillDisplayInboxDetailViewController;
        [Export("localyticsWillDisplayInboxDetailViewController")]
        void LocalyticsWillDisplayInboxDetailViewController();

        // @optional -(void)localyticsDidDisplayInboxDetailViewController;
        [Export("localyticsDidDisplayInboxDetailViewController")]
        void LocalyticsDidDisplayInboxDetailViewController();

        // @optional -(void)localyticsWillDismissInboxDetailViewController;
        [Export("localyticsWillDismissInboxDetailViewController")]
        void LocalyticsWillDismissInboxDetailViewController();

        // @optional -(void)localyticsDidDismissInboxDetailViewController;
        [Export("localyticsDidDismissInboxDetailViewController")]
        void LocalyticsDidDismissInboxDetailViewController();

        // @optional -(BOOL)localyticsShouldDisplayPlacesCampaign:(LLPlacesCampaign * _Nonnull)campaign;
        [Export("localyticsShouldDisplayPlacesCampaign:")]
        bool LocalyticsShouldDisplayPlacesCampaign(LLPlacesCampaign campaign);

        // @optional -(UILocalNotification * _Nonnull)localyticsWillDisplayNotification:(UILocalNotification * _Nonnull)notification forPlacesCampaign:(LLPlacesCampaign * _Nonnull)campaign;
        [Export("localyticsWillDisplayNotification:forPlacesCampaign:")]
        UILocalNotification LocalyticsWillDisplayNotification(UILocalNotification notification, LLPlacesCampaign campaign);

        // @optional -(UNMutableNotificationContent * _Nonnull)localyticsWillDisplayNotificationContent:(UNMutableNotificationContent * _Nonnull)notification forPlacesCampaign:(LLPlacesCampaign * _Nonnull)campaign;
        [Export("localyticsWillDisplayNotificationContent:forPlacesCampaign:"), DelegateName("WillDisplayNotificationContentCondition"), DefaultValueFromArgument("notification")]
        UNMutableNotificationContent LocalyticsWillDisplayNotificationContent(UNMutableNotificationContent notification, LLPlacesCampaign campaign);

        // @optional -(BOOL)localyticsShouldDeeplink:(NSURL * _Nonnull)url;
        [Export("localyticsShouldDeeplink:"), DelegateName("ShouldDeepLinkCondition"), DefaultValue("true")]
        bool LocalyticsShouldDeeplink(NSUrl url);
    }

    // @protocol LLLocationDelegate <NSObject>
    [Model]
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

    // @interface LLInAppConfiguration : NSObject
    [BaseType(typeof(NSObject))]
    public interface LLInAppConfiguration
    {
        // @property (assign, nonatomic) LLInAppMessageDismissButtonLocation dismissButtonLocation;
        [Export("dismissButtonLocation", ArgumentSemantic.Assign)]
        LLInAppMessageDismissButtonLocation DismissButtonLocation { get; set; }

        // @property (nonatomic, strong) UIImage * _Nullable dismissButtonImage;
        [NullAllowed, Export("dismissButtonImage", ArgumentSemantic.Strong)]
        UIImage DismissButtonImage { get; set; }

        // @property (assign, nonatomic) BOOL dismissButtonHidden;
        [Export("dismissButtonHidden")]
        bool DismissButtonHidden { get; set; }

        // @property (assign, nonatomic) CGFloat aspectRatio;
        [Export("aspectRatio")]
        nfloat AspectRatio { get; set; }

        // @property (assign, nonatomic) CGFloat offset;
        [Export("offset")]
        nfloat Offset { get; set; }

        // @property (assign, nonatomic) CGFloat backgroundAlpha;
        [Export("backgroundAlpha")]
        nfloat BackgroundAlpha { get; set; }

        // -(BOOL)isCenterCampaign;
        [Export("isCenterCampaign")]
        bool IsCenterCampaign();

        // -(BOOL)isTopBannerCampaign;
        [Export("isTopBannerCampaign")]
        bool IsTopBannerCampaign();

        // -(BOOL)isBottomBannerCampaign;
        [Export("isBottomBannerCampaign")]
        bool IsBottomBannerCampaign();

        // -(BOOL)isFullScreenCampaign;
        [Export("isFullScreenCampaign")]
        bool IsFullScreenCampaign();

        // -(void)setDismissButtonImageWithName:(NSString * _Nonnull)imageName;
        [Export("setDismissButtonImageWithName:")]
        void SetDismissButtonImageWithName(string imageName);
    }

    // @interface LLInboxDetailViewController : UIViewController
    [BaseType(typeof(UIViewController))]
    public interface LLInboxDetailViewController
    {
        // @property (readonly, nonatomic, strong) LLInboxCampaign * _Nonnull campaign;
        [Export("campaign", ArgumentSemantic.Strong)]
        LLInboxCampaign Campaign { get; }

        // @property (nonatomic, strong) UIView * _Nullable creativeLoadErrorView;
        [NullAllowed, Export("creativeLoadErrorView", ArgumentSemantic.Strong)]
        UIView CreativeLoadErrorView { get; set; }
    }
}
