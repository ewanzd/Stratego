using Montana;
using System;
using System.Collections.Generic;

namespace Stratego.Game
{
    /// <summary>
    /// Help to prepare the board. That include board creation and set pawns.
    /// </summary>
    public class StrategoBenchPrep : IBench
    {
        protected StrategoBoard board;
        protected IGame game;

        protected Dictionary<UnitInfo, int> p1CurrentCount;
        protected Dictionary<UnitInfo, int> p2CurrentCount;

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler PawnPlaced;

        /// <summary>
        /// 
        /// </summary>
        //public event EventHandler NextPhase;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="game"></param>
        /// <param name="initializer"></param>
        public StrategoBenchPrep(IGame game, IBoardInitializer initializer)
        {
            board = new StrategoBoard();
            initializer.Initialize(board);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pawn"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        public bool PlaceUnit(Guid player, UnitInfo unit, Position pos)
        {
            var field = board[pos];

            if (board.HasPawn(pos))
                return false;

            Pawn pawn = new Pawn(unit, player);
            field.Pawn = pawn;

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public bool RemoveUnit(Position pos)
        {
            return false;
        }

        /// <summary>
        /// Get board if it ready.
        /// </summary>
        /// <returns>Prepared board.</returns>
        public StrategoBoard GetBoard()
        {
            return board;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnPawnPlaced(EventArgs e)
        {
            PawnPlaced?.Invoke(this, e);
        }
    }
}
