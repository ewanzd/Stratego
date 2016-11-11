using Montana;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stratego.Game
{
    /// <summary>
    /// Contain all data for one instance of stratego game.
    /// </summary>
    [Serializable]
    public class StrategoData
    {
        private readonly GameInfo info;
        private readonly IEnumerable<Guid> listOfPlayers;

        /// <summary>
        /// Return id of game.
        /// </summary>
        public Guid Id { get { return info.GameId; } }

        /// <summary>
        /// Return title of game.
        /// </summary>
        public string Title { get { return info.Title; } }

        /// <summary>
        /// Return if the game is running or finished.
        /// </summary>
        public bool IsActive { get { return (info.GameState != GameState.Finished) ? true : false; } }

        /// <summary>
        /// Return the state of game.
        /// </summary>
        public GameState GameState
        {
            get { return info.GameState; }
            protected set {
                info.GameState = value;
                OnGameStateChanged(new GameStateEventArgs(value));
            }
        }

        /// <summary>
        /// Player one.
        /// </summary>
        public Guid PlayerOne { get { return listOfPlayers.ElementAt(0); } }

        /// <summary>
        /// Player two.
        /// </summary>
        public Guid PlayerTwo { get { return listOfPlayers.ElementAt(1); } }

        /// <summary>
        /// Game state changed.
        /// </summary>
        public event EventHandler GameStateChanged;

        /// <summary>
        /// Title changed.
        /// </summary>
        public event EventHandler TitleChanged;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="players"></param>
        /// <param name="created"></param>
        protected StrategoData(Guid id,
            IEnumerable<Guid> players,
            DateTime created = default(DateTime))
        {
            info = new GameInfo()
            {
                GameId = id,
                Title = "Stratego Game",
                CreateDateTime = created,
                FinishDateTime = default(DateTime),
                GameState = default(GameState)
            };

            listOfPlayers = players;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="playerOne"></param>
        /// <param name="playerTwo"></param>
        /// <returns></returns>
        public static StrategoData Create(Guid playerOne, Guid playerTwo)
        {
            var id = Guid.NewGuid();
           
            return new StrategoData(id, new Guid[] { playerOne, playerTwo }, created: DateTime.Now).SetStatePrep();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="playerOne"></param>
        /// <param name="playerTwo"></param>
        /// <param name="state"></param>
        /// <param name="created"></param>
        /// <param name="moves"></param>
        /// <returns></returns>
        public static StrategoData Continue(Guid id,
            Guid playerOne, Guid playerTwo, DateTime created)
        {
            return new StrategoData(id, new Guid[] { playerOne, playerTwo }, created: created).SetStateInPlay();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public StrategoData SetTitle(string title)
        {
            info.Title = title;
            OnTitleChanged(new TitleEventArgs(title));
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public StrategoData SetStatePrep()
        {
            GameState = GameState.Prep;
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public StrategoData SetStateInPlay()
        {
            GameState = GameState.InPlay;
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="finished"></param>
        public StrategoData SetStateFinished(DateTime finished)
        {
            GameState = GameState.Finished;
            info.FinishDateTime = finished;
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Tuple<GameInfo, IEnumerable<Guid>> GetData()
        {
            return new Tuple<GameInfo, IEnumerable<Guid>>(info, listOfPlayers);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        private void OnGameStateChanged(GameStateEventArgs e)
        {
            GameStateChanged?.Invoke(this, e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        private void OnTitleChanged(TitleEventArgs e)
        {
            TitleChanged?.Invoke(this, e);
        }
    }

    /// <summary>
    /// Save the state of game.
    /// </summary>
    public class GameStateEventArgs : EventArgs
    {
        private readonly GameState state;

        /// <summary>
        /// Create a <see cref="EventArgs"/> to release the state of game.
        /// </summary>
        /// <param name="state">The state of game.</param>
        public GameStateEventArgs(GameState state)
        {
            this.state = state;
        }

        /// <summary>
        /// The state of game.
        /// </summary>
        public GameState State { get { return state; } }
    }

    /// <summary>
    /// Save the title of game.
    /// </summary>
    public class TitleEventArgs : EventArgs
    {
        private readonly string title;

        /// <summary>
        /// Create a <see cref="EventArgs"/> to release the title of game.
        /// </summary>
        /// <param name="title">The title of game.</param>
        public TitleEventArgs(string title)
        {
            this.title = title;
        }

        /// <summary>
        /// The title of game.
        /// </summary>
        public string Title { get { return title; } }
    }
}
