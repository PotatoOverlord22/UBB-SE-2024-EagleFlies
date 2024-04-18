using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBuddies.Models.Entities
{
    internal class DrawingBoard
    {
        private string filePath;

        public string FilePath
        {
            get { return filePath; }
            set { filePath = value; }
        }
        public DrawingBoard(string filePath)
        {
            FilePath = filePath;
        }

        public void Draw(int x, int y)
        {
            // Draw the point at x, y
        } 

        public void Save()
        {
            // Save the drawing to the file
        }

        public void Render() 
        { 
            // Render the drawing
            
        }

        public void Erase(int x, int y)
        {
            // Erase the point at x, y
        }
    }
}
