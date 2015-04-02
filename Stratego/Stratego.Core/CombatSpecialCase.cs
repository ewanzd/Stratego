using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stratego.Core
{
    public class CombatSpecialCase
    {
        public string AttackerTypeName { get; private set; }

        public string DefenderTypeName { get; private set; }

        public Func<Pawn, Pawn, FightResult> Fight { get; private set; }

        public CombatSpecialCase(string attTypeName, string defTypeName, Func<Pawn, Pawn, FightResult> specialCase)
        {
            this.AttackerTypeName = attTypeName;
            this.DefenderTypeName = defTypeName;
            this.Fight = specialCase;
        }
    }
}
