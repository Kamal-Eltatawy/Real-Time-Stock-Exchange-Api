namespace Infrastructure.Repository
{
    public class RepositoryValidationException : RepositoryException
    {
        public RepositoryValidationException(string message) : base(message) { }
        public RepositoryValidationException(string message, Exception innerException) : base(message, innerException) { }
    }
}
