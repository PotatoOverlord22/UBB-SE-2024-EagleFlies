using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBuddies.Models.Entities
{
    internal abstract class Notification
    {
        protected long NotificationId { get; set; }
        protected DateTime TimeStamp { get; set; }

        protected string Status { get; set; }

        protected string Description { get; set; }

        public Notification(long notificationId, DateTime timeStamp, string status, string description)
        {
            NotificationId = notificationId;
            TimeStamp = timeStamp;
            Status = status;
            Description = description;
        }

        protected abstract void MarkNotification();
    }
}
