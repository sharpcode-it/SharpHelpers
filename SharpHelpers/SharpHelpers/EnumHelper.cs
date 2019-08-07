using System;
using System.ComponentModel;
using System.Linq;

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
    public static class EnumHelper
    {
        /// <summary>
        /// This method returns the description as string of the enum that invokes the method
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetDescription(this Enum value)
        {
            var description = GetAttribute<DescriptionAttribute>(value);
            return description?.Description;
        }

        /// <summary>
        /// This method returns the specific attribute of type TAttribute of the Enum that invokes the method,
        /// </summary>
        /// <typeparam name="TAttribute"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static TAttribute GetAttribute<TAttribute>(this Enum value)
            where TAttribute : Attribute
        {

            var type = value.GetType();
            var name = Enum.GetName(type, value);
            return type.GetField(name)
                .GetCustomAttributes(false)
                .OfType<TAttribute>()
                .SingleOrDefault();
        }

        /// <summary>
        /// This method returns the default value of the specified TEnum
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        public static TEnum GetDefaultValue<TEnum>() where TEnum : struct
        {
            var t = typeof(TEnum);
            var attributes = (DefaultValueAttribute[])t.GetCustomAttributes(typeof(DefaultValueAttribute), false);
            if (attributes.Length > 0)
            {
                return (TEnum)attributes[0].Value;
            }
            return default;
        }

        /// <summary>
        /// this method returns the specified struct T from the string that invokes the method
        /// If the value is null or T is not an enum, the method returns the default value of the T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T GetEnumFromDescription<T>(this string value) where T : struct
        {
            var enumStringValue = string.Empty;
            var enumType = typeof (T);

            if ((!enumType.IsEnum) || string.IsNullOrEmpty(value))
                return default;
            
            foreach (var fieldInfo in enumType.GetFields())
            {
                //Get the StringValueAttribute for each enum member 
                if (fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute),
                        false) is DescriptionAttribute[] attribs && attribs.Length > 0)
                    enumStringValue = attribs[0].Description;

                if (string.Compare(enumStringValue, value, StringComparison.OrdinalIgnoreCase) == 0)
                    return (T)Enum.Parse(enumType, fieldInfo.Name);
            }
            return default;
        }

        /// <summary>
        /// Given  a string this method returns the parsed enum T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}
