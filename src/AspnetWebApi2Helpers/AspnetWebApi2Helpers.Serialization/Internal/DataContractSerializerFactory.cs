using System;
using System.Runtime.Serialization;
using JetBrains.Annotations;

namespace AspnetWebApi2Helpers.Serialization.Internal
{
    /// <summary>
    /// Factory for creating DataContractSerializer configured to preserve references.
    /// </summary>
    public static class DataContractSerializerFactory
    {
        /// <summary>
        /// Creates a DataContractSerializer configured to handle cyclical references.
        /// </summary>
        /// <param name="type">Type to be serialized.</param>
        /// <param name="preserveReferences">Must be set to true for cyclical reference handling.</param>
        /// <returns>Configured DataContractSerializer.</returns>
        public static DataContractSerializer CreateDataContractSerializer([NotNull] Type type, bool preserveReferences)
        {
            var settings = new DataContractSerializerSettings
            {
                PreserveObjectReferences = true
            };
            var serializer = new DataContractSerializer(type, settings);
            return serializer;
        }
    }
}