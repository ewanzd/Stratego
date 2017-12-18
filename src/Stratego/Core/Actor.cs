using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Stratego.Core
{
    public sealed class Actor
    {
        private ulong actorId;
        private Dictionary<ulong, ActorComponent> actorComponents = new Dictionary<ulong, ActorComponent>();

        public ulong ActorId {
            get {
                return actorId;
            }
        }

        public Actor(ulong actorId)
        {
            this.actorId = actorId;
        }

        public bool Init(XElement node)
        {
            return false;
        }

        public void PostInit()
        {

        }

        internal void AddComponent(ActorComponent component)
        {
            actorComponents.Add(component.ComponentId, component);
        }

        public void Update(int deltaMs)
        {
            // function is called every time the game updates
            foreach (var component in actorComponents)
            {
                component.Value.Update(deltaMs);
            }
        }

        public ComponentType GetComponent<ComponentType>(ulong id) where ComponentType : class
        {
            if (actorComponents.TryGetValue(id, out ActorComponent value))
            {
                return value as ComponentType;
            }

            return null;
        }
    }
}
