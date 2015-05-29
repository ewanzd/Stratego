using Stratego.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stratego.AI
{
    public class StrategoAI
    {
        public Guid AiId { get; private set; }

        protected StrategoGame game { get; private set; }

        public StrategoAI(StrategoGame game)
        {
            if(game == null)
                throw new ArgumentNullException("game");

            this.game = game;
            AiId = Guid.NewGuid();

            game.AddPlayer(AiId);
        }
    }
}
