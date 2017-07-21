using Montana;
using System;

namespace Stratego.Core
{
    public class Pawn
    {
        public UnitInfo UnitType { get; }

        public Guid Player { get; }

        /// <summary>
        /// For simple access to position of this pawn.
        /// </summary>
        public Position Position { get; internal set; }

        private string _name;

        public string Name {
            get {
                var type = UnitType;
                var name = _name;

                return !String.IsNullOrWhiteSpace(name) ? name : UnitType.Type;
            }
            set {
                _name = value;
            }
        }

        public int Power {
            get {
                return UnitType.Rank;
            }
        }

        public SpecialSkill SpecialSkill {
            get {
                return UnitType.SpecialSkill;
            }
        }

        public Pawn(UnitInfo type, Guid playerId, string name = "") {
            //if (type == default(Unit))
            //    throw new ArgumentNullException("type");

            this.UnitType = type;
            this.Player = playerId;
            this.Name = name;
        }
    }
}
