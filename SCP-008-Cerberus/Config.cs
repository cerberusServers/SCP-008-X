using System.ComponentModel;
using Exiled.API.Interfaces;

namespace SCP008X
{
    public sealed class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public int InfectionChance { get; set; } = 75;
        public int CureChance { get; set; } = 65;
        [Description("Allow SCP-049 to instantly revive targets?")]
        public bool BuffDoctor { get; set; } = false;
        public int ZombieHealth { get; set; } = 300;
        [Description("How much AHP should be given to Zombies?")]
        public int Scp008Buff { get; set; } = 10;
        public int MaxAhp { get; set; } = 100;
        public bool CassieAnnounce { get; set; } = false;
        public string Announcement { get; set; } = "SCP 0 0 8 containment breach detected . Allremaining";
        public int ZombieDamage { get; set; } = 30;
        [Description("This is the text that will be displayed to SCP-049-2 players on revive and infection!")]
        public string SuicideBroadcast { get; set; } = "";
        [Description("Text displayed to players after they've been infected")]
        public string InfectionAlert { get; set; } = "<color=red>[</color><b><color=green>Plaga Zombie</color></b><color=red>]</color> fuiste infectado por el <color=red>SCP-008</color> curate de inmediato!";
        [Description("Should players keep their inventory after turning into a zombie? Items cannot be used by them.")]
        public bool RetainInventory { get; set; } = true;
    }
}