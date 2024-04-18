using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBuddies.Models.Exceptions
{
    internal class FileNotFound : Exception
    {
        public FileNotFound(string message) : base(message) { }

        public FileNotFound(string message, Exception innerException) : base(message, innerException) { }
    }
}
