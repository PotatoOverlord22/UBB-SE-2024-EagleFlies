using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CodeBuddies;

namespace CodeBuddies.Views.UserControls
{
    /// <summary>
    /// Interaction logic for MainMenuBar.xaml
    /// </summary>
    public partial class MainMenuBar : UserControl
    {
        public MainMenuBar()
        {
            InitializeComponent();
        }

        private void NewSessionButtonClicked(object sender, RoutedEventArgs e)
        {
            CreateNewSessionPopUp createNewSessionPopUp = new CreateNewSessionPopUp();
            createNewSessionPopUp.ShowDialog();
        }
    }
}
