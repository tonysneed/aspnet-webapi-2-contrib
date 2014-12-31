using System;
using System.Linq;
using System.Net.Http.Formatting;
using System.Reflection;
using AspnetWebApi2Helpers.Serialization.Protobuf.Internal;
using JetBrains.Annotations;
using Newtonsoft.Json;
using WebApiContrib.Formatting;

namespace AspnetWebApi2Helpers.Serialization.Protobuf
{
    /// <summary>
    /// Extension methods for configuring formatters to handle cyclical references.
    /// </summary>
    public static class MediaTypeFormatterCollectionExtensions
    {
        /// <summary>
        /// Configure one or more types to handle cyclical references with Protobuf.
        /// </summary>
        /// <param name="formatters">Collection class that contains <see cref="T:System.Net.Http.Formatting.MediaTypeFormatter"/> instances.</param>
        /// <param name="types">Array of types.</param>
        public static void ProtobufPreserveReferences([NotNull] this MediaTypeFormatterCollection formatters, [NotNull] params Type[] types)
        {
            // Configure protobuf formatter to handle cyclical references
            ProtobufFormatterHelper.ConfigureProtobufFormatter(types);

            // Remove protobuf formatters
            var protoBufFormatter = formatters.SingleOrDefault(f => f.GetType() == typeof(ProtoBufFormatter));
            if (protoBufFormatter != null)
                formatters.Remove(protoBufFormatter);

            // Add protobuf formatters
            formatters.Add(new ProtoBufFormatter());
        }

        /// <summary>
        /// Configure all types in an assembly to handle cyclical references with Protobuf.
        /// </summary>
        /// <param name="formatters">Collection class that contains <see cref="T:System.Net.Http.Formatting.MediaTypeFormatter"/> instances.</param>
        /// <param name="assembly">Managed assembly.</param>
        public static void ProtobufPreserveReferences([NotNull] this MediaTypeFormatterCollection formatters, [NotNull] Assembly assembly)
        {
            ProtobufPreserveReferences(formatters, assembly.GetTypes());
        }
    }
}
