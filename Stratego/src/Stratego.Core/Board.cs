using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stratego.Core
{
    /// <summary>
    /// 2D board with any length and height.
    /// </summary>
    public class Board<field> : Matrix where field : Field
    {
        /// <summary>
        /// Get and set a field of board.
        /// </summary>
        /// <param name="x">Horizontal position in board.</param>
        /// <param name="y">Vertical position in board.</param>
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
                base[x, y] = value;
                OnFieldChanged(new Position(x, y));
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

        public event EventHandler BoardInitializing;

        public event EventHandler BoardInitialized;

        public event EventHandler<FieldEventArgs> FieldChanged;

        public int Length
        {
            get
            {
                return GetLength(1);
            }
        }

        public int Height
        {
            get
            {
                return GetLength(2);
            }
        }

        public Board(int length, int height)
            : base(length, height)
        {
            OnBoardInitializing();
            OnBoardInitialized();
        }

        protected void OnBoardInitializing()
        {
            var ev = BoardInitializing;

            if(ev != null)
                ev(this, EventArgs.Empty);
        }

        protected void OnBoardInitialized()
        {
            var ev = BoardInitialized;

            if(ev != null)
                ev(this, EventArgs.Empty);
        }

        protected void OnFieldChanged(Position position)
        {
            var ev = FieldChanged;

            var args = new FieldEventArgs(position);

            if(ev != null)
                ev(this, args);
        }
    }
}
