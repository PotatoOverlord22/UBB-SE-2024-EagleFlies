using CodeBuddies.Repositories;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using CodeBuddies.Models.Entities;
using System.Collections.ObjectModel;


namespace CodeBuddies.Views.UserControls
{
    /// <summary>
    /// Interaction logic for SessionWindowBar.xaml
    /// </summary>
    public partial class SessionWindowBar : UserControl
    {
        private SessionRepository sessionRepository;
        public SessionWindowBar()
        {
            InitializeComponent();

            // Find the parent window of the UserControl
            var parentWindow = Window.GetWindow(this);

            // Check if the parent window is an instance of SessionWindow
            if (parentWindow is SessionWindow sessionWindow)
            {
                // Access the sessionRepository from the parent window
                sessionRepository = sessionWindow.getSessionRepository();
            }
        }

        private void OpenExistingFileButton_Clicked(object sender, RoutedEventArgs e)
        {

        }

        private void CreateNewFileButton_Clicked(object sender, RoutedEventArgs e)
        {

        }

        private void OpenBoardButton_Clicked(object sender, RoutedEventArgs e)
        {

        }

        private void ContributionChartButton_Clicked(object sender, RoutedEventArgs e)
        {

        }

        private void LeaveSessionButton_Clicked(object sender, RoutedEventArgs e)
        {
            //close the whole session window
            Window.GetWindow(this).Close();
        }

        private void SeeCodeReviewSectionButton_Clicked(object sender, RoutedEventArgs e)
        {
            // Check if sessionRepository is not null
            if (sessionRepository != null)
            {
                // Load the CodeReviewSection
                List<CodeReviewSection> codeReviewSections = sessionRepository.GetCodeReviewSectionsForSpecificSession(1);

                //transform the code review sections into obsarvable collection
                ObservableCollection<CodeReviewSection> codeReviewSectionsObservable = new ObservableCollection<CodeReviewSection>(codeReviewSections);

                // Add the CodeReviewSection to the Grid
                GridTextEditor.Children.Clear();

                //add the code review section to the grid
                foreach (var codeReviewSection in codeReviewSectionsObservable)
                {
                    TextBlock textBlock = new TextBlock();
                    textBlock.Text = codeReviewSection.Messages.ToString(); // Set some property of CodeReviewSection to display
                    GridTextEditor.Children.Add(textBlock);
                }

            }
            else
            {
                MessageBox.Show("Session repository is not available.");
            }
        }
    }
}
