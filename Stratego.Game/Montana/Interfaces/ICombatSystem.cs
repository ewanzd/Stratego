using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Montana
{
    public interface ICombatSystem<pawn>
    {
        FightResult Go(pawn attacker, pawn defender);
    }
}
