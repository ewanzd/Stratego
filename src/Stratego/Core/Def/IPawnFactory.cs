using System;
using System.Collections.Generic;
using System.Text;

namespace Stratego.Core.Def
{
    public interface IPawnFactory
    {
        IEnumerable<Pawn> BuildPawnSet();
    }
}
