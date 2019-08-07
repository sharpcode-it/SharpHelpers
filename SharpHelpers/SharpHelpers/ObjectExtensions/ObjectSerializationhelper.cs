using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

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
    public static class ObjectSerializationHelper
    {
        /// <summary>
        /// This method serializes the specific object to JSON
        /// </summary>
        /// <param name="istance"></param>
        /// <returns></returns>
        public static string SerializeToJson(this object istance)
        {
            return istance == null ? string.Empty : JsonConvert.SerializeObject(istance);
        }

        /// <summary>
        /// This method deserializes the JSON to the specific object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="istance"></param>
        /// <returns></returns>
        public static T DeserializeFromJson<T>(this string istance) where T : class
        {
            return string.IsNullOrEmpty(istance) ? default : JsonConvert.DeserializeObject<T>(istance);
        }

        /// <summary>
        /// This method serializes the specific object to XML
        /// </summary>
        /// <param name="istance"></param>
        /// <returns></returns>
        public static string SerializeToXml(this object istance)
        {
            if (istance == null) return string.Empty;

            var xmlSerializer = new XmlSerializer(istance.GetType());

            using (var stringWriter = new StringWriter())
            {
                using (var xmlWriter = XmlWriter.Create(stringWriter))
                {
                    xmlSerializer.Serialize(xmlWriter, istance);
                    return stringWriter.ToString();
                }
            }
        }
    }
}
