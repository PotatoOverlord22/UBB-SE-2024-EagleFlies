using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeBuddies.MVVM;
using CodeBuddies.Repositories;
using CodeBuddies.Models.Entities;
using System.Collections.ObjectModel;

namespace CodeBuddies.ViewModels
{
    internal class ActiveInactiveBuddiesListViewModel : ViewModelBase
    {
        BuddyRepository budyRepository;

        public BuddyRepository BuddyRepository
        {
            get { return budyRepository; }
            set { budyRepository = value; }
        }

        private List<Buddy> activeBuddies;

        public List<Buddy> ActiveBuddies
        {
            get { return activeBuddies; }
            set { activeBuddies = value; OnPropertyChanged(); }
        }

        private List<Buddy> inactiveBuddies;

        public List<Buddy> InactiveBuddies
        {
            get { return inactiveBuddies; }
            set { inactiveBuddies = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Buddy> active = new ObservableCollection<Buddy>();

        public ObservableCollection<Buddy> Active
        {
            get { return active; }
            set { active = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Buddy> inactive = new ObservableCollection<Buddy>();

        public ObservableCollection<Buddy> Inactive
        {
            get { return inactive; }
            set { inactive = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Buddy> allBuddies = new ObservableCollection<Buddy>();

        public ObservableCollection<Buddy> AllBuddies
        {
            get { return allBuddies; }
            set { allBuddies = value; OnPropertyChanged(); }
        }
        
        public ActiveInactiveBuddiesListViewModel()
        {
            // Initialize the BuddyRepository with the path to the buddies.xml file
            BuddyRepository = new BuddyRepository("../../../Resources/Data/buddies.xml");

            ActiveBuddies = BuddyRepository.GetActiveBuddies();
            foreach (Buddy buddy in ActiveBuddies)
            {
                Active.Add(buddy);
            }

            InactiveBuddies = BuddyRepository.GetInactiveBuddies();
            foreach (Buddy buddy in InactiveBuddies)
            {
                Inactive.Add(buddy);
            }

            foreach (Buddy buddy in ActiveBuddies)
            {
                AllBuddies.Add(buddy);
            }

            foreach (Buddy buddy in InactiveBuddies)
            {
                AllBuddies.Add(buddy);
            }
        }

        public void Refresh()
        {
            ActiveBuddies = BuddyRepository.GetActiveBuddies();
            InactiveBuddies = BuddyRepository.GetInactiveBuddies();

            OnPropertyChanged("ActiveBuddies");
            OnPropertyChanged("InactiveBuddies");
            OnPropertyChanged("Active");
            OnPropertyChanged("Inactive");
        }

        public void UpdateBuddyStatus(Buddy buddy)
        {
            BuddyRepository.UpdateBuddyStatus(buddy);
            Refresh();
        }
    }
}
