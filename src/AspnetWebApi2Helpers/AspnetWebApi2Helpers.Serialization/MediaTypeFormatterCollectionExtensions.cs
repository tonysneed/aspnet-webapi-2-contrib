using System.Net.Http.Formatting;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace AspnetWebApi2Helpers.Serialization
{
    /// <summary>
    /// Extension methods for configuring formatters to handle cyclical references.
    /// </summary>
    public static class MediaTypeFormatterCollectionExtensions
    {
        /// <summary>
        /// Configure JsonFormatter to handle cyclical references.
        /// </summary>
        /// <param name="formatters">Collection class that contains <see cref="T:System.Net.Http.Formatting.MediaTypeFormatter"/> instances.</param>
        public static void JsonPreserveReferences([NotNull] this MediaTypeFormatterCollection formatters)
        {
            formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling =
                PreserveReferencesHandling.All;
        }

        /// <summary>
        /// Configure XmlFormatter to handle cyclical references.
        /// </summary>
        /// <param name="formatters">Collection class that contains <see cref="T:System.Net.Http.Formatting.MediaTypeFormatter"/> instances.</param>
        public static void XmlPreserveReferences([NotNull] this MediaTypeFormatterCollection formatters)
        {
            formatters.Remove(formatters.XmlFormatter);
            var xmlFormatter = new CustomXmlDataContractSerializerMediaTypeFormatter();
            formatters.Add(xmlFormatter);
        }
    }
}
