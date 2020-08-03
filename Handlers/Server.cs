using System.Linq;
using Exiled.API.Features;
using Exiled.Events.EventArgs;

namespace Infection
{
    public class Server
    {
        public System.Random Gen = new System.Random();
        public Plugin plugin;
        public Server(Plugin plugin) => this.plugin = plugin;

        public void OnRoundStart()
        {
            if (plugin.Config.CassieAnnounce)
            {
                if (plugin.Config.ZombiesInfect || plugin.Config.PeanutInfects || plugin.Config.DogInfects)
                    Cassie.DelayedMessage("Danger . Critical containment failure of N E nato_a 0 0 8 detected . allremaining", 5f, false, true);
            }
        }
    }
}