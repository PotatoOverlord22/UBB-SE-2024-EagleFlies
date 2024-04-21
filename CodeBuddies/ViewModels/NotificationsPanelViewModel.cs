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
        private NotificationRepository notificationRepository;
        private SessionRepository sessionRepository;

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
            // TODO inject these more cleanly
            notificationRepository = new NotificationRepository();
            sessionRepository = new SessionRepository();

            Notifications = new ObservableCollection<Notification>(notificationRepository.GetAllByBuddyId(Constants.CLIENT_BUDDY_ID));

        }
        private void AcceptInvite(Notification notification)
        {
            SendAcceptedInfoNotification(notification);
            // save the new member
            sessionRepository.AddBuddyMemberToSession(notification.ReceiverId, notification.SessionId);
            // remove the invite notification from the db
            notificationRepository.RemoveById(notification.NotificationId);
            notifications.Remove(notification);
        }
        private void DeclineInvite(Notification notification)
        {
            // send an information notification informing the inviter that the user declined
            SendDeclinedInfoNotification(notification);
            // remove the invite notification from the db
            notificationRepository.RemoveById(notification.NotificationId);
            notifications.Remove(notification);
        }
        private void MarkReadNotification(Notification notification)
        {
            notifications.Remove(notification);
            // also remove from db
            notificationRepository.RemoveById(notification.NotificationId);
        }

        private void SendDeclinedInfoNotification(Notification notification)
        {
            // Reverse sender and receiver ids because this notification goes backwards
            Notification declinedNotification = new InfoNotification(notificationRepository.GetFreeNotificationId(), DateTime.Now, "rejectInformation", "pending", Constants.CLIENT_NAME + " rejected your invitation", notification.ReceiverId, notification.SenderId, notification.SessionId);
            notificationRepository.Save(declinedNotification);
        }

        private void SendAcceptedInfoNotification(Notification notification)
        {
            // Reverse sender and receiver ids because this notification goes backwards
            Notification acceptedNotification = new InfoNotification(notificationRepository.GetFreeNotificationId(), DateTime.Now, "successInformation", "pending", Constants.CLIENT_NAME + " accepted your invitation!", notification.ReceiverId, notification.SenderId, notification.SessionId);
            notificationRepository.Save(acceptedNotification);
        }
    }
}
