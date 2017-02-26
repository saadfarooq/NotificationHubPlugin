using Plugin.NotificationHub.Abstractions;


namespace Plugin.NotificationHub
{
    /// <summary>
    /// Implementation for Feature
    /// </summary>
    public class NotificationHubImplementation : INotificationHub
  {
        private WindowsAzure.Messaging.NotificationHub hub;
        public void Register(string connectionString, string hubName, string token, string[] tags)
        {
            hub = new WindowsAzure.Messaging.NotificationHub(hubName, connectionString, Android.App.Application.Context);
            hub.Register(token, tags);
        }

        public void Unregister()
        {
            if (hub != null) 
                hub.Unregister();
        }
    }
}