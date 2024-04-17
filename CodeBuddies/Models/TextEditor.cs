using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBuddies.Models
{
    internal class TextEditor
    {
        string TextColor { get; set; }
        List<string> FilesPaths { get; set; }


        public TextEditor(string textColor, List<string> filesPaths)
        {
            TextColor = textColor;
            FilesPaths = filesPaths;
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
