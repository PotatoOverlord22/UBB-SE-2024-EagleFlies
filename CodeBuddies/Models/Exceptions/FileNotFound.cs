namespace CodeBuddies.Models.Exceptions
{
    public class FileNotFound : Exception
    {
        public FileNotFound(string message) : base(message) { }

        public FileNotFound(string message, Exception innerException) : base(message, innerException) { }
    }
}
