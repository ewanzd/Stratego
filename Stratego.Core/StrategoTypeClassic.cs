using Montana;

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
        /// 
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
        /// 
        /// </summary>
        /// <returns></returns>
        public IBoardGenerator GetBoard() {
            return _boardGenerator;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public StrategoPawnFactory GetPawnFactory() {
            return _pawnFactory;
        }
    }
}
