using CodeBuddies.Repositories;
using System.Windows;

namespace CodeBuddies
{
    /// <summary>
    /// Interaction logic for SessionWindow.xaml
    /// </summary>
    public partial class SessionWindow : Window
    {

        private SessionRepository sessionRepository;

        public SessionWindow()
        {
            InitializeComponent();
            sessionRepository = new SessionRepository();

            SessionWindowBarControl.DrawingBoardButtonClicked += (sender, e) =>
            {
                ToggleDrawingBoard();
              
            };
        }

        internal SessionRepository getSessionRepository()
        {
            return sessionRepository;
        }

        public void ToggleDrawingBoard()
        {
            DrawingBoardControl.Visibility = DrawingBoardControl.Visibility == Visibility.Visible ? Visibility.Hidden : Visibility.Visible;
        }
    }
}
