using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Montana
{
    public interface IActorFactory
    {
        Actor CreateActor(String actorResource);
    }

    public class ActorFactory : IActorFactory
    {
        private ulong actorId;

        protected Dictionary<string, Func<ActorComponent>> actorComponentCreatorMap = new Dictionary<string, Func<ActorComponent>>();

        public ActorFactory()
        {
            
        }

        public virtual Actor CreateActor(String actorResource)
        {
            XDocument doc = XDocument.Parse(actorResource);

            return CreateActor(doc.Root);
        }

        protected Actor CreateActor(XElement node)
        {
            Actor actor = new Actor(GetNextActorId());

            // any base-level initialization
            actor.Init(node);

            foreach (var kind in node.Elements())
            {
                var component = CreateComponent(kind);
                actor.AddComponent(component);
                component.Owner = actor;
            }

            // initialization that needs to occur after the actor and all
            // components have been fully created.
            actor.PostInit();

            return actor;
        }

        protected virtual ActorComponent CreateComponent(XElement node)
        {
            string name = node.Value;
            ActorComponent component = null;

            if (actorComponentCreatorMap.TryGetValue(name, out Func<ActorComponent> creator))
            {
                component = creator();
            }

            component.Init(node);
            return component;
        }

        private ulong GetNextActorId()
        {
            return ++actorId;
        }
    }
}
