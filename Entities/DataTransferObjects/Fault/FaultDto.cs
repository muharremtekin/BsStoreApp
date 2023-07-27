namespace Entities.DataTransferObjects.Fault
{
    public record FaultDto
    {
        public int Id { get; set; }
        public int EntityId { get; set; }
        public string Description { get; set; }
        public DateTime ReportedAt { get; set; }
        public bool IsResolved { get; set; }
    }
}
