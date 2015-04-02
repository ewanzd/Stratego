﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Montana
{
    public class FieldEventArgs : EventArgs
    {
        public readonly Position Position;

        public FieldEventArgs(Position position)
        {
            this.Position = position;
        }
    }
}