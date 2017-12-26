//using Montana;
//using Stratego.Core.Def;
//using System;
//using System.Collections.Generic;

//namespace Stratego.Core
//{
//    /// <summary>
//    /// A player can set his units on this board in preperation of a game.
//    /// </summary>
//    public class StrategoBenchSetup
//    {
//        private readonly StrategoGame _game;
//        private readonly IBoard _board;
//        private readonly IPawnFactory _factory;

//        /// <summary>
//        /// 
//        /// </summary>
//        public event EventHandler PawnPlaced;

//        /// <summary>
//        /// 
//        /// </summary>
//        public event EventHandler PawnRemoved;

//        /// <summary>
//        /// 
//        /// </summary>
//        public bool IsReady {
//            get {
//                return false;
//            }
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="game"></param>
//        /// <param name="generator"></param>
//        public StrategoBenchSetup(StrategoGame game, IBoard board) {
//            _game = game ?? throw new ArgumentNullException(nameof(game));
//            _board = board ?? throw new ArgumentNullException(nameof(board));
//            _factory = _game.GameType.GetPawnFactory();
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="pawn"></param>
//        /// <param name="pos"></param>
//        /// <returns></returns>
//        public bool PlaceUnit(Guid player, UnitInfo unit, Position pos) {
//            var field = _board[pos.X, pos.Y];

//            /*if (_board.HasPawn(pos))
//                return false;*/

//            Pawn pawn = new Pawn(unit, player);
//            field.Pawn = pawn;

//            return true;
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="pos"></param>
//        /// <returns></returns>
//        public bool RemoveUnit(Position pos) {
//            return false;
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="e"></param>
//        protected virtual void OnPawnPlaced(EventArgs e) {
//            PawnPlaced?.Invoke(this, e);
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="e"></param>
//        protected virtual void OnPawnRemoved(EventArgs e) {
//            PawnRemoved?.Invoke(this, e);
//        }
//    }
//}
