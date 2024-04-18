using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBuddies.Models.Entities
{
    internal class InfoNotification : Notification
    {
        public InfoNotification(long notificationId, DateTime timeStamp, string type, string status, string description) : base(notificationId, timeStamp, type, status, description) {}
      
        protected override void MarkNotification()
        {
            // mark as read
        }
    }
    
    
}
