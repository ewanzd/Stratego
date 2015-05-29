using Montana;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stratego.Game
{
    public interface IBoardInitializer
    {
        Board<Field> Initialize(Board<Field> board);
    }
}
