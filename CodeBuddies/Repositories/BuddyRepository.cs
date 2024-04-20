using CodeBuddies.MVVM;
using CodeBuddies.Models.Entities;
using System.Data.SqlClient;
using System.Data;
namespace CodeBuddies.Repositories
{
    internal class BuddyRepository : DBRepositoryBase
    {

        public BuddyRepository() : base() { }
        

        public List<Buddy> GetAllBuddies()
        {

            List<Buddy> buddies = new List<Buddy>();

            DataSet buddyDataSet = new DataSet();
            string selectAllBuddies = "SELECT * FROM Buddies";
            SqlCommand selectAllBuddiesCommand = new SqlCommand(selectAllBuddies, sqlConnection);
            dataAdapter.SelectCommand = selectAllBuddiesCommand;
            buddyDataSet.Clear();
            dataAdapter.Fill(buddyDataSet, "Buddies");

            foreach (DataRow buddyRow in buddyDataSet.Tables["Buddies"].Rows)
            {

                SqlDataAdapter notificationsDataAdapter = new SqlDataAdapter();

                DataSet notificationDataSet = new DataSet();
                string notificationQuery = "SELECT * FROM Notifications where buddy_id = @id";
                SqlCommand selectAllNotificationsForSpecificBuddyCommand = new SqlCommand(notificationQuery, sqlConnection);
                notificationsDataAdapter.SelectCommand = selectAllNotificationsForSpecificBuddyCommand;
                selectAllNotificationsForSpecificBuddyCommand.Parameters.AddWithValue("@id", buddyRow["id"]);
                notificationDataSet.Clear();
                notificationsDataAdapter.Fill(notificationDataSet, "Notifications");

                List<Notification> notifications = new List<Notification>();

                foreach (DataRow notificationRow in notificationDataSet.Tables["Notifications"].Rows)
                {

                    Notification currentNotification;

                    if (notificationRow["notification_type"].ToString() == "invite")
                    {
                        currentNotification = new InviteNotification((long)notificationRow["id"], (DateTime)notificationRow["notification_timestamp"], notificationRow["notification_type"].ToString(), notificationRow["notification_status"].ToString(), notificationRow["notification_description"].ToString(), (long)notificationRow["session_id"],false);
                    }    
                    else
                    {
                        currentNotification = new InfoNotification((long)notificationRow["id"], (DateTime)notificationRow["notification_timestamp"], notificationRow["notification_type"].ToString(), notificationRow["notification_status"].ToString(), notificationRow["notification_description"].ToString(), (long)notificationRow["session_id"]);

                    }

                    notifications.Add(currentNotification);
             
                }

                Buddy currentBudy = new Buddy((long)buddyRow["id"], buddyRow["buddy_name"].ToString(), buddyRow["profile_photo_url"].ToString(), buddyRow["buddy_status"].ToString(), notifications );
                buddies.Add(currentBudy);
            }

            return buddies;

        }


    }
}
