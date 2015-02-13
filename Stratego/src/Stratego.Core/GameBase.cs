using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stratego.Core
{
    public abstract class GameBase : IGame
    {
        protected List<Guid> listOfPlayers;

        public GameState GameState { get; protected set; }

        public bool IsActive { get; protected set; }

        public Guid GameId { get; private set; }

        public abstract int MaxPlayer { get; protected set; }

        public event EventHandler Ready;
        public event EventHandler Finished;

        public GameBase()
        {
            this.listOfPlayers = new List<Guid>();
            GameState = GameState.Prep;
            GameId = Guid.NewGuid();
            IsActive = true;
        }

        public GameBase(GameSummaryBase summary)
        {
            this.GameId = summary.GameId;
            this.GameState = summary.GameState;
            this.listOfPlayers = summary.ListOfPlayers;
        }

        public bool AddPlayerToGame(Guid player)
        {
            if(!(GameState == GameState.Prep))
                return false;
            if(player == Guid.Empty)
                return false;
            if(listOfPlayers == null || listOfPlayers.Count >= MaxPlayer)
                return false;
            if(listOfPlayers.Count == 1 && listOfPlayers[0] == player)
                return false;

            return true;
        }

        protected void OnReady()
        {
            var ev = Ready;

            if(ev != null)
                ev(this, EventArgs.Empty);
        }

        protected void OnFinished()
        {
            var ev = Finished;

            if(ev != null)
                ev(this, EventArgs.Empty);
        }
    }
}
