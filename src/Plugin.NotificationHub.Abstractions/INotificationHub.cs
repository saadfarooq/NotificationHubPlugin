using System;

namespace Plugin.NotificationHub.Abstractions
{
  /// <summary>
  /// Interface for NotificationHub
  /// </summary>
  public interface INotificationHub
  {
        void Register(string connectionString, string hubName, string token, string[] tags);
        void Unregister();
  }
}
