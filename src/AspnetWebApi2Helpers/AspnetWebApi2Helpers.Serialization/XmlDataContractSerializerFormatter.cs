using System;
using System.Net.Http.Formatting;
using System.Runtime.Serialization;
using JetBrains.Annotations;

namespace AspnetWebApi2Helpers.Serialization
{
    /// <summary>
    /// This class handles deserialization of input XML data
    /// to strongly-typed objects using <see cref="DataContractSerializer"/>.
    /// </summary>
    public class XmlDataContractSerializerFormatter : XmlMediaTypeFormatter
    {
        private DataContractSerializerSettings _serializerSettings = new DataContractSerializerSettings();

        /// <summary>
        /// Gets or sets the <see cref="DataContractSerializerSettings"/> used to configure the 
        /// <see cref="DataContractSerializer"/>.
        /// </summary>
        public DataContractSerializerSettings SerializerSettings
        {
            get { return _serializerSettings; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
                _serializerSettings = value;
            }
        }

        /// <summary>
        /// Called during deserialization to get the <see cref="T:System.Runtime.Serialization.XmlObjectSerializer"/>.
        /// </summary>
        /// <returns>
        /// The <see cref="T:System.Runtime.Serialization.DataContractSerializer"/> used during deserialization.
        /// </returns>
        public override DataContractSerializer CreateDataContractSerializer([NotNull] Type type)
        {
            return new DataContractSerializer(type, _serializerSettings);
        }
    }
}
