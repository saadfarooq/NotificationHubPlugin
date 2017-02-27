using Plugin.NotificationHub.Abstractions;


namespace Plugin.NotificationHub
{
    /// <summary>
    /// Implementation for Feature
    /// </summary>
    public class NotificationHubImplementation : INotificationHub
  {
        private WindowsAzure.Messaging.NotificationHub hub;
        /// <summary>
        /// Register with the Azure NotificationHub client for your platform
        /// </summary>
        /// <param name="connectionString">The NotificationHub connection string</param>
        /// <param name="hubName">Name of notification hub from Azure Portal</param>
        /// <param name="token">Token value to use to register</param>
        /// <param name="tags">Tags to register against</param>
        public void Register(string connectionString, string hubName, string token, string[] tags)
        {
            hub = new WindowsAzure.Messaging.NotificationHub(hubName, connectionString, Android.App.Application.Context);
            hub.Register(token, tags);
        }
        /// <summary>
        /// Unregister the NotificationHub client
        /// </summary>
        public void Unregister()
        {
            if (hub != null) 
                hub.Unregister();
        }
    }
}