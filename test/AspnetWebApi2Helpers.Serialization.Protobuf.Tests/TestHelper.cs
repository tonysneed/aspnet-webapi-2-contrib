using System.IO;
using ProtoBuf.Meta;

namespace AspnetWebApi2Helpers.Serialization.Protobuf.Tests
{
    public static class TestHelper
    {
        public static T Clone<T>(this T obj, RuntimeTypeModel serializer)
        {
            T copy;
            using (var stream = new MemoryStream())
            {
                serializer.Serialize(stream, obj);
                stream.Position = 0;
                copy = (T)serializer.Deserialize(stream, obj, typeof(T));
            }
            return copy;
        }
    }
}
