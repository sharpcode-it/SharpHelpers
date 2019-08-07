using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SharpCoding.SharpHelpers
{
    /*
     * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
     * "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
     * LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR
     * A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT
     * OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL,
     * SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT
     * LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
     * DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY
     * THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
     * (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
     * OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
     *
     * This software consists of voluntary contributions made by many individuals
     * and is licensed under the MIT license. For more information, see
     * <http://www.doctrine-project.org>.
     */

    public static class ByteExtension
    {  
        /// <summary>
        /// Given a byte array, this method returns the specified object 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="istance"></param>
        /// <returns></returns>
        public static T ToObject<T>(this byte[] istance) where T : class
        {
            return (T)istance?.ToObject();
        }

        /// <summary>
        /// Given a byte array, this method returns an object 
        /// </summary>
        /// <param name="istance"></param>
        /// <returns></returns>
        public static object ToObject(this byte[] istance)
        {
            if (istance == null) return null;

            using (var memoryStream = new MemoryStream(istance))
            {
                var binaryFormatter = new BinaryFormatter();
                return binaryFormatter.Deserialize(memoryStream);
            }
        }

        /// <summary>
        /// Given an object, this method returns a byte array
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] ToByteArray(this object value)
        {
            if (value == null) return new byte[0];

            using (var memoryStream = new MemoryStream())
            {
                var binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(memoryStream, value);
                return memoryStream.ToArray();
            }
        }
    }
}
