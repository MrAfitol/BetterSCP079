using Exiled.API.Features;
using MEC;
using System;
using Player = Exiled.Events.Handlers.Player;

namespace BetterSCP079
{
    public class Plugin : Plugin<Config>
    {
        public static Plugin Instance;
        public override string Name => "Better079PublicBeta";
        public override string Prefix => "better079_publicbeta";
        public override string Author => "MrAfitol";
        public override Version Version => new Version(2, 0, 0);
        public override Version RequiredExiledVersion => new Version(3, 0, 0);

        public EventHandlers handlers;

        public override void OnEnabled()
        {
            Instance = this;
            handlers = new EventHandlers();
            Player.ChangingRole += handlers.PlayerSpawn;
        }

        public override void OnDisabled()
        {

            try
            {
                Timing.KillCoroutines("nukeoff");
                Timing.KillCoroutines("nukeon");
                Timing.KillCoroutines("light");
                Timing.KillCoroutines("flash");
            }
            catch { }

            Player.ChangingRole -= handlers.PlayerSpawn;
            handlers = null;
            Instance = null;
        }
    }
}
