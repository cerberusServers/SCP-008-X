using System;
using System.Collections.Generic;
using System.IO;
using Exiled.API.Extensions;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Interfaces;
using Exiled.Events;
using Handlers = Exiled.Events.Handlers;

namespace Infection
{
    public class Plugin : Exiled.API.Features.Plugin<Config>
    {
        public override string Author { get; } = "DGvagabond";
        public override string Name { get; } = "Infection";
        public override Version Version { get; } = new Version(1, 0, 2);
        public override Version RequiredExiledVersion { get; } = new Version(2, 0, 6);

        public Infecting PluginEvents;
        public static Plugin Singleton;
        public override void OnEnabled()
        {
            try
            {
                Singleton = this;
                PluginEvents = new Infecting(this);

                Handlers.Player.Dying += PluginEvents.OnPlayerDying;
                Handlers.Player.Hurting += PluginEvents.OnPlayerHurt;
                Handlers.Server.RoundStarted += PluginEvents.OnRoundStart;

                Log.Info($"v{Version}, made by {Author}, successfully loaded.");
            }

            catch (Exception e)
            {
                Log.Error($"There was an error loading the plugin: {e}");
            }
        }

        public override void OnDisabled()
        {
            Handlers.Player.Dying -= PluginEvents.OnPlayerDying;
            Handlers.Player.Hurting -= PluginEvents.OnPlayerHurt;
            Handlers.Server.RoundStarted -= PluginEvents.OnRoundStart;

            PluginEvents = null;
        }
    }
}
