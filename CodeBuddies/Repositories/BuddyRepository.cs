using CodeBuddies.Models.Entities;
using CodeBuddies.Models.Exceptions;
using System.Linq;
using System.Xml;

namespace CodeBuddies.Repositories
{
    internal class BuddyRepository
    {
        private string filePath;

        public string FilePath
        {
            get { return filePath; }
            set { filePath = value; }
        }

        private List<Buddy> buddies;

        public List<Buddy> Buddies
        {
            get { return buddies; }
            set { buddies = value; }
        }

        public BuddyRepository(string filePath)
        {
            FilePath = filePath;
            Buddies = new List<Buddy>();
            ReadFromFile();
        }

        public void ReadFromFile()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(FilePath);
            buddies.Clear();


        }

        public void SaveToFile()
        {
            // Save the buddies to the xml file given by FilePath
        }

        public List<Buddy> GetAll()
        {
            return Buddies;
        }
    }
}
