using Plugin.NotificationHub.Abstractions;
using System;

namespace Plugin.NotificationHub
{
  /// <summary>
  /// Cross platform NotificationHub implemenations
  /// </summary>
  public class CrossNotificationHub
  {
    static Lazy<INotificationHub> Implementation = new Lazy<INotificationHub>(() => CreateNotificationHub(), System.Threading.LazyThreadSafetyMode.PublicationOnly);

    /// <summary>
    /// Current settings to use
    /// </summary>
    public static INotificationHub Current
    {
      get
      {
        var ret = Implementation.Value;
        if (ret == null)
        {
          throw NotImplementedInReferenceAssembly();
        }
        return ret;
      }
    }

    static INotificationHub CreateNotificationHub()
    {
#if PORTABLE
        return null;
#else
        return new NotificationHubImplementation();
#endif
    }

    internal static Exception NotImplementedInReferenceAssembly()
    {
      return new NotImplementedException("This functionality is not implemented in the portable version of this assembly.  You should reference the NuGet package from your main application project in order to reference the platform-specific implementation.");
    }
  }
}
