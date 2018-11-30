using System;
using CoreLocation;
using Foundation;
//using Localytics;
using ObjCRuntime;
using UIKit;
using UserNotifications;

namespace LocalyticsXamarin.IOS
{
	// @interface LLCustomerBuilder : NSObject
	[BaseType (typeof(NSObject))]
	public interface LLCustomerBuilder
	{
		// @property (nonatomic, strong) NSString * _Nullable customerId;
		[NullAllowed, Export ("customerId", ArgumentSemantic.Strong)]
		string CustomerId { get; set; }

		// @property (nonatomic, strong) NSString * _Nullable firstName;
		[NullAllowed, Export ("firstName", ArgumentSemantic.Strong)]
		string FirstName { get; set; }

		// @property (nonatomic, strong) NSString * _Nullable lastName;
		[NullAllowed, Export ("lastName", ArgumentSemantic.Strong)]
		string LastName { get; set; }

		// @property (nonatomic, strong) NSString * _Nullable fullName;
		[NullAllowed, Export ("fullName", ArgumentSemantic.Strong)]
		string FullName { get; set; }

		// @property (nonatomic, strong) NSString * _Nullable emailAddress;
		[NullAllowed, Export ("emailAddress", ArgumentSemantic.Strong)]
		string EmailAddress { get; set; }
	}

