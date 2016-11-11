using System;

namespace Montana
{
    /// <summary>
    /// 
    /// </summary>
    public class FieldEventArgs : EventArgs
    {
        private readonly Position pos;
        private readonly object oldValue;
        private readonly object newValue;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        public FieldEventArgs(Position pos, object oldValue, object newValue)
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
        public object OldValue { get { return oldValue; } }

        /// <summary>
        /// 
        /// </summary>
        public object NewValue { get { return newValue; } }
    }
}
