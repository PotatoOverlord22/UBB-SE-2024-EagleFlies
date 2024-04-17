using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBuddies.Models
{
    internal class DrawingBoard
    {

        string FilePath { get; set; }
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
