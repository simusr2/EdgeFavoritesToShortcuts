using EdgeFavoritesToShortcuts.Core.Converters;
using EdgeFavoritesToShortcuts.Core.Enums.Favorite;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EdgeFavoritesToShortcuts.Core.Models
{
    public partial class Favorite
    {
        [JsonPropertyName("children")] 
        public List<Favorite> Children { get; set; } = new List<Favorite>(); // TODO: Use EMPTY?

        [JsonPropertyName("date_added")] 
        public string DateAdded { get; set; }

        [JsonPropertyName("date_last_used")]
        [JsonConverter(typeof(LongJsonConverter))] 
        public long? DateLastUsed { get; set; }

        [JsonPropertyName("date_modified")] 
        public string DateModified { get; set; }

        [JsonPropertyName("guid")] 
        public Guid Guid { get; set; }

        [JsonPropertyName("id")]
        [JsonConverter(typeof(LongJsonConverter))] 
        public long? Id { get; set; }

        [JsonPropertyName("name")] public string Name { get; set; }

        [JsonPropertyName("source")]
        [JsonConverter(typeof(JsonStringEnumConverter))] 
        public FavoriteSource Source { get; set; }

        [JsonPropertyName("type")]
        [JsonConverter(typeof(JsonStringEnumConverter))] 
        public FavoriteType Type { get; set; }

        [JsonPropertyName("url")] 
        public string Url { get; set; }
    }
}
