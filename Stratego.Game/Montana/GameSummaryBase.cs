using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Montana
{
    public class GameSummaryBase
    {
        public Guid GameId { get; set; }

        public bool IsActive { get; set; }
        
        public List<Guid> ListOfPlayers { get; set; }
    }
}
