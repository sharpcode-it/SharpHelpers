using System;

namespace SharpCoding.SharpHelpers.ObjectExtensions
{
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
            using (var memoryStream = new System.IO.MemoryStream(istance))
            {
                var binaryFormatter
                    = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                
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

    }
}
