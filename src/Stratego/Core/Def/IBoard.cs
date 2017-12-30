using Montana;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stratego.Core.Def
{
    public interface IBoard
    {
        Actor this[int x, int y] { get; }
        Actor this[Position pos] { get; }

        int Width { get; }
        int Height { get; }

        event EventHandler Placed;
        event EventHandler Removed;

        void Place(Position pos, Actor actor);
        void Remove(Position pos);
    }
}
