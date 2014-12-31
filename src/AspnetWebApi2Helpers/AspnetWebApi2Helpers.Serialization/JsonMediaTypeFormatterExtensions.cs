using System.Net.Http.Formatting;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace AspnetWebApi2Helpers.Serialization
{
    /// <summary>
    /// Extension methods for configuring Json media type formatter to handle cyclical references.
    /// </summary>
    public static class JsonMediaTypeFormatterExtensions
    {
        /// <summary>
        /// Configure serializer for JsonMediaTypeFormatter to handle cyclical references.
        /// </summary>
        /// <param name="jsonFormatter">Json media type formatter</param>
        public static void JsonPreserveReferences([NotNull] this JsonMediaTypeFormatter jsonFormatter)
        {
            jsonFormatter.SerializerSettings.PreserveReferencesHandling =
                PreserveReferencesHandling.All;
        }
    }
}