using Montana;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stratego.Core
{
    public partial class StrategoGame : BoardGame<StrategoGameSummary>
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

        public bool PlacingPawn()
        {
            return false;
        }

        public override StrategoGameSummary GetSummary()
        {
            var sum = base.GetSummary();

            return sum;
        }
    }
}
