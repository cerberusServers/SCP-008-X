using System;
using Exiled.API.Features;
using Exiled.API.Enums;
using Exiled.Events.Handlers;
using Player = Exiled.Events.Handlers.Player;
using Server = Exiled.Events.Handlers.Server;

namespace SCP008X
{
    public class Plugin : Plugin<Config>
    {
        private static readonly Lazy<Plugin> LInstance = new Lazy<Plugin>(() => new Plugin());
        public static Plugin Instance => LInstance.Value;
        private Plugin()
        {
        }

        public override PluginPriority Priority { get; } = PluginPriority.Medium;

        public override string Author { get; } = "DGvagabond";
        public override string Name { get; } = "SCP-008-X";
        public override Version Version { get; } = new Version(1, 1, 0);
        public override Version RequiredExiledVersion { get; } = new Version(2, 0, 10);

        private Handlers.Player PlayerEvents;
        private Handlers.Server ServerEvents;
        public static Plugin Singleton;

        public override void OnEnabled()
        {
            try
            {
                RegisterEvents();
                Log.Info($"v{Version}, made by {Author}, successfully loaded.");
            }

            catch (Exception e)
            {
                Log.Error($"There was an error loading the plugin: {e}");
            }
        }

        public override void OnDisabled()
        {
            UnregisterEvents();
        }

        public void RegisterEvents()
        {
            Singleton = this;
            PlayerEvents = new Handlers.Player(this);
            ServerEvents = new Handlers.Server(this);

            Player.Hurting += PlayerEvents.OnPlayerHurt;
            Player.Dying += PlayerEvents.OnPlayerDying;
            Player.ChangingRole += PlayerEvents.OnRoleChange;
            Player.MedicalItemUsed += PlayerEvents.OnHealing;
            Scp049.StartingRecall += PlayerEvents.OnRecall;
            Server.RoundStarted += ServerEvents.OnRoundStart;
        }
        public void UnregisterEvents()
        {
            Player.Hurting -= PlayerEvents.OnPlayerHurt;
            Player.Dying -= PlayerEvents.OnPlayerDying;
            Player.ChangingRole -= PlayerEvents.OnRoleChange;
            Player.MedicalItemUsed -= PlayerEvents.OnHealing;
            Scp049.StartingRecall -= PlayerEvents.OnRecall;
            Server.RoundStarted -= ServerEvents.OnRoundStart;

            PlayerEvents = null;
            ServerEvents = null;
        }
    }
}