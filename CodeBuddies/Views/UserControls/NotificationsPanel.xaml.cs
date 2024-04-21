using CodeBuddies.ViewModels;
using System.Windows.Controls;


namespace CodeBuddies.Views.UserControls
{
    public partial class NotificationsPanel : UserControl
    {
        public NotificationsPanel()
        {
            InitializeComponent();
            DataContext = new NotificationsPanelViewModel();
        }
    }
}
