namespace CodeBuddies.Models.Exceptions
{
    public class EntityAlreadyExists : Exception
    {
        public EntityAlreadyExists(string message) : base(message) { }

        public EntityAlreadyExists(string message, Exception innerException) : base(message, innerException) { }
    }
}
