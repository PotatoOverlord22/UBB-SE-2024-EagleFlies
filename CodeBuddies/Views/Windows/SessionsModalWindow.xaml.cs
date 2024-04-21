using CodeBuddies.Models.Entities;
using CodeBuddies.MVVM;
using CodeBuddies.Resources.Data;
using CodeBuddies.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CodeBuddies.Views.Windows
{
   
    public partial class SessionsModalWindow : Window
    {
        private SessionsListViewModel viewModel;
        public SessionsModalWindow()
        {
            InitializeComponent();

            viewModel = new SessionsListViewModel();
            viewModel.filterSessionOnlyOwner(Constants.CLIENT_BUDDY_ID);
            DataContext = viewModel;
        }
        public ICommand CloseCommand => new RelayCommand<Buddy>(_ => Close());




    }
}
