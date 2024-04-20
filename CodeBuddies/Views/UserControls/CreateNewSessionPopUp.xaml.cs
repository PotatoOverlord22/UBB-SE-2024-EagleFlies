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

namespace CodeBuddies.Views.UserControls
{
    /// <summary>
    /// Interaction logic for CreateNewSessionPopUp.xaml
    /// </summary>
    public partial class CreateNewSessionPopUp : Window
    {
        public CreateNewSessionPopUp()
        {
            InitializeComponent();
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

            //Session newSession = new Session(sessionName, maxParticipants);
            //SessionList.Add(newSession);

            //SessionEndingCancelEventArgs args = new SessionEndingCancelEventArgs(false, SessionEndReasons.UserClosing);

            //generate a new session id randomly
            Random random = new Random();
            long sessionId = random.Next(1000, 9999);

            SessionWindow sessionWindow = new SessionWindow();
            sessionWindow.ShowDialog();
        }
    }
}
