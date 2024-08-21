using System.Linq;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Map;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.EventArgs.Server;
using MEC;

namespace Blackout
{
    public class EventHandlers
    {
        private readonly Plugin plugin;
        private Config config = Plugin.Instance.Config;
        private string cassieMessage = "<size=0> PITCH_.2 .G4 .G4 PITCH_.9 ATTENTION ALL PITCH_.6 PERSONNEL .G2 PITCH_.8 JAM_027_4 . PITCH_.15 .G4 .G4 PITCH_9999</size><color=#d64542>Attention, <color=#f5e042>all personnel...<split><size=0> PITCH_.9 GENERATORS PITCH_.7 IN THE PITCH_.85 FACILITY HAVE BEEN PITCH_.8 DAMAGED PITCH_.2 .G4 .G4 PITCH_9999</size><color=#d67d42>Generators in <color=#f5e042>the facility <color=#d67d42>have been <color=#d64542>damaged.<split><size=0> PITCH_.8 THE FACILITY PITCH_.9 IS GOING THROUGH PITCH_.85 A BLACK OUT PITCH_.15 .G4 .G4 PITCH_9999</size><color=#d64542><color=#f5e042>The facility <color=#d67d42>is going through a <color=#000000>blackout.";
        public EventHandlers(Plugin plugin) => this.plugin = plugin;
        
        internal void OnRoundStart()
        {
            if (!plugin.ForceNextRound && SeriouslyRandom.Next(0, config.Rarity) != 0)
                return;
            
            plugin.IsOccuring = true;
            plugin.ForceNextRound = false;
            Timing.CallDelayed(.5f, () => plugin.Methods.Give());
            
            Map.TurnOffAllLights(float.MaxValue);
            Cassie.Message(cassieMessage, false, false, true);
        }

        internal void OnChangingRole(ChangingRoleEventArgs ev)
        {
            if (!plugin.IsOccuring)
                return;
            
            Timing.CallDelayed(1.0f, () => ev.Player.AddItem(ItemType.Flashlight));
        }

        internal void OnRoundEnd(RoundEndedEventArgs ev)
        {
            if (!plugin.IsOccuring)
                return;

            plugin.IsOccuring = false;
        }
        
        internal void OnTriggeringTesla(TriggeringTeslaEventArgs ev)
        {
            if (!plugin.IsOccuring)
                return;

            ev.IsAllowed = false;
        }

        internal void OnGeneratorActivating(GeneratorActivatingEventArgs ev)
        {
            if (!plugin.IsOccuring)
                return;
            
            if (Generator.Get(GeneratorState.Engaged).Count() == 2)
            {
                plugin.IsOccuring = false;
                Map.TurnOffAllLights(float.MinValue);
            }
        }
    }
}