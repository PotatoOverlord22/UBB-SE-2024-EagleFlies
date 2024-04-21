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

            SessionWindowBarControl.TextEditorButtonClicked += (sender, e) =>
            {
                ToggleTextEditor();

            };

            SessionWindowBarControl.FilesButtonClicked += (sender, e) =>
            {
                ToggleFiles();

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

        public void ToggleTextEditor()
        {
            TextEditorControl.Visibility = TextEditorControl.Visibility == Visibility.Visible ? Visibility.Hidden : Visibility.Visible;
        }

        public void ToggleFiles()
        {
            FilesControl.Visibility = FilesControl.Visibility == Visibility.Visible ? Visibility.Hidden : Visibility.Visible;
        }
    }
}
