using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;

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
     public static class ObjectToDictionaryHelper
    {
        /// <summary>
        /// This method maps the object to dictionary
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IDictionary<string, object> ToDictionary(this object source)
        {
            var dictionary = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);

            if (source == null) return dictionary;

            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(source))
            {
                var obj = descriptor.GetValue(source);
                dictionary.Add(descriptor.Name, obj);
            }

            return dictionary;
        }

        /// <summary>
        /// This method maps the collection to dictionary
        /// </summary>
        /// <param name="nvc"></param>
        /// <returns></returns>
        public static IDictionary<string, string> ToDictionary(this NameValueCollection nvc)
        {
            if ((nvc == null) || !nvc.AllKeys.Any()) return new Dictionary<string, string>();

            return nvc.AllKeys.ToDictionary(k => k, k => nvc[k]);
        }
    }
}
