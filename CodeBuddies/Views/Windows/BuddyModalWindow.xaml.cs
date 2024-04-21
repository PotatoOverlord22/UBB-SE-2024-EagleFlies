using System.Windows;
using System.Windows.Input;
using CodeBuddies.Models.Entities;
using CodeBuddies.MVVM;

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
    }

}
