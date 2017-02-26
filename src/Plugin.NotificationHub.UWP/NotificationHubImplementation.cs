using Plugin.NotificationHub.Abstractions;
using System;

namespace Plugin.NotificationHub
{
    /// <summary>
    /// Implementation for Feature
    /// </summary>
    public class NotificationHubImplementation : INotificationHub
    {
        Microsoft.WindowsAzure.Messaging.NotificationHub hub;
        public async void Register(string connectionString, string hubName, string token, string[] tags)
        {
            hub = new Microsoft.WindowsAzure.Messaging.NotificationHub(hubName, connectionString);
            var result = await hub.RegisterNativeAsync(token, tags);            
        }

        public async void Unregister()
        {
            if (hub != null)
                await hub.UnregisterNativeAsync();
        }
    }
}