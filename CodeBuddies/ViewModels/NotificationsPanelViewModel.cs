using CodeBuddies.Models.Entities;
using CodeBuddies.MVVM;
using CodeBuddies.Repositories;
using CodeBuddies.Resources.Data;
using System.Collections.ObjectModel;

namespace CodeBuddies.ViewModels
{
    internal class NotificationsPanelViewModel : ViewModelBase
    {
        private ObservableCollection<Notification> notifications;
        private NotificationRepository repository;

        // This creates a command that runs a function and sends the 
        public RelayCommand<Notification> AcceptCommand => new RelayCommand<Notification>(AcceptInvite);
        public RelayCommand<Notification> DeclineCommand => new RelayCommand<Notification>(DeclineInvite);
        public RelayCommand<Notification> MarkReadCommand => new RelayCommand<Notification>(MarkReadNotification);

        public ObservableCollection<Notification> Notifications
        {
            get { return notifications; }
            set { notifications = value; OnPropertyChanged(); }
        }


        public NotificationsPanelViewModel()
        {
            // TODO inject this more cleanly
            repository = new NotificationRepository();
            Notifications = new ObservableCollection<Notification>(repository.GetAll());

        }

        public void PopulateWithHardCodedNotifications()
        {
            Notification infoNotification1 = new InfoNotification(1, DateTime.Now, "successInformation", "delivered", "Successfully sent invitation notification", 1);
            Notification infoNotification2 = new InfoNotification(2, DateTime.Now, "rejectInformation", "delivered", "Rejected invite notification", 1);
            Notification inviteNotification1 = new InviteNotification(3, DateTime.Now, "invite", "pending", "Invited by yo1 - Accept or Decline", 1, false);
            Notification inviteNotification2 = new InviteNotification(4, DateTime.Now, "invite", "pending", "Invited by yo2 - Accept or Decline", 1, false);
            Notification inviteNotification3 = new InviteNotification(5, DateTime.Now, "invite", "pending", "Invited by yo3 - Accept or Decline", 1, false);

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
        private void DeclineInvite(Notification notification)
        {
            notifications.Remove(notification);
            // remove the invite notification from the db
            repository.RemoveById(notification.NotificationId);
            // send an information notification informing 
            SendDeclinedInfoNotification(notification);
        }
        private void MarkReadNotification(Notification notification)
        {
            notifications.Remove(notification);
            // also remove from db
            repository.RemoveById(notification.NotificationId);
        }

        private void SendDeclinedInfoNotification(Notification notification)
        {
            Notification declinedNotification = new InfoNotification(repository.GetFreeNotificationId(), DateTime.Now, "rejectInformation", "pending", Constants.CLIENT_NAME + " rejected your invitation", notification.NotificationId);
        }
    }
}
