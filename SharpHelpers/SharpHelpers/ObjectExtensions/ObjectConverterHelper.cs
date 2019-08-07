using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SharpCoding.SharpHelpers.ObjectExtensions
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
    public static class ObjectConverterHelper
    {
        #region Convert to int [Int32]
        public static int ToInt32(this object istance)
        {
            if (istance == null) return 0;

            var valueTemp = istance.ToString();

            return valueTemp.ToInt32();
        }

        public static int ToInt32(this Enum istance )
        {
            return Convert.ToInt32(istance);
        }

        public static int ToInt32(this string istance)
        {
            return int.TryParse(istance, out var result) ? result : default;
        }
        #endregion

        #region Convert to long [Int64]
        public static long ToInt64(this object istance)
        {
            if (istance == null) return 0;

            var valueTemp = istance.ToString();

            return valueTemp.ToInt64();
        }

        public static long ToInt64(this Enum istance )
        {
            return Convert.ToInt64(istance);
        }

        public static long ToInt64(this string istance)
        {
            return long.TryParse(istance, out var result) ? result : default;
        }
        #endregion

        public static bool ToBoolean(this string istance)
        {
            return bool.TryParse(istance, out var outValue) && outValue;
        }
        
        public static DateTime ToDateTime(this string istance)
        {
            return DateTime.TryParse(istance, out var outValue) ? outValue : default;
        }

        public static T ToEnum<T>(this string istance)
        {
            return (T) Enum.Parse(typeof (T), istance);
        }

        public static T ToObject<T>(this byte[] istance) where T:class
        {
            return (T) istance.ToObject();
        }

        private static object ToObject(this byte[] istance)
        {
            using (var memoryStream = new MemoryStream(istance))
            {
                var binaryFormatter = new BinaryFormatter();
                
                return binaryFormatter.Deserialize(memoryStream);
            }
        }

        public static string ToBase(this int number, int targetBase)
        {
            if (targetBase < 2 || targetBase > 36) return string.Empty;
            if (targetBase == 10) return number.ToString();
            var n = targetBase;
            var q = number;
            var rtn = string.Empty;
            while (q >= n)
            {
                var r = q % n;
                q /= n;
                if (r < 10) { rtn = r + rtn; }
                else
                {
                    rtn = Convert.ToChar(r + 55) + rtn;
                }
            }
            if (q < 10)
            { rtn = q + rtn; }
            else { rtn = Convert.ToChar(q + 55) + rtn; }

            return rtn.PadLeft(5, '0');
        }

        /// <summary>
        /// This method returns the byte array of the specific object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static byte[] ToByteArray(this object obj)
        {
            if (obj == null) return null;

            var binaryFormatter = new BinaryFormatter();
            using (var memoryStream = new MemoryStream())
            {
                binaryFormatter.Serialize(memoryStream, obj);
                return memoryStream.ToArray();
            }
        }
    }
}
