using Montana;

namespace Stratego.Core.Def
{
    public interface ICombatSystem
    {
        FightResult Go(Pawn attacker, Pawn defender);
    }
}
