using Montana;

namespace Stratego.Game
{
    /// <summary>
    /// Define board and offer checks.
    /// </summary>
    public class StrategoBoard : Board<Field>
    {
        /// <summary>
        /// New board.
        /// </summary>
        public StrategoBoard() : base(10, 10) { }

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
