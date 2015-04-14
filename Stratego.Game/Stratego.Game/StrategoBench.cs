using Montana;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stratego.Game
{
    public class StrategoBench
    {
        StrategoBoard board;
        List<GameMove> listOfMoves;

        public int Length
        {
            get
            {
                return board.Length;
            }
        }

        public int Height
        {
            get
            {
                return board.Height;
            }
        }

        public event EventHandler FieldChanged;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="board"></param>
        public StrategoBench(StrategoBoard board)
        {
            this.board = board;
        }

        /// <summary>
        /// Check the field have a pawn.
        /// </summary>
        /// <param name="pos">Position of field to check.</param>
        /// <returns>Return <c>true</c> if have a pawn.</returns>
        public bool HavePawn(Position pos)
        {
            var field = board[pos];
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
            var field = board[pos];

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
        public bool MakeMove(Position from, Position to)
        {
            var move = new GameMove()
            {
                From = from,
                To = to
            };

            return MakeMove(move);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="move"></param>
        /// <returns></returns>
        public bool MakeMove(GameMove move)
        {

            listOfMoves.Add(move);

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="field"></param>
        protected void OnFieldChanged(Field field)
        {
            var ev = FieldChanged;

            if(ev != null)
                ev(field, EventArgs.Empty);
        }
    }
}
