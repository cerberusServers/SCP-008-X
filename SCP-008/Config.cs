using System.ComponentModel;
using Exiled.API.Interfaces;

namespace SCP008X
{
    public sealed class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        [Description("Only enable this if you're looking for bug sources!")]
        public bool DebugMode { get; set; }
        [Description("Display plugins stats at the end of the round?")]
        public bool SummaryStats { get; set; }
        public int InfectionChance { get; set; } = 40;
        public int CureChance { get; set; } = 60;
        [Description("Toggle players getting infected via area of effect")]
        public bool AoeInfection { get; set; } = false;
        [Description("Set AOE infection to run when infected players turn?")]
        public bool AoeTurned { get; set; } = false;
        [Description("Set the percentage chance players will get infected by area of effect")]
        public int AoeChance { get; set; } = 50;
        [Description("Allow SCP-049 to instantly revive targets?")]
        public bool BuffDoctor { get; set; } = false;
        public int ZombieHealth { get; set; } = 385;
        [Description("How much AHP should be given to Zombies?")]
        public int Scp008Buff { get; set; } = 30;
        public int MaxAhp { get; set; } = 150;
        public bool CassieAnnounce { get; set; } = true;
        public string Announcement { get; set; } = "SCP 0 0 8 containment breach detected . Allremaining";
        public int ZombieDamage { get; set; } = 45;
        [Description("This is the text that will be displayed to SCP-049-2 players on spawn")]
        public string SuicideBroadcast { get; set; } = "<color=red> Fuiste completamente consumido por el SCP-008, ahora cuando ataques a tus enemigos hay una probabilidad de que los infectes</color>";
        [Description("Text displayed to players after they've been infected")]
        public string InfectionAlert { get; set; } = "<color=red>[</color><b><color=green>Plaga Zombie</color></b><color=red>]</color> fuiste infectado por el <color=red>SCP-008</color> curate con un medikit o con un SCP-500 para eliminar la infeccion!!";
        [Description("Text displayed to newly turned SCP-049-2 players")]
        public string SpawnHint { get; set; } = "<color=yellow>Los jugadores que ataques seran infectados con el</color> SCP-008</color><color=yellow>!</colot>";
        [Description("Should players keep their inventory after turning into a zombie? Items cannot be used by them.")]
        public bool RetainInventory { get; set; } = true;
    }
}