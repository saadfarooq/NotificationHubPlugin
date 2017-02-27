namespace Plugin.NotificationHub.Abstractions
{
    /// <summary>
    /// Interface for NotificationHub
    /// </summary>
    public interface INotificationHub
  {
        /// <summary>
        /// Register with the Azure NotificationHub client for your platform
        /// </summary>
        /// <param name="connectionString">The NotificationHub connection string</param>
        /// <param name="hubName">Name of notification hub from Azure Portal</param>
        /// <param name="token">Token value to use to register</param>
        /// <param name="tags">Tags to register against</param>
        void Register(string connectionString, string hubName, string token, params string[] tags);
        /// <summary>
        /// Unregister the NotificationHub client
        /// </summary>
        void Unregister();
  }
}
