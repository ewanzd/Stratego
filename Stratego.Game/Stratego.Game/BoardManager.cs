using Montana;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stratego.Game
{
    public class BoardManager
    {
        StrategoBoard board;

        public bool HavePawn(Position pos)
        {
            return board[pos].Pawn != null;
        }

        public bool PlacingPawn(Pawn pawn, Position pos)
        {
            var field = board[pos];

            if (HavePawn(pos))
                return false;

            field.Pawn = pawn;

            return true;
        }

        public bool RemovePawn(Position pos)
        {
            return false;
        }

        public bool MakeMove(Position from, Position to)
        {
            return false;
        }
    }
}
