using Montana;

namespace Stratego.Game
{
    public class Combat
    {
        public virtual FightResult Fight(Pawn attacker, Pawn defender)
        {
            switch(defender.SpecialUnit)
            {
                case SpecialUnit.Flag:
                    return FightFlag(attacker, defender);
                case SpecialUnit.Bomb:
                    return FightBomb(attacker, defender);
                case SpecialUnit.Marshal:
                    return FightMarshal(attacker, defender);
                default:
                    return FightNormal(attacker, defender);
            }
        }

        protected virtual FightResult FightNormal(Pawn attacker, Pawn defender)
        {
            return (attacker.Power > defender.Power) ?
                FightResult.Win : (attacker.Power < defender.Power) ?
                FightResult.Lose : FightResult.Draw;
        }

        protected virtual FightResult FightFlag(Pawn attacker, Pawn defender)
        {
            return FightResult.Win;
        }

        protected virtual FightResult FightBomb(Pawn attacker, Pawn defender)
        {
            return (attacker.SpecialUnit == SpecialUnit.Miner) ?
                FightResult.Win : FightResult.Lose;
        }

        protected virtual FightResult FightMarshal(Pawn attacker, Pawn defender)
        {
            return (defender.SpecialUnit == SpecialUnit.Marshal) ?
                FightResult.Win : FightResult.Lose;
        }
    }
}
