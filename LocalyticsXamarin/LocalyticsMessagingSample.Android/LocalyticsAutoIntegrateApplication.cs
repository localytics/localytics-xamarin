using System;
using System.Collections.Generic;
using Android.App;
using Android.Locations;
using Android.Runtime;
using Android.Support.V4.App;

using LocalyticsXamarin.Android;
using LocalyticsXamarin.AndroidPatch;

namespace LocalyticsMessagingSample.Android
{
	[Application]
	public class LocalyticsAutoIntegrateApplication: Application
	{

		public LocalyticsAutoIntegrateApplication (IntPtr handle, JniHandleOwnership ownerShip) : base (handle, ownerShip) 
		{ 
		}

		override public void OnCreate() {
			base.OnCreate ();

			#if DEBUG
			Localytics.LoggingEnabled = true;
			#endif

			Localytics.AutoIntegrate(this);
			Localytics.SetLocationMonitoringEnabled(true);

			LocalyticsEvents.SubscribeToAll ();

			// Analytics callbacks
			LocalyticsEvents.OnLocalyticsDidTagEvent += LL_OnLocalyticsDidTagEvent;
			LocalyticsEvents.OnLocalyticsSessionWillOpen += LL_OnLocalyticsSessionWillOpen;
			LocalyticsEvents.OnLocalyticsSessionDidOpen += LL_OnLocalyticsSessionDidOpen;
			LocalyticsEvents.OnLocalyticsSessionWillClose += LL_OnLocalyticsSessionWillClose;

			// Messaging callbacks
			LocalyticsEvents.OnLocalyticsDidDismissInAppMessage += LL_OnLocalyticsDidDismissInAppMessage;
			LocalyticsEvents.OnLocalyticsDidDisplayInAppMessage += LL_OnLocalyticsDidDisplayInAppMessage;
			LocalyticsEvents.OnLocalyticsWillDismissInAppMessage += LL_OnLocalyticsWillDismissInAppMessage;
			LocalyticsEvents.OnLocalyticsWillDisplayInAppMessage += LL_OnLocalyticsWillDisplayInAppMessage;
			LocalyticsEvents.OnLocalyticsShouldShowPushNotification += LL_OnLocalyticsShouldShowPushNotification;
			LocalyticsEvents.OnLocalyticsWillShowPushNotification += LL_OnLocalyticsWillShowPushNotification;
			LocalyticsEvents.OnLocalyticsShouldShowPlacesPushNotification += LL_OnLocalyticsShouldShowPlacesPushNotification;
			LocalyticsEvents.OnLocalyticsWillShowPlacesPushNotification += LL_OnLocalyticsWillShowPlacesPushNotification;

			// Location callbacks
			LocalyticsEvents.OnLocalyticsDidUpdateLocation += LL_OnLocalyticsDidUpdateLocation;
			LocalyticsEvents.OnLocalyticsDidTriggerRegions += LL_OnLocalyticsDidTriggerRegions;
			LocalyticsEvents.OnLocalyticsDidUpdateMonitoredGeofences += LL_OnLocalyticsDidUpdateMonitoredGeofences;
		}

		void LL_OnLocalyticsDidTagEvent(string eventName, IDictionary<string, string> attributes, long customerValueIncrease)
		{
			if (attributes != null)
			{
				Console.WriteLine("Did tag event: name: " + eventName + " attributes.Count: " + attributes.Count + " customerValueIncrease: " + customerValueIncrease);
			}
			else
			{
				Console.WriteLine("Did tag event: name: " + eventName + " attributes.Count: " + 0 + " customerValueIncrease: " + customerValueIncrease);
			}
		}

		void LL_OnLocalyticsSessionWillClose()
		{
			Console.WriteLine("Session will close");
		}

		void LL_OnLocalyticsSessionDidOpen(bool isFirst, bool isUpgrade, bool isResume)
		{
			Console.WriteLine("Session did open: isFirst: " + isFirst + " isUpgrade: " + isUpgrade + " isResume: " + isResume);
		}

		void LL_OnLocalyticsSessionWillOpen(bool isFirst, bool isUpgrade, bool isResume)
		{
			Console.WriteLine("Session will open: isFirst: " + isFirst + " isUpgrade: " + isUpgrade + " isResume: " + isResume);
		}

		void LL_OnLocalyticsDidDismissInAppMessage()
		{
			Console.WriteLine ("DidDismissInAppMessage");
		}

		void LL_OnLocalyticsDidDisplayInAppMessage()
		{
			Console.WriteLine ("DidDisplayInAppMessage");
		}

		void LL_OnLocalyticsWillDismissInAppMessage()
		{
			Console.WriteLine ("WillDismissInAppMessage");
		}

		void LL_OnLocalyticsWillDisplayInAppMessage()
		{
			Console.WriteLine ("WillDisplayInAppMessage");
		}

		bool LL_OnLocalyticsShouldShowPushNotification(PushCampaign campaign)
		{
			Console.WriteLine("Should show push notification. Name: " + campaign.Name + ". Campaign Id: " + campaign.CampaignId + ". Message: " + campaign.Message);
			return true;
		}

		NotificationCompat.Builder LL_OnLocalyticsWillShowPushNotification(NotificationCompat.Builder builder, PushCampaign campaign)
		{
			Console.WriteLine("Will show push notification. Name: " + campaign.Name + ". Campaign Id: " + campaign.CampaignId + ". Message: " + campaign.Message);
			return builder;
		}

		bool LL_OnLocalyticsShouldShowPlacesPushNotification(PlacesCampaign campaign)
		{
			Console.WriteLine("Should show places notification. Name: " + campaign.Name + ". Campaign Id: " + campaign.CampaignId + ". Message: " + campaign.Message);
			return true;
		}

		NotificationCompat.Builder LL_OnLocalyticsWillShowPlacesPushNotification(NotificationCompat.Builder builder, PlacesCampaign campaign)
		{
			Console.WriteLine("Will show places push notification. Name: " + campaign.Name + ". Campaign Id: " + campaign.CampaignId + ". Message: " + campaign.Message);
			return builder;
		}

		void LL_OnLocalyticsDidUpdateLocation(Location location)
		{
			Console.WriteLine("Did update location: " + location);
		}

		void LL_OnLocalyticsDidTriggerRegions(IList<Region> regions, LLRegionEvent regionEvent)
		{
			Console.WriteLine("Did trigger regions: " + regions + " with event: " + regionEvent);
		}

		void LL_OnLocalyticsDidUpdateMonitoredGeofences(IList<CircularRegion> added, IList<CircularRegion> removed)
		{
			Console.WriteLine("Did update monitored geofences. Added: " + added + " and removed: " + removed);
		}
	}
}

