using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SharpCoding.SharpHelpers
{
    public static class ByteExtension
    {
        public static T ToObject<T>(this byte[] istance) where T:class
        {
            return (T) istance?.ToObject();
        }

        public static object ToObject(this byte[] istance)
        {
            if (istance == null) return null;

            using (var memoryStream = new System.IO.MemoryStream(istance))
            {
                var binaryFormatter
                    = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                return binaryFormatter.Deserialize(memoryStream);
            }
        }

        public static byte[] ToByteArray(this object value)
        {
            if (value == null) return new byte[0];

            using (var memoryStream = new MemoryStream())
            {
                var binaryFormatter
                    = new BinaryFormatter();
                binaryFormatter.Serialize(memoryStream, value);

                return memoryStream.ToArray();
            }
        }
    }
}
