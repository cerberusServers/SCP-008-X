using CommandSystem;
using RemoteAdmin;
using Exiled.Permissions.Extensions;
using Targets = Exiled.API.Features.Player;
using CustomPlayerEffects;
using System;

namespace SCP008X.Commands.Cure
{
    class All : ICommand
    {
        public string Command { get; } = "all";

        public string[] Aliases { get; } = { "*" };

        public string Description { get; } = "Cure all players with SCP-008";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!(sender as PlayerCommandSender).CheckPermission("scp008.cure"))
            {
                response = "Missing permission: \"scp008.cure\"";
                return false;
            }

            if (arguments.Count != 2)
            {
                response = "Usage: \"cure all\" or \"cure *\"";
                return false;
            }

            foreach (Targets player in Targets.List)
            {
                if (player.Role.IsSCP(false))
                    continue;

                player.ReferenceHub.playerEffectsController.DisableEffect<Poisoned>();
            }

            response = "All human-class players have been cured.";
            return true;
        }
    }
}
