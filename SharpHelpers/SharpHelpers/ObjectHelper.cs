// (c) 2019 SharpCoding
// This code is licensed under MIT license (see LICENSE.txt for details)
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace SharpCoding.SharpHelpers
{
    public static class ObjectHelper
    {
        /// <summary>
        ///  This method verifies that the passed type is a .Net Type 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsSystemType(this Type type)
        {
            return
                type.IsValueType ||
                type.IsPrimitive ||
                new[]
                {
                    typeof(Enum),
                    typeof(string),
                    typeof(decimal),
                    typeof(DateTime),
                    typeof(DateTimeOffset),
                    typeof(TimeSpan),
                    typeof(Guid)
                }.Contains(type) ||
                Convert.GetTypeCode(type) != TypeCode.Object ||
                (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>) &&
                 IsSystemType(type.GetGenericArguments()[0]));
        }

        public static MemoryStream SerializeToStream(this object obj)
        {
            using var stream = new MemoryStream();
            IFormatter formatter = new BinaryFormatter();

            formatter.Serialize(stream, obj);
            
            return stream;
        }

        public static object DeserializeFromStream(MemoryStream stream)
        {
            var formatter = new BinaryFormatter();
            stream.Seek(0, SeekOrigin.Begin);
            return formatter.Deserialize(stream);
        }

        public static string ToBase64(this object obj)
        {
            if (obj == null)
                return null;

            using var fs = SerializeToStream(obj);
            using var br = new BinaryReader(fs);
            var bytes = br.ReadBytes((int)fs.Length);
            return Convert.ToBase64String(bytes, 0, bytes.Length);
        }
    }
}
