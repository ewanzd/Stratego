using Stratego.Core;
using System;

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
        }
    }
}
