﻿using System.ComponentModel;
using Exiled.API.Interfaces;

namespace SCP008X
{
    public sealed class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public int InfectionChance { get; set; } = 100;
        public int CureChance { get; set; } = 50;
        [Description("Allow SCP-049 to instantly revive targets?")]
        public bool BuffDoctor { get; set; } = false;
        public int ZombieHealth { get; set; } = 300;
        [Description("How much AHP should be given to Zombies?")]
        public int Scp008Buff { get; set; } = 10;
        public int InfectedHealth { get; set; } = 1500;
        public bool CassieAnnounce { get; set; } = true;
        public string Announcement { get; set; } = "SCP 0 0 8 containment breach detected . Allremaining";
        public int ZombieDamage { get; set; } = 24;
        [Description("This is the text that will be displayed to SCP-049-2 players on revive and infection!")]
        public string SuicideBroadcast { get; set; } = "";
    }
}