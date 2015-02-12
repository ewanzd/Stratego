using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stratego.Core
{
    [Flags]
    public enum MoveType
    {
        None        = 0,
        Diagonal    = 1 << 0,
        Cross       = 1 << 1,

        Abroad = Diagonal | Cross
    }
}
