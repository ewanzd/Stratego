using Montana;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stratego.Game
{
    public class StrategoGameSummary : GameSummaryBase
    {
        public GameInfo GameInfo { get; set; }
        public GameState GameState { get; set; }
        public List<GameMove> ListOfMoves { get; set; }
    }
}
