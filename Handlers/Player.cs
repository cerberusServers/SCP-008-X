using CustomPlayerEffects;
using Targets = Exiled.API.Features.Player;
using Exiled.Events.EventArgs;
using System.Collections.Generic;
using System.Linq;
using Exiled.API.Features;

namespace SCP008X.Handlers
{
    public class Player
    {
        public System.Random Gen = new System.Random();
        private bool contained008 = false;
        public Plugin plugin;
        public Player(Plugin plugin) => this.plugin = plugin;

        public void OnPlayerJoin(JoinedEventArgs ev)
        {

        }
        public void OnPlayerLeave(LeftEventArgs ev)
        {
            SCP008Check();
        }
        public void OnPlayerHurt(HurtingEventArgs ev)
        {
            if (ev.Target != ev.Attacker && ev.Attacker.Role == RoleType.Scp0492)
            {
                if (Plugin.Instance.Config.ZombieDamage >= 0)
                    ev.Amount = Plugin.Instance.Config.ZombieDamage;
                if (Plugin.Instance.Config.Scp008Buff >= 0)
                    ev.Attacker.AdrenalineHealth += Plugin.Instance.Config.Scp008Buff;
                int chance = (int)Gen.Next(1, 100);
                if (chance <= Plugin.Instance.Config.InfectionChance && ev.Target.Team != Team.SCP)
                {
                    ev.Target.ReferenceHub.playerEffectsController.EnableEffect<Poisoned>();
                    ev.Target.ClearBroadcasts();
                    ev.Target.Broadcast(10, "<color=yellow>You've been <color=red>infected</color>!</color>\n<i>Use a medkit or SCP-500!</i>");
                }
            }
        }
        public void OnHealing(UsedMedicalItemEventArgs ev)
        {
            if(ev.Player.ReferenceHub.playerEffectsController.GetEffect<Poisoned>().Enabled)
            {
                int cure = Gen.Next(1, 100);
                if (ev.Item == ItemType.SCP500)
                    ev.Player.ReferenceHub.playerEffectsController.DisableEffect<Poisoned>();
                if (ev.Item == ItemType.Medkit && cure <= Plugin.Instance.Config.CureChance)
                    ev.Player.ReferenceHub.playerEffectsController.DisableEffect<Poisoned>();
                if (ev.Item == ItemType.Medkit && cure >= Plugin.Instance.Config.CureChance)
                {
                    ev.Player.ReferenceHub.playerEffectsController.DisableEffect<Poisoned>();
                    ev.Player.ReferenceHub.playerEffectsController.EnableEffect<Poisoned>();
                } // Reset the poison effect to at least restart the HP drain rate
            }
        }
        public void OnPlayerDying(DyingEventArgs ev)
        {
            if (ev.Target.ReferenceHub.playerEffectsController.GetEffect<Poisoned>().Enabled || ev.Killer.Role == RoleType.Scp0492)
            {
                ev.Target.SetRole(RoleType.Scp0492, true, false);
            }
            SCP008Check();
        }
        public void OnRoleChange(ChangingRoleEventArgs ev)
        {
            if (ev.NewRole == RoleType.Scp0492)
            {
                if(Plugin.Instance.Config.SuicideBroadcast != null)
                    ev.Player.ClearBroadcasts();
                    ev.Player.Broadcast(10, Plugin.Instance.Config.SuicideBroadcast);
                if (!Plugin.Instance.Config.RetainInventory)
                    ev.Player.ClearInventory();
                if(Plugin.Instance.Config.Scp008Buff >= 0)
                    ev.Player.AdrenalineHealth += Plugin.Instance.Config.Scp008Buff;
                ev.Player.Health = Plugin.Instance.Config.ZombieHealth;
            }
            SCP008Check();
        }
        public void OnReviving(StartingRecallEventArgs ev)
        {
            if(Plugin.Instance.Config.BuffDoctor)
            {
                ev.IsAllowed = false;
                ev.Target.SetRole(RoleType.Scp0492, true, false);
            }
        }
        private void SCP008Check()
        {
            if (contained008) return;
            List<Targets> infecteds = Targets.List.Where(player => player.Role == RoleType.Scp049 || player.Role == RoleType.Scp0492).ToList();
            if (infecteds == null)
            {
                Cassie.Message("SCP 0 0 8 has been secured . NoSCPsLeft");
                contained008 = true;
            }
        }
    }
}