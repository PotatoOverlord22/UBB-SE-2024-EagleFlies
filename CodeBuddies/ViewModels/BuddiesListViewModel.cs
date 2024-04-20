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


        private ObservableCollection<Buddy> buddies;

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
            repository = new BuddyRepository();
            Buddies = new ObservableCollection<Buddy>(repository.GetAllBuddies());
        }

        private void FilterBuddies()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                Buddies.Clear();
                foreach (Buddy buddy in repository.GetAllBuddies())
                {
                    Buddies.Add(buddy);
                }
            }
            else
            {
                ObservableCollection<Buddy> filteredBuddies = new ObservableCollection<Buddy>();
                foreach (var buddy in repository.GetAllBuddies())
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