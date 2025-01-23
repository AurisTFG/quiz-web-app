using QuizApi.Models.Enums;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace QuizApi.Infrastructure.Converters;

public class QuestionTypeConverter : JsonConverter<QuestionType>
{
    public override QuestionType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Number)
        {
            int value = reader.GetInt32();
            return (QuestionType)value;
        }

        throw new JsonException();
    }

    public override void Write(Utf8JsonWriter writer, QuestionType value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString().ToLower());
    }
}

