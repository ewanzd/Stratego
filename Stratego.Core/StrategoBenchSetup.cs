using Montana;
using System;
using System.Collections.Generic;

namespace Stratego.Core
{
    /// <summary>
    /// Help to prepare the board. That include board creation and set pawns.
    /// </summary>
    public class StrategoBenchSetup
    {
        private readonly StrategoBoard _board;
        private readonly StrategoGame _game;

        private readonly List<UnitInfo> _p1Units;
        private readonly List<UnitInfo> _p2Units;

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler PawnPlaced;

        /// <summary>
        /// 
        /// </summary>
        public bool IsReady
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="game"></param>
        /// <param name="generator"></param>
        public StrategoBenchSetup(StrategoGame game)
        {
            if (game == null) throw new ArgumentNullException("game cant be null");

            _game = game;
            var mapGenerator = game.GameType.GetMapGenerator();
            _board = mapGenerator.DrawBoard();

            _p1Units = new List<UnitInfo>();
            _p2Units = new List<UnitInfo>();

            var units = game.GameType.GetAllUnits();
            GenerateUnits(_p1Units, units);
            GenerateUnits(_p2Units, units);
        }

        private void GenerateUnits(List<UnitInfo> reserve, IEnumerable<UnitInfo> source)
        {
            foreach(var unit in source)
            {
                for(int i = 0; i <= unit.MaxAvailable; i++)
                {
                    
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pawn"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        public bool PlaceUnit(Guid player, UnitInfo unit, Position pos)
        {
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
            return _board;
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
