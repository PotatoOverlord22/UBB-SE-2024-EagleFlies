using CodeBuddies.Models;

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
            PopulateBuddiesFromFile();
        }

        public void PopulateBuddiesFromFile()
        {
            // Read from an xml file given by FilePath all the buddies and populate the list
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
