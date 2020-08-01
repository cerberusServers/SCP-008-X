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
    public class Infecting
    {
        public System.Random Gen = new System.Random();
        public Plugin plugin;
        public Infecting(Plugin plugin) => this.plugin = plugin;

        public void OnRoundStart()
        {
            if(plugin.Config.CassieAnnounce)
            {
                if (plugin.Config.ZombiesInfect || plugin.Config.PeanutInfects || plugin.Config.DogInfects)
                    RespawnEffectsController.PlayCassieAnnouncement("Danger . Critical containment failure of N E nato_a 0 0 8 detected . allremaining", false, true);
            }
        }

        public void OnPlayerHurt(HurtingEventArgs ev)
        {
            if (plugin.Config.DogDamage >= 0 && ev.Attacker.Role == RoleType.Scp93953 || plugin.Config.DogDamage >= 0 && ev.Attacker.Role == RoleType.Scp93989)
                ev.Amount = plugin.Config.DogDamage;
            if (plugin.Config.ZombieDamage >= 0 && ev.Attacker.Role == RoleType.Scp0492)
                ev.Amount = plugin.Config.ZombieDamage;
        }

        public void OnPlayerDying(DyingEventArgs ev)
        {
            if (ev.Killer.Role == RoleType.Scp0492 && plugin.Config.ZombiesInfect || ev.Killer.Role == RoleType.Scp173 && plugin.Config.PeanutInfects || ev.Killer.Role == RoleType.Scp93953 && plugin.Config.DogInfects || ev.Killer.Role == RoleType.Scp93989 && plugin.Config.DogInfects)
            {
                ev.IsAllowed = false;
                float chance = (float)Gen.Next(1, 100);
                if (chance <= plugin.Config.InfectionChance)
                {
                    ev.Target.SetRole(ev.Killer.Role);
                    Timing.CallDelayed(0.3f, () =>
                        ev.Target.Position = ev.Killer.Position);

                    if(plugin.Config.InfectedHealth >= 0)
                    {
                        if (ev.Target.Role == RoleType.Scp0492)
                            ev.Target.Health = 225;
                        else
                            ev.Target.Health = plugin.Config.InfectedHealth;
                    }

                }
            }
        }
    }
}