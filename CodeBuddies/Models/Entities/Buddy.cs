using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBuddies.Models.Entities
{
    internal class Buddy
    {
        private long id;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        private string buddyName;

        public string BuddyName
        {
            get { return buddyName; }
            set { buddyName = value; }
        }

        private string profilePhotoUrl;

        public string ProfilePhotoUrl
        {
            get { return profilePhotoUrl; }
            set { profilePhotoUrl = value; }
        }

        private string status;

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        List<Notification> Notifications;


        public Buddy(long buddyId, string buddyName, string profilePhotoUrl, string status, List<Notification> notifications)
        {
            Id = buddyId;
            BuddyName = buddyName;
            ProfilePhotoUrl = profilePhotoUrl;
            Status = status;
            Notifications = notifications;
        }


        public void CreateNewSession(string sessionName)
        {
            // create a new session
        }

        public void AcceptInvite()
        {
            // accept invite
        }

        public void DeclineInvite()
        {
            // decline invite
        }

        public void SendInvite()
        {
            // send invite
        }
    }
}
