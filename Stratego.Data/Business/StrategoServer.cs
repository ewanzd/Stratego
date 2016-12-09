using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stratego.Data.Business
{
    public class StrategoServer
    {
        private Collection<StrategoGameManager> _games;
        //private readonly Collection<NetworkPlayer> _unorderedPlayers;
        // Network - wait for new Connections

        public event EventHandler GameAdded;
        public event EventHandler GameRemoved;
        public event EventHandler GameTitleChanged;
        public event EventHandler GameCountOfPlayersChanged;
    }
}
