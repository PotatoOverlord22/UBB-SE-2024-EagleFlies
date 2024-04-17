using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBuddies.Models
{
    internal class InviteNotification : Notification
    {

        bool IsAccepted { get; set; }
        public InviteNotification(long notificationId, DateTime timeStamp, string type, string status, string description, bool isAccepted) : base(notificationId, timeStamp, type, status, description)
        { 
            IsAccepted = isAccepted;
        }
      
        protected override void MarkNotification()
        {
            // mark as declined/accepted
        }
    }
}
