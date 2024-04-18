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

        public SessionRepository(string filePath)
        {
            FilePath = filePath;
            Sessions = new List<Session>();
            ReadFromFile();
        }

        public void ReadFromFile()
        {
            XDocument doc = XDocument.Load(FilePath);

            Sessions = doc.Descendants("Session").Select(session => new Session(
                (long)session.Element("Id"),
                (long)session.Element("OwnerId"),
                (string)session.Element("Name"),
                DateTime.Parse((string)session.Element("CreationDate")),
                DateTime.Parse((string)session.Element("LastEditDate")),
                session.Element("Buddies").Elements("BuddyRef").Select(b => new Buddy(b)).ToList(),
                session.Element("Messages").Elements("Message").Select(m => new Message(m)).ToList(),
                session.Element("CodeContributions").Elements("CodeContribution").Select(c => new CodeContribution(c)).ToList(),
                session.Element("CodeReviewSections").Elements("CodeReviewSection").Select(c => new CodeReviewSection(c)).ToList(),
                session.Element("FilePaths").Elements("FilePath").Select(f => f.Value).ToList(),
                new TextEditor((string)session.Element("TextEditor").Element("TextColor"), session.Element("TextEditor").Elements("FilesPaths").Select(f => f.Value).ToList()),
                new DrawingBoard((string)session.Element("DrawingBoard").Element("FilePath"))
            )).ToList();
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
