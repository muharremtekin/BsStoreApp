namespace Entities.Exceptions
{
    public abstract class BadRequesException : Exception
    {
        protected BadRequesException(string? message) : base(message)
        {
        }
    }
}
