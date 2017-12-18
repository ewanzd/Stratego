using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Stratego.Core
{
    public abstract class ActorComponent
    {
        private Actor owner;

        public void SetOwner(Actor owner)
        {
            this.owner = owner;
        }

        public abstract ulong ComponentId { get; }

        public virtual bool Init(XElement node)
        {
            return false;
        }

        public virtual void PostInit()
        {

        }

        public virtual void Update(int deltaMs)
        {

        }


    }
}
