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