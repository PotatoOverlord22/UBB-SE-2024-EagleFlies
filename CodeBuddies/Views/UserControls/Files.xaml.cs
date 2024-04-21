using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CodeBuddies.Repositories;
using Xceed.Wpf.Toolkit;
using CodeBuddies.Models.Entities;
using CodeBuddies.Views.UserControls;

namespace CodeBuddies.Views.UserControls
{
    public partial class Files : UserControl
    {

        private SessionProjectRepository projectRepository;

        public event EventHandler TextEditorButtonClicked;

        public Files()
        {
            InitializeComponent();
            projectRepository = new SessionProjectRepository();
            Loaded += Files_Loaded;
        }

        private void Files_Loaded(object sender, RoutedEventArgs e)
        {
            PopulateFileList();
        }

        private void lstFiles_SelectionChanged(object sender, RoutedEventArgs e)
        {
        }

        private void PopulateFileList()
        {
            try
            {
                List<FileType> fileList = projectRepository.GetAllFiles();

                lstFiles.ItemsSource = fileList;
            }
            catch (Exception ex)
            {
            }
        }

        private void FileButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                int fileId = Convert.ToInt32(button.Tag);
                TextEditorButtonClicked?.Invoke(this, EventArgs.Empty);
            }
        }

    }
}