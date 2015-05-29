using Montana;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stratego.Game
{
    public class Pawn
    {
        protected Unit UnitType { get; set; }

        public Guid Player { get; set; }

        private string _name;
        private int _power;

        public string Name
        {
            get
            {
                var type = UnitType;
                var name = _name;

                return !String.IsNullOrWhiteSpace(name) ? name : UnitType.TypeName;
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
                return UnitType.Power;
            }
        }

        public Pawn(Unit type, Guid playerId = default(Guid), string name = "")
        {
            if (type == null)
                throw new ArgumentNullException("type");

            this.UnitType = type;
            this.Player = playerId;
            this.Name = name;
        }
    }
}
