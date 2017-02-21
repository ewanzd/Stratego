using Stratego.Core;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Stratego.Data.Business
{
    /// <summary>
    /// 
    /// </summary>
    public class StrategoGameManager
    {
        // Data
        private readonly Guid _gameId;
        private string _title;
        private Collection<StrategoPlayerManager> _players;

        // Move between states
        private StrategoGame _game;
        private StrategoBoard _board;

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler TitleChanged;

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler GameStateChanged;

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler CountOfPlayersChanged;

        /// <summary>
        /// 
        /// </summary>
        public string Title {
            get { return _title; }
            set {
                _title = value;
                OnTitleChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Guid GameId {
            get { return _gameId; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsReadyToPrep {
            get {
                if (_players.Count == 2) {
                    return true;
                } else {
                    return false;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsReadyToPlay {
            get {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsFinished {
            get {
                if (_game.CurrentGameState == GameState.Finished) {
                    return true;
                } else {
                    return false;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected StrategoGameManager(Guid gameId) {
            _title = string.Empty;
            _gameId = gameId;
            _game = null;
            _players = new Collection<StrategoPlayerManager>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static StrategoGameManager New() {
            var id = Guid.NewGuid();
            var game = new StrategoGameManager(id);
            return game;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="game"></param>
        /// <returns></returns>
        public static StrategoGameManager Load(Game game) {
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="game"></param>
        /// <returns></returns>
        public static Game Save(StrategoGameManager game) {
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public bool AddPlayer(Player player) {
            if (_players.Count >= 2) { return false; }

            var sPlayer = new StrategoPlayerManager(player.Id) {
                Name = player.Name
            };
            _players.Add(sPlayer);

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool RemovePlayer(Guid id) {
            var toRemove = _players.Single(player => player.Id == id);
            return _players.Remove(toRemove);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnTitleChanged(EventArgs e) {
            TitleChanged?.Invoke(this, e);
        }
    }
}
