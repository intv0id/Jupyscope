using System.Text.Json;

namespace Telescope.Common.Serializers
{
    public class TelescopeConverter
    {
        public static readonly JsonSerializerOptions Options = new JsonSerializerOptions
        {
            Converters = { 
                new CellConverter(),
                new CellOutputConverter(),
            },
            WriteIndented = true,
        };
    }
}
