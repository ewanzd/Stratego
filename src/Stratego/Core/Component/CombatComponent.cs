using Montana;
using Stratego.Core.Def;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stratego.Core
{
    public class CombatComponent : ActorComponent
    {
        private static ulong _componentId;
        public override ulong ComponentId => _componentId;

        private SpecialSkill _specialSkill;
        public SpecialSkill SpecialSkill { get => _specialSkill; set => _specialSkill = value; }

        private int _rank;
        public int Rank { get => _rank; set => _rank = value; }

        public FightResult Fight(CombatComponent defender)
        {
            switch (defender.SpecialSkill)
            {
                case SpecialSkill.Flag:
                    return FightResult.Win;
                case SpecialSkill.Bomb:
                    return (SpecialSkill == SpecialSkill.Miner) ?
                        FightResult.Win : FightResult.Lose;
                case SpecialSkill.Marshal:
                    return (defender.SpecialSkill == SpecialSkill.Marshal) ?
                        FightResult.Win : FightResult.Lose;
                default:
                    return (Rank > defender.Rank) ?
                        FightResult.Win : (Rank < defender.Rank) ?
                        FightResult.Lose : FightResult.Draw;
            }
        }
    }
}
