using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBuddies.Models.Entities
{
    internal class InviteNotification : Notification
    {
        private bool isAccepted;

        public bool IsAccepted
        {
            get { return isAccepted; }
            set { isAccepted = value; }
        }

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
