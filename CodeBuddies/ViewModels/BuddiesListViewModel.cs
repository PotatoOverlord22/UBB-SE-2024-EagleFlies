using CodeBuddies.Models;
using CodeBuddies.MVVM;

namespace CodeBuddies.ViewModels
{
    internal class BuddiesListViewModel : ViewModelBase
    {
        private List<Buddy> buddies;

        public List<Buddy> Buddies
        {
            get { return buddies; }
            set { buddies = value; OnPropertyChanged(); }
        }


        public BuddiesListViewModel()
        {

        }

        public static void PopulateWithHardCodedBuddies()
        {

        }
    }
}
