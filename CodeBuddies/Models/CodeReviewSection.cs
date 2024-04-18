using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBuddies.Models
{
    internal class CodeReviewSection
    {
        private long id;

        private long Id
        {
            get { return id; }
            set { id = value; }
        }

        private long ownerId;

        public long OwnerId
        {
            get { return ownerId; }
            set { ownerId = value; }
        }
        private List<Message> messages;

        public List<Message> Messages
        {
            get { return messages; }
            set { messages = value; }
        }
        private string codeSection;

        public string CodeSection
        {
            get { return codeSection; }
            set { codeSection = value; }
        }

        private bool isClosed;

        public bool IsClosed
        {
            get { return isClosed; }
            set { isClosed = value; }
        }

        public CodeReviewSection(long codeReviewSectionId, long ownerId, List<Message> message, string codeSection, bool isClosed)
        {
            Id = codeReviewSectionId;
            OwnerId = ownerId;
            Messages = message;
            CodeSection = codeSection;
            IsClosed = isClosed;
        }
    }
}
