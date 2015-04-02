using Montana;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stratego.Core
{
    public partial class StrategoGame : GameBase<StrategoGameSummary>
    {
        // Verfügt über die Spiellogik von Stratego

        protected Board<StrategoField> board;
        protected List<GameMove> listOfMoves;
        protected CombatSystem fight;
        private int _maxPlayer;

        public GameState GameState { get; protected set; }

        public sealed override int MaxPlayer
        {
            get
            {
                return _maxPlayer;
            }
            protected set
            {
                _maxPlayer = value;
            }
        }

        public StrategoGame()
        {
            board       = new Board<StrategoField>(10, 10);
            listOfMoves = new List<GameMove>();
            fight       = new CombatSystem();

            InitializeGame();
        }

        public StrategoGame(StrategoGameSummary summary) : base(summary)
        {
            this.listOfMoves = summary.ListOfMoves;

            InitializeGame();
        }

        public bool PlacingPawn()
        {
            return false;
        }

        public void MakeMove(GameMove move)
        {

        }

        public StrategoGameSummary GetSummary()
        {
            return null;
        }
    }
}
