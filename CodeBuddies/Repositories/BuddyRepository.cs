﻿using CodeBuddies.Models.Entities;

using System.Xml.Linq;

namespace CodeBuddies.Repositories
{
    internal class BuddyRepository
    {
        private string filePath;

        public string FilePath
        {
            get { return filePath; }
            set { filePath = value; }
        }

        private List<Buddy> buddies;

        public List<Buddy> Buddies
        {
            get { return buddies; }
            set { buddies = value; }
        }

        public BuddyRepository(string filePath)
        {
            FilePath = filePath;
            Buddies = new List<Buddy>();
            ReadFromFile();
        }

        public void ReadFromFile()
        {
            XDocument doc = XDocument.Load(FilePath);
            List<Buddy> buddies = doc.Descendants("Buddy").Select(buddy =>
            {
                long id = (long)buddy.Element("Id");
                string name = (string)buddy.Element("Name");
                string imageUrl = (string)buddy.Element("ImageUrl");
                string status = (string)buddy.Element("Status");

                List<Notification> notifications = new List<Notification>();

                foreach (var notification in buddy.Descendants("Notification"))
                {
                    long notificationId = (long)notification.Element("Id");
                    DateTime timeStamp = (DateTime)notification.Element("TimeStamp");
                    string type = (string)notification.Element("Type");
                    string notificationStatus = (string)notification.Element("Status");
                    string message = (string)notification.Element("Message");

                    if (type == "information")
                        notifications.Add(new InfoNotification(notificationId, timeStamp, type, notificationStatus, message));
                    if (type == "invite")
                        notification.Add(new InviteNotification(notificationId, timeStamp, type, notificationStatus, message, false));
                }

                return new Buddy(id, name, imageUrl, status, notifications);
            }).ToList();

            Buddies = buddies;

        }

        public void SaveToFile()
        {
            XElement buddiesXml = new XElement("Buddies");

            foreach (var buddy in Buddies)
            {
                XElement buddyXml = new XElement("Buddy",
                    new XElement("Id", buddy.Id),
                    new XElement("Name", buddy.BuddyName),
                    new XElement("ImageUrl", buddy.ProfilePhotoUrl),
                    new XElement("Status", buddy.Status),
                    new XElement("Notifications",
                        buddy.Notifications.Select(notification =>
                            new XElement("Notification",
                                new XElement("Id", notification.NotificationId),
                                new XElement("Type", notification.Type),
                                new XElement("Status", notification.Status),
                                new XElement("Message", notification.Description),
                                new XElement("TimeStamp", notification.TimeStamp.ToString("yyyy-MM-ddTHH:mm:ss"))
                            )
                        )
                    )
                );

                buddiesXml.Add(buddyXml);
            }

            buddiesXml.Save(filePath);
        }

        public List<Buddy> GetAll()
        {
            return Buddies;
        }

        public Buddy GetById(int id)
        {
            foreach (var buddy in Buddies) 
            {
                if (buddy.Id == id)
                    return buddy;
            }
            return null;
        }

        // TODO remove this
        public void PopulateWithHardCodedBuddies()
        {
            buddies.Add(new Buddy(1, "yo1", "pack://application:,,,/CodeBuddies;component/resources/pictures/dog_picture.png", "active", new List<Notification>()));
            buddies.Add(new Buddy(2, "yo2", "pack://application:,,,/CodeBuddies;component/resources/pictures/dog_picture.png", "inactive", new List<Notification>()));
            buddies.Add(new Buddy(3, "yo3", "pack://application:,,,/CodeBuddies;component/resources/pictures/dog_picture.png", "inactive", new List<Notification>()));
        }
    }
}
