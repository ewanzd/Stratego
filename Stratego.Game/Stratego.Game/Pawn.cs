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

        public string Name
        {
            get
            {
                return UnitType.TypeName;
            }
        }

        public int Power
        {
            get
            {
                return UnitType.Power;
            }
        }
    }
}
