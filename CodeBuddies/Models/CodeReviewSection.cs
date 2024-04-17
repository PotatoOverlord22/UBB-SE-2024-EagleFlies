using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBuddies.Models
{
    internal class CodeReviewSection
    {

        long CodeReviewSectionId { get; set; }
        long OwnerId { get; set; }
        List<Message> Messages { get; set; }

        string CodeSection { get; set; }

        bool IsClosed { get; set; }

        public CodeReviewSection(long codeReviewSectionId, long ownerId, List<Message> message, string codeSection, bool isClosed)
        {
            CodeReviewSectionId = codeReviewSectionId;
            OwnerId = ownerId;
            Messages = message;
            CodeSection = codeSection;
            IsClosed = isClosed;
        }
    }
}
