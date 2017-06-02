using Montana;
using System;
using System.Collections.Generic;

namespace Stratego.Core
{
    internal interface Bench
    {
        event EventHandler KingFailed;
        event EventHandler<MoveEventArgs> Moved;

        void Move(Position from, Position to);
        bool TryMove(Position from, Position to);
        void Back();
        Position[] GetPossibleMoves(Position pos);
    }

    /// <summary>
    /// Manage the access to board.
    /// </summary>
    public class StrategoBenchInPlay : Bench
    {
        private Field[,] _board;
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
        public event EventHandler<FightEventArgs> Fighted;

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler KingFailed;

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
        public bool CanMove(Position from, Position to) {
            return false;
        }

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
                    if (def.SpecialSkill == SpecialSkill.Flag)
                        OnKingFailed(EventArgs.Empty);
                    start.Pawn = null;
                    end.Pawn = att;
                    break;
                case FightResult.Lose:

                    break;
                case FightResult.Draw:
                    break;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnMoved(MoveEventArgs e) {
            Moved?.Invoke(this, e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnFight(FightEventArgs e) {
            Fighted?.Invoke(this, e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnKingFailed(EventArgs e) {
            KingFailed?.Invoke(this, e);
        }

        public void Move(Position from, Position to) {
            throw new NotImplementedException();
        }

        public bool TryMove(Position from, Position to) {
            throw new NotImplementedException();
        }

        public Position[] GetPossibleMoves(Position pos) {
            throw new NotImplementedException();
        }

        public void Back() {
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
        public MoveEventArgs(Move move)
        {
            this.move = move;
        }

        /// <summary>
        /// 
        /// </summary>
        public Move Move { get { return move; } }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FightEventArgs : EventArgs
    {
        private readonly Position from, to;
        private readonly Pawn att, def;
        private readonly FightResult result;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="att"></param>
        /// <param name="def"></param>
        /// <param name="result"></param>
        public FightEventArgs(Position from, Position to, Pawn att, Pawn def, FightResult result)
        {
            this.from = from; this.to = to; this.att = att; this.def = def; this.result = result;
        }

        /// <summary>
        /// 
        /// </summary>
        public Position From { get { return from; } }

        /// <summary>
        /// 
        /// </summary>
        public Position To { get { return to; } }

        /// <summary>
        /// 
        /// </summary>
        public Pawn Att { get { return att; } }

        /// <summary>
        /// 
        /// </summary>
        public Pawn Def { get { return def; } }

        /// <summary>
        /// 
        /// </summary>
        public FightResult Result { get { return result; } }
    }
}
