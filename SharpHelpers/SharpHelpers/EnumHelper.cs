using System;
using System.ComponentModel;
using System.Linq;

namespace SharpCoding.SharpHelpers
{
    public static class EnumHelper
    {
        public static string GetDescription(this Enum value)
        {
            var description = GetAttribute<DescriptionAttribute>(value);
            return description?.Description;
        }

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

        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}
