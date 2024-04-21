using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using CodeBuddies.Models.Entities;
using CodeBuddies.MVVM;
using CodeBuddies.ViewModels;
using CodeBuddies.Views.Windows;

namespace CodeBuddies.Views
{
    public partial class BuddyModalWindow : Window
    {
        public BuddyModalWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        public ICommand CloseCommand => new RelayCommand<Buddy>(_ => Close());

        public ICommand OpenWindowModalCommand => new RelayCommand<Buddy>(_ => OpenSessionModal());

        internal RelayCommand<Buddy> PinBuddyCommand => new RelayCommand<Buddy>(HandlePinBuddy);

        private void OpenSessionModal()
        {
            Console.WriteLine("test");
            Close();
            var sessionWindow = new SessionsModalWindow();
            sessionWindow.Owner = Application.Current.MainWindow; // Ensure it's modal to the main window
            bool? dialogResult = sessionWindow.ShowDialog();


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

        internal void HandlePinBuddy(Buddy buddy)
        {
            GlobalEvents.RaiseBuddyPinned(buddy);
        }

    }

}
