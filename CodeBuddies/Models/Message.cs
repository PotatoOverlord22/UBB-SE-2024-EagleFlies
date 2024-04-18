using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBuddies.Models
{
    internal class Message
    {
        private long messageId;

        public long MessageId
        {
            get { return messageId; }
            set { messageId = value; }
        }

        private DateTime timeStamp;

        public DateTime TimeStamp
        {
            get { return timeStamp; }
            set { timeStamp = value; }
        }
        private string content;

        public string Content
        {
            get { return content; }
            set { content = value; }
        }

        private long senderId;

        public long SenderId
        {
            get { return senderId; }
            set { senderId = value; }
        }

        public Message(long messageId, DateTime timeStamp, string messageContent, long senderId)
        {
            MessageId = messageId;
            TimeStamp = timeStamp;
            Content = messageContent;
            SenderId = senderId;
        }
    }
}
