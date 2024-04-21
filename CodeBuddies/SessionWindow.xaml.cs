using CodeBuddies.Models.Entities;
using CodeBuddies.ViewModels;
using System.Windows;

namespace CodeBuddies
{
    /// <summary>
    /// Interaction logic for SessionWindow.xaml
    /// </summary>
    public partial class SessionWindow : Window
    {
        public SessionWindow()
        {
            InitializeComponent();
            DataContext = new SessionViewModel();
        }
    }
}
