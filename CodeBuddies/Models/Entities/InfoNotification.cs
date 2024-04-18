using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBuddies.Models.Entities
{
    internal class InfoNotification : Notification
    {
        public InfoNotification(long notificationId, DateTime timeStamp, string status, string description) : base(notificationId, timeStamp, status, description) { }

        protected override void MarkNotification()
        {
            // mark as read
        }
    }


}
