using System;
using System.IO;
using System.Text;

namespace SharpCoding.SharpHelpers
{
    public static class StreamHelper
    {
        /// <summary>
        /// This method returns a string from a stream
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static string ToString(this Stream stream)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        /// <summary>
        /// This method returns a Base64 stream
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static Stream ToBase64(this Stream stream)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));
            byte[] bytes;
            using (var memoryStream = new MemoryStream())
            {
                stream.CopyTo(memoryStream);
                bytes = memoryStream.ToArray();
            }
            var base64 = Convert.ToBase64String(bytes);
            return new MemoryStream(Encoding.UTF8.GetBytes(base64));
        }

        /// <summary>
        /// This method returns a byte array from a stream
        /// </summary>
        /// <returns>The byte array.</returns>
        /// <param name="stream">Input.</param>
        public static byte[] ToByteArray(this Stream stream)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));
            using (MemoryStream memoryStream = new MemoryStream())
            {
                stream.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }

        /// <summary>
        /// This method returns a MemoryStream from stream
        /// </summary>
        /// <returns>The memory stream.</returns>
        /// <param name="stream">Stream.</param>
        public static MemoryStream ToMemoryStream(this Stream stream)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));
            using (MemoryStream memoryStream = new MemoryStream())
            {
                stream.CopyTo(memoryStream);
                return memoryStream;
            }
        }
    }
}
