using System.Text.Json.Serialization;

namespace EdgeFavoritesToShortcuts.Core.Models
{
    public partial class Roots
    {
        [JsonPropertyName("bookmark_bar")] 
        public Favorite? BookmarkBar { get; set; }

        [JsonPropertyName("other")] 
        public Favorite? Other { get; set; }

        [JsonPropertyName("synced")] 
        public Favorite? Synced { get; set; }
    }
}
