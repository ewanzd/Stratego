using System;
using System.Collections.Generic;
using System.Text;

namespace Stratego.Core.Component
{
    class AnimationComponent : ActorComponent
    {
        private static ulong _componentId;
        public override ulong ComponentId => _componentId;

        private IDictionary<String, AnimationState> _states = new Dictionary<String, AnimationState>();
        private AnimationState _defaultState;
        private AnimationState _state;
        public AnimationState State => _state;

        public override void Update(int deltaMs)
        {
            
        }
    }

    public class AnimationState
    {
        private bool _isLoop;
        private String _name;
    }
}
