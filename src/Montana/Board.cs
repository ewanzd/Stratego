using System;

namespace Montana
{
    /// <summary>
    /// 2D board with any length and height.
    /// </summary>
    /// <typeparam name="T">Type of field.</typeparam>
    public class Board<T> : Matrix<T>
    {
        /// <summary>
        /// Get and set a field of <see cref="Stratego.Game.Board{T}"/>.
        /// </summary>
        /// <param name="x">Horizontal position in <see cref="Stratego.Game.Board{T}"/>.</param>
        /// <param name="y">Vertical position in <see cref="Stratego.Game.Board{T}"/>.</param>
        /// <returns>Return field in target position.</returns>
        /// <exception cref="IndexOutOfRangeException">Position is out of range.</exception>
        public T this[int x, int y] {
            get {
                return base[x, y];
            }
            set {
                var newValue = value;
                var oldValue = base[x, y];

                base[x, y] = newValue;

                var eventArgs = new FieldEventArgs<T>(new Position(x, y), oldValue, newValue);
                OnFieldChanged(eventArgs);
            }
        }

        /// <summary>
        /// Get and set a field of board.
        /// </summary>
        /// <param name="position">Position in board.</param>
        /// <returns>Return field in target position.</returns>
        /// <exception cref="IndexOutOfRangeException">Position is out of range.</exception>
        public T this[Position position] {
            get {
                return this[position.X, position.Y];
            }
            set {
                this[position.X, position.Y] = value;
            }
        }

        /// <summary>
        /// Event after field change.
        /// </summary>
        public event EventHandler<FieldEventArgs<T>> FieldChanged;

        /// <summary>
        /// Get length of <see cref="Stratego.Game.Board{T}"/>.
        /// </summary>
        public int Width {
            get {
                return GetLength(0);
            }
        }

        /// <summary>
        /// Get height of <see cref="Stratego.Game.Board{T}"/>.
        /// </summary>
        public int Height {
            get {
                return GetLength(1);
            }
        }

        /// <summary>
        /// Create new instance of <see cref="Stratego.Game.Board{T}"/>.
        /// </summary>
        /// <param name="length">Length of <see cref="Stratego.Game.Board{T}"/>.</param>
        /// <param name="height">Height of <see cref="Stratego.Game.Board{T}"/>.</param>
        public Board(int length, int height)
            : base(length, height) {

        }

        /// <summary>
        /// Fire <see cref="Stratego.Game.Board{T}.FieldChanged"/>.
        /// </summary>
        /// <param name="e">Event args with changed data.</param>
        protected void OnFieldChanged(FieldEventArgs<T> e) {
            FieldChanged?.Invoke(this, e);
        }
    }
}
