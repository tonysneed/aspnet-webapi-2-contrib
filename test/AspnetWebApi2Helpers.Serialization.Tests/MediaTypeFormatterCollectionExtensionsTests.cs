using System;
using System.Net.Http.Formatting;
using AspnetWebApi2Helpers.Serialization.Tests.Entities;
using Newtonsoft.Json;
using Xunit;

namespace AspnetWebApi2Helpers.Serialization.Tests
{
    public class MediaTypeFormatterCollectionExtensionsTests
    {
        [Fact]
        public void Formatters_JsonPreserveReferences_should_configure_JsonFormatter()
        {
            // Arrange
            var formatters = new MediaTypeFormatterCollection
                { new JsonMediaTypeFormatter() };

            // Act
            formatters.JsonPreserveReferences();

            // Assert
            Assert.Equal(PreserveReferencesHandling.All, formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling);
        }

        [Fact]
        public void Formatters_XmlPreserveReferences_should_configure_XmlFormatters()
        {
            // Arrange
            var formatters = new MediaTypeFormatterCollection { new JsonMediaTypeFormatter() };

            // Act
            formatters.XmlPreserveReferences();

            // Assert
            Assert.IsAssignableFrom<CustomXmlDataContractSerializerMediaTypeFormatter>(formatters.XmlFormatter);
        }
    }
}
