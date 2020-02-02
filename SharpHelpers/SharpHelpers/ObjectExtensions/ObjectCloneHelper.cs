// (c) 2019 SharpCoding
// This code is licensed under MIT license (see LICENSE.txt for details)
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace SharpCoding.SharpHelpers.ObjectExtensions
{
    public static class ObjectCloneHelper
    {
        #region Private Properties

        private const BindingFlags Binding = BindingFlags.Instance |
                                             BindingFlags.NonPublic | BindingFlags.Public |
                                             BindingFlags.FlattenHierarchy;

        #endregion

        public static T Clone<T>(this object istance,ICollection<string> propertyExcludeList = null)
        {
            if (istance == null)
                return default;

            return (T) DeepClone(istance,propertyExcludeList);
        }

        public static object Clone(this object istance)
        {
            return DeepClone(istance);
        }

        #region Privat Method Deep Clone

        // Clone the object Properties and its children recursively
        private static object DeepClone(object istance,ICollection<string> propertyExcludeList = null)
        {
            var desireObjectToBeCloned = istance;

            var primaryType = istance.GetType();

            if (primaryType.IsArray)
                return ((Array) desireObjectToBeCloned).Clone();

            object tObject = desireObjectToBeCloned as IList;
            if (tObject != null)
            {
                var properties = primaryType.GetProperties();
                // Get the IList Type of the object
                var customList = typeof(List<>).MakeGenericType
                    ((properties[properties.Length - 1]).PropertyType);
                tObject = (IList) Activator.CreateInstance(customList);
                var list = (IList) tObject;
                // loop throw each object in the list and clone it
                foreach (var item in ((IList) desireObjectToBeCloned))
                {
                    if (item == null)
                        continue;
                    var value = DeepClone(item,propertyExcludeList);
                    list?.Add(value);
                }
            }
            else
            {
                // if the item is a string then Clone it and return it directly.
                if (primaryType == typeof(string))
                    return (desireObjectToBeCloned as string)?.Clone();

                // Create an empty object and ignore its construtore.
                tObject = FormatterServices.GetUninitializedObject(primaryType);
                var fields = desireObjectToBeCloned.GetType().GetFields(Binding);
                foreach (var property in fields)
                {
                    if((propertyExcludeList!=null) && (propertyExcludeList.Any()))
                        if (propertyExcludeList.Contains(property.Name.ExtractBetween("<",">")?.FirstOrDefault()))
                            continue;

                    if (property.IsInitOnly) // Validate if the property is a writable one.
                        continue;
                    var value = property.GetValue(desireObjectToBeCloned);
                    if (property.FieldType.IsClass && property.FieldType != typeof(string))
                        tObject.GetType().GetField(property.Name, Binding)?.SetValue
                            (tObject, DeepClone(value,propertyExcludeList));
                    else
                        tObject.GetType().GetField(property.Name, Binding)?.SetValue(tObject, value);
                }
            }

            return tObject;
        }

        #endregion
    }
}
