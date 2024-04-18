using CodeBuddies.Models.Entities;
using CodeBuddies.MVVM;
using CodeBuddies.Repositories;
using System.Collections.ObjectModel;
using System.IO;

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
            BuddyRepository repository = new BuddyRepository("../../../Resources/Data/buddies.xml");
            foreach (Buddy buddy in repository.GetAll())
            {
                buddies.Add(buddy);
            }
        }
    }
}
