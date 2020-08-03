using System.Linq;
using CustomPlayerEffects;
using Exiled.Events.EventArgs;
using UnityEngine;

namespace Infection
{
    public class Player
    {
        public System.Random Gen = new System.Random();
        public Plugin plugin;
        public Player(Plugin plugin) => this.plugin = plugin;

        public void OnPlayerHurt(HurtingEventArgs ev)
        {
            if (plugin.Config.DogDamage >= 0 && ev.Attacker.Role.Is939())
                ev.Amount = plugin.Config.DogDamage;
            if (plugin.Config.ZombieDamage >= 0 && ev.Attacker.Role == RoleType.Scp0492)
                ev.Amount = plugin.Config.ZombieDamage;
            if(plugin.Config.ZombiesInfect && ev.Attacker.Role == RoleType.Scp0492)
            {
                int chance = (int)Gen.Next(1, 100);
                if(chance <= plugin.Config.InfectionChance)
                {
                    ev.Target.ReferenceHub.playerEffectsController.EnableEffect<Poisoned>();
                    ev.Target.ClearBroadcasts();
                    ev.Target.Broadcast(10, "You've been infected! Use a medkit to have a chance to cure yourself, or use SCP 500 to be fully cured!");
                }
            }
        }

        public void OnHealing(UsedMedicalItemEventArgs ev)
        {
            int cure = (int)Gen.Next(1, 100);
            if (ev.Item == ItemType.SCP500)
                ev.Player.ReferenceHub.playerEffectsController.DisableEffect<Poisoned>(); // Guaranteed cure, regardless of config settings
            if(ev.Item == ItemType.Medkit && cure <= plugin.Config.CureChance)
                ev.Player.ReferenceHub.playerEffectsController.DisableEffect<Poisoned>(); // Percentage cure based on config settings
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
                    ev.IsAllowed = false;
                }

                if (ev.Killer.Role == RoleType.Scp0492 && plugin.Config.ZombiesInfect || 
                    ev.Killer.Role == RoleType.Scp173 && plugin.Config.PeanutInfects || 
                    ev.Killer.Role.Is939() && plugin.Config.DogInfects)
                {
                    int chance = (int)Gen.Next(1, 100);
                    if(chance <= plugin.Config.InfectionChance)
                        ev.Target.SetRole(ev.Killer.Role, true);
                        if (ev.Target.Role == RoleType.Scp0492)
                            ev.Target.Health = plugin.Config.ZombieHealth;
                        else
                            ev.Target.Health = plugin.Config.InfectedHealth;
                }
                if (DamageTypes.FromIndex(ev.HitInformation.Tool).name == "POISONED")
                {
                    ev.Target.SetRole(RoleType.Scp0492, true);
                    ev.Target.Health = plugin.Config.ZombieHealth;
                }
            }
        }
        public void OnRecall(StartingRecallEventArgs ev)
        {
            if (plugin.Config.BuffDoctor)
            {
                ev.Target.SetRole(RoleType.Scp0492, false, false);
                ev.IsAllowed = false;
            }
        }
        public void OnRoleChange(ChangingRoleEventArgs ev)
        {
            if(ev.NewRole == RoleType.Scp0492)
            {
                if (plugin.Config.SuicideBroadcast != null)
                {
                    ev.Player.ClearBroadcasts();
                    ev.Player.Broadcast(10, plugin.Config.SuicideBroadcast);
                }
            }
        }
    }
}
