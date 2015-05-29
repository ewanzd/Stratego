using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Montana
{
    /// <summary>
    /// 2D board with any length and height.
    /// </summary>
    /// <typeparam name="field">Type of field.</typeparam>
    public class Board<field> : Matrix
    {
        /// <summary>
        /// Get and set a field of <see cref="Stratego.Game.Board{field}"/>.
        /// </summary>
        /// <param name="x">Horizontal position in <see cref="Stratego.Game.Board{field}"/>.</param>
        /// <param name="y">Vertical position in <see cref="Stratego.Game.Board{field}"/>.</param>
        /// <returns>Return field in target position.</returns>
        /// <exception cref="IndexOutOfRangeException">Position is out of range.</exception>
        public field this[int x, int y]
        {
            get
            {
                return (field)base[x, y];
            }
            set
            {
                var newValue = value;
                var oldValue = base[x, y];

                base[x, y] = newValue;

                OnFieldChanged(new Position(x, y), oldValue, newValue);
            }
        }

        /// <summary>
        /// Get and set a field of board.
        /// </summary>
        /// <param name="position">Position in board.</param>
        /// <returns>Return field in target position.</returns>
        /// <exception cref="IndexOutOfRangeException">Position is out of range.</exception>
        public field this[Position position]
        {
            get
            {
                return this[position.X, position.Y];
            }
            set
            {
                this[position.X, position.Y] = value;
            }
        }

        /// <summary>
        /// Event after field change.
        /// </summary>
        public event EventHandler<FieldEventArgs> FieldChanged;

        /// <summary>
        /// Get length of <see cref="Stratego.Game.Board{field}"/>.
        /// </summary>
        public int Length
        {
            get
            {
                return GetLength(1);
            }
        }

        /// <summary>
        /// Get height of <see cref="Stratego.Game.Board{field}"/>.
        /// </summary>
        public int Height
        {
            get
            {
                return GetLength(2);
            }
        }

        /// <summary>
        /// Create new instance of <see cref="Stratego.Game.Board{field}"/>.
        /// </summary>
        /// <param name="length">Length of <see cref="Stratego.Game.Board{field}"/>.</param>
        /// <param name="height">Height of <see cref="Stratego.Game.Board{field}"/>.</param>
        public Board(int length, int height)
            : base(length, height)
        {
            
        }

        /// <summary>
        /// Fire <see cref="Stratego.Game.Board{field}.FieldChanged"/>.
        /// </summary>
        /// <param name="cor"></param>
        /// <param name="newValue"></param>
        protected void OnFieldChanged(Position cor, object oldValue, object newValue)
        {
            var ev = FieldChanged;
            var args = new FieldEventArgs(cor, oldValue, newValue);

            if (ev != null)
                ev(this, args);
        }
    }
}
