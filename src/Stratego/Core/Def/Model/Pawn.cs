using Montana;
using System;

namespace Stratego.Core.Def
{
    public class Pawn
    {
        private Guid _player;
        private UnitInfo _unitInfo;
        private Position _position;
        private string _name;

        public Guid Player { get => _player; set => _player = value; }
        public UnitInfo UnitInfo { get => _unitInfo; set => _unitInfo = value; }

        /// <summary>
        /// For simple access to position of this pawn.
        /// </summary>
        public Position Position { get => _position; internal set => _position = value; }

        public string Name {
            get {
                var type = UnitInfo;
                var name = _name;

                return !String.IsNullOrWhiteSpace(name) ? name : type.Type;
            }
            set {
                _name = value;
            }
        }

        public Pawn(UnitInfo type, Guid playerId, string name = "") {
            this.UnitInfo = type;
            this.Player = playerId;
            this.Name = name;
        }
    }
}
