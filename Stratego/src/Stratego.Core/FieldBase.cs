﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stratego.Core
{
    public class FieldBase
    {
        public FieldType Type { get; set; }

        public FieldBase()
        {
            
        }

        public FieldBase(FieldBase field)
        {
            Type = field.Type;
        }
    }
}