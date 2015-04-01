using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Montana
{
    public interface IGame
    {
        event EventHandler Finished;
        bool AddPlayerToGame(Guid player);
    }
}
