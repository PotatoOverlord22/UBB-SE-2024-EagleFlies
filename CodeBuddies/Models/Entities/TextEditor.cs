using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBuddies.Models.Entities
{
    internal class TextEditor
    {
        private string textColor;

        public string TextColor
        {
            get { return textColor; }
            set { textColor = value; }
        }
        private List<string> filePaths;

        public List<string> FilePaths
        {
            get { return filePaths; }
            set { filePaths = value; }
        }


        public TextEditor(string textColor, List<string> filesPaths)
        {
            TextColor = textColor;
            FilePaths = filesPaths;
        }

        public void Insert(int row, int column, string text)
        {
            // Insert text at row, column
        }

        public void Delete(int row, int column)
        {
            // Delete at row, column
        }

        public void SelectSelection(int startRow, int startColumn, int endRow, int endColumn)
        {
            // Select the text from startRow, startColumn to endRow, endColumn
        }

        public void OpenFile(string filePath)
        {
            // Open the file
        }

     

    }
}
