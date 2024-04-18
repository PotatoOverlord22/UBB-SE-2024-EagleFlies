using System.Windows.Controls;
using CodeBuddies.ViewModels;

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
