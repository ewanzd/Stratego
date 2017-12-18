using System;
using System.Collections.Generic;
using System.Text;

namespace Stratego.Core.Def
{
    public interface IBoard
    {
        Actor this[int x, int y] { get; set; }
    }
}
