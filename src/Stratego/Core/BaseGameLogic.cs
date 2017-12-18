using System;
using System.Collections.Generic;
using System.Text;

namespace Stratego.Core
{
    public class BaseGameLogic
    {
        private Dictionary<ulong, Actor> actorMap = new Dictionary<ulong, Actor>();

        public virtual Actor GetActor(ulong actorId)
        {
            if (actorMap.TryGetValue(actorId, out Actor value))
            {
                return value;
            }

            return null;
        }
    }
}
