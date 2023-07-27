namespace Entities.Models
{
    public class Fault
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Description { get; set; }
        public DateTime ReportedAt { get; set; }
        public bool IsResolved { get; set; }
    }
}
