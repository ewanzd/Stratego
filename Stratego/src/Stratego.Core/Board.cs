using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stratego.Core
{
    public class Board
    {
        public Field this[int x, int y]
        {
            get
            {
                return Fields[x - 1, y - 1];
            }
            set
            {
                Fields[x - 1, y - 1] = value;
            }
        }

        protected readonly Field[,] Fields;

        public int Length
        {
            get
            {
                return Fields.GetLength(0);
            }
        }

        public int Height
        {
            get
            {
                return Fields.GetLength(1);
            }
        }

        public Board(int length, int height)
            : this(length, height, new Field())
        {

        }

        public Board(int length, int height, Field standardField)
        {
            Fields = new Field[length, height];
            fillFields(standardField);
        }

        protected virtual void fillFields(Field standardField)
        {
            for(int x = 0; x < this.Length; x++)
            {
                for(int y = 0; y < this.Height; y++)
                {
                    Fields[x, y] = new Field(standardField);
                }
            }
        }
    }
}
