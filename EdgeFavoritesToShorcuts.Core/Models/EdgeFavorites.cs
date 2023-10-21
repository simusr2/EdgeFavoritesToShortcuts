using System.Text.Json.Serialization;

namespace EdgeFavoritesToShortcuts.Core.Models
{
    public partial class EdgeFavorites
    {
        [JsonPropertyName("checksum")] 
        public string Checksum { get; set; } = "";

        [JsonPropertyName("roots")] 
        public Roots Roots { get; set; }

        [JsonPropertyName("sync_metadata")] 
        public string SyncMetadata { get; set; }

        [JsonPropertyName("version")] 
        public long Version { get; set; }
    }
}
