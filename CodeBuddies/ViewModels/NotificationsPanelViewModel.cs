using CodeBuddies.Models.Entities;
using CodeBuddies.Models.Exceptions;
using CodeBuddies.MVVM;
using CodeBuddies.Repositories;
using CodeBuddies.Resources.Data;
using System.Collections.ObjectModel;
using System.Windows;

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
            try
            {
                sessionRepository.AddBuddyMemberToSession(notification.ReceiverId, notification.SessionId);
                // Raise the event to notify the other components they need to update their sessions list
                GlobalEvents.RaiseBuddyAddedToSessionEvent(notification.ReceiverId, notification.SessionId);
            }
            catch (EntityAlreadyExists error)
            {
                ShowErrorPopup("You are already a member of the session " + sessionRepository.GetSessionName(notification.SessionId));

            }
            finally
            {
                RemoveNotification(notification);
            }
        }
        private void DeclineInvite(Notification notification)
        {
            // send an information notification informing the inviter that the user declined
            SendDeclinedInfoNotification(notification);
            RemoveNotification(notification);
        }
        private void MarkReadNotification(Notification notification)
        {
            RemoveNotification(notification);
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
        private void ShowErrorPopup(string errorMessage)
        {

            MessageBox.Show(errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void RemoveNotification(Notification notification)
        {
            // update optimistically
            notifications.Remove(notification);
            // remove from db
            try
            { 
                notificationRepository.RemoveById(notification.NotificationId);
            } catch(Exception ex)
            {
                // if failure, fetch again
                Notifications = new ObservableCollection<Notification>(notificationRepository.GetAllByBuddyId(Constants.CLIENT_BUDDY_ID));
            }
        }
    }
}
