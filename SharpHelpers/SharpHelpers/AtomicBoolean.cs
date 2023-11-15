// (c) 2023 SharpCoding
// This code is licensed under MIT license (see LICENSE.txt for details)using System;

using System;
using System.Data.Common;
using System.Threading;

namespace SharpCoding.SharpHelpers
{
    /// <summary>
    /// This class represents a boolean value that may be updated atomically.
    /// It is designed to be thread-safe and can be used in multi-threaded environments
    /// where atomic operations are required.
    /// </summary>
    public class AtomicBoolean : IEquatable<AtomicBoolean>
    {
        public static readonly AtomicBoolean False = new AtomicBoolean(false);
        public static readonly AtomicBoolean True = new AtomicBoolean(true);

        /// <summary>
        /// A private integer field that holds the atomic boolean value. It uses 0 for false and 1 for true.
        /// </summary>
        private int _value;
        /// <summary>
        /// FALSE and TRUE: Private constants representing the integer values of false and true respectively.
        /// </summary>
        private const int FALSE = 0;
        private const int TRUE = 1;

        /// <summary>
        /// The constructor that initializes the atomic boolean with a specified value.
        /// It uses the Interlocked.Exchange method to safely set the initial value in a thread-safe manner.
        /// </summary>
        /// <param name="value">Initial value of the instance. Is false by default.</param>
        public AtomicBoolean(bool value = false)
        {
            Interlocked.Exchange(ref _value, value ? TRUE : FALSE);
        }

        /// <summary>
        /// A private property that gets the current boolean value of the atomic boolean.
        /// It uses the Interlocked.CompareExchange method to safely get the current value in a thread-safe manner.
        /// </summary>
        private bool Value => Interlocked.CompareExchange(ref _value, FALSE, FALSE) == TRUE;

        /// <summary>
        /// An implicit conversion operator that allows an AtomicBoolean to be used where a bool is expected.
        /// </summary>
        /// <param name="abool"></param>
        public static implicit operator bool(AtomicBoolean abool) => abool.Value;

        /// <summary>
        /// An implicit conversion operator that allows a bool to be used where an AtomicBoolean is expected.
        /// </summary>
        /// <param name="v"></param>
        public static implicit operator AtomicBoolean(bool v) => new AtomicBoolean(v);

        #region Equality members

        /// <inheritdoc />
        public bool Equals(AtomicBoolean other)
        {
            if (other is null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return _value == other._value;
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            return obj.GetType() == GetType() && Equals((AtomicBoolean)obj);
        }

        /// <inheritdoc />
        // ReSharper disable once NonReadonlyMemberInGetHashCode
        public override int GetHashCode() => _value;

        public static bool operator ==(AtomicBoolean left, AtomicBoolean right) => Equals(left, right);

        public static bool operator !=(AtomicBoolean left, AtomicBoolean right) => !Equals(left, right);

        #endregion
    }
}