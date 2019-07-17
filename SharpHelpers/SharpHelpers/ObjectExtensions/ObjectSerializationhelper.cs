using Newtonsoft.Json;

namespace SharpCoding.SharpHelpers.ObjectExtensions
{
    public static class ObjectSerializationHelper
    {
        public static string SerializeToJson(this object istance)
        {
            return istance == null ? string.Empty : JsonConvert.SerializeObject(istance);
        }

        public static T DeserializeFromJson<T>(this string istance) where T : class
        {
            return string.IsNullOrEmpty(istance) ? null : JsonConvert.DeserializeObject<T>(istance);
        }
        
    }
}
