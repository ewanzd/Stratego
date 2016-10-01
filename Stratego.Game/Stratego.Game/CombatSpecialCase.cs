using Montana;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stratego.Game
{
    public class CombatSpecialCase
    {
        public string AttackerTypeName { get; private set; }

        public string DefenderTypeName { get; private set; }

        public Func<Unit, Unit, FightResult> Fight { get; private set; }

        public CombatSpecialCase(string attTypeName, string defTypeName, Func<Unit, Unit, FightResult> specialCase)
        {
            this.AttackerTypeName = attTypeName;
            this.DefenderTypeName = defTypeName;
            this.Fight = specialCase;
        }
    }
}
