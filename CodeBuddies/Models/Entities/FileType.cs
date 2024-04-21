using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBuddies.Models.Entities
{
    internal class FileType
    {
        protected int fileId;

        public int FileId
        {
            get { return fileId; }
            set { fileId = value; }
        }
        protected string text;

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        public FileType(int id, string text)
        {
            FileId = id;
            Text = text;
        }
    }
}
