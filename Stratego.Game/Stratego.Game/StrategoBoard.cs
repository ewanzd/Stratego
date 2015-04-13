using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Montana;

namespace Stratego.Game
{
    public class StrategoBoard : Board<Field>
    {
        public StrategoBoard(int length, int height) : base(length, height)
        {
            Initialize();
        }

        public void Initialize()
        {
            for (int x = 1; x <= Length; x++)
                for (int y = 1; y <= Height; y++)
                    this[x, y] = new Field();
        }
    }
}
