using System;
using System.Collections.ObjectModel;

namespace Stratego.Core
{
    /// <summary>
    /// Create and manage a game.
    /// </summary>
    public class StrategoGame
    {
        private readonly IGameType _type;
        private Guid _currentPlayer;
        private readonly ReadOnlyCollection<Guid> _listOfPlayers;

        /// <summary>
        /// Game type from this game.
        /// </summary>
        public IGameType GameType { get { return _type; } }

        /// <summary>
        /// Create new game with any type of game.
        /// </summary>
        /// <param name="type">Type of game.</param>
        /// <param name="players">All players <see cref="System.Guid"/>, who participate this game.</param>
        protected StrategoGame(IGameType type, params Guid[] players)
        {
            if (players.Length != type.CountOfPlayer)
                throw new ArgumentException("Count of players are not valid.");

            _type = type ?? new StrategoTypeClassic();
            _listOfPlayers = new ReadOnlyCollection<Guid>(players);
        }

        /// <summary>
        /// Create a new classic stratego game with two players.
        /// </summary>
        /// <param name="playerOne"><see cref="System.Guid"/> of player one.</param>
        /// <param name="playerTwo"><see cref="System.Guid"/> of player two.</param>
        /// <returns>Game of type classic.</returns>
        public static StrategoGame CreateClassic(Guid playerOne, Guid playerTwo) 
            => new StrategoGame(null, new Guid[] { playerOne, playerTwo });
        

        /// <summary>
        /// Get player on position X (start on 1).
        /// </summary>
        /// <param name="pos">The position of the player.</param>
        /// <returns><see cref="System.Guid"/> of player.</returns>
        public Guid GetPlayer(int pos)
        {
            return _listOfPlayers[pos - 1];
        }
    }
}
