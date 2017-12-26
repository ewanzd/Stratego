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
            set {
                _board[x, y] = value;
            }
        }

        public Actor this[Position pos] {
            get {
                return _board[pos.X, pos.Y];
            }
            set {
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
    }
}
