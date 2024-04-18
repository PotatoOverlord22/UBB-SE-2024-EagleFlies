using CodeBuddies.ViewModels;
using System.Windows.Controls;


namespace CodeBuddies.Views.UserControls
{
    /// <summary>
    /// Interaction logic for NotificationsPanel.xaml
    /// </summary>
    public partial class NotificationsPanel : UserControl
    {
        public NotificationsPanel()
        {
            InitializeComponent();
            DataContext = new NotificationsPanelViewModel();
        }
    }
}
