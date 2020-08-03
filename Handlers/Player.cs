using System.Linq;
using Exiled.Events.EventArgs;

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
                if (ev.Killer.Role == RoleType.Scp0492 && plugin.Config.ZombiesInfect || ev.Killer.Role == RoleType.Scp173 && plugin.Config.PeanutInfects || ev.Killer.Role.Is939() && plugin.Config.DogInfects)
                {
                    int chance = (int)Gen.Next(1, 100);
                    if (chance <= plugin.Config.InfectionChance)
                    {
                        ev.Target.SetRole(ev.Killer.Role, true);
                        if (ev.Target.Role == RoleType.Scp0492)
                            ev.Target.Health = plugin.Config.ZombieHealth;
                        else
                            ev.Target.Health = plugin.Config.InfectedHealth;
                    }
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
