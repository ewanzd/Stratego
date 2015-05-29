using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Montana
{
    [Serializable]
    public struct Position
    {
        public int X, Y;

        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public override string ToString()
        {
            return String.Format("({0},{1})", X, Y);
        }
    }
}
