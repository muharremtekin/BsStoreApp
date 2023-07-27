namespace Entities.Exceptions
{
    public class ProductNotFoundException : NotFoundException
    {
        public ProductNotFoundException(int id) : base($"Product with id: {id} doesn't exist in the database.")
        {
        }
    }
}
