using CQRS.Core.Events;
using Post.Common.Events;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Post.Query.Infrasructure.Converters
{
    public class EventJsonConverter : JsonConverter<BaseEvent>
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return typeToConvert.IsAssignableFrom(typeof(BaseEvent));
        }

        public override BaseEvent? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if(!JsonDocument.TryParseValue(ref reader, out var doc))
            {
                throw new JsonException($"Failed to parse {nameof(JsonDocument)}!");
            }

            if (!doc.RootElement.TryGetProperty("Type", out var type))
            {
                throw new JsonException("Could not take the Type discriminator property!");
            }

            var typeDiscriminator = type.GetString();
            var json = doc.RootElement.GetRawText();

            return typeDiscriminator switch
            {
                nameof(PostCreatedEvent) => JsonSerializer.Deserialize<PostCreatedEvent>(json, options),
                nameof(MessageUpdatedEvent) => JsonSerializer.Deserialize<PostCreatedEvent>(json, options),
                nameof(PostLikedEvent) => JsonSerializer.Deserialize<PostCreatedEvent>(json, options),
                nameof(CommentAddedEvent) => JsonSerializer.Deserialize<PostCreatedEvent>(json, options),
                nameof(CommentUpdatedEvent) => JsonSerializer.Deserialize<PostCreatedEvent>(json, options),
                nameof(CommentRemoveEvent) => JsonSerializer.Deserialize<PostCreatedEvent>(json, options),
                nameof(PostRemovedEvent) => JsonSerializer.Deserialize<PostCreatedEvent>(json, options),
                _ => throw new JsonException($"{typeDiscriminator} is not supported yet!")
            };
        }

        public override void Write(Utf8JsonWriter writer, BaseEvent value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
