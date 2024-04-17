using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBuddies.Models
{
    internal class Buddy
    {

        long BuddyId { get; set; }
        string BuddyName { get; set; }
        string ProfilePhotoUrl { get; set; }
        string Status { get; set; }

        List<Notification> Notifications;


        public Buddy(long buddyId, string buddyName, string profilePhotoUrl, string status, List<Notification> notifications)
        {
            BuddyId = buddyId;
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
