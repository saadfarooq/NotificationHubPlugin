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
        /// <summary>
        /// Register with the Azure NotificationHub client for your platform
        /// </summary>
        /// <param name="connectionString">The NotificationHub connection string</param>
        /// <param name="hubName">Name of notification hub from Azure Portal</param>
        /// <param name="token">Token value to use to register</param>
        /// <param name="tags">Tags to register against</param>
        public async void Register(string connectionString, string hubName, string token, params string[] tags)
        {
            hub = new Microsoft.WindowsAzure.Messaging.NotificationHub(hubName, connectionString);
            var result = await hub.RegisterNativeAsync(token, tags);
        }
        /// <summary>
        /// Unregister the NotificationHub client
        /// </summary>
        public async void Unregister()
        {
            if (hub != null)
                await hub.UnregisterNativeAsync();
        }
    }
}