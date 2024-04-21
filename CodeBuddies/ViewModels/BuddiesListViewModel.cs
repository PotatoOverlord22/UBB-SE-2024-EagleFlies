using CodeBuddies.Models.Entities;
using CodeBuddies.MVVM;
using CodeBuddies.Repositories;
using CodeBuddies.Views;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace CodeBuddies.ViewModels
{
    internal class BuddiesListViewModel : ViewModelBase
    {
        private ObservableCollection<Buddy> buddies = new ObservableCollection<Buddy>();
        public ICommand OpenPopupCommand { get; }
        private BuddyRepository repository;

        public BuddyRepository Repository
        {
            get { return repository; }
            set { repository = value; }
        }

        public RelayCommand<Buddy> OpenModalCommand => new RelayCommand<Buddy>(_ => OpenModal());
      
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
            LoadBuddies();
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
            LoadBuddies();

        }
       

        private void LoadBuddies()
        {
            Buddies = new ObservableCollection<Buddy>(repository.GetAllBuddies());
        }

        private void OpenModal()
        {
            Console.WriteLine("test");
            var modalWindow = new BuddyModalWindow();
            modalWindow.Owner = Application.Current.MainWindow; // Ensure it's modal to the main window
            
            bool? dialogResult = modalWindow.ShowDialog();


            if (dialogResult == true)
            {
                Debug.WriteLine("Action pressed! \n");
            }
            else
            {
                Debug.WriteLine("Close pressed!");
                // Handle actions if Cancelled or closed
            }
        }


    }
}