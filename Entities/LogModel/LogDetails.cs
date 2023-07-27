using System.Text.Json;

namespace Entities.LogModel
{
    public class LogDetails
    {
        public object? ModelName { get; set; }
        public object? Controller { get; set; }
        public object? Action { get; set; }
        public object? Id { get; set; }
        public object? CreatedAt { get; set; }

        public LogDetails()
        {
            CreatedAt = System.DateTime.Now;
        }

        override public string ToString() => JsonSerializer.Serialize(this);
    }
}
