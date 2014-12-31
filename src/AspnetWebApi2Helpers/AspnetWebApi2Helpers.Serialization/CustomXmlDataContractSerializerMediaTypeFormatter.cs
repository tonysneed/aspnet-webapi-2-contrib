using System;
using System.Net.Http.Formatting;
using System.Runtime.Serialization;
using AspnetWebApi2Helpers.Serialization.Internal;

namespace AspnetWebApi2Helpers.Serialization
{
    /// <summary>
    /// This class handles cyclical references in deserialization of input XML data 
    /// to strongly-typed objects using <see cref="T:System.Runtime.Serialization.DataContractSerializer"/>.
    /// </summary>
    public class CustomXmlDataContractSerializerMediaTypeFormatter : XmlMediaTypeFormatter
    {
        /// <summary>
        /// Called during deserialization to get the <see cref="T:System.Runtime.Serialization.XmlObjectSerializer"/>.
        /// </summary>
        /// <returns>
        /// The <see cref="T:System.Runtime.Serialization.DataContractSerializer"/> used during deserialization.
        /// </returns>
        public override DataContractSerializer CreateDataContractSerializer(Type type)
        {
            return DataContractSerializerFactory.CreateDataContractSerializer(type, true);
        }
    }
}
