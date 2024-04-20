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
            Notifications = new ObservableCollection<Notification>(repository.GetAllByBuddyId(Constants.CLIENT_BUDDY_ID));

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
            // send an information notification informing the inviter that the user declined
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
            // Reverse sender and receiver ids because this notification goes backwards
            Notification declinedNotification = new InfoNotification(repository.GetFreeNotificationId(), DateTime.Now, "rejectInformation", "pending", Constants.CLIENT_NAME + " rejected your invitation", notification.ReceiverId, notification.SenderId,notification.SessionId);
            repository.Save(declinedNotification);
        }
    }
}
