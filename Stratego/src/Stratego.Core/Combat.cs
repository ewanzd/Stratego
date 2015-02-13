using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stratego.Core
{
    public class Combat
    {
        private List<CombatSpecialCase> specialcases;

        public Combat()
        {
            specialcases = new List<CombatSpecialCase>();
        }

        public FightResult Go(Pawn attacker, Pawn defender)
        {
            return FightResult.Draw;
        }

        public void AddSpecialCase(CombatSpecialCase specialCase)
        {
            specialcases.Add(specialCase);
        }
    }
}
