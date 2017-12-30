using System;
using System.Collections.Generic;
using System.Text;

namespace Stratego.Core
{
    public class MembershipComponent : ActorComponent
    {
        private static ulong _componentId;
        public override ulong ComponentId => _componentId;

        private Guid _player;
        public Guid Player { get => _player; set => _player = value; }
    }
}
