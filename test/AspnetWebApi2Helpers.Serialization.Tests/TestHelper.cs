using System.IO;
using System.Runtime.Serialization;

namespace AspnetWebApi2Helpers.Serialization.Tests
{
    public static class TestHelper
    {
        public static T Clone<T>(this T obj, XmlObjectSerializer serializer)
        {
            T copy;
            using (var stream = new MemoryStream())
            {
                serializer.WriteObject(stream, obj);
                stream.Position = 0;
                copy = (T)serializer.ReadObject(stream);
            }
            return copy;
        }
    }
}
