using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stratego.Core
{
    [Serializable]
    public class Position
    {
        public int X { get; private set; }

        public int Y { get; private set; }

        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
