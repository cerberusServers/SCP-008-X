using System;
using System.Linq;
using System.Collections.Generic;
using Exiled.API.Extensions;
using Exiled.API.Features;
using Exiled.Events.EventArgs;
using Exiled.Permissions.Extensions;
using Exiled.Events.Handlers;
using MEC;
using Respawning;
using UnityEngine;
using System.Security.Cryptography;

namespace Infection
{
    public class EventHandlers
    {
        public System.Random Gen = new System.Random();
        public Plugin plugin;
        public EventHandlers(Plugin plugin) => this.plugin = plugin;

        public void OnRoundStart()
        {
            if (plugin.Config.CassieAnnounce)
            {
                if (plugin.Config.ZombiesInfect || plugin.Config.PeanutInfects || plugin.Config.DogInfects)
                    Cassie.DelayedMessage("Danger . Critical containment failure of N E nato_a 0 0 8 detected . allremaining", 5f, false, true);
            }
        }

        public void OnPlayerHurt(HurtingEventArgs ev)
        {
            if (plugin.Config.DogDamage >= 0 && ev.Attacker.Role.Is939())
                ev.Amount = plugin.Config.DogDamage;
            if (plugin.Config.ZombieDamage >= 0 && ev.Attacker.Role == RoleType.Scp0492)
                ev.Amount = plugin.Config.ZombieDamage;
        }

        public void OnPlayerDying(DyingEventArgs ev)
        {
            if (!plugin.Config.ZombieSuicides)
            {
                if (ev.Target.Role == RoleType.Scp0492 && ev.Target == ev.Killer)
                {
                    if (DamageTypes.FromIndex(ev.HitInformation.Tool).name == "FALLDOWN")
                    {
                        Exiled.API.Features.Player zombie = Exiled.API.Features.Player.List.FirstOrDefault(x => x.Role == RoleType.Scp0492 && x.UserId != string.Empty && x != ev.Target);
                        if (zombie != null) ev.Target.Position = zombie.Position;
                        else ev.IsAllowed = true;
                    }
                    ev.Target.ClearBroadcasts();
                    ev.Target.Broadcast(10, plugin.Config.SuicideBroadcast);
                }
                if (ev.Killer.Role == RoleType.Scp0492 && plugin.Config.ZombiesInfect || ev.Killer.Role == RoleType.Scp173 && plugin.Config.PeanutInfects || ev.Killer.Role.Is939() && plugin.Config.DogInfects)
                {
                    int chance = (int)Gen.Next(1, 100);
                    if (chance <= plugin.Config.InfectionChance)
                    {
                        ev.IsAllowed = false;
                        ev.Target.SetRole(ev.Killer.Role, true);
                        if (ev.Target.Role == RoleType.Scp0492)
                            ev.Target.Health = plugin.Config.ZombieHealth;
                        else
                            ev.Target.Health = plugin.Config.InfectedHealth;
                    }
                }
            }
        }
        public void OnRoleChange(ChangingRoleEventArgs ev)
        {
            if(ev.NewRole == RoleType.Scp0492)
            {
                if (!plugin.Config.ZombieSuicides)
                {
                    ev.Player.ClearBroadcasts();
                    ev.Player.Broadcast(10, plugin.Config.SuicideBroadcast);
                }
            }
        }
    }
}