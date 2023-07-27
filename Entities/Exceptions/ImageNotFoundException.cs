namespace Entities.Exceptions
{
    public class ImageNotFoundException : NotFoundException
    {
        public ImageNotFoundException(int id) : base("Resim bulunamadı!")
        {
        }
    }
}
