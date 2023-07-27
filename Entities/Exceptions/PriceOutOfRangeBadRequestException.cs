namespace Entities.Exceptions
{

    public class PriceOutOfRangeBadRequestException : BadRequesException
    {
        public PriceOutOfRangeBadRequestException() : base("Fiyat 1-1000 dahil aralığında olmalıdır!")
        {
        }
    }

}
