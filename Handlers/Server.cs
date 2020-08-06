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
            if (Plugin.Instance.Config.CassieAnnounce && Plugin.Instance.Config.Announcement != null)
            {
                Cassie.DelayedMessage(Plugin.Instance.Config.Announcement, 5f, false, true);
            }
        }
    }
}
