using CodeBuddies.Models.Entities;
using CodeBuddies.MVVM;
using CodeBuddies.Repositories;
using CodeBuddies.Views;
using CodeBuddies.Views.Windows;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Input;
using SessionsModalWindow = CodeBuddies.Views.Windows.SessionsModalWindow;

namespace CodeBuddies.ViewModels
{
    internal class BuddiesListViewModel : ViewModelBase
    {
        private ObservableCollection<Buddy> buddies;
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
            GlobalEvents.BuddyPinned += HandleBuddyPinned;
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

        private Buddy selectedBuddy;
        public Buddy SelectedBuddy
        {
            get => selectedBuddy;
            set
            {
                selectedBuddy = value;
                OnPropertyChanged();
            }
        }

        private void OpenModal()
        {
            Console.WriteLine("test ", selectedBuddy.BuddyName);
            if (SelectedBuddy != null)
            {

                
                var modalWindow = new BuddyModalWindow(SelectedBuddy);
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

        internal void HandleBuddyPinned()
        {
            Buddies.Remove(selectedBuddy);
            Buddies.Insert(0, selectedBuddy);
            OnPropertyChanged();
        }

        
    }
}