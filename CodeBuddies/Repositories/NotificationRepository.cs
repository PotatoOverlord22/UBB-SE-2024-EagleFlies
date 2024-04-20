using CodeBuddies.Models.Entities;
using CodeBuddies.MVVM;
using System.Data;
using System.Data.SqlClient;

namespace CodeBuddies.Repositories
{
    internal class NotificationRepository : DBRepositoryBase
    {
        public NotificationRepository() : base()
        {

        }

        public List<Notification> GetAll()
        {
            List<Notification> notifications = new List<Notification>();

            DataSet notificationDataSet = new DataSet();
            string selectAll = "SELECT * FROM Notifications";
            SqlCommand selectAllNotifications = new SqlCommand(selectAll, sqlConnection);
            dataAdapter.SelectCommand = selectAllNotifications;
            notificationDataSet.Clear();
            dataAdapter.Fill(notificationDataSet, "Notifications");

            foreach (DataRow notificationRow in notificationDataSet.Tables["Notifications"].Rows)
            {

                Notification currentNotification;

                if (notificationRow["notification_type"].ToString() == "invite")
                {
                    currentNotification = new InviteNotification((long)notificationRow["id"], (DateTime)notificationRow["notification_timestamp"], notificationRow["notification_type"].ToString(), notificationRow["notification_status"].ToString(), notificationRow["notification_description"].ToString(), (long)notificationRow["sender_id"], (long)notificationRow["receiver_id"], (long)notificationRow["session_id"], false);
                }
                else
                {
                    currentNotification = new InfoNotification((long)notificationRow["id"], (DateTime)notificationRow["notification_timestamp"], notificationRow["notification_type"].ToString(), notificationRow["notification_status"].ToString(), notificationRow["notification_description"].ToString(), (long)notificationRow["sender_id"], (long)notificationRow["receiver_id"], (long)notificationRow["session_id"]);

                }

                notifications.Add(currentNotification);

            }

            return notifications;
        }

        public List<Notification> GetAllByBuddyId(long buddyId)
        {
            List<Notification> notifications = new List<Notification>();

            DataSet notificationDataSet = new DataSet();
            string selectAll = "SELECT * FROM Notifications WHERE receiver_id=@buddyId";
            SqlCommand selectAllNotifications = new SqlCommand(selectAll, sqlConnection);
            selectAllNotifications.Parameters.AddWithValue("@buddyId", buddyId);
            dataAdapter.SelectCommand = selectAllNotifications;
            notificationDataSet.Clear();
            dataAdapter.Fill(notificationDataSet, "Notifications");

            foreach (DataRow notificationRow in notificationDataSet.Tables["Notifications"].Rows)
            {

                Notification currentNotification;

                if (notificationRow["notification_type"].ToString() == "invite")
                {
                    currentNotification = new InviteNotification((long)notificationRow["id"], (DateTime)notificationRow["notification_timestamp"], notificationRow["notification_type"].ToString(), notificationRow["notification_status"].ToString(), notificationRow["notification_description"].ToString(), (long)notificationRow["sender_id"], (long)notificationRow["receiver_id"], (long)notificationRow["session_id"], false);
                }
                else
                {
                    currentNotification = new InfoNotification((long)notificationRow["id"], (DateTime)notificationRow["notification_timestamp"], notificationRow["notification_type"].ToString(), notificationRow["notification_status"].ToString(), notificationRow["notification_description"].ToString(), (long)notificationRow["sender_id"], (long)notificationRow["receiver_id"], (long)notificationRow["session_id"]);

                }

                notifications.Add(currentNotification);

            }

            return notifications;
        }

        public void RemoveById(long notificationId)
        {
            string deleteNotificationQuery = "DELETE FROM Notifications WHERE id = @notificationId";
            using (SqlCommand deleteCommand = new SqlCommand(deleteNotificationQuery, sqlConnection))
            {
                deleteCommand.Parameters.AddWithValue("@notificationId", notificationId);

                deleteCommand.ExecuteNonQuery();
            }
        }

        public long GetFreeNotificationId()
        {
            long maxId = 0;
            string maxIdQuery = "SELECT MAX(id) FROM Notifications";

            using (SqlCommand command = new SqlCommand(maxIdQuery, sqlConnection))
            {
                object result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    maxId = Convert.ToInt64(result);
                }
            }


            // Increment the maximum ID to get a free ID
            return maxId + 1;
        }

        public void Save(Notification notification)
        {

        }
    }
}
