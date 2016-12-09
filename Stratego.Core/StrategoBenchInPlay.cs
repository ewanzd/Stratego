using Montana;
using System;
using System.Collections.Generic;

namespace Stratego.Core
{
    /// <summary>
    /// Manage the access to board.
    /// </summary>
    public class StrategoBenchInPlay
    {
        private readonly List<Move> _listOfMoves;
        private readonly StrategoBoard _board;
        protected Combat combat;

        protected int currentPlayer; // order (0 / 1)
        protected int round;

        protected object sync = new object();

        /// <summary>
        /// Contain list with all past moved in this game.
        /// </summary>
        public List<Move> ListOfMoves { get { return _listOfMoves; } }

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<MoveEventArgs> PawnMoved;

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
        public event EventHandler NextPhase;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="game"></param>
        /// <param name="prep"></param>
        public StrategoBenchInPlay(StrategoGame game, StrategoBenchSetup prep) 
        {
            // check input
            if (game == null) throw new ArgumentNullException(nameof(game));
            if (prep == null) throw new ArgumentNullException(nameof(prep));

            // initialize data
            round = 0;
            _listOfMoves = new List<Move>();

            // manage args
            //game.RegisterBench(this);
            _board = prep.GetBoard();
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
        /// <param name="move"></param>
        /// <returns></returns>
        public bool MakeMove(Move move) => MakeMove(move.From, move.To);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public virtual bool MakeMove(Position from, Position to)
        {
            lock (sync)
            {
                // Get fields
                var start = _board[from.X, from.Y];
                var end = _board[to.X, to.Y];

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
                    var eventArgs = new MoveEventArgs(new Move(from, to));
                    OnPawnMoved(eventArgs);
                    return true;
                }

                // Fight
                var att = start.Pawn;
                var def = end.Pawn;
                var result = combat.Fight(att, def);

                switch(result)
                {
                    case FightResult.Win:
                        if (def.SpecialUnit == SpecialSkill.Flag) OnKingFailed(EventArgs.Empty);
                        start.Pawn = null;
                        end.Pawn = att;
                        break;
                    case FightResult.Lose:

                        break;
                    case FightResult.Draw:
                        break;
                }
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnPawnMoved(MoveEventArgs e)
        {
            PawnMoved?.Invoke(this, e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnFight(FightEventArgs e)
        {
            Fighted?.Invoke(this, e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnKingFailed(EventArgs e)
        {
            KingFailed?.Invoke(this, e);
        }
    }

    /// <summary>
    /// A pawn move from <see cref="Position"/> to <see cref="Position"/>.
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
