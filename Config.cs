using System.ComponentModel;
using Exiled.API.Interfaces;
using Exiled.Loader;

namespace Infection
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public int InfectionChance { get; set; } = 25;
        public int InfectedHealth { get; set; } = 1500;
        public bool CassieAnnounce { get; set; } = true;
        public int ZombieDamage { get; set; } = 65;
        public bool ZombiesInfect { get; set; } = true;
        public bool PeanutInfects { get; set; } = false;
        public bool DogInfects { get; set; } = false;
        public int DogDamage { get; set; } = 65;
    }
}
