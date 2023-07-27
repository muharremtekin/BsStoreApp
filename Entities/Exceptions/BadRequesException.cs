namespace Entities.Exceptions
{
    public abstract partial class BadRequesException : Exception
    {
        protected BadRequesException(string? message) : base(message)
        {
        }
    }
}
