namespace Entities.Exceptions
{
    public class FaultNotFoundException : NotFoundException
    {
        public FaultNotFoundException(int id) : base($"Fault with id: {id} doesn't exist in the database.")
        {
        }
    }
}
