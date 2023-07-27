namespace Entities.DataTransferObjects.Image
{
    public record ImageDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] ImageData { get; set; }
        public int ProductId { get; set; }
    }
}
