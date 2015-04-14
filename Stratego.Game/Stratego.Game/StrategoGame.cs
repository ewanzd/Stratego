using Montana;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stratego.Game
{
    public class StrategoGame : GameBase<StrategoGameSummary>
    {
        // Verfügt über die Spiellogik von Stratego

        protected List<GameMove> listOfMoves;
        protected CombatSystem fight;
        private int _maxPlayer;

        public GameState GameState { get; protected set; }

        public override int MaxPlayer
        {
            get
            {
                return _maxPlayer;
            }
            protected set
            {
                if(IsActive && !IsReady)
                    _maxPlayer = value;
            }
        }

        public StrategoGame()
        {
            listOfMoves = new List<GameMove>();
            fight       = new CombatSystem();
        }

        public StrategoGame(StrategoGameSummary summary) : base(summary)
        {
            this.listOfMoves = summary.ListOfMoves;
        }

        

        

        public override StrategoGameSummary GetSummary()
        {
            var sum = base.GetSummary();

            return sum;
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();

            this.MaxPlayer = 2;

            var bomber = new Unit()
            {
                TypeName = "PAWN_BOMBER",
                Power = 12,
                Range = 0,
                MoveType = MoveType.None
            };
            var fieldMarshal = new Unit()
            {
                TypeName = "PAWN_FIELDMARSHAL",
                Power = 11,
                Range = 1,
                MoveType = MoveType.Cross
            };
            var general = new Unit()
            {
                TypeName = "PAWN_GENERAL",
                Power = 10,
                Range = 1,
                MoveType = MoveType.Cross
            };

            //fight.AddSpecialCase(new CombatSpecialCase(fieldMarshal.TypeName, bomber.TypeName, new Func<Pawn, Pawn, FightResult>((att, def) => FightResult.Draw)));
            //fight.AddSpecialCase(new CombatSpecialCase(general.TypeName, bomber.TypeName, new Func<Pawn, Pawn, FightResult>((att, def) => FightResult.Draw)));
        }
    }
}
