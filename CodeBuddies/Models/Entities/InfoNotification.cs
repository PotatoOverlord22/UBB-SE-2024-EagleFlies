using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBuddies.Models.Entities
{
    internal class InfoNotification : Notification
    {
        public InfoNotification(long notificationId, DateTime timeStamp, string type, string status, string description, long senderId, long receiverId, long sessionId) : base(notificationId, timeStamp, type, status, description, senderId, receiverId, sessionId) { }

        protected override void MarkNotification()
        {
            // mark as read
        }
    }


}
