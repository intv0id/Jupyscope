using Dahomey.Json;
using Dahomey.Json.Serialization.Conventions;
using System.Text.Json;
using Jupyscope.Contracts.CellOutputs;
using Jupyscope.Contracts.Cells;

namespace Jupyscope.Serializers
{
    public static class TelescopeConverter
    {
        private static readonly JsonSerializerOptions options;

        static TelescopeConverter()
        {
            options = new JsonSerializerOptions()
            {
                WriteIndented = true,
            };
            options.SetupExtensions();

            DiscriminatorConventionRegistry registry = options.GetDiscriminatorConventionRegistry();
            registry.ClearConventions();
            registry.DiscriminatorPolicy = DiscriminatorPolicy.Always;

            // Cell types
            registry.RegisterConvention(new DefaultDiscriminatorConvention<string>(options, "cell_type"));
            registry.RegisterType<CodeCell>();
            registry.RegisterType<MarkdownCell>();
            registry.RegisterType<RawCell>();

            // Cell output types
            registry.RegisterConvention(new DefaultDiscriminatorConvention<string>(options, "output_type"));
            registry.RegisterType<DataOutput>();
            registry.RegisterType<ErrorOutput>();
            registry.RegisterType<ExecuteResultOutput>();
            registry.RegisterType<StreamOutput>();
        }

        public static T Deserialize<T>(string serializedObject)
        {
            return JsonSerializer.Deserialize<T>(serializedObject, options);
        }
    }
}
