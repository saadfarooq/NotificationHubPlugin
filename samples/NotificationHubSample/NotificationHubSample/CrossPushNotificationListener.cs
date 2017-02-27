using PushNotification.Plugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using PushNotification.Plugin.Abstractions;
using System.Diagnostics;
using Plugin.NotificationHub;

namespace NotificationHubSample
{
    public class CrossPushNotificationListener : IPushNotificationListener
    {
        public void OnError(string message, DeviceType deviceType)
        {
            Debug.WriteLine(message);
        }

        public void OnMessage(JObject values, DeviceType deviceType)
        {
            Debug.WriteLine("OnMessage: " + values);
        }

        public void OnRegistered(string token, DeviceType deviceType)
        {
            Debug.WriteLine("OnRegistered: {0}, deviceType: {1}", token, deviceType);
            CrossNotificationHub.Current.Register(Constants.NOTIFICATION_HUB_CONNECTION_STRING,
                Constants.NOTIFICATION_HUB_NAME, token, "TEST");
        }

        public void OnUnregistered(DeviceType deviceType)
        {
            Debug.WriteLine("UnRegistered on Device: {0}", deviceType);
            CrossNotificationHub.Current.Unregister();
        }

        public bool ShouldShowNotification()
        {
            return true;
        }
    }
}
