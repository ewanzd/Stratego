using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stratego.Core
{
    public class GameBase : IGame
    {
        private GameState _gameState;

        public GameState GameState
        {
            get
            {
                return _gameState;
            }
            protected set
            {
                _gameState = value;
            }
        }

        public event EventHandler Finished;

        public bool AddPlayerToGame(Guid player)
        {
            throw new NotImplementedException();
        }
    }
}
