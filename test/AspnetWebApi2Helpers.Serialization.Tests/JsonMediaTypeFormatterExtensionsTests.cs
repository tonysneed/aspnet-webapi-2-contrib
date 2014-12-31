using System;
using System.Net.Http.Formatting;
using Newtonsoft.Json;
using Xunit;

namespace AspnetWebApi2Helpers.Serialization.Tests
{
    public class JsonMediaTypeFormatterExtensionsTests
    {
        [Fact]
        public void InputFormatters_PreserveReferences_should_configure_JsonInputFormatter()
        {
            // Arrange
            var formatter = new JsonMediaTypeFormatter();

            // Act
            formatter.JsonPreserveReferences();

            // Assert
            Assert.Equal(PreserveReferencesHandling.All, formatter.SerializerSettings.PreserveReferencesHandling);
        }
    }
}
