using CommandSystem;
using RemoteAdmin;
using Exiled.Permissions.Extensions;
using Targets = Exiled.API.Features.Player;
using CustomPlayerEffects;
using System;

namespace SCP008X.Commands.Infect
{
    class All : ICommand
    {
        public string Command { get; } = "all";

        public string[] Aliases { get; } = { "*" };

        public string Description { get; } = "Infect all players with SCP-008";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!(sender as PlayerCommandSender).CheckPermission("scp008.infect"))
            {
                response = "Missing permission: \"scp008.infect\"";
                return false;
            }

            if (arguments.Count != 2)
            {
                response = "Usage: \"infect all\" or \"infect *\"";
                return false;
            }

            foreach (Targets player in Targets.List)
            {
                if (player.Role.IsSCP(false))
                    continue;

                player.ReferenceHub.playerEffectsController.EnableEffect<Poisoned>();
            }

            response = "All human-class players have been infected.";
            return true;
        }
    }
}
