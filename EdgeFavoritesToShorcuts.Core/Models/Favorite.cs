using EdgeFavoritesToShortcuts.Core.Converters;
using EdgeFavoritesToShortcuts.Core.Enums.Favorite;
using System.Text.Json.Serialization;

namespace EdgeFavoritesToShortcuts.Core.Models;

/// <summary>
/// Edge favorite model
/// </summary>
public partial class Favorite
{
    /// <summary>
    /// Childrens: used only if current record is a directory
    /// </summary>
    [JsonPropertyName("children")] 
    public List<Favorite> Children { get; set; } = new List<Favorite>();

    /// <summary>
    /// Datetime of addition
    /// </summary>
    [JsonPropertyName("date_added")] 
    public string? DateAdded { get; set; }

    /// <summary>
    /// Last used timestamp 
    /// </summary>
    [JsonPropertyName("date_last_used")]
    [JsonConverter(typeof(LongJsonConverter))] 
    public long? DateLastUsed { get; set; }

    /// <summary>
    /// Last edit datetime
    /// </summary>
    [JsonPropertyName("date_modified")] 
    public string? DateModified { get; set; }

    /// <summary>
    /// Idenitifer as GUID
    /// </summary>
    [JsonPropertyName("guid")] 
    public Guid Guid { get; set; }

    /// <summary>
    /// Numeric identifier (sequential)
    /// </summary>
    [JsonPropertyName("id")]
    [JsonConverter(typeof(LongJsonConverter))] 
    public long? Id { get; set; }

    /// <summary>
    /// Favorite's name
    /// </summary>
    [JsonPropertyName("name")] 
    public string? Name { get; set; }

    /// <summary>
    /// Favorite's source (From user, from extension, ...)
    /// </summary>
    [JsonPropertyName("source")]
    [JsonConverter(typeof(JsonStringEnumConverter))] 
    public FavoriteSource Source { get; set; }

    /// <summary>
    /// Record's type (directory, favorite entry)
    /// </summary>
    [JsonPropertyName("type")]
    [JsonConverter(typeof(JsonStringEnumConverter))] 
    public FavoriteType Type { get; set; }

    /// <summary>
    /// Favorite's destination url
    /// </summary>
    [JsonPropertyName("url")] 
    public string? Url { get; set; }
}
