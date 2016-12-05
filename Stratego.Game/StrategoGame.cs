using System;
using System.Collections.ObjectModel;

namespace Stratego.Game
{
    /// <summary>
    /// Create and manage a game.
    /// </summary>
    public sealed class StrategoGame
    {
        private readonly Guid _gameId;
        private readonly IGameType _type;
        private readonly ReadOnlyCollection<Guid> _listOfPlayers;

        /// <summary>
        /// The <see cref="System.Guid"/> of game.
        /// </summary>
        public Guid GameId { get { return _gameId; } }

        /// <summary>
        /// Game type from this game.
        /// </summary>
        public IGameType GameType { get { return _type; } }

        /// <summary>
        /// Create a new classic stratego game with two players.
        /// </summary>
        /// <param name="playerOne"><see cref="System.Guid"/> of player one.</param>
        /// <param name="playerTwo"><see cref="System.Guid"/> of player two.</param>
        public StrategoGame(Guid playerOne, Guid playerTwo) 
            : this(null, new Guid[] { playerOne, playerTwo })
        {

        }

        /// <summary>
        /// Create new game with any type of game.
        /// </summary>
        /// <param name="type">Type of game.</param>
        /// <param name="players">All players <see cref="System.Guid"/>, who participate this game.</param>
        private StrategoGame(IGameType type, params Guid[] players)
        {
            if (players.Length != type.CountOfPlayer)
                throw new ArgumentException("Count of players are not valid.");

            _type = type ?? new StrategoTypeClassic();
            _gameId = Guid.NewGuid();
            _listOfPlayers = new ReadOnlyCollection<Guid>(players);
        }

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
