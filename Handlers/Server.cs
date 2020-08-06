using Exiled.API.Features;

namespace SCP008X.Handlers
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
                Cassie.DelayedMessage(plugin.Config.Announcement, 5f, false, true);
            }
        }
    }
}