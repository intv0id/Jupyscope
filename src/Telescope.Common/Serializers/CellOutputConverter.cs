using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telescope.Common.Contracts.CellOutputs;
using Telescope.Common.Contracts.Enums;

namespace Telescope.Common.Serializers
{
    public class CellOutputConverter : JsonConverter<BaseCellOutput>
    {
        const string TypeDiscriminator = "output_type";

        public override bool CanConvert(Type typeToConvert)
        {
            return typeof(BaseCellOutput).IsAssignableFrom(typeToConvert);
        }

        public override BaseCellOutput Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            }

            if (!reader.Read()
                || reader.TokenType != JsonTokenType.PropertyName
                || reader.GetString() != TypeDiscriminator)
            {
                throw new JsonException();
            }

            if (!reader.Read() || reader.TokenType != JsonTokenType.Number)
            {
                throw new JsonException();
            }

            // Discriminate type
            string cellTypeString = reader.GetString();
            if (!Enum.IsDefined(typeof(OutputType), cellTypeString) || !Enum.TryParse(cellTypeString, out OutputType cellType))
            {
                throw new JsonException();
            }

            // Deserialize the object to the right type
            BaseCellOutput cell = cellType switch
            {
                OutputType.display_data => (DataOutput)JsonSerializer.Deserialize(ref reader, typeof(DataOutput)),
                OutputType.error => (ErrorOutput)JsonSerializer.Deserialize(ref reader, typeof(ErrorOutput)),
                OutputType.execute_result => (ExecuteResultOutput)JsonSerializer.Deserialize(ref reader, typeof(ExecuteResultOutput)),
                OutputType.stream => (StreamOutput)JsonSerializer.Deserialize(ref reader, typeof(StreamOutput)),
                _ => throw new NotSupportedException(),
            };

            // Check we reached the end
            if (!reader.Read() || reader.TokenType != JsonTokenType.EndObject)
            {
                throw new JsonException();
            }

            return cell;
        }

        public override void Write(
            Utf8JsonWriter writer,
            BaseCellOutput value,
            JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            try
            {
                switch (Enum.Parse(typeof(OutputType), value.Type))
                {
                    case OutputType.display_data:
                        JsonSerializer.Serialize(writer, (DataOutput)value);
                        break;
                    case OutputType.error:
                        JsonSerializer.Serialize(writer, (ErrorOutput)value);
                        break;
                    case OutputType.execute_result:
                        JsonSerializer.Serialize(writer, (ExecuteResultOutput)value);
                        break;
                    case OutputType.stream:
                        JsonSerializer.Serialize(writer, (StreamOutput)value);
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
            finally
            {
                writer.WriteEndObject();
            }            
        }
    }
}
