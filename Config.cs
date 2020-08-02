using System.ComponentModel;
using System.Diagnostics.Tracing;
using Exiled.API.Interfaces;
using Exiled.Loader;

namespace Infection
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public int InfectionChance { get; set; } = 25;
        public int ZombieHealth { get; set; } = 225;
        public int InfectedHealth { get; set; } = 1500;
        public bool CassieAnnounce { get; set; } = true;
        public int ZombieDamage { get; set; } = 65;
        public bool ZombiesInfect { get; set; } = true;
        [Description("Should SCP-049-2 be allowed to commit suicide?")]
        public bool ZombieSuicides { get; set; } = false;
        [Description("This is the text that will be displayed to SCP-049-2 players on revive and infection!")]
        public string SuicideBroadcast { get; set; } = "SCP-049-2 is not allowed to suicide on this server!";
        public bool PeanutInfects { get; set; } = false;
        public bool DogInfects { get; set; } = false;
        public int DogDamage { get; set; } = 65;
    }
}
