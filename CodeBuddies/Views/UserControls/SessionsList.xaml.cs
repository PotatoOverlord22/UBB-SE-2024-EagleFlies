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

namespace CodeBuddies.Views.UserControls
{
    /// <summary>
    /// Interaction logic for SessionsList.xaml
    /// </summary>
    public partial class SessionsList : UserControl
    {
        public SessionsList()
        {
            InitializeComponent();
            DataContext = this;
            sessionsDataGrid.Items.Add(new ListItem());
            sessionsDataGrid.Items.Add(new ListItem());
            sessionsDataGrid.Items.Add(new ListItem());
            sessionsDataGrid.Items.Add(new ListItem());
            sessionsDataGrid.Items.Add(new ListItem());
            sessionsDataGrid.Items.Add(new ListItem());
            sessionsDataGrid.Items.Add(new ListItem());
            sessionsDataGrid.Items.Add(new ListItem());
            sessionsDataGrid.Items.Add(new ListItem());
        }
    }
}
