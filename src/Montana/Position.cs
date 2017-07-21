using System;

namespace Montana
{
    /// <summary>
    /// Immutable position with x and y coordinates.
    /// </summary>
    public class Position : IComparable<Position>
    {
        private readonly int x, y;

        /// <summary>
        /// X-coordinate.
        /// </summary>
        public int X { get { return x; } }

        /// <summary>
        /// Y-coordinate.
        /// </summary>
        public int Y { get { return y; } }

        /// <summary>
        /// Create new coordinates.
        /// </summary>
        /// <param name="x">X-coordinate.</param>
        /// <param name="y">Y-coordinate.</param>
        public Position(int x, int y) {
            this.x = x;
            this.y = y;
        }

        public override string ToString() {
            return $"({X},{Y})";
        }

        /// <summary>
        /// Compare X first. Nord and east is bigger than south and west.
        /// </summary>
        /// <param name="other">Position to compare.</param>
        /// <returns>Result of compare.</returns>
        public int CompareTo(Position other) {
            if (other == null) return 1;
            if (X == other.X) return Y.CompareTo(other.Y);
            return X.CompareTo(other.X);
        }
    }
}