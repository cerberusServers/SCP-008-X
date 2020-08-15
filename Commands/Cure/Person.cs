using CommandSystem;
using RemoteAdmin;
using Exiled.Permissions.Extensions;
using Target = Exiled.API.Features.Player;
using CustomPlayerEffects;
using System;

namespace SCP008X.Commands.Cure
{
    class Person : ICommand
    {
        public string Command { get; } = "person";

        public string[] Aliases { get; } = { "player", "user" };

        public string Description { get; } = "Cure a player with SCP-008";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!(sender as PlayerCommandSender).CheckPermission("scp008.cure"))
            {
                response = "Missing permission: \"scp008.cure\"";
                return false;
            }

            if (arguments.Count != 3)
            {
                response = "Usage: \"cure player (player id / name)\"";
                return false;
            }

            Target player = Target.Get(arguments.At(0));
            if (player == null)
            {
                response = $"Player \"{arguments.At(0)}\" not found";
                return false;
            }
            else if (player.Role.IsSCP(false))
            {
                response = $"Player \"{arguments.At(0)}\" is not a valid class to infect";
                return false;
            }

            player.ReferenceHub.playerEffectsController.DisableEffect<Poisoned>();
            response = $"{player.Nickname} has been cured";
            return true;
        }
    }
}
