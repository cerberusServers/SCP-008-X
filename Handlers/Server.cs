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
            if (plugin.Config.CassieAnnounce && plugin.Config.Announcement != null)
            {
                if (plugin.Config.ZombiesInfect || plugin.Config.PeanutInfects || plugin.Config.DogInfects)
                    Cassie.DelayedMessage(plugin.Config.Announcement, 5f, false, true);
            }
        }
    }
}
