using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Montana
{
    public abstract class ActorComponent
    {
        private Actor _owner;

        public Actor Owner { get => _owner; set => _owner = value; }

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
