using CodeBuddies.Models.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;

namespace CodeBuddies.Repositories
{
    internal class SessionRepository
    {
        private string filePath;
        private BuddyRepository buddyRepository;

        public string FilePath
        {
            get { return filePath; }
            set { filePath = value; }
        }

        private List<Session> sessions;

        public List<Session> Sessions
        {
            get { return sessions; }
            set { sessions = value; }
        }

        public SessionRepository(BuddyRepository buddyRepository, string filePath)
        {
            FilePath = filePath;
            Sessions = new List<Session>();
            this.buddyRepository = buddyRepository;
            ReadFromFile();
        }

        public void ReadFromFile()
        {
            XDocument doc = XDocument.Load(filePath);

            this.Sessions = doc.Descendants("Session").Select(session =>
            {
                long id = (long)session.Element("Id");
                long ownerId = (long)session.Element("OwnerId");
                string name = (string)session.Element("Name");
                DateTime creationDate = DateTime.Parse((string)session.Element("CreationDate"));
                DateTime lastEditDate = DateTime.Parse((string)session.Element("LastEditDate"));
                var buddies = session.Element("Buddies").Elements("BuddyRef")
                    .Select(br => this.buddyRepository.GetById((int)br))
                    .Where(b => b != null)
                    .ToList();

                var messages = session.Element("Messages").Elements("Message")
                    .Select(m => new Message(
                        (long)m.Element("MessageId"),
                        DateTime.Parse((string)m.Element("TimeStamp")),
                        (string)m.Element("Content"),
                        (long)m.Element("SenderId")
                    )).ToList();

                var codeContributions = session.Element("CodeContributions").Elements("CodeContribution")
                    .Select(c => new CodeContribution(
                        this.buddyRepository.GetById((int)c.Element("ContributorRef")), // Assuming Contributor is directly under CodeContribution
                        DateTime.Parse((string)c.Element("ContributionDate")),
                        (int)c.Element("ContributionValue")
                    )).ToList();

                var codeReviewSections = session.Element("CodeReviewSections").Elements("CodeReviewSection")
                    .Select(crs => new CodeReviewSection(
                        (long)crs.Element("Id"),
                        (long)crs.Element("OwnerId"),
                        crs.Element("Messages").Elements("Message").Select(m => new Message(
                            (long)m.Element("MessageId"),
                            DateTime.Parse((string)m.Element("TimeStamp")),
                            (string)m.Element("Content"),
                            (long)m.Element("SenderId")
                        )).ToList(),
                        (string)crs.Element("CodeSection"),
                        (bool)crs.Element("IsClosed")
                    )).ToList();

                return new Session(id, ownerId, name, creationDate, lastEditDate, buddies, messages, codeContributions, codeReviewSections, null, null, null);
            }).ToList();
        }
        public void SaveToFile()
        {
            var sessionsXml = new XElement("Sessions",
                Sessions.Select(session => new XElement("Session",
                    new XElement("Id", session.Id),
                    new XElement("OwnerId", session.OwnerId),
                    new XElement("Name", session.Name),
                    new XElement("CreationDate", session.CreationDate.ToString("s")),
                    new XElement("LastEditDate", session.LastEditDate.ToString("s")),
                    new XElement("Buddies", session.Buddies.Select(b => new XElement("BuddyRef", b.Id))),
                    new XElement("Messages", session.Messages.Select(m =>
                        new XElement("Message",
                            new XElement("MessageId", m.MessageId),
                            new XElement("SenderId", m.SenderId),
                            new XElement("TimeStamp", m.TimeStamp.ToString("s")),
                            new XElement("Content", m.Content)
                        )
                    )),
                    new XElement("CodeContributions", session.CodeContributions.Select(c =>
                        new XElement("CodeContribution",
                            new XElement("Contributor", c.Contributor.Id),
                            new XElement("ContributionDate", c.ContributionDate.ToString("s")),
                            new XElement("ContributionValue", c.ContributionValue)
                        )
                    )),
                    new XElement("CodeReviewSections", session.CodeReviewSections.Select(c =>
                        new XElement("CodeReviewSection",
                            new XElement("Id", c.Id),
                            new XElement("OwnerId", c.OwnerId),
                            new XElement("IsClosed", c.IsClosed),
                            new XElement("CodeSection", c.CodeSection)
                        )
                    )),
                    new XElement("FilePaths", session.FilePaths.Select(f => new XElement("FilePath", f))),
                    new XElement("TextEditor",
                        new XElement("TextColor", session.TextEditor.TextColor),
                        new XElement("FilesPaths", session.TextEditor.FilePaths.Select(f => new XElement("FilePath", f)))
                    ),
                    new XElement("DrawingBoard",
                        new XElement("FilePath", session.DrawingBoard.FilePath)
                    )
                ))
            );

            sessionsXml.Save(FilePath);
        }

        public List<Session> GetAll()
        {
            return Sessions;
        }
    }
}
