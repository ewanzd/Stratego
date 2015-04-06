using Montana;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stratego.Core
{
    public class StrategoGameSummary : BoardGameSummary
    {
        public GameState GameState { get; set; }
        public List<GameMove> ListOfMoves { get; set; }
    }
}
