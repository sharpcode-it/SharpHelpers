// (c) 2019 SharpCoding
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace SharpCoding.SharpHelpers
{
    public static class BooleanHelper
    {
        /// <summary>
        /// This method returns TRUE when istance is different from op2
        /// </summary>
        /// <param name="istance"></param>
        /// <param name="op2"></param>
        /// <returns></returns>
        public static bool Xor(this bool istance, bool op2)
        {
            return istance ^ op2;
        }

        /// <summary>
        /// This method returns TRUE when both istance and op2 are true
        /// </summary>
        /// <param name="istance"></param>
        /// <param name="op2"></param>
        /// <returns></returns>
        public static bool And(this bool istance, bool op2)
        {
            return istance && op2;
        }

        /// <summary>
        /// This method returns TRUE when istance that invokes the method or parameter is true.
        /// It returns true when also both are true
        /// </summary>
        /// <param name="istance"></param>
        /// <param name="op2"></param>
        /// <returns></returns>
        public static bool Or(this bool istance, bool op2)
        {
            return istance || op2;
        }

        /// <summary>
        /// This method maps the instance value in one of the two parameters
        /// </summary>
        /// <param name="value"></param>
        /// <param name="trueValue"></param>
        /// <param name="falseValue"></param>
        /// <returns></returns>
        public static string ToStringValues(this bool? value, string trueValue, string falseValue)
        {
            return value.HasValue ? (value.Value ? trueValue : falseValue) : falseValue;
        }
    }
}
