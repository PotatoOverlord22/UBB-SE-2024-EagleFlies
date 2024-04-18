using CodeBuddies.ViewModels;
using System.Windows.Controls;

namespace CodeBuddies.Views.UserControls
{
    public partial class BuddiesList : UserControl
    {
        public BuddiesList()
        {
            InitializeComponent();
            DataContext = new BuddiesListViewModel();
        }
    }
}
