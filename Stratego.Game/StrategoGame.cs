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
        /// Game type.
        /// </summary>
        public IGameType GameType { get { return _type; } }

        /// <summary>
        /// Create a new classic stratego game with two players.
        /// </summary>
        /// <param name="playerOne"></param>
        /// <param name="playerTwo"></param>
        public StrategoGame(Guid playerOne, Guid playerTwo) 
            : this(new StrategoTypeClassic(), new Guid[] { playerOne, playerTwo })
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="players"></param>
        public StrategoGame(IGameType type, params Guid[] players)
        {
            if (players.Length != type.CountOfPlayer)
                throw new ArgumentException("Count of players are not valid.");

            _gameId = Guid.NewGuid();
            _listOfPlayers = new ReadOnlyCollection<Guid>(players);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public Guid GetPlayer(int order)
        {
            return _listOfPlayers[order];
        }
    }
}
