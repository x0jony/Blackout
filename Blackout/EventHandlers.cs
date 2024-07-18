using System;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.EventArgs.Server;
using MEC;

namespace Blackout
{
    public class EventHandlers
    {
        private readonly Plugin plugin;
        private Random RNG = new Random();
        private Config config = Plugin.Singleton.Config;
        public EventHandlers(Plugin plugin) => this.plugin = plugin;

        public void OnRoundStart()
        {
            if (!plugin.IsEnabled || !plugin.ForceNextRound && RNG.Next(1, config.Rarity) != 1)
                return;
            
            plugin.IsOccuring = true;
            plugin.ForceNextRound = false;
            Timing.CallDelayed(.5f, () => plugin.Methods.Give());
            
            Map.TurnOffAllLights(float.MaxValue);
            Map.Broadcast(10, "<color=red>The facility is experiencing a blackout, all lights are off.</color>");
        }

        public void OnChangingRole(ChangingRoleEventArgs ev)
        {
            if (!plugin.IsOccuring)
                return;
            
            Timing.CallDelayed(1.0f, () => ev.Player.AddItem(ItemType.Flashlight));
        }

        public void OnRoundEnd(RoundEndedEventArgs ev)
        {
            if (!plugin.IsOccuring)
                return;

            plugin.IsOccuring = false;
        }
    }
}