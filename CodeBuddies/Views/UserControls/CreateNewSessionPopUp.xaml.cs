using CodeBuddies.Repositories;
using CodeBuddies.Resources.Data;
using CodeBuddies.ViewModels;
using System.Windows;
using System.Windows.Controls;
using static CodeBuddies.Models.Validators.ValidationForNewSession;

namespace CodeBuddies.Views.UserControls
{
    /// <summary>
    /// Interaction logic for CreateNewSessionPopUp.xaml
    /// </summary>
    public partial class CreateNewSessionPopUp : Window
    {
        private CreateNewSessionPopUpViewModel viewModel;
        public CreateNewSessionPopUp()
        {
            InitializeComponent();
            viewModel = new CreateNewSessionPopUpViewModel();
        }

        private void SessionNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //take the text from the textbox and store it in a variable
            //check if the text is empty
            //if it is empty, make the button disabled
            //if it is not empty, make the button enabled

            string sessionName = SessionNameTextBox.Text;
            if (sessionName == "")
            {
                CreateSessionButton.IsEnabled = false;
            }
            else
            {
                CreateSessionButton.IsEnabled = true;
            }
        }

        private void MaxParticipantsTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string maxParticipants = MaxParticipantsTextBox.Text;

            if (maxParticipants == "")
            {
                CreateSessionButton.IsEnabled = false;
            }
            else
            {
                CreateSessionButton.IsEnabled = true;
            }

        }

        private void CreateSessionButton_Click(object sender, RoutedEventArgs e)
        {
            //take the text from the textbox and store it in a variable
            //check if the text is empty
            //if it is empty, make the button disabled
            //if it is not empty, make the button enabled

            string sessionName = SessionNameTextBox.Text;
            string maxParticipants = MaxParticipantsTextBox.Text;

            if (sessionName == "" || maxParticipants == "")
            {
                MessageBox.Show("Please enter a session name and max participants");
                CreateSessionButton.IsEnabled = false;
            }
            else
            {
                CreateSessionButton.IsEnabled = true;
            }

            //create a new session with the session name and max participants
            //add the session to the list of sessions
            //close the popup

            //generate a new session id randomly

            try
            {
                viewModel.AddNewSession(sessionName, maxParticipants);

                if (sessionName != "" && maxParticipants != "")
                {
                    SessionWindow sessionWindow = new SessionWindow();
                    sessionWindow.ShowDialog();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //close the popup
            this.Close();
        }
    }
}
