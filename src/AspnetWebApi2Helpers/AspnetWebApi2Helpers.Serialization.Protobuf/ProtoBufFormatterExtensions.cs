using System;
using System.Reflection;
using AspnetWebApi2Helpers.Serialization.Protobuf.Internal;
using JetBrains.Annotations;
using WebApiContrib.Formatting;

namespace AspnetWebApi2Helpers.Serialization.Protobuf
{
    /// <summary>
    /// Extension methods for configuring ProtoBuf media type formatter to handle cyclical references.
    /// </summary>
    public static class ProtobufFormatterExtensions
    {
        /// <summary>
        /// Configure serializer for ProtoBufFormatter to handle cyclical references.
        /// </summary>
        /// <param name="protoBufFormatter">ProtoBuf media type formatter</param>
        /// <param name="types">One or more types to be configured.</param>
        public static void ProtobufPreserveReferences([NotNull] this ProtoBufFormatter protoBufFormatter,
            [NotNull] params Type[] types)
        {
            ProtobufFormatterHelper.ConfigureProtobufFormatter(types);
        }

        /// <summary>
        /// Configure serializer for ProtoBufFormatter to handle cyclical references.
        /// </summary>
        /// <param name="protoBufFormatter">ProtoBuf media type formatter</param>
        /// <param name="assembly">Assembly containing types to be configured.</param>
        public static void ProtobufPreserveReferences([NotNull] this ProtoBufFormatter protoBufFormatter,
            [NotNull] Assembly assembly)
        {
            ProtobufPreserveReferences(protoBufFormatter, assembly.GetTypes());
        }
    }
}
