using System.Text.Json;

namespace Entities.ErrorModel
{
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }

        override public string ToString() => JsonSerializer.Serialize(this);
    }
}
