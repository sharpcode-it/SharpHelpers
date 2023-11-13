// (c) 2023 SharpCoding
// This code is licensed under MIT license (see LICENSE.txt for details)using System;

namespace SharpCoding.SharpHelpers
{
    /// <summary>
    /// The AtomicBooleanHelper class is a static class that provides extension methods for the AtomicBoolean class. 
    /// </summary>
    public static class AtomicBooleanHelper
    {
        /// <summary>
        /// This extension method performs a logical XOR operation on the instance and op2.
        /// It returns true if the instance is different from op2.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="op2"></param>
        /// <returns></returns>
        public static bool Xor(this AtomicBoolean instance, AtomicBoolean op2) => ((bool)instance).Xor(op2);

        /// <summary>
        /// This extension method performs a logical AND operation on the instance and op2.
        /// It returns true if both the instance and op2 are true.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="op2"></param>
        /// <returns></returns>
        public static bool And(this AtomicBoolean instance, AtomicBoolean op2) => ((bool)instance).And(op2);

        /// <summary>
        /// This extension method performs a logical OR operation on the instance and op2.
        /// It returns true if either the instance that invokes the method or op2 is true.
        /// It also returns true when both are true.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="op2"></param>
        /// <returns></returns>
        public static bool Or(this AtomicBoolean instance, AtomicBoolean op2) => ((bool)instance).Or(op2);

        /// <summary>
        /// This extension method maps the instance value to one of the two parameters.
        /// If the value is false or null, it returns falseValue; otherwise, it returns trueValue.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="trueValue"></param>
        /// <param name="falseValue"></param>
        /// <returns></returns>
        //public static string ToStringValues(this AtomicBoolean value, string trueValue, string falseValue) => (value == null || value == false) ? falseValue : trueValue;
        public static string ToStringValues(this AtomicBoolean value, string trueValue, string falseValue) => (value.GetValueOrDefault() == false) ? falseValue : trueValue;

        /// <summary>
        /// This extension method retrieves the value of the current AtomicBoolean object or the false value if the object is null.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static AtomicBoolean GetValueOrDefault(this AtomicBoolean value) => value.GetValueOrDefault(AtomicBoolean.False);

        /// <summary>
        /// This extension method retrieves the value of the current AtomicBoolean object or the defaultValue if the object is null.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static AtomicBoolean GetValueOrDefault(this AtomicBoolean value, AtomicBoolean defaultValue) => value ?? defaultValue;
    }
}