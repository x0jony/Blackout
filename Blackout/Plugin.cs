using System;
using Exiled.API.Features;

namespace Blackout
{
    public class Plugin : Plugin<Config>
    {
        public override string Author { get; } = "x0jony";
        public override string Name { get; } = "Blackout";
        public override Version Version { get; } = new Version(1, 0, 7);
        public override Version RequiredExiledVersion { get; } = new Version(8, 0, 0);
        
        
        public static Plugin Instance;
        public Methods Methods;
        public EventHandlers EventHandlers;
        public bool IsOccuring = false;
        public bool ForceNextRound = false;

        public override void OnEnabled()
        {
            Instance = this;
            Methods = new Methods(this);
            EventHandlers = new EventHandlers(this);
            
            Methods.EventRegistration();
            
            base.OnEnabled();
        }
        
        public override void OnDisabled()
        {
            Methods.EventRegistration(false);
            
            Methods = null;
            EventHandlers = null;

            base.OnDisabled();
        }
    }
}