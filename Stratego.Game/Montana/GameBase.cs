using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Montana
{
    /// <summary>
    /// The base for several games.
    /// </summary>
    public abstract class GameBase<summary>
        where summary : GameSummaryBase, new()
    {
        // Grundlogik für verschiedene Arten von Spiele.

        /// <summary>
        /// All players <see cref="System.Guid"/>.
        /// </summary>
        protected List<Guid> listOfPlayers;

        /// <summary>
        /// Is the game active.
        /// </summary>
        public bool IsActive { get; private set; }

        /// <summary>
        /// Is the game ready to play.
        /// </summary>
        public bool IsReady { get; private set; }

        /// <summary>
        /// The <see cref="System.Guid"/> of game.
        /// </summary>
        public Guid GameId { get; private set; }

        /// <summary>
        /// Max player of game.
        /// </summary>
        public abstract int MaxPlayer { get; protected set; }

        /// <summary>
        /// The game is ready.
        /// </summary>
        public event EventHandler Ready;

        /// <summary>
        /// The game is finish.
        /// </summary>
        public event EventHandler Finished;

        /// <summary>
        /// Initialize a new default game.
        /// </summary>
        public GameBase()
        {
            this.listOfPlayers = new List<Guid>();
            GameId = Guid.NewGuid();
            IsActive = true;

            OnInitialize();
        }

        public GameBase(summary sum)
        {
            this.GameId = sum.GameId;
            this.listOfPlayers = sum.ListOfPlayers;
            this.IsActive = sum.IsActive;

            OnInitialize();
        }

        protected virtual void OnInitialize()
        {

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

            if (CheckReady()) OnReady();

            return true;
        }

        protected virtual bool CheckReady()
        {
            if (listOfPlayers.Count != MaxPlayer - 1)
                return false;

            if (!IsActive)
                return false;

            return true;
        }

        protected void OnReady()
        {
            IsReady = true;

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

        public virtual summary GetSummary()
        {
            return new summary()
            {
                GameId = GameId,
                ListOfPlayers = listOfPlayers,
                IsActive = IsActive
            };
        }
    }
}
