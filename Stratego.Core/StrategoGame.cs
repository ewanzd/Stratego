using System;

namespace Stratego.Core
{
    /// <summary>
    /// Central data object who moved between the states ande objects.
    /// </summary>
    public class StrategoGame
    {
        private readonly IGameType _type;
        private int _currentPlayerPosition;
        private GameState _state;

        /// <summary>
        /// Game type from this game.
        /// </summary>
        public IGameType GameType { get { return _type; } }

        /// <summary>
        /// State of the game.
        /// </summary>
        public GameState CurrentGameState { get { return _state; } }

        /// <summary>
        /// Player, who can drag a unit.
        /// </summary>
        public int CurrentPlayer { get { return _currentPlayerPosition; } }

        /// <summary>
        /// Game state changed.
        /// </summary>
        public event EventHandler GameStateChanged;

        /// <summary>
        /// Create new game with any type of game.
        /// </summary>
        /// <param name="type">Type of game.</param>
        /// <param name="state"></param>
        /// <param name="currentPlayer"></param>
        protected StrategoGame(IGameType type, GameState state = GameState.Setup, int currentPlayer = 0) {
            _type = type ?? new StrategoTypeClassic();
            _currentPlayerPosition = 0;
        }

        /// <summary>
        /// Create a new classic stratego game with two players.
        /// </summary>
        /// <param name="type"></param>
        /// <returns>Game.</returns>
        public static StrategoGame Create(IGameType type)
            => new StrategoGame(type);

        /// <summary>
        /// Change current player to next one.
        /// </summary>
        public void NextPlayer() {
            if (CurrentGameState != GameState.InPlay) {
                throw new InvalidOperationException($"Only possible in {GameState.InPlay.ToString()}.");
            }

            if(_currentPlayerPosition < _type.CountOfPlayer - 1) {
                _currentPlayerPosition++;
            } else {
                _currentPlayerPosition = 0;
            }
        }

        /// <summary>
        /// Game go to the next state.
        /// </summary>
        public void NextState() {
            if(_state < GameState.Finished) {
                _state++;
            } else {
                throw new InvalidOperationException($"Game is already finished.");
            }
        }
    }
}
