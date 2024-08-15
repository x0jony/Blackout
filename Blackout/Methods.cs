using Exiled.API.Features;
using Exiled.API.Features.Items;
using MEC;

namespace Blackout
{
    public class Methods
    {
        private readonly Plugin plugin;
        private Config config = Plugin.Instance.Config;
        public Methods(Plugin plugin) => this.plugin = plugin;

        public void Give()
        {
            Timing.CallDelayed(1.5f, () =>
            {
                if (config.Item == "flashlight") { GiveFlashlight(); }
                else if (config.Item == "lantern") { GiveLantern(); }
                else { GiveFlashlight(); GiveLantern(); }
            });
        }
        
        void GiveFlashlight()
        {
            foreach (Player player in Player.List)
            {
                bool hasFlashlight = false;
                foreach (Item item in player.Items)
                {
                    if (item.Type == ItemType.Flashlight)
                    {
                        hasFlashlight = true;
                        break;
                    }
                }
                if (!hasFlashlight)
                    player.AddItem(ItemType.Flashlight);
            }
        }
        
        void GiveLantern()
        {
            foreach (Player player in Player.List)
            {
                bool hasLantern = false;
                foreach (Item item in player.Items)
                {
                    if (item.Type == ItemType.Lantern)
                    {
                        hasLantern = true;
                        break;
                    }
                }
                if (!hasLantern)
                    player.AddItem(ItemType.Lantern);
            }
        }

        internal void EventRegistration(bool enabled = true)
        {
            if (enabled)
            {
                Exiled.Events.Handlers.Server.RoundStarted += plugin.EventHandlers.OnRoundStart;
                Exiled.Events.Handlers.Server.RoundEnded += plugin.EventHandlers.OnRoundEnd;
                
                Exiled.Events.Handlers.Player.ChangingRole += plugin.EventHandlers.OnChangingRole;
                Exiled.Events.Handlers.Player.TriggeringTesla += plugin.EventHandlers.OnTriggeringTesla;
                
                Exiled.Events.Handlers.Map.GeneratorActivating += plugin.EventHandlers.OnGeneratorActivating;
            }
            else
            {
                Exiled.Events.Handlers.Server.RoundStarted -= plugin.EventHandlers.OnRoundStart;
                Exiled.Events.Handlers.Server.RoundEnded -= plugin.EventHandlers.OnRoundEnd;
                
                Exiled.Events.Handlers.Player.ChangingRole -= plugin.EventHandlers.OnChangingRole;
                Exiled.Events.Handlers.Player.TriggeringTesla -= plugin.EventHandlers.OnTriggeringTesla;
                
                Exiled.Events.Handlers.Map.GeneratorActivating -= plugin.EventHandlers.OnGeneratorActivating;
            }
        }
    }
}