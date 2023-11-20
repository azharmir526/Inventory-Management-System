using System.Text.Json.Serialization;

namespace InventoryManagementSystem.API.Models
{
    public class DefaultPayload
    {
        [JsonPropertyName("Message")]
        public string? Message { get; set; }
    }
}
