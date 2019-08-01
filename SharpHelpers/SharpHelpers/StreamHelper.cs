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
            var reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }

        /// <summary>
        /// This method returns a Base64 stream
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static Stream ConvertToBase64(this Stream stream)
        {
            byte[] bytes;
            using (var memoryStream = new MemoryStream())
            {
                stream.CopyTo(memoryStream);
                bytes = memoryStream.ToArray();
            }
            var base64 = Convert.ToBase64String(bytes);
            return new MemoryStream(Encoding.UTF8.GetBytes(base64));
        }
    }
}
