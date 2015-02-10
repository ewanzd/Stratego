using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stratego.Core
{
    public class Field
    {
        public FieldType Type { get; set; }

        public Field()
        {

        }

        public Field(Field field)
        {
            Type = field.Type;
        }
    }
}
