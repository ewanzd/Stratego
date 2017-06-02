using System;

namespace Montana
{
    /// <summary>
    /// Save source and destination position.
    /// </summary>
    public class Move
    {
        private readonly Position from;
        private readonly Position to;

        /// <summary>
        /// Get source position.
        /// </summary>
        public Position From { get { return from; } }

        /// <summary>
        /// Get destination position.
        /// </summary>
        public Position To { get { return to; } }

        /// <summary>
        /// Create new move with source and destination position.
        /// </summary>
        /// <param name="from">Source position.</param>
        /// <param name="to">Destination position.</param>
        public Move(Position from, Position to) {
            this.from = from;
            this.to = to;
        }
    }
}
