using CodeBuddies.Models.Entities;
using CodeBuddies.MVVM;
using System.Collections.ObjectModel;

namespace CodeBuddies.ViewModels
{
    internal class NotificationsPanelViewModel : ViewModelBase
    {
        private ObservableCollection<Notification> notifications = new ObservableCollection<Notification>();

        // This creates a command that runs a function and sends the 
        public RelayCommand<Notification> AcceptCommand => new RelayCommand<Notification>(AcceptInvite);

        public ObservableCollection<Notification> Notifications
        {
            get { return notifications; }
            set { notifications = value; OnPropertyChanged(); }
        }


        public NotificationsPanelViewModel()
        {
            PopulateWithHardCodedNotifications();
        }

        public void PopulateWithHardCodedNotifications()
        {
            Notification infoNotification1 = new InfoNotification(1, DateTime.Now, "successInformation", "delivered", "Successfully sent invitation notification");
            Notification infoNotification2 = new InfoNotification(2, DateTime.Now, "rejectInformation", "delivered", "Rejected invite notification");
            Notification inviteNotification1 = new InviteNotification(3, DateTime.Now, "invite", "pending", "Invited by yo1 - Accept or Decline", false);
            Notification inviteNotification2 = new InviteNotification(4, DateTime.Now, "invite", "pending", "Invited by yo2 - Accept or Decline", false);
            Notification inviteNotification3 = new InviteNotification(5, DateTime.Now, "invite", "pending", "Invited by yo3 - Accept or Decline", false);

            Notifications.Add(infoNotification1);
            Notifications.Add(infoNotification2);
            Notifications.Add(inviteNotification1);
            Notifications.Add(inviteNotification2);
            Notifications.Add(inviteNotification3);

        }
        private void AcceptInvite(Notification notification)
        {
            Console.WriteLine(notification.NotificationId);

        }
    }
}
