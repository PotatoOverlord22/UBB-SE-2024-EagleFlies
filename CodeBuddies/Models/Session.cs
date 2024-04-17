using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBuddies.Models
{
    internal class Session
    {

        long SessionId { get; set; }

        long OwnerId { get; set; }

        string Name { get; set; }

        DateTime CreationDate { get; set; }

        DateTime LastEditedDate { get; set; }

        List<Buddy> Buddies { get; set;}

        List<Message> Messages { get; set; }

        List<CodeContribution> CodeContributions { get; set;}

        List<CodeReviewSection> CodeReviewSections { get; set;}

        List<string> FilesPaths { get; set; }


        TextEditor TextEditor { get; set; }

        DrawingBoard DrawingBoard { get; set; }

        public Session(long sessionId, long ownerId, string name, DateTime creationDate, DateTime lastEditedDate, List<Buddy> buddies, List<Message> messages, List<CodeContribution> codeContributions, List<CodeReviewSection> codeReviewSections, List<string> filesPaths, TextEditor textEditor, DrawingBoard drawingBoard)
        {
            SessionId = sessionId;
            OwnerId = ownerId;
            Name = name;
            CreationDate = creationDate;
            LastEditedDate = lastEditedDate;
            Buddies = buddies;
            Messages = messages;
            CodeContributions = codeContributions;
            CodeReviewSections = codeReviewSections;
            FilesPaths = filesPaths;
            TextEditor = textEditor;
            DrawingBoard = drawingBoard;
        }

        public void AddBuddy(int buddyId)
        {
            // Add buddy to the session
        }

        public void RemoveBuddy(int buddyId)
        {
            // Remove buddy from the session
        }

        public void LeaveSession(int buddyId)
        {
            // Leave the session
        }

        public void UploadFile(string filePath)
        {
            FilesPaths.Add(filePath);
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
