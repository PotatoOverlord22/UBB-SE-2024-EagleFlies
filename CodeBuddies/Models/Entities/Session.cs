using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBuddies.Models.Entities
{
    internal class Session
    {
        private long id;

        public long Id
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

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private DateTime creationDate;

        public DateTime CreationDate
        {
            get { return creationDate; }
            set { creationDate = value; }
        }

        private DateTime lastEditDate;

        public DateTime LastEditDate
        {
            get { return lastEditDate; }
            set { lastEditDate = value; }
        }

        private List<long> buddies;

        public List<long> Buddies
        {
            get { return buddies; }
            set { buddies = value; }
        }

        private List<Message> messages;

        public List<Message> Messages
        {
            get { return messages; }
            set { messages = value; }
        }

        private List<CodeContribution> codeContributions;

        public List<CodeContribution> CodeContributions
        {
            get { return codeContributions; }
            set { codeContributions = value; }
        }

        private List<CodeReviewSection> codeReviewSections;

        public List<CodeReviewSection> CodeReviewSections
        {
            get { return codeReviewSections; }
            set { codeReviewSections = value; }
        }

        private List<string> filePaths;

        public List<string> FilePaths
        {
            get { return filePaths; }
            set { filePaths = value; }
        }

        private TextEditor textEditor;

        public TextEditor TextEditor
        {
            get { return textEditor; }
            set { textEditor = value; }
        }

        private DrawingBoard drawingBoard;

        public DrawingBoard DrawingBoard
        {
            get { return drawingBoard; }
            set { drawingBoard = value; }
        }

        public Session(long sessionId, long ownerId, string name, DateTime creationDate, DateTime lastEditedDate, List<long> buddies, List<Message> messages, List<CodeContribution> codeContributions, List<CodeReviewSection> codeReviewSections, List<string> filePaths, TextEditor textEditor, DrawingBoard drawingBoard)
        {
            Id = sessionId;
            OwnerId = ownerId;
            Name = name;
            CreationDate = creationDate;
            LastEditDate = lastEditedDate;
            Buddies = buddies;
            Messages = messages;
            CodeContributions = codeContributions;
            CodeReviewSections = codeReviewSections;
            FilePaths = filePaths;
            TextEditor = textEditor;
            DrawingBoard = drawingBoard;
        }

        public void AddBuddy(long buddyId)
        {
            // Add buddy to the session
        }

        public void RemoveBuddy(long buddyId)
        {
            // Remove buddy from the session
        }

        public void LeaveSession(long buddyId)
        {
            // Leave the session
        }

        public void UploadFile(string filePath)
        {
            FilePaths.Add(filePath);
        }

        public void addCodeContribution(int buddyId, DateTime date, int contributionValue)
        {
            // Add code contribution
        }

        public void PostMessage(Message message)
        {
            Messages.Add(message);
        }

        public void PostCodeReviewSection(CodeReviewSection codeReviewSection)
        {
            CodeReviewSections.Add(codeReviewSection);
        }

        public void PostCodeReviewSectionMessage(long codeReviewSectionId, Message message)
        {
            // Post message to code review section
        }


    }
}
