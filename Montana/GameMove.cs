using Montana;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Montana
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class GameMove
    {
        private readonly Position from;
        private readonly Position to;

        /// <summary>
        /// 
        /// </summary>
        public Position From { get { return from; } }

        /// <summary>
        /// 
        /// </summary>
        public Position To { get { return to; } }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        public GameMove(Position from, Position to)
        {
            this.from = from;
            this.to = to;
        }
    }
}
