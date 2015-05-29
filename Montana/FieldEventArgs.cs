using Montana;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Montana
{
    public class FieldEventArgs : EventArgs
    {
        public readonly Position Position;
        public readonly object OldValue;
        public readonly object NewValue;

        public FieldEventArgs(Position cor, object oldValue, object newValue)
        {
            this.OldValue = oldValue;
            this.NewValue = newValue;
            this.Position = cor;
        }
    }
}
