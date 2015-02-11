using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stratego.Core
{
    public class Board : Matrix
    {
        public Field this[int x, int y]
        {
            get
            {
                return (Field)base[x, y];
            }
            set
            {
                base[x, y] = value;
                //OnFieldChanged(new Point(posX, posY));
            }
        }

        protected object sync = new object();

        public event EventHandler BoardInitializing;

        public event EventHandler BoardInitialized;

        public event EventHandler<FieldEventArgs> FieldChanged;

        public int Length
        {
            get
            {
                return GetLength(1);
            }
        }

        public int Height
        {
            get
            {
                return GetLength(2);
            }
        }

        public Board(int length, int height) : base(length, height)
        {
            OnBoardInitializing();
            OnBoardInitialized();
        }

        protected void OnBoardInitializing()
        {
            var ev = BoardInitializing;

            if(ev != null) ev(this, EventArgs.Empty);
        }

        protected void OnBoardInitialized()
        {
            var ev = BoardInitialized;

            if(ev != null) ev(this, EventArgs.Empty);
        }

        protected void OnFieldChanged(Point pos)
        {
            var ev = FieldChanged;

            //var eventArgs = new FieldEventArgs(pos, )

            //if(ev != null) ev(this, EventArgs.Empty);
        }
    }

    public class FieldEventArgs : EventArgs
    {
        public readonly Point Position;

        public readonly Field Field;

        public FieldEventArgs(Point pos, Field field)
        {
            this.Position = pos;
            this.Field = field;
        }
    }
}
