using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telescope.Common.Contracts.Cells;
using Telescope.Common.Contracts.Enums;

namespace Telescope.Common.Serializers
{
    public class CellConverter : JsonConverter<BaseCell>
    {
        const string TypeDiscriminator = "cell_type";

        public override bool CanConvert(Type typeToConvert)
        {
            return typeof(BaseCell).IsAssignableFrom(typeToConvert);
        }

        public override BaseCell Read(
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
            if (!Enum.IsDefined(typeof(CellType), cellTypeString) || !Enum.TryParse(cellTypeString, out CellType cellType))
            {
                throw new JsonException();
            }

            // Deserialize the object to the right type
            BaseCell cell = cellType switch
            {
                CellType.code => (CodeCell)JsonSerializer.Deserialize(ref reader, typeof(CodeCell)),
                CellType.markdown => (MarkdownCell)JsonSerializer.Deserialize(ref reader, typeof(MarkdownCell)),
                CellType.raw => (RawCell)JsonSerializer.Deserialize(ref reader, typeof(RawCell)),
                _ => throw new NotSupportedException(),
            };
            cell.Type = cellType;

            // Check we reached the end
            if (!reader.Read() || reader.TokenType != JsonTokenType.EndObject)
            {
                throw new JsonException();
            }

            return cell;
        }

        public override void Write(
            Utf8JsonWriter writer,
            BaseCell value,
            JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            try
            {
                switch (value)
                {
                    case CodeCell c:
                        JsonSerializer.Serialize<CodeCell>(writer, c);
                        break;
                    case MarkdownCell c:
                        JsonSerializer.Serialize<MarkdownCell>(writer, c);
                        break;
                    case RawCell c:
                        JsonSerializer.Serialize<RawCell>(writer, c);
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
