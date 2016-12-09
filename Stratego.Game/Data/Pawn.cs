using Montana;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stratego.Core
{
    public class Pawn
    {
        protected UnitInfo UnitType { get; }

        public Guid Player { get; }

        private string _name;

        public string Name
        {
            get
            {
                var type = UnitType;
                var name = _name;

                return !String.IsNullOrWhiteSpace(name) ? name : UnitType.Type;
            }
            set
            {
                _name = value;
            }
        }

        public int Power
        {
            get
            {
                return UnitType.Rank;
            }
        }

        public SpecialSkill SpecialUnit
        {
            get
            {
                return UnitType.SpecialUnit;
            }
        }

        public Pawn(UnitInfo type, Guid playerId, string name = "")
        {
            //if (type == default(Unit))
            //    throw new ArgumentNullException("type");

            this.UnitType = type;
            this.Player = playerId;
            this.Name = name;
        }
    }
}
