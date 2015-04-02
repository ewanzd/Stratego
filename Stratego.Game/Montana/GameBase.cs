using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Montana
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class GameBase<info> : IGame 
        where info : GameSummaryBase
    {
        /// <summary>
        /// All players <see cref="System.Guid"/>.
        /// </summary>
        protected List<Guid> listOfPlayers;

        protected info GameInfo;

        public bool IsActive { get; protected set; }

        public Guid GameId { get; private set; }

        public abstract int MaxPlayer { get; protected set; }

        public event EventHandler Ready;
        public event EventHandler Finished;

        public GameBase()
        {
            this.listOfPlayers = new List<Guid>();
            GameId = Guid.NewGuid();
            IsActive = true;
        }

        public GameBase(info summary)
        {
            this.GameId = summary.GameId;
            this.listOfPlayers = summary.ListOfPlayers;
            this.IsActive = summary.IsActive;
        }

        public virtual bool AddPlayerToGame(Guid player)
        {
            if(player == Guid.Empty)
                return false;
            if(listOfPlayers == null || listOfPlayers.Count >= MaxPlayer)
                return false;
            if(listOfPlayers.Count == 1 && listOfPlayers[0] == player)
                return false;

            listOfPlayers.Add(player);

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
