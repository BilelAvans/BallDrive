using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace BallDrive.Data.Notifications
{
    public class Notification
    {
        public Notification()
        {
        }
        

        public string standardNotification(string title, string message)
        {
            return $@"
            <toast activationType='foreground' launch='args'>
                <visual>
                    <binding template='ToastGeneric'>
                        <text>{ title }</text>
                        <text>{ message }</text>
                    </binding>
                </visual>
            </toast>";

        }

        public string messageWithImageNotification(string title, string message, Image image)
        {
            return $@"
            <toast activationType='forground' launch='args'>
                <visual>
                    <binding template='ToastGeneric'>
                        
                    </binding>
                </visual>
            </toast>";
        }

        public void sendNote(string content)
        {

            // Notificatie moet in een XML formaat aangeleverd worden
            XmlDocument doc = new XmlDocument();
            // Onze XAML code erin zetten
            doc.LoadXml(content);
            // Inladen in een toast notificatie (Standaard in Windows 10)
            ToastNotification notification = new ToastNotification(doc);
            // Toast Manager aanmaken, oproepen en bewaren
            ToastNotifier notifier = ToastNotificationManager.CreateToastNotifier();
            notification.Activated += Notification_Activated;
            
            // Notificatie aanleveren aan manager, de manager toont vervolgens de notificatie
            notifier.Show(notification);
        }


        private async void Notification_Activated(ToastNotification sender, object args)
        {
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.High, () =>
            {
                Frame frame = (Frame)Window.Current.Content;
                frame.Navigate(typeof(GameView), null);
                
            });
        }
    }
}
