using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EdgeFavoritesToShortcuts.Core.Converters
{
    public class LongJsonConverter : JsonConverter<long?>
    {
        public override long? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string stringValue = reader.GetString();

            if (stringValue != null)
            {
                return long.Parse(stringValue);
            }
            else
            {
                return null;
            }
        }

        public override void Write(Utf8JsonWriter writer, long? longValue, JsonSerializerOptions options) =>
                longValue?.ToString();
    }
}




