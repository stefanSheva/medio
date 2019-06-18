﻿using Foundation;
using UIKit;

namespace Medio {
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
	[Register ("AppDelegate")]
	public class AppDelegate : UIApplicationDelegate {
		// class-level declarations
		public static MockTableData DataStore = new MockTableData();
		public static bool IsMedication = true;
		public override UIWindow Window {
			get;
			set;
		}

		public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions) {
			// Override point for customization after application launch.
			// If not required for your application you can safely delete this method
			Window = new UIWindow(UIScreen.MainScreen.Bounds);
			var sb = UIStoryboard.FromName("Main", null);
			var navController = sb.InstantiateInitialViewController();
			Window.RootViewController = navController;
			Window.MakeKeyAndVisible();

			if(launchOptions != null) {

				// check for a local notification
				if (launchOptions.ContainsKey(UIApplication.LaunchOptionsLocalNotificationKey))
				{

					UILocalNotification localNotification = launchOptions[UIApplication.LaunchOptionsLocalNotificationKey] as UILocalNotification;
					if (localNotification != null)
					{

						new UIAlertView(localNotification.AlertAction, localNotification.AlertBody, null, "OK", null).Show();
						// reset our badge
						UIApplication.SharedApplication.ApplicationIconBadgeNumber = 0;
					}
				}
			}

			//var settings = UIUserNotificationSettings.GetSettingsForTypes(UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound, null);
			//UIApplication.SharedApplication.RegisterUserNotificationSettings (settings);

			var notificationSettings = UIUserNotificationSettings.GetSettingsForTypes(UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound, null);

			application.RegisterUserNotificationSettings (notificationSettings);
			application.RegisterForRemoteNotifications ();

			return true;
		}

		public override void ReceivedLocalNotification(UIApplication application, UILocalNotification notification)
		{
			new UIAlertView(notification.AlertAction, notification.AlertBody, null, "OK", null).Show();

			// reset our badge
			//Window.RootViewController.PresentViewController(okayAlertController, true, null);
			UIApplication.SharedApplication.ApplicationIconBadgeNumber = 0;
		}

		public override void OnResignActivation (UIApplication application) {
			// Invoked when the application is about to move from active to inactive state.
			// This can occur for certain types of temporary interruptions (such as an incoming phone call or SMS message) 
			// or when the user quits the application and it begins the transition to the background state.
			// Games should use this method to pause the game.
		}

		public override void DidEnterBackground (UIApplication application) {
			// Use this method to release shared resources, save user data, invalidate timers and store the application state.
			// If your application supports background exection this method is called instead of WillTerminate when the user quits.
		}

		public override void WillEnterForeground (UIApplication application) {
			// Called as part of the transiton from background to active state.
			// Here you can undo many of the changes made on entering the background.
		}

		public override void OnActivated (UIApplication application) {
			// Restart any tasks that were paused (or not yet started) while the application was inactive. 
			// If the application was previously in the background, optionally refresh the user interface.
		}

		public override void WillTerminate (UIApplication application) {
			// Called when the application is about to terminate. Save data, if needed. See also DidEnterBackground.
		}
	}
}

