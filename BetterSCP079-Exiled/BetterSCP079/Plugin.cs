using Exiled.API.Features;
using MEC;
using System;
using Player = Exiled.Events.Handlers.Player;

namespace BetterSCP079
{
    public class Plugin : Plugin<Config>
    {
        public static Plugin Instance;
        public override string Name => "Better079";
        public override string Prefix => "better079";
        public override string Author => "MrAfitol";
        public override Version Version => new Version(1, 2, 0);

        public EventHandlers handlers;

        public override void OnEnabled()
        {
            Instance = this;
            handlers = new EventHandlers();
            Player.Spawning += handlers.PlayerSpawn;
        }

        public override void OnDisabled()
        {

            try
            {
                Timing.KillCoroutines("nukeoff");
                Timing.KillCoroutines("light");
            }
            catch { }

            Player.Spawning -= handlers.PlayerSpawn;
            handlers = null;
            Instance = null;
        }
    }
}
