## Azure NotificationHubs Plugin for Xamarin and Windows

Simple cross platform plugin to configure Azure's NotificationHubs in your Xamarin (Forms) project.

### Setup
* Available on NuGet: [http://www.nuget.org/packages/Xam.Plugin.NotificationHub](http://www.nuget.org/packages/Xam.Plugin.NotificationHub)
* Install into your PCL project and Client projects.


[![Build status](https://ci.appveyor.com/api/projects/status/584wph2uyyqsgif9?svg=true)](https://ci.appveyor.com/project/saadfarooq/notificationhubplugin)

### API Usage
*Note:* This plugin is designed to work with the excellent [Push Notification Plugin for Xamarin](https://github.com/rdelrosario/xamarin-plugins/tree/master/PushNotification)
- Follow the instructions for setting up the push notification listener from the Push Notification Plugin.
- In the `OnRegistered` method of the push notification listener, call `CrossNotificationHub.Current.Register`
with your NotificationHub name, connection string, the device token (provided by `OnRegistered`) and any tags.
- And that's it. You should be able to get push notifications sent from your Azure NotificationHub now in the 
same push notification listener.
- To unregister, just call `CrossNotificationHub.Current.Unregister()`

See the sample project for an implementation.
