using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBuddies.Models.Entities
{
    internal class TextEditorEventArgs : EventArgs
    {
        public int FileId { get; }

        public TextEditorEventArgs(int fileId)
        {
            FileId = fileId;
        }
    }
}
