using Exiled.API.Features;
using Exiled.API.Features.Items;
using MEC;

namespace Blackout
{
    public class Methods
    {
        private readonly Plugin plugin;
        public Methods(Plugin plugin) => this.plugin = plugin;

        public void Give()
        {
            Timing.CallDelayed(1.5f, () => GiveFlashlight());
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

        internal void EventRegistration(bool enabled = true)
        {
            if (enabled)
            {
                Exiled.Events.Handlers.Server.RoundStarted += plugin.EventHandlers.OnRoundStart;
                Exiled.Events.Handlers.Server.RoundEnded += plugin.EventHandlers.OnRoundEnd;
                Exiled.Events.Handlers.Player.ChangingRole += plugin.EventHandlers.OnChangingRole;
            }
            else
            {
                Exiled.Events.Handlers.Server.RoundStarted -= plugin.EventHandlers.OnRoundStart;
                Exiled.Events.Handlers.Server.RoundEnded -= plugin.EventHandlers.OnRoundEnd;
                Exiled.Events.Handlers.Player.ChangingRole -= plugin.EventHandlers.OnChangingRole;
            }
        }
    }
}