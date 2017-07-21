using Montana;
using System;
using System.Collections.Generic;

namespace Stratego.Core
{
    internal interface Bench
    {
        event EventHandler<MoveEventArgs> Moved;

        void Move(Pawn pawn, Position to);
        Move Back();

        List<Position> GetPossibleMoves(Pawn pawn);
    }

    /// <summary>
    /// Manage the access to board.
    /// </summary>
    public class StrategoBenchInPlay : Bench
    {
        protected StrategoBoard _board;
        protected StrategoCombat combat;

        protected int currentPlayer; // order (0 / 1)
        private Stack<Move> _listOfMoves;

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<MoveEventArgs> Moved;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="game"></param>
        /// <param name="prep"></param>
        public StrategoBenchInPlay(StrategoGame game, StrategoBenchSetup prepPlayerOne, StrategoBenchSetup prepPlayerTwo) {
            // check input
            if (game == null)
                throw new ArgumentNullException(nameof(game));
            if (prepPlayerOne == null)
                throw new ArgumentNullException(nameof(prepPlayerOne));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        protected bool CanMove(Position from, Position to) {
            return false;
        }

        /*
        /// <summary>
        /// 
        /// </summary>
        /// <param name="move"></param>
        /// <returns></returns>
        public bool MakeMove(Move move) => MakeMove(move.From, move.To);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public virtual bool MakeMove(Position from, Position to) {
            // Get fields
            var start = _board[from.X, from.Y];
            var end = _board[to.X, to.Y];

            // Can't move the pawn
            if (start.Pawn == null)
                return false;
            if (!CanMove(from, to))
                return false;

            // Move the pawn
            if (end.Pawn == null) {
                var pawn = start.Pawn;
                start.Pawn = null;
                end.Pawn = pawn;
                var eventArgs = new MoveEventArgs(new Move(from, to, pawn));
                OnMoved(eventArgs);
                return true;
            }

            // Fight
            var att = start.Pawn;
            var def = end.Pawn;
            var result = combat.Fight(att, def);

            switch (result) {
                case FightResult.Win:
                    
                    start.Pawn = null;
                    end.Pawn = att;
                    break;
                case FightResult.Lose:

                    break;
                case FightResult.Draw:
                    break;
            }

            return false;
        }*/

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnMoved(MoveEventArgs e) {
            Moved?.Invoke(this, e);
        }

        public void Move(Pawn pawn, Position to) {
            if (pawn == null) throw new ArgumentNullException(nameof(pawn));
            if (pawn.Position == null) throw new ArgumentException("Pawn must has a position.");
            if (to == null) throw new ArgumentNullException(nameof(to));

            var from = pawn.Position;
            if (from.CompareTo(to) == 0) return;

            if(GetPossibleMoves(pawn).Find(p => p.CompareTo(to) == 0) != null) {
                throw new ArgumentException("Move isn't possible.");
            }

            var f = _board[from.X, from.Y];
            var t = _board[to.X, to.Y];

            // move
        }

        public List<Position> GetPossibleMoves(Pawn pawn) {
            if (pawn == null) throw new ArgumentNullException(nameof(pawn));
            if (pawn.Position == null) throw new ArgumentException("Pawn must has a position.");

            var pos = pawn.Position;
            var moveType = pawn.UnitType.MoveType;
            var maxRange = pawn.UnitType.MaxRange;
            var possiblePos = new List<Position>();
            
            if (moveType.Is(MoveType.None) || maxRange == 0) return possiblePos;

            Action<int, int> way = (stepX, stepY) => {
                int currentRange = 1, x = pos.X + stepX, y = pos.Y + stepY;
                while (currentRange <= maxRange && x >= 0 && x < _board.Width && y >= 0 && y < _board.Height && 
                !_board[x, y].IsLocked && _board[x, y].Pawn != null) {
                    possiblePos.Add(new Position(x, y));

                    currentRange++;
                    x += stepX;
                    y += stepY;
                }
            };

            if(moveType.Has(MoveType.Cross)) {
                way(1, 0);
                way(-1, 0);
                way(0, 1);
                way(0, -1);
            }
            if(moveType.Has(MoveType.Diagonal)) {
                way(1, 1);
                way(-1, 1);
                way(1, -1);
                way(-1, -1);
            }

            return possiblePos;
        }

        public Move Back() {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Save a move of a pawn and when he fight, then it save the result.
    /// </summary>
    public class MoveEventArgs : EventArgs
    {
        private readonly Move move;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="move"></param>
        public MoveEventArgs(Move move) {
            this.move = move;
        }

        /// <summary>
        /// 
        /// </summary>
        public Move Move { get { return move; } }
    }
}
