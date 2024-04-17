using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBuddies.Models
{
    internal class Message
    {
        long MessageId { get; set; }
        DateTime TimeStamp { get; set; }
        string MessageContent { get; set; }

        long SenderId { get; set; }

        public Message(long messageId, DateTime timeStamp, string messageContent, long senderId)
        {
            MessageId = messageId;
            TimeStamp = timeStamp;
            MessageContent = messageContent;
            SenderId = senderId;
        }
    }
}
