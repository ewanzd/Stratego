﻿using Montana;
using System;
using System.Collections.Generic;

namespace Stratego.Core
{
    /// <summary>
    /// A player can set his units on this board in preperation of a game.
    /// </summary>
    public class StrategoBenchSetup
    {
        private readonly StrategoGame _game;
        private readonly StrategoBoard _board;
        //private readonly List<UnitInfo> _availableUnits;

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler PawnPlaced;

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler PawnRemoved;

        /// <summary>
        /// 
        /// </summary>
        public bool IsReady {
            get {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="game"></param>
        /// <param name="generator"></param>
        public StrategoBenchSetup(StrategoGame game, StrategoBoard board) {
            if (game == null) { throw new ArgumentNullException(nameof(game)); }
            if (board == null) { throw new ArgumentNullException(nameof(board)); }

            _game = game;
            _board = board;

            //_availableUnits = new List<UnitInfo>();

            //var units = game.GameType.GetSetOfUnits();
            //GenerateUnits(_availableUnits, units);
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="reserve"></param>
        ///// <param name="source"></param>
        //private void GenerateUnits(List<UnitInfo> reserve, IEnumerable<UnitInfo> source) {
        //    foreach (var unit in source) {
        //        for (int i = 0; i <= unit.MaxAvailable; i++) {

        //        }
        //    }
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pawn"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        public bool PlaceUnit(Guid player, UnitInfo unit, Position pos) {
            var field = _board[pos];

            if (_board.HasPawn(pos))
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
        public bool RemoveUnit(Position pos) {
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnPawnPlaced(EventArgs e) {
            PawnPlaced?.Invoke(this, e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnPawnRemoved(EventArgs e) {
            PawnRemoved?.Invoke(this, e);
        }
    }
}
