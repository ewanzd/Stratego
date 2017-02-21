using Montana;
using System.Collections.Generic;

namespace Stratego.Core
{
    /// <summary>
    /// Default game type. Contain all units and board.
    /// </summary>
    public class StrategoTypeClassic : IGameType
    {
        private readonly int _countOfPlayer = 2;
        private readonly StrategoPawnFactory _pawnFactory
             = new StrategoPawnFactory();
        private readonly StrategoBoardGeneratorClassic _boardGenerator
             = new StrategoBoardGeneratorClassic();

        /// <summary>
        /// Get count of player from classic game type.
        /// </summary>
        public int CountOfPlayer { get { return _countOfPlayer; } }

        /// <summary>
        /// 
        /// </summary>
        public StrategoTypeClassic() {
            _pawnFactory.Register(new UnitInfo() {
                Type = "UNIT_FLAG",
                DisplayName = "TXT_NAME_UNIT_FLAG",
                Description = "TXT_DESC_UNIT_FLAG",
                MaxAvailable = 1,
                Rank = 0,
                SpecialSkill = SpecialSkill.Flag,
                MoveType = MoveType.None
            });
            // ...
        }

        /// <summary>
        /// Get board generator which help to create a board.
        /// </summary>
        /// <returns>Board generator.</returns>
        public IBoardGenerator GetBoardGenerator() {
            return _boardGenerator;
        }

        /// <summary>
        /// Get pawn factory which help to create pawn from selected unit.
        /// </summary>
        /// <returns>Pawn factory.</returns>
        public StrategoPawnFactory GetPawnFactory() {
            return _pawnFactory;
        }

        /// <summary>
        /// Get all units from classic game type.
        /// </summary>
        /// <returns>All infos to units.</returns>
        public List<UnitInfo> GetAllUnitInfo() {
            return _pawnFactory.GetAllUnitInfo();
        }
    }
}
