using System;
using Exiled.API.Features;
using Exiled.API.Enums;
using Exiled.Events.Handlers;
using Handlers = Exiled.Events.Handlers;

namespace Infection
{
    public class Plugin : Plugin<Config>
    {
        private static readonly Lazy<Plugin> Linstance = new Lazy<Plugin>(valueFactory:() => new Plugin());
        public Plugin Instance => Linstance.Value;
        private Plugin()
        {
        }

        public override PluginPriority Priority { get; } = PluginPriority.Medium;

        public override string Author { get; } = "DGvagabond";
        public override string Name { get; } = "Infection";
        public override Version Version { get; } = new Version(1, 0, 6);
        public override Version RequiredExiledVersion { get; } = new Version(2, 0, 10);

        private Player PlayerEvents;
        private Server ServerEvents;
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
            PlayerEvents = new Player(this);
            ServerEvents = new Server(this);

            Handlers.Player.Hurting += PlayerEvents.OnPlayerHurt;
            Handlers.Player.Dying += PlayerEvents.OnPlayerDying;
            Handlers.Player.ChangingRole += PlayerEvents.OnRoleChange;
            Handlers.Player.MedicalItemUsed += PlayerEvents.OnHealing;
            Scp049.StartingRecall += PlayerEvents.OnRecall;
            Handlers.Server.RoundStarted += ServerEvents.OnRoundStart;
        }
        public void UnregisterEvents()
        {
            Handlers.Player.Hurting -= PlayerEvents.OnPlayerHurt;
            Handlers.Player.Dying -= PlayerEvents.OnPlayerDying;
            Handlers.Player.ChangingRole -= PlayerEvents.OnRoleChange;
            Handlers.Player.MedicalItemUsed -= PlayerEvents.OnHealing;
            Scp049.StartingRecall -= PlayerEvents.OnRecall;
            Handlers.Server.RoundStarted -= ServerEvents.OnRoundStart;

            PlayerEvents = null;
            ServerEvents = null;
        }
    }
}