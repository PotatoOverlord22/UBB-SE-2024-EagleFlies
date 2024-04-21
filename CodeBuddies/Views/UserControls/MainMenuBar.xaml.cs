using System.Windows;
using System.Windows.Controls;
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

        /*
        private void DrawingBoardButton_Click(object sender, RoutedEventArgs e)
        {
            if (App.Current.MainWindow is MainWindow mainWindow)
            {
                mainWindow.ToggleDrawingBoard();
            }
        }
        */
        private void NewSessionButtonClicked(object sender, RoutedEventArgs e)
        {
            CreateNewSessionPopUp createNewSessionPopUp = new CreateNewSessionPopUp();
            createNewSessionPopUp.ShowDialog();
        }
    }
}
