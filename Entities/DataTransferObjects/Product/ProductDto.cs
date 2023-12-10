namespace Entities.DataTransferObjects.Product
{
    public record ProductDto
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string Model { get; init; }
        public decimal Price { get; init; }
        public int CategoryId { get; init; }
    }
}
