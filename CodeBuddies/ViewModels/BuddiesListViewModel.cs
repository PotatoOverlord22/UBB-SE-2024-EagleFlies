using CodeBuddies.Models;
using CodeBuddies.MVVM;
using System.Collections.ObjectModel;

namespace CodeBuddies.ViewModels
{
    internal class BuddiesListViewModel : ViewModelBase
    {
        private ObservableCollection<Buddy> buddies = new ObservableCollection<Buddy>();

        public ObservableCollection<Buddy> Buddies
        {
            get { return buddies; }
            set { buddies = value; OnPropertyChanged(); }
        }


        public BuddiesListViewModel()
        {
            PopulateWithHardCodedBuddies();
        }

        public void PopulateWithHardCodedBuddies()
        {
            buddies.Add(new Buddy(1, "yo1", "pack://application:,,,/CodeBuddies;component/resources/pictures/dog_picture.png", "active", new List<Notification>()));
            buddies.Add(new Buddy(2, "yo2", "pack://application:,,,/CodeBuddies;component/resources/pictures/dog_picture.png", "inactive", new List<Notification>()));
            buddies.Add(new Buddy(3, "yo3", "pack://application:,,,/CodeBuddies;component/resources/pictures/dog_picture.png", "inactive", new List<Notification>()));
        }
    }
}
