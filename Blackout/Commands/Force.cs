using System;
using CommandSystem;
using Exiled.Permissions.Extensions;

namespace Blackout.Commands
{
    public class Force : ICommand
    {
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (sender.CheckPermission("blackout.force"))
            {
                Plugin.Singleton.ForceNextRound = true;
                response = "Successfully forcing the blackout to occur next round.";
                return true;
            }
            
            response = "You do not have permission to run this command.";
            return false;
        }
        
        public string Command { get; } = "force";
        public string[] Aliases { get; } = { "f" };
        public string Description { get; } = "Forces the blackout to occur next round.";
        public bool SanitizeResponse { get; } = true;
    }
}