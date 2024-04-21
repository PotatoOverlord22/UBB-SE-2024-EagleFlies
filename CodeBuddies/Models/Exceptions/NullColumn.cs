namespace CodeBuddies.Models.Exceptions
{
    public class NullColumn : Exception
    {
        public NullColumn(string message) : base(message) { }

        public NullColumn(string message, Exception innerException) : base(message, innerException) { }
    }
}
