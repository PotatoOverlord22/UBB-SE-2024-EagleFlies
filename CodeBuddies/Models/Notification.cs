using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBuddies.Models
{
    internal abstract class Notification
    {
        protected long NotificationId { get; set; }
        protected DateTime TimeStamp { get; set; }
        protected string Type { get; set; }

        protected string Status { get; set; }

        protected string Description { get; set; }

        public Notification(long notificationId, DateTime timeStamp, string type, string status, string description)
        {
            NotificationId = notificationId;
            TimeStamp = timeStamp;
            Type = type;
            Status = status;
            Description = description;
        }

        protected abstract void MarkNotification();
    }
}
