using System.ComponentModel;
using Exiled.API.Interfaces;

namespace Blackout
{
    public class Config : IConfig
    {
        [Description("Whether or not this plugin is enabled on the server.")]
        public bool IsEnabled { get; set; } = true;
        
        [Description("Whether or not to show logs used for debugging.")]
        public bool Debug { get; set; } = false;

        [Description("Probability of the blackout occuring. (1 out of X)")]
        public int Rarity { get; set; } = 3;

        [Description("Which item to give to all players during the blackout. (flashlight, lantern, both)")]
        public string Item { get; set; } = "both";
    }
}