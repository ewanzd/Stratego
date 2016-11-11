﻿using Montana;
using System;
using System.Collections.Generic;

namespace Stratego.Game
{
    /// <summary>
    /// Manage the access to board.
    /// </summary>
    public class StrategoBench
    {
        private readonly List<GameMove> listOfMoves;
        private Board<Field> board;
        private Combat combat;

        protected int currentPlayer; // 0 / 1
        protected int round;

        protected Dictionary<UnitInfo, int> p1CurrentCount;
        protected Dictionary<UnitInfo, int> p2CurrentCount;

        protected object sync = new object();

        /// <summary>
        /// Contain list with all past moved in this game.
        /// </summary>
        public List<GameMove> ListOfMoves { get { return listOfMoves; } }

        public event EventHandler PawnPlaced;
        public event EventHandler<MoveEventArgs> PawnMoved;
        public event EventHandler<FightEventArgs> Fighted;
        public event EventHandler KingFailed;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="board"></param>
        public StrategoBench(IGame game, IBoardInitializer initializer) 
        {
            if (game == null) throw new ArgumentNullException(nameof(game));

            game.RegisterBench(this);
            board = new Board<Field>(10, 10);
            initializer.Initialize(board);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public Field GetField(Position pos)
        {
            return board[pos.X, pos.Y];
        }

        /// <summary>
        /// Check the field have a pawn.
        /// </summary>
        /// <param name="pos">Position of field to check.</param>
        /// <returns>Return <c>true</c> if have a pawn.</returns>
        public bool HasPawn(Position pos)
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
        public bool PlaceUnit(Guid player, UnitInfo unit, Position pos)
        {
            var field = board[pos];

            if (HasPawn(pos))
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
        public virtual bool MakeMove(Position from, Position to)
        {
            lock (sync)
            {
                // Get fields
                var start = GetField(from);
                var end = GetField(to);

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
                    var eventArgs = new MoveEventArgs(from, to);
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
                        if (def.SpecialUnit == SpecialUnit.Flag) OnKingFailed(EventArgs.Empty);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnPawnPlaced(EventArgs e)
        {
            PawnPlaced?.Invoke(this, e);
        }
    }

    /// <summary>
    /// A pawn move from <see cref="Position"/> to <see cref="Position"/>.
    /// </summary>
    public class MoveEventArgs : EventArgs
    {
        private readonly Position from, to;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        public MoveEventArgs(Position from, Position to)
        {
            this.from = from; this.to = to;
        }

        /// <summary>
        /// 
        /// </summary>
        public Position From { get { return from; } }

        /// <summary>
        /// 
        /// </summary>
        public Position To { get { return to; } }
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
