using System;
using Exiled.Permissions.Extensions;
using CommandSystem;

namespace SCP008X.Commands.Infect
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class Infect : ParentCommand
    {
        public Infect() => LoadGeneratedCommands();
        public override string Command { get; } = "infect";

        public override string[] Aliases { get; } = null;

        public override string Description { get; } = "Infect the targeted player(s)";

        public override void LoadGeneratedCommands()
        {
            RegisterCommand(new All());
            RegisterCommand(new Person());
        }

        protected override bool ExecuteParent(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!(sender as CommandSender).CheckPermission("scp008.infect"))
            {
                response = "Missing permission: \"scp008.infect\"";
                return false;
            }

            response = "Missing subcommand! Available: all, to";
            return false;
        }
    }
}
