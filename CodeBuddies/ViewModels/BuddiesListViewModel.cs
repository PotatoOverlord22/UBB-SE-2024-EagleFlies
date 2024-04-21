using CodeBuddies.Models.Entities;
using CodeBuddies.MVVM;
using CodeBuddies.Repositories;
using CodeBuddies.Stores;
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
        private readonly ModalNavigationStore _modalNavigationStore;
        public ICommand OpenPopupCommand { get; }

        public ICommand OpenModalCommand { get; }
      
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

            OpenModalCommand = new RelayCommand(_ => OpenModal());
            LoadBuddies();

        }
       

        private void LoadBuddies()
        {
            // Load buddies logic here
        }

        private void OpenModal()
        {
            var modalWindow = new BuddyModalWindow();
            modalWindow.Owner = Application.Current.MainWindow; // Ensure it's modal to the main window
            
            bool? dialogResult = modalWindow.ShowDialog();


            //aici nu stiu cum trebuie facut ca sa faca diferit intreaba pe gpt

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
