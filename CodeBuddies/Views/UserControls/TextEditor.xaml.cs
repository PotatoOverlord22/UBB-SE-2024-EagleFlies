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

namespace CodeBuddies.Views.UserControls
{
    public partial class TextEditor : UserControl
    {

        private SessionProjectRepository projectRepository;
        private int id;

        public TextEditor()
        {
            InitializeComponent();
            projectRepository = new SessionProjectRepository();
            this.id = 0;
        }

        public TextEditor(int id)
        {
            this.id = id;
            InitializeComponent();
            projectRepository = new SessionProjectRepository();
            txtEditor.Text = projectRepository.GetTextFromId(id);
        }

        private void ColorPicker(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            Color selectedColor = (Color)(e.NewValue ?? Colors.Black);
            SolidColorBrush brush = new SolidColorBrush(selectedColor);
            txtEditor.Foreground = brush;
        }

        private void FontStyle(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;

            if (selectedItem != null)
            {
                string fontStyle = selectedItem.Content.ToString();

                switch (fontStyle)
                {
                    case "Normal":
                        txtEditor.FontWeight = FontWeights.Normal;
                        txtEditor.FontStyle = FontStyles.Normal;
                        break;
                    case "Bold":
                        txtEditor.FontWeight = FontWeights.Bold;
                        break;
                    case "Italic":
                        txtEditor.FontStyle = FontStyles.Italic;
                        break;
                }
            }
        }

        private void FontSize(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;

            if (selectedItem != null)
            {
                string fontSizeString = selectedItem.Content.ToString();
                if (int.TryParse(fontSizeString, out int fontSize))
                {
                    txtEditor.FontSize = fontSize;
                }
            }
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            string searchText = txtSearch.Text;
            if (!string.IsNullOrEmpty(searchText))
            {
                ResetSearchHighlights();
                HighlightSearchMatches(searchText);
            }
        }

        private void ResetSearchHighlights()
        {
            txtEditor.SelectAll();
            txtEditor.SelectionBrush = Brushes.Transparent;
            txtEditor.SelectionTextBrush = Brushes.Black;
        }

        private void HighlightSearchMatches(string searchText)
        {
            string text = txtEditor.Text;
            int index = text.IndexOf(searchText);

            if (index != -1)
            {
                txtEditor.Focus();
                txtEditor.Select(index, searchText.Length);
                txtEditor.SelectionBrush = SystemColors.HighlightBrush;
                txtEditor.SelectionTextBrush = SystemColors.HighlightTextBrush;
            }
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            ResetSearchHighlights();
            txtSearch.Clear();
        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            ResetSearchHighlights();
        }

        private void Send(object sender, RoutedEventArgs e)
        {
            string textContent = txtEditor.Text;

            if (!string.IsNullOrEmpty(textContent))
            {
                projectRepository.Save(id, textContent);
            }
        }
    }
}