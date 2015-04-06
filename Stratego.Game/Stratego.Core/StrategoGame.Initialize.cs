using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stratego.Core
{
    public partial class StrategoGame
    {
        protected override void OnInitialize()
        {
            base.OnInitialize();

            this.MaxPlayer = 2;

            Pawn bomber = new Pawn("PAWN_BOMBER", 12)
            {
                Range       = Range.Stand,
                MoveType    = MoveType.None
            };
            Pawn fieldMarshal = new Pawn("PAWN_FIELDMARSHAL", 11)
            {
                Range       = Range.OneStep,
                MoveType    = MoveType.Cross
            };
            Pawn general = new Pawn("PAWN_GENERAL", 10)
            {
                Range       = Range.OneStep,
                MoveType    = MoveType.Cross
            };

            //fight.AddSpecialCase(new CombatSpecialCase(fieldMarshal.TypeName, bomber.TypeName, new Func<Pawn, Pawn, FightResult>((att, def) => FightResult.Draw)));
            //fight.AddSpecialCase(new CombatSpecialCase(general.TypeName, bomber.TypeName, new Func<Pawn, Pawn, FightResult>((att, def) => FightResult.Draw)));
        }
    }
}
