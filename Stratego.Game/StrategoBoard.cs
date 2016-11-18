using Montana;

namespace Stratego.Game
{
    /// <summary>
    /// Define board and offer checks.
    /// </summary>
    public class StrategoBoard : Board<Field>
    {
        /// <summary>
        /// Create uninitialize board with 10x10 fields.
        /// </summary>
        public StrategoBoard() : this(10, 10)
        {

        }

        /// <summary>
        /// Create uninitialize board.
        /// </summary>
        /// <param name="width">Width of board.</param>
        /// <param name="height">Height of board.</param>
        public StrategoBoard(int width, int height) : base(width, height)
        {
            
        }

        /// <summary>
        /// Check the field have a pawn.
        /// </summary>
        /// <param name="pos">Position of field to check.</param>
        /// <returns>Return <c>true</c> if have a pawn.</returns>
        public bool HasPawn(Position pos)
        {
            var field = this[pos];
            return (field != null) ? field.Pawn != null : false;
        }
    }
}
