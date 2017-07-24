using Montana;

namespace Stratego.Core.Def
{
    public class UnitInfo : IDisplay
    {
        private string _type;
        private string _displayName;
        private string _description;
        private int _rank;
        private int _maxAvailable;
        private MoveType _moveType;
        private int _maxRange;
        private SpecialSkill _specialSkill;

        public string Type { get => _type; set => _type = value; }
        public string DisplayName { get => _displayName; set => _displayName = value; }
        public string Description { get => _description; set => _description = value; }
        public int Rank { get => _rank; set => _rank = value; }
        public int MaxAvailable { get => _maxAvailable; set => _maxAvailable = value; }
        public MoveType MoveType { get => _moveType; set => _moveType = value; }
        public int MaxRange { get => _maxRange; set => _maxRange = value; }
        public SpecialSkill SpecialSkill { get => _specialSkill; set => _specialSkill = value; }
    }
}
