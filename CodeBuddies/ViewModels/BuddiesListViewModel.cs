using CodeBuddies.Models.Entities;
using CodeBuddies.MVVM;
using CodeBuddies.Repositories;
using System.Collections.ObjectModel;
using System.IO;

namespace CodeBuddies.ViewModels
{
    internal class BuddiesListViewModel : ViewModelBase
    {
        private BuddyRepository repository;

        public BuddyRepository Repository
        {
            get { return repository; }
            set { repository = value; }
        }


        private ObservableCollection<Buddy> buddies = new ObservableCollection<Buddy>();

        public ObservableCollection<Buddy> Buddies
        {
            get { return buddies; }
            set { buddies = value; OnPropertyChanged(); }
        }

        private string searchText;

        public string SearchText
        {
            get { return searchText; }
            set
            {
                searchText = value;
                FilterBuddies();
                OnPropertyChanged();
            }
        }

        public BuddiesListViewModel()
        {
            repository = new BuddyRepository("../../../Resources/Data/buddies.xml");
            foreach (Buddy buddy in repository.GetAll())
            {
                buddies.Add(buddy);
            }
        }

        private void FilterBuddies()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                Buddies.Clear();
                foreach (Buddy buddy in repository.GetAll())
                {
                    Buddies.Add(buddy);
                }
            }
            else
            {
                ObservableCollection<Buddy> filteredBuddies = new ObservableCollection<Buddy>();
                foreach (var buddy in repository.GetAll())
                {
                    if (buddy.BuddyName.ToLower().Contains(SearchText.ToLower()))
                    {
                        filteredBuddies.Add(buddy);
                    }
                }
                Buddies = filteredBuddies;
            }
        }
    }
}