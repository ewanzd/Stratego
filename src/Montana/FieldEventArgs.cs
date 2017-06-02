using System;

namespace Montana
{
    /// <summary>
    /// Save old and new field, which changed.
    /// </summary>
    /// <typeparam name="T">Type of field.</typeparam>
    public class FieldEventArgs<T> : EventArgs
    {
        private readonly Position pos;
        private readonly T oldValue, newValue;

        /// <summary>
        /// Create new event args.
        /// </summary>
        /// <param name="pos">Position of field.</param>
        /// <param name="oldValue">Old field.</param>
        /// <param name="newValue">New field.</param>
        public FieldEventArgs(Position pos, T oldValue, T newValue) {
            this.oldValue = oldValue;
            this.newValue = newValue;
            this.pos = pos;
        }

        /// <summary>
        /// Position of field.
        /// </summary>
        public Position Position { get { return pos; } }

        /// <summary>
        /// Old field.
        /// </summary>
        public T OldValue { get { return oldValue; } }

        /// <summary>
        /// New field.
        /// </summary>
        public T NewValue { get { return newValue; } }
    }
}
