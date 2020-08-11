using CustomPlayerEffects;
using Exiled.Events.EventArgs;

namespace SCP008X.Handlers
{
    public class Player
    {
        public System.Random Gen = new System.Random();
        public Plugin plugin;
        public Player(Plugin plugin) => this.plugin = plugin;

public void OnPlayerHurt(HurtingEventArgs ev)
        {
            if(ev.Target.Team != Team.SCP && ev.Target.Team != Team.RIP && ev.Target.Team != Team.TUT && ev.Target != ev.Attacker)
            {
                if (ev.Attacker.Role == RoleType.Scp0492)
                {
                    if (Plugin.Instance.Config.ZombieDamage >= 0)
                        ev.Amount = Plugin.Instance.Config.ZombieDamage;
                    if(Plugin.Instance.Config.Scp008Buff >= 0)
                        ev.Attacker.AdrenalineHealth += Plugin.Instance.Config.Scp008Buff;
                    int chance = (int)Gen.Next(1, 100);
                    if (chance <= Plugin.Instance.Config.InfectionChance)
                    {
                        ev.Target.ReferenceHub.playerEffectsController.EnableEffect<Poisoned>();
                        ev.Target.ClearBroadcasts();
                        ev.Target.Broadcast(10, "You've been <color=red>infected</color>! Use a medkit to have a chance to cure yourself, or use SCP-500 to be fully cured!");
                    }
                }
            }
        }
        public void OnHealing(UsedMedicalItemEventArgs ev)
        {
            int cure = (int)Gen.Next(1, 100);
            if (ev.Item == ItemType.SCP500)
                ev.Player.ReferenceHub.playerEffectsController.DisableEffect<Poisoned>();
            if (ev.Item == ItemType.Medkit && cure <= Plugin.Instance.Config.CureChance)
                ev.Player.ReferenceHub.playerEffectsController.DisableEffect<Poisoned>();
        }
        public void OnPlayerDying(DyingEventArgs ev)
        {
            if (ev.Target.ReferenceHub.playerEffectsController.GetEffect<Poisoned>().Enabled)
            {
                ev.Target.SetRole(RoleType.Scp0492, true, false);
                ev.Target.Health = Plugin.Instance.Config.ZombieHealth;
            }
        }
        public void OnRoleChange(ChangingRoleEventArgs ev)
        {
            if (ev.NewRole == RoleType.Scp0492 && Plugin.Instance.Config.SuicideBroadcast != null)
            {
                ev.Player.ClearBroadcasts();
                ev.Player.Broadcast(10, Plugin.Instance.Config.SuicideBroadcast);
                if(Plugin.Instance.Config.Scp008Buff >= 0)
                    ev.Player.AdrenalineHealth += Plugin.Instance.Config.Scp008Buff;
            }
        }
    }
}
