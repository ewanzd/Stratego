using Montana;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stratego.Game
{
    /// <summary>
    /// Manage the access to board.
    /// </summary>
    public class StrategoBench
    {
        protected Board<Field> Board;
        protected CombatSystem Combat;
        protected List<GameMove> ListOfMoves;

        protected object sync = new object();

        public event EventHandler<MoveEventArgs> PawnMoved;
        public event EventHandler PawnPlaced;
        public event EventHandler Fighted;
        public event EventHandler KingFailed;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="board"></param>
        public StrategoBench() 
            : this(new Board<Field>(10, 10))
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="board"></param>
        public StrategoBench(Board<Field> board)
        {
            this.Board = board;
            ListOfMoves = new List<GameMove>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="initializer"></param>
        public void Initialize(IBoardInitializer initializer)
        {
            initializer.Initialize(Board);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public Field GetField(Position pos)
        {
            return Board[pos.X, pos.Y];
        }

        /// <summary>
        /// Check the field have a pawn.
        /// </summary>
        /// <param name="pos">Position of field to check.</param>
        /// <returns>Return <c>true</c> if have a pawn.</returns>
        public bool HavePawn(Position pos)
        {
            var field = Board[pos];
            return (field != null) ? field.Pawn != null : false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pawn"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        public bool PlacingPawn(Pawn pawn, Position pos)
        {
            var field = Board[pos];

            if (HavePawn(pos))
                return false;

            field.Pawn = pawn;

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public bool RemovePawn(Position pos)
        {
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public bool CanMove(Position from, Position to)
        {
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public bool MakeMove(Position from, Position to)
        {
            var start = GetField(from);
            var end = GetField(to);

            lock (sync)
            {
                // Can't move the pawn
                if (start.Pawn == null)
                    return false;
                if (!CanMove(from, to))
                    return false;

                // Move the pawn
                if (end.Pawn == null)
                {
                    var pawn = start.Pawn;
                    start.Pawn = null;
                    end.Pawn = pawn;
                    OnPawnMoved(from, to, pawn);
                    return true;
                }

                // Fight
                var att = start.Pawn;
                var def = end.Pawn;
                var result = Combat.Go(att, def);

                //listOfMoves.Add(move);
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="field"></param>
        protected void OnPawnMoved(Position from, Position to, Pawn pawn)
        {
            var ev = PawnMoved;
            var args = new MoveEventArgs(from, to, pawn);

            if(ev != null) ev(this, args);
        }
    }

    public class MoveEventArgs : EventArgs
    {
        public MoveEventArgs(Position from, Position to, Pawn pawn)
        {

        }
    }
}
