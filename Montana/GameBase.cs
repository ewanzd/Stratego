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
    public abstract class GameBase<data>
        where data : GameData, new()
    {
        // Grundlogik für verschiedene Arten von Spiele.

        /// <summary>
        /// User game data.
        /// </summary>
        public data Data { get; private set; }

        /// <summary>
        /// All players <see cref="System.Guid"/>.
        /// </summary>
        protected List<Guid> listOfPlayers
        {
            get { return Data.ListOfPlayers; }
            private set { Data.ListOfPlayers = value; }
        }

        /// <summary>
        /// Is the game active.
        /// </summary>
        public bool IsActive
        {
            get { return Data.Active; }
            private set { Data.Active = value; }
        }

        /// <summary>
        /// Is the game ready to play.
        /// </summary>
        public bool IsReady { get; private set; }

        /// <summary>
        /// The <see cref="System.Guid"/> of game.
        /// </summary>
        public Guid GameId
        {
            get { return Data.GameId; }
            private set { Data.GameId = value; }
        }

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
        /// 
        /// </summary>
        /// <param name="data"></param>
        public GameBase(data data)
        {
            if (data == null) throw new NullReferenceException();

            Data = data;

            OnInitialize();
        }

        protected virtual void OnInitialize()
        {
            if(listOfPlayers == null) listOfPlayers = new List<Guid>();
            if(GameId == Guid.Empty) GameId = Guid.NewGuid();
        }

        public virtual bool AddPlayer(Guid player)
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
            if (listOfPlayers.Count < MaxPlayer)
                return false;

            if (!IsActive)
                return false;

            return true;
        }

        protected void OnReady()
        {
            IsReady = true;

            Ready?.Invoke(this, EventArgs.Empty);
        }

        protected void OnFinished()
        {
            Finished?.Invoke(this, EventArgs.Empty);
        }
    }
}
