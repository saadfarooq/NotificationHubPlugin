using Foundation;
using Plugin.NotificationHub.Abstractions;
using System;
using WindowsAzure.Messaging;

namespace Plugin.NotificationHub
{
    /// <summary>
    /// Implementation for NotificationHub
    /// </summary>
    public class NotificationHubImplementation : INotificationHub
    {
        private SBNotificationHub hub;
        /// <summary>
        /// Register with the Azure NotificationHub client for your platform
        /// </summary>
        /// <param name="connectionString">The NotificationHub connection string</param>
        /// <param name="hubName">Name of notification hub from Azure Portal</param>
        /// <param name="token">Token value to use to register</param>
        /// <param name="tags">Tags to register against</param>
        public void Register(string connectionString, string hubName, string token, string[] tags)
        {
            hub = new SBNotificationHub(connectionString, hubName);
            hub.RegisterNativeAsync(token, new NSSet(tags), err => {
                if (err != null)
                {
                    Console.WriteLine("Error: " + err.Description);
                }
                else
                {
                    Console.WriteLine("Success");
                }
            });
        }
        /// <summary>
        /// Unregister the NotificationHub client
        /// </summary>
        public void Unregister()
        {
            if (hub != null)
                hub.UnregisterNativeAsync(err => {
                    if (err != null)
                    {
                        Console.WriteLine("Error: " + err.Description);
                    }
                    else
                    {
                        Console.WriteLine("Success");
                    }
                });
        }
    }
}