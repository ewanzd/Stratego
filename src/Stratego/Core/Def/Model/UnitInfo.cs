using Montana;
using System;

namespace Stratego.Core.Def
{
    /*public class UnitInfo : IDisplay
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
    }*/

    public class MoveAbility : ActorComponent
    {
        private static ulong _componentId;
        public override ulong ComponentId => _componentId;

        private Position _position;
        public Position Position { get => _position; internal set => _position = value; }

        private MoveType _moveType;
        public MoveType MoveType { get => _moveType; set => _moveType = value; }

        private int _maxRange;
        public int MaxRange { get => _maxRange; set => _maxRange = value; }
    }

    public class CombatAbility : ActorComponent
    {
        private static ulong _componentId;
        public override ulong ComponentId => _componentId;

        private SpecialSkill _specialSkill;
        public SpecialSkill SpecialSkill { get => _specialSkill; set => _specialSkill = value; }

        private int _rank;
        public int Rank { get => _rank; set => _rank = value; }
    }

    public class Membership : ActorComponent
    {
        private static ulong _componentId;
        public override ulong ComponentId => _componentId;

        private Guid _player;
        public Guid Player { get => _player; set => _player = value; }
    }
}
