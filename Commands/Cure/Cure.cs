using System;
using Exiled.Permissions.Extensions;
using CommandSystem;

namespace SCP008X.Commands.Cure
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class Cure : ParentCommand
    {
        public Cure() => LoadGeneratedCommands();
        public override string Command { get; } = "cure";

        public override string[] Aliases { get; } = null;

        public override string Description { get; } = "Cure the targeted player(s)";

        public override void LoadGeneratedCommands()
        {
            RegisterCommand(new All());
            RegisterCommand(new Person());
        }

        protected override bool ExecuteParent(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!(sender as CommandSender).CheckPermission("scp008.cure"))
            {
                response = "Missing permission: \"scp008.cure\"";
                return false;
            }

            response = "Missing subcommand! Available: all, to";
            return false;
        }
    }
}
