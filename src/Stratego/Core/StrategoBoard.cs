using Montana;
using Stratego.Core.Def;
using System;

namespace Stratego.Core
{
    /// <summary>
    /// Define board and offer checks.
    /// </summary>
    public class StrategoBoard : IBoard // World
    {
        internal object sync = new object();

        private readonly Actor[,] _board;
        
        public int Width { get; }
        public int Height { get; }

        public event EventHandler Placed;
        public event EventHandler Removed;

        /// <summary>
        /// Access to a field with x and y coordinates.
        /// </summary>
        /// <param name="x">x-coordinate.</param>
        /// <param name="y">y-coordinate.</param>
        /// <returns>Field from this coordinates.</returns>
        public Actor this[int x, int y] {
            get {
                return _board[x, y];
            }
            private set {
                _board[x, y] = value;
            }
        }

        public Actor this[Position pos] {
            get {
                return _board[pos.X, pos.Y];
            }
            private set {
                _board[pos.X, pos.Y] = value;
            }
        }

        /// <summary>
        /// Create uninitialize board with 10x10 fields.
        /// </summary>
        public StrategoBoard() : this(10, 10) {

        }

        /// <summary>
        /// Create uninitialize board.
        /// </summary>
        /// <param name="width">Width of board.</param>
        /// <param name="height">Height of board.</param>
        public StrategoBoard(int width, int height) {
            Width = width;
            Height = height;

            _board = new Actor[width, height];
        }

        public void Place(Position pos, Actor actor)
        {
            if (pos == null) throw new ArgumentNullException(nameof(pos));
            if (this[pos] != null) throw new ArgumentException("It's already a pawn on this field");

            this[pos] = actor;

            OnActorPlaced(EventArgs.Empty);
        }

        public void Remove(Position pos)
        {
            this[pos] = null;

            OnActorRemoved(EventArgs.Empty);
        }

        protected virtual void OnActorPlaced(EventArgs e)
        {
            Placed?.Invoke(this, e);
        }

        protected virtual void OnActorRemoved(EventArgs e)
        {
            Removed?.Invoke(this, e);
        }
    }
}
