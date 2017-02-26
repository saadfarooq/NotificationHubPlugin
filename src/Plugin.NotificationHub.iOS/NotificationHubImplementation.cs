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