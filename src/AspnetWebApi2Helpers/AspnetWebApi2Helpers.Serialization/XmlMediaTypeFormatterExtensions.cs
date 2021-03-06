﻿using System;
using System.Net.Http.Formatting;
using JetBrains.Annotations;
using System.Runtime.Serialization;

namespace AspnetWebApi2Helpers.Serialization
{
    /// <summary>
    /// Extension methods for configuring Xml media type formatter to handle cyclical references.
    /// </summary>
    public static class XmlMediaTypeFormatterExtensions
    {
        /// <summary>
        /// Configure serializer for Xml formatter to handle cyclical references.
        /// </summary>
        /// <param name="xmlFormatter">Xml media type formatter</param>
        /// <param name="types">One or more types to be configured.</param>
        public static void XmlPreserveReferences([NotNull] this XmlMediaTypeFormatter xmlFormatter, [NotNull] params Type[] types)
        {
            var settings = new DataContractSerializerSettings
            {
                PreserveObjectReferences = true
            };

            foreach (var type in types)
            {
                var serializer = new DataContractSerializer(type, settings);
                xmlFormatter.SetSerializer(type, serializer);
            }
        }
    }
}