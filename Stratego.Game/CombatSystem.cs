using Montana;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stratego.Game
{
    public class CombatSystem
    {
        private List<CombatSpecialCase> specialcases;

        public CombatSystem()
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
