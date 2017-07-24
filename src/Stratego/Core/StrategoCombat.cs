using System;
using Montana;
using Stratego.Core.Def;

namespace Stratego.Core
{
    public class StrategoCombat : ICombatSystem
    {
        /*public virtual FightResult Fight(Pawn attacker, Pawn defender)
        {
            switch(defender.UnitInfo.SpecialSkill)
            {
                case SpecialSkill.Flag:
                    return FightFlag(attacker, defender);
                case SpecialSkill.Bomb:
                    return FightBomb(attacker, defender);
                case SpecialSkill.Marshal:
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
            return (attacker.SpecialSkill == SpecialSkill.Miner) ?
                FightResult.Win : FightResult.Lose;
        }

        protected virtual FightResult FightMarshal(Pawn attacker, Pawn defender)
        {
            return (defender.SpecialSkill == SpecialSkill.Marshal) ?
                FightResult.Win : FightResult.Lose;
        }*/

        public FightResult Go(Pawn attacker, Pawn defender)
        {
            throw new NotImplementedException();
        }
    }
}
