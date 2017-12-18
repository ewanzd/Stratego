using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Stratego.Core
{
    public class ActorFactory
    {
        private ulong actorId;

        protected Dictionary<string, Func<ActorComponent>> actorComponentCreatorMap = new Dictionary<string, Func<ActorComponent>>();

        public ActorFactory()
        {
            //actorComponentCreatorMap.Add("AmmoPickup", () => new AmmoPickup());
            //actorComponentCreatorMap.Add("HealthPickup", () => new HealthPickup());
        }

        public Actor CreateActor(String actorResource)
        {
            XDocument doc = XDocument.Parse(actorResource);

            Actor actor = new Actor(GetNextActorId());

            // any base-level initialization
            actor.Init(doc.Root);

            foreach (var node in doc.Root.Elements())
            {
                var component = CreateComponent(node);
                actor.AddComponent(component);
                component.SetOwner(actor);
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
