using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stratego.Core
{
    public class Pawn
    {
        public string TypeName { get; private set; }

        public int Power { get; set; }

        public int Value { get; set; }

        public Range Range { get; set; }

        public MoveType MoveType { get; set; }

        public Pawn(string typeName, int power)
        {
            this.TypeName = typeName;
            this.Power = power;
        }
    }
}
