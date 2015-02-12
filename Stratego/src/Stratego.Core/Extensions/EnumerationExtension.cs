using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stratego.Core
{
    // from http://www.codeproject.com/Articles/37921/Enums-Flags-and-C-Oh-my-bad-pun

    /// <summary>
    /// Extensions from <see cref="System.Enum"/>.
    /// </summary>
    public static class EnumerationExtensions
    {
        /// <summary>
        /// Check <see cref="System.Enum"/> has value.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="System.Enum"/>.</typeparam>
        /// <param name="type">Type <see cref="System.Enum"/>.</param>
        /// <param name="value">The value for equal.</param>
        /// <returns>Return true if available.</returns>
        public static bool Has<T>(this Enum type, T value)
        {
            try
            {
                return (((int)(object)type & (int)(object)value) == (int)(object)value);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Check <see cref="System.Enum"/> is value.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="System.Enum"/>.</typeparam>
        /// <param name="type">Type <see cref="System.Enum"/>.</param>
        /// <param name="value">The value for equal.</param>
        /// <returns>Return is euqal.</returns>
        public static bool Is<T>(this Enum type, T value)
        {
            try
            {
                return (int)(object)type == (int)(object)value;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Add value to <see cref="System.Enum"/>.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="System.Enum"/>.</typeparam>
        /// <param name="type">Type <see cref="System.Enum"/>.</param>
        /// <param name="value">The value for add.</param>
        /// <returns>Return combined <see cref="System.Enum"/>.</returns>
        public static T Add<T>(this Enum type, T value)
        {
            try
            {
                return (T)(object)(((int)(object)type | (int)(object)value));
            }
            catch(Exception ex)
            {
                throw new ArgumentException(String.Format("Could not append value from enumerated type '{0}'.", typeof(T).Name), ex);
            }
        }

        /// <summary>
        /// Remove value from <see cref="System.Enum"/>.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="System.Enum"/>.</typeparam>
        /// <param name="type">Type <see cref="System.Enum"/>.</param>
        /// <param name="value">The value for remove.</param>
        /// <returns>Return the enum without value.</returns>
        public static T Remove<T>(this Enum type, T value)
        {
            try
            {
                return (T)(object)(((int)(object)type & ~(int)(object)value));
            }
            catch(Exception ex)
            {
                throw new ArgumentException(String.Format("Could not remove value from enumerated type '{0}'.", typeof(T).Name), ex);
            }
        }
    }
}
