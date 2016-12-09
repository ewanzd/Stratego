using Stratego.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stratego.Data.Business
{
    /// <summary>
    /// 
    /// </summary>
    public class StrategoGameManager
    {
        private readonly Guid _gameId;
        private StrategoGame _game;
        private StrategoBoard _board;
        private GameState _state;
        private string _title;
        private Collection<StrategoPlayer> _players;

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
                if (_state == GameState.Finished) {
                    return true;
                } else {
                    return false;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected StrategoGameManager(Guid gameId, GameState state = GameState.Setup) {
            _title = string.Empty;
            _gameId = gameId;
            _game = null;
            _board = null;
            _state = state;
            _players = new Collection<StrategoPlayer>();
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
        public static StrategoGameManager Continue(Game game) {
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public bool AddPlayer(Player player) {
            if (_players.Count >= 2) { return false; }

            var sPlayer = new StrategoPlayer(player.Id) {
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
