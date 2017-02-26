using PushNotification.Plugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace NotificationHubSample
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NotificationHubSample.MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            CrossPushNotification.Current.Register();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
            CrossPushNotification.Current.Unregister();
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
