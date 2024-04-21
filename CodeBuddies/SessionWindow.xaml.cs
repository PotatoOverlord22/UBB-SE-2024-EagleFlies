using CodeBuddies.Repositories;
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
using System.Windows.Shapes;

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
        }

        internal SessionRepository getSessionRepository()
        {
            return sessionRepository;
        }
    }
}
