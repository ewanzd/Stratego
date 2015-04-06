using Montana;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Montana
{
    public class GameMove
    {
        public Guid PlayerId { get; set; }

        public Position From { get; set; }

        public Position To { get; set; }
    }
}