	// @interface LLCustomer : NSObject
	[BaseType (typeof(NSObject))]
	public interface LLCustomer
	{
		// @property (readonly, nonatomic, strong) NSString * _Nullable customerId;
		[NullAllowed, Export ("customerId", ArgumentSemantic.Strong)]
		string CustomerId { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nullable firstName;
		[NullAllowed, Export ("firstName", ArgumentSemantic.Strong)]
		string FirstName { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nullable lastName;
		[NullAllowed, Export ("lastName", ArgumentSemantic.Strong)]
		string LastName { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nullable fullName;
		[NullAllowed, Export ("fullName", ArgumentSemantic.Strong)]
		string FullName { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nullable emailAddress;
		[NullAllowed, Export ("emailAddress", ArgumentSemantic.Strong)]
		string EmailAddress { get; }

		// +(instancetype _Nullable)customerWithBlock:(void (^ _Nonnull)(LLCustomerBuilder * _Nonnull))block;
		[Export ("customerWithBlock:")]
		[return: NullAllowed]
		[Static]
		LLCustomer CustomerWithBlock (Action<LLCustomerBuilder> block);
	}

	// @interface LLCampaignBase : NSObject
	[BaseType (typeof(NSObject))]
	public interface LLCampaignBase
	{
		// @property (readonly, assign, nonatomic) NSInteger campaignId;
		[Export ("campaignId")]
		nint CampaignId { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull name;
		[Export ("name")]
		string Name { get; }

		// @property (readonly, copy, nonatomic) NSDictionary<NSString *,NSString *> * _Nullable attributes;
		[NullAllowed, Export ("attributes", ArgumentSemantic.Copy)]
		NSDictionary Attributes { get; }
		//TODONEXTRELEASE - NSDictionary<NSString, NSString> Attributes { get; }
	}

	// @interface LLWebViewCampaign : LLCampaignBase
	[BaseType (typeof(LLCampaignBase))]
	public interface LLWebViewCampaign
	{
		// @property (readonly, copy, nonatomic) NSString * _Nullable creativeFilePath;
		[NullAllowed, Export ("creativeFilePath")]
		string CreativeFilePath { get; }
	}

	// @interface LLInboxCampaign : LLWebViewCampaign
	[BaseType (typeof(LLWebViewCampaign))]
	public interface LLInboxCampaign
	{
		// @property (getter = isRead, assign, nonatomic) BOOL read;
		[Export ("read")]
		bool Read { [Bind ("isRead")] get; set; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable titleText;
		[NullAllowed, Export ("titleText")]
		string TitleText { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable summaryText;
		[NullAllowed, Export ("summaryText")]
		string SummaryText { get; }

		// @property (readonly, copy, nonatomic) NSURL * _Nullable thumbnailUrl;
		[NullAllowed, Export ("thumbnailUrl", ArgumentSemantic.Copy)]
		NSUrl ThumbnailUrl { get; }

		// @property (readonly, assign, nonatomic) BOOL hasCreative;
		[Export ("hasCreative")]
		bool HasCreative { get; }

		// @property (readonly, assign, nonatomic) NSInteger sortOrder;
		[Export ("sortOrder")]
		nint SortOrder { get; }

		// @property (readonly, assign, nonatomic) NSTimeInterval receivedDate;
		[Export ("receivedDate")]
		double ReceivedDate { get; }

		// @property (readonly, copy, nonatomic) NSURL * _Nullable deepLinkURL;
		[NullAllowed, Export ("deepLinkURL", ArgumentSemantic.Copy)]
		NSUrl DeepLinkURL { get; }

		// @property (readonly, assign, nonatomic) BOOL isPushToInboxCampaign;
		[Export ("isPushToInboxCampaign")]
		bool IsPushToInboxCampaign { get; }

	        // @property(nonatomic, assign, getter= isDeleted, readonly) BOOL deleted;
	        [Export("isDeleted")]
	        bool IsDeleted { get; }

		// -(void)delete;
		[Export ("delete")]
		void Delete ();
	}

	// @interface LLPlacesCampaign : LLCampaignBase
	[BaseType (typeof(LLCampaignBase))]
	public interface LLPlacesCampaign
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull message;
		[Export ("message")]
		string Message { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable soundFilename;
		[NullAllowed, Export ("soundFilename")]
		string SoundFilename { get; }

		// @property (readonly, copy, nonatomic) LLRegion * _Nonnull region;
		[Export ("region", ArgumentSemantic.Copy)]
		LLRegion Region { get; }

		// @property (readonly, assign, nonatomic) LLRegionEvent event;
		[Export ("event", ArgumentSemantic.Assign)]
		LLRegionEvent Event { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable category;
		[NullAllowed, Export ("category")]
		string Category { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable attachmentURL;
		[NullAllowed, Export ("attachmentURL")]
		string AttachmentUrl { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable attachmentType;
		[NullAllowed, Export ("attachmentType")]
		string AttachmentType { get; }
	}

	// @interface LLInAppCampaign : LLWebViewCampaign
	[BaseType (typeof(LLWebViewCampaign))]
	public interface LLInAppCampaign
	{
		// @property (readonly, assign, nonatomic) LLInAppMessageType type;
		[Export ("type", ArgumentSemantic.Assign)]
		LLInAppMessageType Type { get; }

		// @property (readonly, assign, nonatomic) BOOL isResponsive;
		[Export ("isResponsive")]
		bool IsResponsive { get; }

		// @property (readonly, assign, nonatomic) CGFloat aspectRatio;
		[Export ("aspectRatio")]
		nfloat AspectRatio { get; }

		// @property (readonly, assign, nonatomic) CGFloat offset;
		[Export ("offset")]
		nfloat Offset { get; }

		// @property (readonly, assign, nonatomic) CGFloat backgroundAlpha;
		[Export ("backgroundAlpha")]
		nfloat BackgroundAlpha { get; }

		// @property (readonly, getter = isDismissButtonHidden, assign, nonatomic) BOOL dismissButtonHidden;
		[Export ("dismissButtonHidden")]
		bool IsDismissButtonHidden { [Bind ("isDismissButtonHidden")] get; }

		// @property (readonly, assign, nonatomic) LLInAppMessageDismissButtonLocation dismissButtonLocation;
		[Export ("dismissButtonLocation", ArgumentSemantic.Assign)]
        LLInAppMessageDismissButtonLocation DismissButtonLocation { get; }


        // @property (readonly, copy, nonatomic) NSString * _Nonnull eventName;
        [Export ("eventName")]
		string EventName { get; }

		// @property (readonly, copy, nonatomic) NSDictionary * _Nullable eventAttributes;
		[NullAllowed, Export ("eventAttributes", ArgumentSemantic.Copy)]
		NSDictionary EventAttributes { get; }
	}

	// @interface LLRegion : NSObject
	[BaseType (typeof(NSObject))]
	public interface LLRegion
	{
		// @property (readonly, copy, nonatomic) NSString * _Nullable name;
		[NullAllowed, Export ("name")]
		string Name { get; }

		// @property (readonly, copy, nonatomic) NSDictionary<NSString *,NSString *> * _Nullable attributes;
		[NullAllowed, Export ("attributes", ArgumentSemantic.Copy)]
		NSDictionary Attributes { get; }

		// @property (readonly, copy, nonatomic) CLRegion * _Nonnull region;
		[Export ("region", ArgumentSemantic.Copy)]
		CLRegion Region { get; }
	}

	// @interface LLGeofence : LLRegion
	[BaseType (typeof(LLRegion))]
	public interface LLGeofence
	{
		// @property (readonly, copy, nonatomic) CLCircularRegion * _Nonnull region;
		[Export ("region", ArgumentSemantic.Copy)]
		CLCircularRegion CircularRegion { get; }
	}

	// @protocol LLInboxCampaignsRefreshingDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	public interface LLInboxCampaignsRefreshingDelegate
	{
		// @optional -(void)localyticsDidBeginRefreshingInboxCampaigns;
		[Export ("localyticsDidBeginRefreshingInboxCampaigns")]
		void LocalyticsDidBeginRefreshingInboxCampaigns ();

		// @optional -(void)localyticsDidFinishRefreshingInboxCampaigns;
		[Export ("localyticsDidFinishRefreshingInboxCampaigns")]
		void LocalyticsDidFinishRefreshingInboxCampaigns ();
	}

	// @interface LLInboxViewController : UIViewController <UITableViewDelegate, UITableViewDataSource, LLInboxCampaignsRefreshingDelegate>
	[BaseType (typeof(UIViewController))]
	[Model]
	public interface LLInboxViewController : IUITableViewDelegate, IUITableViewDataSource, LLInboxCampaignsRefreshingDelegate
	{
		// @property (nonatomic, strong) UITableView * _Nonnull tableView;
		[Export ("tableView", ArgumentSemantic.Strong)]
		UITableView TableView { get; set; }

		// @property (nonatomic, strong) NSArray * _Nullable tableData;
		[NullAllowed, Export ("tableData", ArgumentSemantic.Strong)]
		NSObject[] TableData { get; set; }

		// @property (nonatomic, strong) UIView * _Nonnull emptyCampaignsView;
		[Export ("emptyCampaignsView", ArgumentSemantic.Strong)]
		UIView EmptyCampaignsView { get; set; }

		// @property (assign, nonatomic) BOOL showsActivityIndicatorView;
		[Export ("showsActivityIndicatorView")]
		bool ShowsActivityIndicatorView { get; set; }

		// @property (assign, nonatomic) BOOL enableSwipeDelete;
		[Export ("enableSwipeDelete")]
		bool EnableSwipeDelete { get; set; }

		// @property (assign, nonatomic) BOOL enableDetailViewDelete;
		[Export ("enableDetailViewDelete")]
		bool EnableDetailViewDelete { get; set; }

		// @property (assign, nonatomic) BOOL downloadsThumbnails;
		[Export ("downloadsThumbnails")]
		bool DownloadsThumbnails { get; set; }

		// @property (nonatomic, strong) UIFont * _Nonnull textLabelFont;
		[Export ("textLabelFont", ArgumentSemantic.Strong)]
		UIFont TextLabelFont { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull textLabelColor;
		[Export ("textLabelColor", ArgumentSemantic.Strong)]
		UIColor TextLabelColor { get; set; }

		// @property (nonatomic, strong) UIFont * _Nonnull detailTextLabelFont;
		[Export ("detailTextLabelFont", ArgumentSemantic.Strong)]
		UIFont DetailTextLabelFont { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull detailTextLabelColor;
		[Export ("detailTextLabelColor", ArgumentSemantic.Strong)]
		UIColor DetailTextLabelColor { get; set; }

		// @property (nonatomic, strong) UIFont * _Nonnull timeTextLabelFont;
		[Export ("timeTextLabelFont", ArgumentSemantic.Strong)]
		UIFont TimeTextLabelFont { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull timeTextLabelColor;
		[Export ("timeTextLabelColor", ArgumentSemantic.Strong)]
		UIColor TimeTextLabelColor { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull unreadIndicatorColor;
		[Export ("unreadIndicatorColor", ArgumentSemantic.Strong)]
		UIColor UnreadIndicatorColor { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull cellBackgroundColor;
		[Export ("cellBackgroundColor", ArgumentSemantic.Strong)]
		UIColor CellBackgroundColor { get; set; }

		// @property (nonatomic, strong) UIView * _Nullable creativeLoadErrorView;
		[NullAllowed, Export ("creativeLoadErrorView", ArgumentSemantic.Strong)]
		UIView CreativeLoadErrorView { get; set; }

		// -(LLInboxCampaign * _Nullable)campaignForRowAtIndexPath:(NSIndexPath * _Nonnull)indexPath;
		[Export ("campaignForRowAtIndexPath:")]
		[return: NullAllowed]
		LLInboxCampaign CampaignForRowAtIndexPath (NSIndexPath indexPath);
	}

	// @interface LLInboxDetailViewController : UIViewController
	[BaseType (typeof(UIViewController))]
	public interface LLInboxDetailViewController
	{
		// @property (readonly, nonatomic, strong) LLInboxCampaign * _Nonnull campaign;
		[Export ("campaign", ArgumentSemantic.Strong)]
		LLInboxCampaign Campaign { get; }

		// @property (nonatomic, strong) UIView * _Nullable creativeLoadErrorView;
		[NullAllowed, Export ("creativeLoadErrorView", ArgumentSemantic.Strong)]
		UIView CreativeLoadErrorView { get; set; }

		// @property (assign, nonatomic) BOOL deleteInNavBar;
		[Export ("deleteInNavBar")]
		bool DeleteInNavBar { get; set; }
	}

	// @interface LLInAppConfiguration : NSObject
	[BaseType (typeof(NSObject))]
	public interface LLInAppConfiguration
	{
		// @property (assign, nonatomic) LLInAppMessageDismissButtonLocation dismissButtonLocation;
		[Export ("dismissButtonLocation", ArgumentSemantic.Assign)]
		LLInAppMessageDismissButtonLocation DismissButtonLocation { get; set; }

		// @property (nonatomic, strong) UIImage * _Nullable dismissButtonImage;
		[NullAllowed, Export ("dismissButtonImage", ArgumentSemantic.Strong)]
		UIImage DismissButtonImage { get; set; }

		// @property (assign, nonatomic) BOOL dismissButtonHidden;
		[Export ("dismissButtonHidden")]
		bool DismissButtonHidden { get; set; }

		// @property (assign, nonatomic) CGFloat aspectRatio;
		[Export ("aspectRatio")]
		nfloat AspectRatio { get; set; }

		// @property (assign, nonatomic) CGFloat offset;
		[Export ("offset")]
		nfloat Offset { get; set; }

		// @property (assign, nonatomic) CGFloat backgroundAlpha;
		[Export ("backgroundAlpha")]
		nfloat BackgroundAlpha { get; set; }

		// @property (assign, nonatomic) BOOL autoHideHomeScreenIndicator;
		[Export ("autoHideHomeScreenIndicator")]
		bool AutoHideHomeScreenIndicator { get; set; }

		// @property (assign, nonatomic) BOOL notchFullScreen;
		[Export ("notchFullScreen")]
		bool NotchFullScreen { get; set; }

		// -(BOOL)isCenterCampaign;
		[Export ("isCenterCampaign")]
		bool IsCenterCampaign();

		// -(BOOL)isTopBannerCampaign;
		[Export ("isTopBannerCampaign")]
		bool IsTopBannerCampaign();

		// -(BOOL)isBottomBannerCampaign;
		[Export ("isBottomBannerCampaign")]
		bool IsBottomBannerCampaign();

		// -(BOOL)isFullScreenCampaign;
		[Export ("isFullScreenCampaign")]
		bool IsFullScreenCampaign();

		// -(void)setDismissButtonImageWithName:(NSString * _Nonnull)imageName;
		[Export ("setDismissButtonImageWithName:")]
		void SetDismissButtonImageWithName (string imageName);
	}

	// @interface Localytics : NSObject
	[BaseType(typeof(NSObject), Name = "Localytics")]
	partial interface Localytics
	{
        // @required +(void)autoIntegrate:(NSString * _Nonnull)appKey withLocalyticsOptions:(NSDictionary * _Nullable)localyticsOptions launchOptions:(NSDictionary * _Nullable)launchOptions __attribute__((availability(ios, introduced=8_0)));
        [Introduced(PlatformName.iOS, 8, 0)]
        [Static]
		[Export ("autoIntegrate:withLocalyticsOptions:launchOptions:")]
		[Protected]
		void AutoIntegratePrivate(string appKey, [NullAllowed] NSDictionary localyticsOptions, [NullAllowed] NSDictionary launchOptions);

        // @required +(void)integrate:(NSString * _Nonnull)appKey withLocalyticsOptions:(NSDictionary * _Nullable)localyticsOptions __attribute__((availability(ios, introduced=8_0)));
        [Introduced(PlatformName.iOS, 8, 0)]
        [Static]
		[Export ("integrate:withLocalyticsOptions:")]
		[Protected]
		void IntegratePrivate(string appKey, [NullAllowed] NSDictionary localyticsOptions);

        // @required +(void)openSession __attribute__((availability(ios, introduced=8_0)));
        [Introduced(PlatformName.iOS, 8, 0)]
        [Static]
		[Export ("openSession")]
		[Internal]
		void OpenSession ();

		// @required +(void)closeSession __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Static]
		[Export ("closeSession")]
		[Internal]
		void CloseSession ();

        // @required +(void)upload __attribute__((availability(ios, introduced=8_0)));
        [Introduced(PlatformName.iOS, 8, 0)]
        [Static]
		[Export ("upload")]
		void Upload ();

        // @required +(void)pauseDataUploading:(BOOL)pause __attribute__((availability(ios, introduced=8_0)));
        [Introduced(PlatformName.iOS, 8, 0)]
        [Static]
		[Export ("pauseDataUploading:")]
		void PauseDataUploading (bool pause);

        // @required +(void)tagEvent:(NSString * _Nonnull)eventName __attribute__((availability(ios, introduced=8_0)));
        [Introduced(PlatformName.iOS, 8, 0)]
        [Static]
		[Export ("tagEvent:")]
		[Internal]
		void TagEvent (string eventName);

        // @required +(void)tagEvent:(NSString * _Nonnull)eventName attributes:(NSDictionary<NSString *,NSString *> * _Nullable)attributes __attribute__((availability(ios, introduced=8_0)));
        [Introduced(PlatformName.iOS, 8, 0)]
        [Static]
		[Export ("tagEvent:attributes:")]
		[Internal]
		void TagEvent(string eventName, NSDictionary attributes);

        // @required +(void)tagEvent:(NSString * _Nonnull)eventName attributes:(NSDictionary<NSString *,NSString *> * _Nullable)attributes customerValueIncrease:(NSNumber * _Nullable)customerValueIncrease __attribute__((availability(ios, introduced=8_0)));
        [Introduced(PlatformName.iOS, 8, 0)]
        [Static]
		[Export ("tagEvent:attributes:customerValueIncrease:")]
		[Internal]
		void TagEvent (string eventName, [NullAllowed] NSDictionary attributes, [NullAllowed] NSNumber customerValueIncrease);

		// @required +(void)tagPurchased:(NSString * _Nullable)itemName itemId:(NSString * _Nullable)itemId itemType:(NSString * _Nullable)itemType itemPrice:(NSNumber * _Nullable)itemPrice attributes:(NSDictionary<NSString *,NSString *> * _Nullable)attributes __attribute__((availability(ios, introduced=8_0)));
		[Introduced(PlatformName.iOS, 8, 0)]
        [Static]
		[Export ("tagPurchased:itemId:itemType:itemPrice:attributes:")]
		[Internal]
		void TagPurchased ([NullAllowed] string itemName, [NullAllowed] string itemId, [NullAllowed] string itemType, [NullAllowed] NSNumber itemPrice, [NullAllowed] NSDictionary attributes);

        // @required +(void)tagAddedToCart:(NSString * _Nullable)itemName itemId:(NSString * _Nullable)itemId itemType:(NSString * _Nullable)itemType itemPrice:(NSNumber * _Nullable)itemPrice attributes:(NSDictionary<NSString *,NSString *> * _Nullable)attributes __attribute__((availability(ios, introduced=8_0)));
        [Introduced(PlatformName.iOS, 8, 0)]
        [Static]
		[Export ("tagAddedToCart:itemId:itemType:itemPrice:attributes:")]
		[Internal]
		void TagAddedToCart ([NullAllowed] string itemName, [NullAllowed] string itemId, [NullAllowed] string itemType, [NullAllowed] NSNumber itemPrice, [NullAllowed] NSDictionary attributes);

        // @required +(void)tagStartedCheckout:(NSNumber * _Nullable)totalPrice itemCount:(NSNumber * _Nullable)itemCount attributes:(NSDictionary<NSString *,NSString *> * _Nullable)attributes __attribute__((availability(ios, introduced=8_0)));
        [Introduced(PlatformName.iOS, 8, 0)]
        [Static]
		[Export ("tagStartedCheckout:itemCount:attributes:")]
		[Internal]
		void TagStartedCheckout ([NullAllowed] NSNumber totalPrice, [NullAllowed] NSNumber itemCount, [NullAllowed] NSDictionary attributes);

        // @required +(void)tagCompletedCheckout:(NSNumber * _Nullable)totalPrice itemCount:(NSNumber * _Nullable)itemCount attributes:(NSDictionary<NSString *,NSString *> * _Nullable)attributes __attribute__((availability(ios, introduced=8_0)));
        [Introduced(PlatformName.iOS, 8, 0)]
        [Static]
		[Export ("tagCompletedCheckout:itemCount:attributes:")]
		void TagCompletedCheckout ([NullAllowed] NSNumber totalPrice, [NullAllowed] NSNumber itemCount, [NullAllowed] NSDictionary attributes);

        // @required +(void)tagContentViewed:(NSString * _Nullable)contentName contentId:(NSString * _Nullable)contentId contentType:(NSString * _Nullable)contentType attributes:(NSDictionary<NSString *,NSString *> * _Nullable)attributes __attribute__((availability(ios, introduced=8_0)));
        [Introduced(PlatformName.iOS, 8, 0)]
        [Static]
		[Export ("tagContentViewed:contentId:contentType:attributes:")]
		[Internal]
		void TagContentViewed ([NullAllowed] string contentName, [NullAllowed] string contentId, [NullAllowed] string contentType, [NullAllowed] NSDictionary attributes);

        // @required +(void)tagSearched:(NSString * _Nullable)queryText contentType:(NSString * _Nullable)contentType resultCount:(NSNumber * _Nullable)resultCount attributes:(NSDictionary<NSString *,NSString *> * _Nullable)attributes __attribute__((availability(ios, introduced=8_0)));
        [Introduced(PlatformName.iOS, 8, 0)]
        [Static]
		[Export ("tagSearched:contentType:resultCount:attributes:")]
		[Internal]
		void TagSearched ([NullAllowed] string queryText, [NullAllowed] string contentType, [NullAllowed] NSNumber resultCount, [NullAllowed] NSDictionary attributes);

        // @required +(void)tagShared:(NSString * _Nullable)contentName contentId:(NSString * _Nullable)contentId contentType:(NSString * _Nullable)contentType methodName:(NSString * _Nullable)methodName attributes:(NSDictionary<NSString *,NSString *> * _Nullable)attributes __attribute__((availability(ios, introduced=8_0)));
        [Introduced(PlatformName.iOS, 8, 0)]
        [Static]
		[Export ("tagShared:contentId:contentType:methodName:attributes:")]
		[Internal]
		void TagShared ([NullAllowed] string contentName, [NullAllowed] string contentId, [NullAllowed] string contentType, [NullAllowed] string methodName, [NullAllowed] NSDictionary attributes);

        // @required +(void)tagContentRated:(NSString * _Nullable)contentName contentId:(NSString * _Nullable)contentId contentType:(NSString * _Nullable)contentType rating:(NSNumber * _Nullable)rating attributes:(NSDictionary<NSString *,NSString *> * _Nullable)attributes __attribute__((availability(ios, introduced=8_0)));
        [Introduced(PlatformName.iOS, 8, 0)]
        [Static]
		[Export ("tagContentRated:contentId:contentType:rating:attributes:")]
		[Internal]
		void TagContentRated ([NullAllowed] string contentName, [NullAllowed] string contentId, [NullAllowed] string contentType, [NullAllowed] NSNumber rating, [NullAllowed] NSDictionary attributes);

        // @required +(void)tagCustomerRegistered:(LLCustomer * _Nullable)customer methodName:(NSString * _Nullable)methodName attributes:(NSDictionary<NSString *,NSString *> * _Nullable)attributes __attribute__((availability(ios, introduced=8_0)));
        [Introduced(PlatformName.iOS, 8, 0)]
        [Static]
		[Export ("tagCustomerRegistered:methodName:attributes:")]
		[Protected]
		void TagCustomerRegisteredPrivate ([NullAllowed] LLCustomer customer, [NullAllowed] string methodName, [NullAllowed] NSDictionary attributes);

        // @required +(void)tagCustomerLoggedIn:(LLCustomer * _Nullable)customer methodName:(NSString * _Nullable)methodName attributes:(NSDictionary<NSString *,NSString *> * _Nullable)attributes __attribute__((availability(ios, introduced=8_0)));
        [Introduced(PlatformName.iOS, 8, 0)]
        [Static]
		[Export ("tagCustomerLoggedIn:methodName:attributes:")]
		[Protected]
		void TagCustomerLoggedInPrivate ([NullAllowed] LLCustomer customer, [NullAllowed] string methodName, [NullAllowed] NSDictionary attributes);

        // @required +(void)tagCustomerLoggedOut:(NSDictionary<NSString *,NSString *> * _Nullable)attributes __attribute__((availability(ios, introduced=8_0)));
        [Introduced(PlatformName.iOS, 8, 0)]
        [Static]
		[Export ("tagCustomerLoggedOut:")]
		[Internal]
		void TagCustomerLoggedOut ([NullAllowed] NSDictionary attributes);

        // @required +(void)tagInvited:(NSString * _Nullable)methodName attributes:(NSDictionary<NSString *,NSString *> * _Nullable)attributes __attribute__((availability(ios, introduced=8_0)));
        [Introduced(PlatformName.iOS, 8, 0)]
        [Static]
		[Export ("tagInvited:attributes:")]
		[Internal]
		void TagInvited ([NullAllowed] string methodName, [NullAllowed] NSDictionary attributes);

        // @required +(void)tagScreen:(NSString * _Nonnull)screenName __attribute__((availability(ios, introduced=8_0)));
        [Introduced(PlatformName.iOS, 8, 0)]
        [Static]
		[Export ("tagScreen:")]
		[Internal]
		void TagScreen (string screenName);

        // @required +(void)setValue:(NSString * _Nullable)value forCustomDimension:(NSUInteger)dimension __attribute__((availability(ios, introduced=8_0)));
        [Introduced(PlatformName.iOS, 8, 0)]
        [Static]
		[Export ("setValue:forCustomDimension:")]
		[Internal]
		void SetCustomDimension ([NullAllowed] string value, nuint dimension);

        // @required +(NSString * _Nullable)valueForCustomDimension:(NSUInteger)dimension __attribute__((availability(ios, introduced=8_0)));
        [Introduced(PlatformName.iOS, 8, 0)]
        [Static]
		[Export ("valueForCustomDimension:")]
		[return: NullAllowed]
		[Internal]
		string GetCustomDimension (nuint dimension);

        // @required +(void)setValue:(NSString * _Nullable)value forIdentifier:(NSString * _Nonnull)identifier __attribute__((availability(ios, introduced=8_0)));
        [Introduced(PlatformName.iOS, 8, 0)]
        [Static]
		[Export ("setValue:forIdentifier:")]
		[Protected]
		void SetIdentifierPrivate ([NullAllowed] string value, string identifier);

        // @required +(NSString * _Nullable)valueForIdentifier:(NSString * _Nonnull)identifier __attribute__((availability(ios, introduced=8_0)));
        [Introduced(PlatformName.iOS, 8, 0)]
        [Static]
		[Export ("valueForIdentifier:")]
		[return: NullAllowed]
		[Internal]
		string GetIdentifier (string identifier);

        // @required +(void)setCustomerId:(NSString * _Nullable)customerId privacyOptedOut:(BOOL)optedOut __attribute__((availability(ios, introduced=8_0)));
        [Introduced(PlatformName.iOS, 8, 0)]
        [Static]
		[Export ("setCustomerId:privacyOptedOut:")]
		[Internal]
		void SetCustomerIdWithPrivacyOptedOut ([NullAllowed] string customerId, bool optedOut);

        // @required +(NSString * _Nullable)customerId __attribute__((availability(ios, introduced=8_0)));
        // @required +(void)setCustomerId:(NSString * _Nullable)customerId __attribute__((availability(ios, introduced=8_0)));
        [Introduced(PlatformName.iOS, 8, 0)]
        [Static]
		[NullAllowed, Export ("customerId")]
		[Internal]
		string CustomerId { get; set; }

        // @required +(void)setValue:(id _Nonnull)value forProfileAttribute:(NSString * _Nonnull)attribute withScope:(LLProfileScope)scope __attribute__((availability(ios, introduced=8_0)));
        [Introduced(PlatformName.iOS, 8, 0)]
        [Static]
		[Export ("setValue:forProfileAttribute:withScope:")]
		[Internal]
		void SetProfileAttribute (NSObject value, string attribute, LLProfileScope scope);

        //// @required +(void)setValue:(id _Nonnull)value forProfileAttribute:(NSString * _Nonnull)attribute __attribute__((availability(ios, introduced=8_0)));
        //[Introduced (PlatformName.iOS, 8, 0)]
        //[Static]
        //[Export ("setValue:forProfileAttribute:")]
        //void SetProfileAttribute (NSObject value, string attribute);

        // @required +(void)addValues:(NSArray * _Nonnull)values toSetForProfileAttribute:(NSString * _Nonnull)attribute withScope:(LLProfileScope)scope __attribute__((availability(ios, introduced=8_0)));
        [Introduced(PlatformName.iOS, 8, 0)]
        [Static]
		[Export ("addValues:toSetForProfileAttribute:withScope:")]
		[Internal]
		void AddProfileAttributesToSetPrivate(NSArray values, string attribute, LLProfileScope scope);

        // @required +(void)addValues:(NSArray * _Nonnull)values toSetForProfileAttribute:(NSString * _Nonnull)attribute;
        //[Static]
        //[Export("addValues:toSetForProfileAttribute:")]
        //void AddProfileAttributesToSet(NSArray values, string attribute);

        // @required +(void)removeValues:(NSArray * _Nonnull)values fromSetForProfileAttribute:(NSString * _Nonnull)attribute withScope:(LLProfileScope)scope __attribute__((availability(ios, introduced=8_0)));
        [Introduced(PlatformName.iOS, 8, 0)]
        [Static]
		[Export ("removeValues:fromSetForProfileAttribute:withScope:")]
		[Protected]
		void RemoveProfileAttributesFromSetPrivate (NSArray values, string attribute, LLProfileScope scope);

        //// @required +(void)removeValues:(NSArray * _Nonnull)values fromSetForProfileAttribute:(NSString * _Nonnull)attribute __attribute__((availability(ios, introduced=8_0)));
        //[Introduced (PlatformName.iOS, 8, 0)]
        //[Static]
        //[Export ("removeValues:fromSetForProfileAttribute:")]
        //void RemoveProfileAttributesFromSet (NSObject[] values, string attribute);

        // @required +(void)incrementValueBy:(NSInteger)value forProfileAttribute:(NSString * _Nonnull)attribute withScope:(LLProfileScope)scope __attribute__((availability(ios, introduced=8_0)));
        [Introduced(PlatformName.iOS, 8, 0)]
        [Static]
		[Export ("incrementValueBy:forProfileAttribute:withScope:")]
		[Internal]
		void IncrementProfileAttribute (nint value, string attribute, LLProfileScope scope);

        //// @required +(void)incrementValueBy:(NSInteger)value forProfileAttribute:(NSString * _Nonnull)attribute __attribute__((availability(ios, introduced=8_0)));
        //[Introduced (PlatformName.iOS, 8, 0)]
        //[Static]
        //[Export ("incrementValueBy:forProfileAttribute:")]
        //void IncrementProfileAttribute (nint value, string attribute);

        // @required +(void)decrementValueBy:(NSInteger)value forProfileAttribute:(NSString * _Nonnull)attribute withScope:(LLProfileScope)scope __attribute__((availability(ios, introduced=8_0)));
        [Introduced(PlatformName.iOS, 8, 0)]
        [Static]
		[Export ("decrementValueBy:forProfileAttribute:withScope:")]
		[Internal]
		void DecrementProfileAttribute (nint value, string attribute, LLProfileScope scope);

        //// @required +(void)decrementValueBy:(NSInteger)value forProfileAttribute:(NSString * _Nonnull)attribute __attribute__((availability(ios, introduced=8_0)));
        //[Introduced (PlatformName.iOS, 8, 0)]
        //[Static]
        //[Export ("decrementValueBy:forProfileAttribute:")]
        //void DecrementProfileAttribute (nint value, string attribute);

        // @required +(void)deleteProfileAttribute:(NSString * _Nonnull)attribute withScope:(LLProfileScope)scope __attribute__((availability(ios, introduced=8_0)));
        [Introduced(PlatformName.iOS, 8, 0)]
        [Static]
		[Export ("deleteProfileAttribute:withScope:")]
		[Internal]
		void DeleteProfileAttribute (string attribute, LLProfileScope scope);

        //// @required +(void)deleteProfileAttribute:(NSString * _Nonnull)attribute __attribute__((availability(ios, introduced=8_0)));
        //[Introduced (PlatformName.iOS, 8, 0)]
        //[Static]
        //[Export ("deleteProfileAttribute:")]
        //void DeleteProfileAttribute (string attribute);

        // @required +(void)setCustomerEmail:(NSString * _Nullable)email __attribute__((availability(ios, introduced=8_0)));
        [Introduced(PlatformName.iOS, 8, 0)]
        [Static]
		[Export ("setCustomerEmail:")]
		[Internal]
		void SetCustomerEmail ([NullAllowed] string email);

        // @required +(void)setCustomerFirstName:(NSString * _Nullable)firstName __attribute__((availability(ios, introduced=8_0)));
        [Introduced(PlatformName.iOS, 8, 0)]
        [Static]
		[Export ("setCustomerFirstName:")]
		[Internal]
		void SetCustomerFirstName ([NullAllowed] string firstName);

        // @required +(void)setCustomerLastName:(NSString * _Nullable)lastName __attribute__((availability(ios, introduced=8_0)));
        [Introduced(PlatformName.iOS, 8, 0)]
        [Static]
		[Export ("setCustomerLastName:")]
		[Internal]
		void SetCustomerLastName ([NullAllowed] string lastName);

        // @required +(void)setCustomerFullName:(NSString * _Nullable)fullName __attribute__((availability(ios, introduced=8_0)));
        [Introduced(PlatformName.iOS, 8, 0)]
        [Static]
		[Export ("setCustomerFullName:")]
		[Internal]
		void SetCustomerFullName ([NullAllowed] string fullName);

        // @required +(void)setOptions:(NSDictionary<NSString *,NSObject *> * _Nullable)options __attribute__((availability(ios, introduced=8_0)));
        [Introduced(PlatformName.iOS, 8, 0)]
        [Static]
		[Export ("setOptions:")]
		void SetOptions ([NullAllowed] NSDictionary options);

        // @required +(BOOL)isLoggingEnabled __attribute__((availability(ios, introduced=8_0)));
        [Introduced(PlatformName.iOS, 8, 0)]
        [Static]
		[Export ("isLoggingEnabled")]
		[Protected]
		bool IsLoggingEnabledPrivate { get; }

        // @required +(void)setLoggingEnabled:(BOOL)loggingEnabled __attribute__((availability(ios, introduced=8_0)));
        [Introduced(PlatformName.iOS, 8, 0)]
        [Static]
		[Export ("setLoggingEnabled:")]
		[Protected]
		void SetLoggingEnabledPrivate(bool loggingEnabled);

		// @required +(void)redirectLoggingToDisk __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Static]
		[Export ("redirectLoggingToDisk")]
		void RedirectLoggingToDisk ();

		// @required +(BOOL)isOptedOut __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Static]
		[Export ("isOptedOut")]
		[Internal]
		bool IsOptedOut { get; }

		// @required +(void)setOptedOut:(BOOL)optedOut __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Static]
		[Export ("setOptedOut:")]
		[Internal]
		void SetOptedOut (bool optedOut);

		// @required +(BOOL)isPrivacyOptedOut __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Static]
		[Export ("isPrivacyOptedOut")]
		[Protected]
		bool IsPrivacyOptedOutPrivate();

		// @required +(void)setPrivacyOptedOut:(BOOL)optedOut __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Static]
		[Export ("setPrivacyOptedOut:")]
		[Protected]
		void SetPrivacyOptedOutPrivate(bool optedOut);

		// @required +(NSString * _Nullable)installId __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Static]
		[NullAllowed, Export ("installId")]
		[Internal]
		string InstallId { get; }

		// @required +(NSString * _Nonnull)libraryVersion __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Static]
		[Export ("libraryVersion")]
		[Internal]
		string LibraryVersion { get; }

		// @required +(NSString * _Nullable)appKey __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Static]
		[NullAllowed, Export ("appKey")]
		[Internal]
		string AppKey { get; }

		// @required +(BOOL)isTestModeEnabled __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Static]
		[Export ("isTestModeEnabled")]
		[Protected]
		bool IsTestModeEnabled { get; }

		// @required +(void)setTestModeEnabled:(BOOL)enabled __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Static]
		[Export ("setTestModeEnabled:")]
		[Protected]
		void SetTestModeEnabled (bool enabled);

		// @required +(void)setAnalyticsDelegate:(id<LLAnalyticsDelegate> _Nullable)delegate __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Static]
		[Export ("setAnalyticsDelegate:")]
		[Internal]
		void SetAnalyticsDelegate ([NullAllowed] LLAnalyticsDelegate @delegate);

		// @required +(void)setLocation:(CLLocationCoordinate2D)location __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Static]
		[Export ("setLocation:")]
		void SetLocation (CLLocationCoordinate2D location);

		// @required +(NSString * _Nullable)pushToken __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Static]
		[NullAllowed, Export ("pushToken")]
		[Internal]
		string PushToken();

		// @required +(void)setPushToken:(NSData * _Nullable)pushToken __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Static]
		[Export ("setPushToken:")]
		void SetPushToken ([NullAllowed] NSData pushToken);

		// @required +(void)handleNotification:(NSDictionary * _Nonnull)notificationInfo __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Static]
		[Export ("handleNotification:")]
		void HandleNotification (NSDictionary notificationInfo);

		// @required +(void)handleNotification:(NSDictionary * _Nonnull)notificationInfo withActionIdentifier:(NSString * _Nullable)identifier __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Static]
		[Export ("handleNotification:withActionIdentifier:")]
		void HandleNotification (NSDictionary notificationInfo, [NullAllowed] string identifier);

        // @required +(void)didReceiveNotificationResponseWithUserInfo:(NSDictionary * _Nonnull)userInfo __attribute__((availability(ios, introduced=10_0)));
        [Introduced(PlatformName.iOS, 10, 0)]
		[Static]
		[Export ("didReceiveNotificationResponseWithUserInfo:")]
		void DidReceiveNotificationResponseWithUserInfo (NSDictionary userInfo);

        // @required +(void)didReceiveNotificationResponseWithUserInfo:(NSDictionary * _Nonnull)userInfo andActionIdentifier:(NSString * _Nullable)identifier __attribute__((availability(ios, introduced=10_0)));
        [Introduced(PlatformName.iOS, 10, 0)]
		[Static]
		[Export ("didReceiveNotificationResponseWithUserInfo:andActionIdentifier:")]
		void DidReceiveNotificationResponseWithUserInfo (NSDictionary userInfo, [NullAllowed] string identifier);

		// @required +(void)didRegisterUserNotificationSettings __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Static]
		[Export ("didRegisterUserNotificationSettings")]
		void DidRegisterUserNotificationSettings ();

		// @required +(void)didRequestUserNotificationAuthorizationWithOptions:(NSUInteger)options granted:(BOOL)granted __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Static]
		[Export ("didRequestUserNotificationAuthorizationWithOptions:granted:")]
		void DidRequestUserNotificationAuthorizationWithOptions (nuint options, bool granted);

		// @required +(BOOL)handleTestModeURL:(NSURL * _Nonnull)url __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Static]
		[Export ("handleTestModeURL:")]
		bool HandleTestModeURL (NSUrl url);

		// @required +(void)setInAppMessageDismissButtonImage:(UIImage * _Nullable)image __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Static]
		[Export ("setInAppMessageDismissButtonImage:")]
		void SetInAppMessageDismissButtonImage ([NullAllowed] UIImage image);

		// @required +(void)setInAppMessageDismissButtonImageWithName:(NSString * _Nullable)imageName __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Static]
		[Export ("setInAppMessageDismissButtonImageWithName:")]
		void SetInAppMessageDismissButtonImageWithName ([NullAllowed] string imageName);

		// @required +(LLInAppMessageDismissButtonLocation)inAppMessageDismissButtonLocation __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Static]
		[Export ("inAppMessageDismissButtonLocation")]
		[Internal]
		LLInAppMessageDismissButtonLocation GetInAppMessageDismissButtonLocation();

		// @required +(void)setInAppMessageDismissButtonLocation:(LLInAppMessageDismissButtonLocation)location __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Static]
		[Export("setInAppMessageDismissButtonLocation:")]
		[Internal]
		void SetInAppMessageDismissButtonLocation(LLInAppMessageDismissButtonLocation dismissButtonLocation);

		// @required +(void)setInAppMessageDismissButtonHidden:(BOOL)hidden __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Static]
		[Export ("setInAppMessageDismissButtonHidden:")]
		[Internal]
		void SetInAppMessageDismissButtonHidden (bool hidden);

		// @required +(void)triggerInAppMessage:(NSString * _Nonnull)triggerName __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Static]
		[Export ("triggerInAppMessage:")]
		[Internal]
		void TriggerInAppMessageInternal (string triggerName);

		// @required +(void)triggerInAppMessage:(NSString * _Nonnull)triggerName withAttributes:(NSDictionary<NSString *,NSString *> * _Nonnull)attributes __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Static]
		[Export ("triggerInAppMessage:withAttributes:")]
		[Internal]
		void TriggerInAppMessage (string triggerName, NSDictionary attributes);

		// @required +(void)triggerInAppMessagesForSessionStart __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Static]
		[Export ("triggerInAppMessagesForSessionStart")]
		[Internal]
		void TriggerInAppMessagesForSessionStart ();

		// @required +(void)dismissCurrentInAppMessage __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Static]
		[Export ("dismissCurrentInAppMessage")]
		[Internal]
		void DismissCurrentInAppMessage ();

		// @required +(void)tagImpressionForInAppCampaign:(LLInAppCampaign * _Nonnull)campaign withType:(LLImpressionType)impressionType __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Static]
		[Export ("tagImpressionForInAppCampaign:withType:")]
		void TagInAppImpression (LLInAppCampaign campaign, LLImpressionType impressionType);

		// @required +(void)tagImpressionForInAppCampaign:(LLInAppCampaign * _Nonnull)campaign withCustomAction:(NSString * _Nonnull)customAction __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Static]
		[Export ("tagImpressionForInAppCampaign:withCustomAction:")]
		void TagInAppImpression (LLInAppCampaign campaign, string customAction);

		// @required +(NSArray<LLInboxCampaign *> * _Nonnull)inboxCampaigns __attribute__((deprecated("inboxCampaigns has been deprecated, please use displayableInboxCampaigns")));
		[Static]
		[Export ("inboxCampaigns")]
		[Internal]
		LLInboxCampaign[] InboxCampaigns { get; }

		// @required +(NSArray<LLInboxCampaign *> * _Nonnull)displayableInboxCampaigns __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Static]
		[Export ("displayableInboxCampaigns")]
        [Internal]
		LLInboxCampaign[] DisplayableInboxCampaigns { get; }

		// @required +(NSArray<LLInboxCampaign *> * _Nonnull)allInboxCampaigns __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Static]
		[Export ("allInboxCampaigns")]
		[Internal]
		LLInboxCampaign[] AllInboxCampaigns { get; }

		// @required +(void)refreshInboxCampaigns:(void (^ _Nonnull)(NSArray<LLInboxCampaign *> * _Nullable))completionBlock __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Static]
		[Export ("refreshInboxCampaigns:")]
		[Internal]
		void RefreshInboxCampaigns (Action<LLInboxCampaign[]> completionBlock);

		// @required +(void)refreshAllInboxCampaigns:(void (^ _Nonnull)(NSArray<LLInboxCampaign *> * _Nullable))completionBlock __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Static]
		[Export ("refreshAllInboxCampaigns:")]
		[Internal]
		void RefreshAllInboxCampaigns (Action<LLInboxCampaign[]> completionBlock);

		// @required +(void)setInboxCampaign:(LLInboxCampaign * _Nonnull)campaign asRead:(BOOL)read __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Static]
		[Export ("setInboxCampaign:asRead:")]
		[Internal]
		void SetInboxCampaignRead (LLInboxCampaign campaign, bool read);

		// @required +(void)deleteInboxCampaign:(LLInboxCampaign * _Nonnull)campaign __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Static]
		[Export ("deleteInboxCampaign:")]
        [Internal]
		void DeleteInboxCampaign (LLInboxCampaign campaign);

		// @required +(NSInteger)inboxCampaignsUnreadCount __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Static]
		[Export ("inboxCampaignsUnreadCount")]
		[Internal]
		nint InboxCampaignsUnreadCount { get; }

		// @required +(LLInboxDetailViewController * _Nonnull)inboxDetailViewControllerForCampaign:(LLInboxCampaign * _Nonnull)campaign __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Static]
		[Export ("inboxDetailViewControllerForCampaign:")]
		LLInboxDetailViewController InboxDetailViewControllerForCampaign (LLInboxCampaign campaign);

		// @required +(void)tagImpressionForInboxCampaign:(LLInboxCampaign * _Nonnull)campaign withType:(LLImpressionType)impressionType __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Static]
		[Export ("tagImpressionForInboxCampaign:withType:")]
		[Internal]
		void TagInboxImpression (LLInboxCampaign campaign, LLImpressionType impressionType);

		// @required +(void)tagImpressionForInboxCampaign:(LLInboxCampaign * _Nonnull)campaign withCustomAction:(NSString * _Nonnull)customAction __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Static]
		[Export ("tagImpressionForInboxCampaign:withCustomAction:")]
		[Internal]
		void TagInboxImpression (LLInboxCampaign campaign, string customAction);

		// @required +(void)tagImpressionForPushToInboxCampaign:(LLInboxCampaign * _Nonnull)campaign success:(BOOL)success __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Static]
		[Export ("tagImpressionForPushToInboxCampaign:success:")]
		void TagImpressionForPushToInboxCampaign (LLInboxCampaign campaign, bool success);

		// @required +(void)inboxListItemTapped:(LLInboxCampaign * _Nonnull)campaign __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Static]
		[Export ("inboxListItemTapped:")]
		[Internal]
		void InboxListItemTapped (LLInboxCampaign campaign);

		// @required +(void)setLocationMonitoringEnabled:(BOOL)enabled __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Static]
		[Export ("setLocationMonitoringEnabled:")]
		void SetLocationMonitoringEnabled (bool enabled);

		// @required +(void)persistLocationMonitoring:(BOOL)persist __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Static]
		[Export ("persistLocationMonitoring:")]
		void PersistLocationMonitoring (bool enableLocationMonitoring);

		// @required +(NSArray<LLRegion *> * _Nonnull)geofencesToMonitor:(CLLocationCoordinate2D)currentCoordinate __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Static]
		[Export ("geofencesToMonitor:")]
		LLRegion[] GeofencesToMonitor (CLLocationCoordinate2D currentCoordinate);

		// @required +(void)triggerRegion:(CLRegion * _Nonnull)region withEvent:(LLRegionEvent)event atLocation:(CLLocation * _Nullable)location __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Static]
		[Export ("triggerRegion:withEvent:atLocation:")]
		void TriggerRegion (CLRegion region, LLRegionEvent @event, [NullAllowed] CLLocation location);

		// @required +(void)triggerRegions:(NSArray<CLRegion *> * _Nonnull)regions withEvent:(LLRegionEvent)event atLocation:(CLLocation * _Nullable)location __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Static]
		[Export ("triggerRegions:withEvent:atLocation:")]
		void TriggerRegions (CLRegion[] regions, LLRegionEvent @event, [NullAllowed] CLLocation location);

		// @required +(void)tagPlacesPushReceived:(LLPlacesCampaign * _Nonnull)campaign __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Static]
		[Export ("tagPlacesPushReceived:")]
		[Protected]
		void TagPlacesPushReceivedPrivate(LLPlacesCampaign campaign);

		// @required +(void)tagPlacesPushOpened:(LLPlacesCampaign * _Nonnull)campaign __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Static]
		[Export ("tagPlacesPushOpened:")]
		[Protected]
		void TagPlacesPushOpenedPrivate(LLPlacesCampaign campaign);

		// @required +(void)tagPlacesPushOpened:(LLPlacesCampaign * _Nonnull)campaign withActionIdentifier:(NSString * _Nonnull)identifier __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Static]
		[Export ("tagPlacesPushOpened:withActionIdentifier:")]
		[Protected]
		void TagPlacesPushOpenedPrivate(LLPlacesCampaign campaign, string identifier);

		// @required +(void)triggerPlacesNotificationForCampaign:(LLPlacesCampaign * _Nonnull)campaign __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Static]
		[Export ("triggerPlacesNotificationForCampaign:")]
		void TriggerPlacesNotification (LLPlacesCampaign campaign);

		// @required +(void)triggerPlacesNotificationForCampaignId:(NSInteger)campaignId regionIdentifier:(NSString * _Nonnull)regionId __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Static]
		[Export ("triggerPlacesNotificationForCampaignId:regionIdentifier:")]
		void TriggerPlacesNotification(nint campaignId, string regionId);

		// @required +(void)setMessagingDelegate:(id<LLMessagingDelegate> _Nullable)delegate __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Static]
		[Export ("setMessagingDelegate:")]
		[Protected]
		void SetMessagingDelegate ([NullAllowed] LLMessagingDelegate @delegate);

		// @required +(void)setCallToActionDelegate:(id<LLCallToActionDelegate> _Nullable)delegate __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Static]
		[Export ("setCallToActionDelegate:")]
        [Internal]
		void SetCallToActionDelegate ([NullAllowed] LLCallToActionDelegate @delegate);

		// @required +(BOOL)isInAppAdIdParameterEnabled __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Static]
		[Export ("isInAppAdIdParameterEnabled")]
		[Internal]
		bool IsAdidAppendedToInAppUrls { get; }

		// @required +(void)setInAppAdIdParameterEnabled:(BOOL)enabled __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Static]
		[Export ("setInAppAdIdParameterEnabled:")]
		[Internal]
		void AppendAdidToInAppUrls(bool enabled);

		// @required +(BOOL)isInboxAdIdParameterEnabled __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Static]
		[Export ("isInboxAdIdParameterEnabled")]
		[Internal]
		bool IsAdidAppendedToInboxUrls { get; }

		// @required +(void)setInboxAdIdParameterEnabled:(BOOL)enabled __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Static]
		[Export ("setInboxAdIdParameterEnabled:")]
		[Internal]
		void AppendAdidToInboxUrls(bool enabled);

		// @required +(void)setLocationDelegate:(id<LLLocationDelegate> _Nullable)delegate __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Static]
		[Export ("setLocationDelegate:")]
        [Internal]
		void SetLocationDelegate ([NullAllowed] LLLocationDelegate @delegate);

	}

	// @protocol LLAnalyticsDelegate <NSObject>
	[BaseType (typeof(NSObject))]
	[Protocol]
    [Internal]
	interface LLAnalyticsDelegate
	{
		// @optional -(void)localyticsSessionWillOpen:(BOOL)isFirst isUpgrade:(BOOL)isUpgrade isResume:(BOOL)isResume __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Export ("localyticsSessionWillOpen:isUpgrade:isResume:")]
		void LocalyticsSessionWillOpenHandler (bool isFirst, bool isUpgrade, bool isResume);

		// @optional -(void)localyticsSessionDidOpen:(BOOL)isFirst isUpgrade:(BOOL)isUpgrade isResume:(BOOL)isResume __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Export ("localyticsSessionDidOpen:isUpgrade:isResume:")]
		void LocalyticsSessionDidOpenHandler (bool isFirst, bool isUpgrade, bool isResume);

		// @optional -(void)localyticsDidTagEvent:(NSString * _Nonnull)eventName attributes:(NSDictionary<NSString *,NSString *> * _Nullable)attributes customerValueIncrease:(NSNumber * _Nullable)customerValueIncrease __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Export ("localyticsDidTagEvent:attributes:customerValueIncrease:")]
		void LocalyticsDidTagEventHandler (string eventName, [NullAllowed] NSDictionary attributes, [NullAllowed] NSNumber customerValueIncrease);

		// @optional -(void)localyticsSessionWillClose;
		[Export ("localyticsSessionWillClose")]
		void LocalyticsSessionWillCloseHandler();
	}

	// @protocol LLMessagingDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface LLMessagingDelegate
	{
		// @optional -(BOOL)localyticsShouldShowInAppMessage:(LLInAppCampaign * _Nonnull)campaign __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Export ("localyticsShouldShowInAppMessage:")]
		bool LocalyticsShouldShowInAppMessage (LLInAppCampaign campaign);

		// @optional -(BOOL)localyticsShouldDelaySessionStartInAppMessages __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Export ("localyticsShouldDelaySessionStartInAppMessages")]
		bool LocalyticsShouldDelaySessionStartInAppMessages();

		// @optional -(LLInAppConfiguration * _Nonnull)localyticsWillDisplayInAppMessage:(LLInAppCampaign * _Nonnull)campaign withConfiguration:(LLInAppConfiguration * _Nonnull)configuration __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Export ("localyticsWillDisplayInAppMessage:withConfiguration:")]
		LLInAppConfiguration LocalyticsWillDisplayInAppMessage (LLInAppCampaign campaign, LLInAppConfiguration configuration);

		// @optional -(void)localyticsDidDisplayInAppMessage __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Export ("localyticsDidDisplayInAppMessage")]
		void LocalyticsDidDisplayInAppMessage ();

		// @optional -(void)localyticsWillDismissInAppMessage __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Export ("localyticsWillDismissInAppMessage")]
		void LocalyticsWillDismissInAppMessage ();

		// @optional -(void)localyticsDidDismissInAppMessage __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Export ("localyticsDidDismissInAppMessage")]
		void LocalyticsDidDismissInAppMessage ();

		// @optional -(void)localyticsWillDisplayInboxDetailViewController __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Export ("localyticsWillDisplayInboxDetailViewController")]
		void LocalyticsWillDisplayInboxDetailViewController ();

		// @optional -(void)localyticsDidDisplayInboxDetailViewController __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Export ("localyticsDidDisplayInboxDetailViewController")]
		void LocalyticsDidDisplayInboxDetailViewController ();

		// @optional -(void)localyticsWillDismissInboxDetailViewController __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Export ("localyticsWillDismissInboxDetailViewController")]
		void LocalyticsWillDismissInboxDetailViewController ();

		// @optional -(void)localyticsDidDismissInboxDetailViewController __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Export ("localyticsDidDismissInboxDetailViewController")]
		void LocalyticsDidDismissInboxDetailViewController ();

		// @optional -(BOOL)localyticsShouldDisplayPlacesCampaign:(LLPlacesCampaign * _Nonnull)campaign __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Export ("localyticsShouldDisplayPlacesCampaign:")]
		bool LocalyticsShouldDisplayPlacesCampaign (LLPlacesCampaign campaign);

		// @optional -(UILocalNotification * _Nonnull)localyticsWillDisplayNotification:(UILocalNotification * _Nonnull)notification forPlacesCampaign:(LLPlacesCampaign * _Nonnull)campaign __attribute__((availability(ios, introduced=8_0, deprecated=10_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Deprecated (PlatformName.iOS, 10, 0)]
		[Export ("localyticsWillDisplayNotification:forPlacesCampaign:")]
		UILocalNotification LocalyticsWillDisplayNotification (UILocalNotification notification, LLPlacesCampaign campaign);

        // @optional -(UNMutableNotificationContent * _Nonnull)localyticsWillDisplayNotificationContent:(UNMutableNotificationContent * _Nonnull)notification forPlacesCampaign:(LLPlacesCampaign * _Nonnull)campaign __attribute__((availability(ios, introduced=10_0)));
        [Introduced(PlatformName.iOS, 10, 0)]
		[Export ("localyticsWillDisplayNotificationContent:forPlacesCampaign:")]
		UNMutableNotificationContent LocalyticsWillDisplayNotificationContent (UNMutableNotificationContent notification, LLPlacesCampaign campaign);

		// @optional -(BOOL)localyticsShouldDeeplink:(NSURL * _Nonnull)url __attribute__((availability(ios, introduced=8_0))) __attribute__((deprecated("localyticsShouldDeeplink in the LLMessagingDelegate has been deprecated, please use localyticsShouldDeeplink in the LLCallToActionDelegate instead")));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Export ("localyticsShouldDeeplink:")]
		bool LocalyticsShouldDeeplink (NSUrl url);
	}

	// @protocol LLLocationDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface LLLocationDelegate
	{
		// @optional -(void)localyticsDidUpdateLocation:(CLLocation * _Nonnull)location __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Export ("localyticsDidUpdateLocation:")]
		void LocalyticsDidUpdateLocation (CLLocation location);

		// @optional -(void)localyticsDidUpdateMonitoredRegions:(NSArray<LLRegion *> * _Nonnull)addedRegions removeRegions:(NSArray<LLRegion *> * _Nonnull)removedRegions __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Export ("localyticsDidUpdateMonitoredRegions:removeRegions:")]
		void LocalyticsDidUpdateMonitoredRegions (LLRegion[] addedRegions, LLRegion[] removedRegions);

		// @optional -(void)localyticsDidTriggerRegions:(NSArray<LLRegion *> * _Nonnull)regions withEvent:(LLRegionEvent)event __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Export ("localyticsDidTriggerRegions:withEvent:")]
		void LocalyticsDidTriggerRegions (LLRegion[] regions, LLRegionEvent @event);
	}

	// @protocol LLCallToActionDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface LLCallToActionDelegate
	{
		// @optional -(BOOL)localyticsShouldDeeplink:(NSURL * _Nonnull)url campaign:(LLCampaignBase * _Nullable)campaign __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Export ("localyticsShouldDeeplink:campaign:")]
		bool LocalyticsShouldDeeplink (NSUrl url, [NullAllowed] LLCampaignBase campaign);

		// @optional -(void)localyticsDidOptOut:(BOOL)optedOut campaign:(LLCampaignBase * _Nonnull)campaign __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Export ("localyticsDidOptOut:campaign:")]
		void LocalyticsDidOptOut (bool optedOut, LLCampaignBase campaign);

		// @optional -(void)localyticsDidPrivacyOptOut:(BOOL)privacyOptedOut campaign:(LLCampaignBase * _Nonnull)campaign __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Export ("localyticsDidPrivacyOptOut:campaign:")]
		void LocalyticsDidPrivacyOptOut (bool privacyOptedOut, LLCampaignBase campaign);

		// @optional -(BOOL)localyticsShouldPromptForLocationWhenInUsePermissions:(LLCampaignBase * _Nonnull)campaign __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Export ("localyticsShouldPromptForLocationWhenInUsePermissions:")]
		bool LocalyticsShouldPromptForLocationWhenInUsePermissions (LLCampaignBase campaign);

		// @optional -(BOOL)localyticsShouldPromptForLocationAlwaysPermissions:(LLCampaignBase * _Nonnull)campaign __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Export ("localyticsShouldPromptForLocationAlwaysPermissions:")]
		bool LocalyticsShouldPromptForLocationAlwaysPermissions (LLCampaignBase campaign);

		// @optional -(BOOL)localyticsShouldPromptForNotificationPermissions:(LLCampaignBase * _Nonnull)campaign __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Export ("localyticsShouldPromptForNotificationPermissions:")]
		bool LocalyticsShouldPromptForNotificationPermissions (LLCampaignBase campaign);

		// @optional -(BOOL)localyticsShouldDeeplinkToSettings:(LLCampaignBase *)campaign __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Export ("localyticsShouldDeeplinkToSettings:")]
		bool LocalyticsShouldDeeplinkToSettings (LLCampaignBase campaign);

		// @optional -(void)requestAlwaysAuthorization:(CLLocationManager * _Nonnull)locationManager __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Export ("requestAlwaysAuthorization:")]
		void RequestAlwaysAuthorizationFromApp (CLLocationManager locationManager);

		// @optional -(void)requestWhenInUseAuthorization:(CLLocationManager * _Nonnull)locationManager __attribute__((availability(ios, introduced=8_0)));
		[Introduced (PlatformName.iOS, 8, 0)]
		[Export ("requestWhenInUseAuthorization:")]
		void RequestWhenInUseAuthorizationFromApp(CLLocationManager locationManager);
	}
}
