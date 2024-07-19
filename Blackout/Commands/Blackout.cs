using System;
using CommandSystem;

namespace Blackout.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public sealed class Blackout : ParentCommand
    {
        public Blackout() => LoadGeneratedCommands();
        
        public override void LoadGeneratedCommands()
        {
            RegisterCommand(new Force());
        }
        
        protected override bool ExecuteParent(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            response = "Invalid subcommand.\nForce - forces the blackout to occur next round. (.blackout/.bl force/f)";
            return false;
        }

        public override string Command { get; } = ".blackout";
        public override string[] Aliases { get; } = { ".bl" };
        public override string Description { get; } = "Main command for the Blackout plugin.";
    }
}