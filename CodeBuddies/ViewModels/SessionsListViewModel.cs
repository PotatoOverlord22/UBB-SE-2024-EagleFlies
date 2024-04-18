using CodeBuddies.Models.Entities;
using CodeBuddies.MVVM;
using System.Collections.ObjectModel;


namespace CodeBuddies.ViewModels
{
    internal class SessionsListViewModel : ViewModelBase
    {
        private ObservableCollection<Session> sessions = new ObservableCollection<Session>();

        public ObservableCollection<Session> Sessions
        {
            get { return sessions; }
            set { sessions = value; OnPropertyChanged(); }
        }


        public SessionsListViewModel()
        {
            PopulateWithHardCodedSessions();
        }

        public void PopulateWithHardCodedSessions()
        {
            for (int i = 1; i <= 10; i++)
            {
                long sessionId = i;
                long ownerId = 100 + i; // Just sample data
                string name = "Session " + i;
                DateTime creationDate = DateTime.Now;
                DateTime lastEditedDate = DateTime.Now;
                List<Buddy> buddies = new List<Buddy>
                {
                    new Buddy(i, "Buddy " + i, "url", "Active", new List<Notification>())
                };
                List<Message> messages = new List<Message>
                {
                    new Message(i, DateTime.Now, "Hello from session " + i, i)
                };
                List<CodeContribution> codeContributions = new List<CodeContribution>
                {
                    new CodeContribution(new Buddy(i, "Buddy " + i, "url", "Active", new List<Notification>()), DateTime.Now, 10)
                };
                List<CodeReviewSection> codeReviewSections = new List<CodeReviewSection>
                {
                    new CodeReviewSection(i, ownerId, new List<Message>(), "Code section example", false)
                };
                List<string> filePaths = new List<string> { $"path_to_file_{i}.txt" };
                TextEditor textEditor = new TextEditor("grey", filePaths); // Assuming a constructor exists
                DrawingBoard drawingBoard = new DrawingBoard($"drawing_{i}.png");

                sessions.Add(new Session(sessionId, ownerId, name, creationDate, lastEditedDate, buddies, messages, codeContributions, codeReviewSections, filePaths, textEditor, drawingBoard));
            }

        }
    }
}
