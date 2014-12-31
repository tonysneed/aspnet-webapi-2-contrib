using System;
using System.Linq;
using System.Net.Http.Formatting;
using System.Reflection;
using JetBrains.Annotations;
using ProtoBuf.Meta;
using WebApiContrib.Formatting;

namespace AspnetWebApi2Helpers.Serialization.Protobuf.Internal
{
    /// <summary>
    /// Utility methods for configuring Protobuf formatters.
    /// </summary>
    public static class ProtobufFormatterHelper
    {
        /// <summary>
        /// Configure one or more types to handle cyclical references with Protobuf.
        /// </summary>
        /// <param name="types">Array of types.</param>
        public static void ConfigureProtobufFormatter([NotNull] params Type[] types)
        {
            foreach (var type in types)
            {
                if (!ProtoBufFormatter.Model.GetTypes().OfType<MetaType>().Any(t => t.Type == type))
                {
                    var meta = ProtoBufFormatter.Model.Add(type, false);
                    var props = type.GetProperties();
                    for (var i = 0; i < props.Length; i++)
                    {
                        meta.Add(i + 1, props[i].Name);
                    }
                    meta.AsReferenceDefault = true;
                }
            }
        }
    }
}
