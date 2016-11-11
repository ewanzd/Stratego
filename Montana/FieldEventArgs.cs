using System;

namespace Montana
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T">Field type.</typeparam>
    public class FieldEventArgs<T> : EventArgs
    {
        private readonly Position pos;
        private readonly T oldValue;
        private readonly T newValue;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        public FieldEventArgs(Position pos, T oldValue, T newValue)
        {
            this.oldValue = oldValue;
            this.newValue = newValue;
            this.pos = pos;
        }

        /// <summary>
        /// 
        /// </summary>
        public Position Position { get { return pos; } }

        /// <summary>
        /// 
        /// </summary>
        public T OldValue { get { return oldValue; } }

        /// <summary>
        /// 
        /// </summary>
        public T NewValue { get { return newValue; } }
    }
}
